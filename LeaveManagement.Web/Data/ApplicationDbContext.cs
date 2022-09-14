// To παρακάτω είναι μια γέφυρα μεταξύ του πως φαίνονται οι πίνακες της Β.Δ και του τι απαιτεί ο κώδικας C# να δει από την Β.Δ

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Data
{   
    // IdentityDbContext σημαίνει ότι θέλουμε να χρησιμοποιήσουμε User-Related Tables και προσθέτωντας το <Employee> κάνω την δουλειά
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Την επόμενη γραμμή την προσθέτω για να ξέρει το πρόγραμμα μου ότι πρέπει να συμπεριλάβει και αυτόν τον πίνακα
        // Συνήθως μετα τον τύπο του πίνακα δίνω σαν όνομα τον πληθυντικό του ονόματος του πίνακα για να είμαι περιγραφικός
        // Δημιούργησε ένα DBSet που είναι ένα Collection Of Objects του τύπου LeaveType το οποίο πλέον θα καλώ με την ονομασία
        // LeaveTypes

        public DbSet<LeaveType> LeaveTypes { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }


    }
}