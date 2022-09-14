using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Data
    // Αυτό το table θα είναι εξαρτημένο από το LeaveType άρα χρειάζομαι ένα foreign key
    // To foreign key είναι μια αναφορά στο primary key και συνδέει του 2 πίνακες
{
    public class LeaveAllocation : BaseEntity
    {

        public int NumberOfDays { get; set; }

        // Μπορώ αν θέλω για περιγραφικούς λόγους να κάνω append ένα annotation που αναφέρεται στο ξένο κλειδί που θα δηλώσω
        [ForeignKey("LeaveTypeId")]

        // Πρέπει να δηλώση σαν πρώτο βήμα και τον πίνακα στον οποίο θέλω να γίνει η σύνδεση σαν μεταβλητή
        public LeaveType LeaveType { get; set; }    

        // Πρέπει να δηλώσω και την ενεργή στήλη στην οποία αναφέρεται το Foreign Key (δηλαδή το πεδίο)
        public int LeaveTypeId { get; set; }

        public string EmployeeId { get; set; }

       
    }
}
