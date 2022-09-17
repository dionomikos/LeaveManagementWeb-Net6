using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using AutoMapper;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Controllers
{
    // It generates a LeaveTypesController which inherits from Controller class
    public class LeaveTypesController : Controller
    {
        // In the next few lines we have a dependency injection
        // ApplicationDbContext is the bridge to our database (it houses all of our tables)
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        // The following line is a constructor that takes a parameter of the same Data Type and initializes the field
        public LeaveTypesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
              // return _context.LeaveTypes != null ? 
                          // The following line is an action that says: "Go to the DB (_context) and go to the LeaveTypes table
                          // and everything that is in it is converted to a list!
                          // It is equal to SQL line SELECT * FROM LeaveTypes
                          // View(await _context.LeaveTypes.ToListAsync()) :
                          // Problem("Entity set 'ApplicationDbContext.LeaveTypes'  is null.");
            var leaveTypes = mapper.Map<List<LeaveTypeVM>>(await _context.LeaveTypes.ToListAsync());
            return View(leaveTypes);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            // Παρακάτω προσθέτω μια νέα μεταβλητή που προκύπτει από mapping
            var leaveTypeVM = mapper.Map<LeaveTypeVM>(leaveType);
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Into the parenthesis i see all the information i need to create a new form
        // Ότι ειναι μέσα στο Bind λειτουργεί σαν φίλτρο για το τι τελικά θα εμφανιστεί στην οθόνη μας
        // Αν χρησιμοιποιήσω το LeaveTypeVM μπορώ να παραλείψω το bind γιατι το LeaveTypeVM φιλτράρει από μόνο του την φόρμα μας
        // Έχουμε πλέον πολύ πιο καθαρό και ευανάγνωστο κώδικα
        public async Task<IActionResult> Create(LeaveTypeVM leaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                // Αν είναι valid πήγαινε και πρόσθεσε το στην Βάση Δεδομένων
                // To _context είναι reserved για database data types
                // You cannot add LeaveTypeVM to the database cause there is no database with the name LeaveTypeVM
                // So i will need an Auto-Mapper
                // The analogy here is 1-1 LeaveType -> LeaveTypeVM - In the index we had to use a collection MANY-1
                var leaveType = mapper.Map<LeaveType>(leaveTypeVM);
                // Μετά το mapping που έκανα μπορώ πλέον να εκτελέσω ελεύθερα το add μου στην παρακάτω γραμμή
                _context.Add(leaveType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));  // ΅We put nameof to avoid of typing errors that will lead us to bugs
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            // Παρακάτω προσθέτω μια νέα μεταβλητή που προκύπτει από mapping
            var leaveTypeVM = mapper.Map<LeaveTypeVM>(leaveType);
            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeVM leaveTypeVM)
        {
            if (id != leaveTypeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Εδώ πάλι προσθέτω μια καινουργια μεταβλητή που θα κάνει το mapping
                    var leaveType = mapper.Map<LeaveType>(leaveTypeVM);
                    _context.Update(leaveType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeExists(leaveTypeVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LeaveTypes == null)
            {
                return NotFound();
            }

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LeaveTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LeaveTypes'  is null.");
            }
            var leaveType = await _context.LeaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                _context.LeaveTypes.Remove(leaveType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeExists(int id)
        {
          return (_context.LeaveTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
