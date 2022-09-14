using Microsoft.AspNetCore.Identity;

namespace LeaveManagement.Web.Data
{       // Έχω ένα custom class που λέγεται Employee και θέλω να κληρονομεί τις ιδιότητες του IdentityUser
    public class Employee: IdentityUser
    {   // Εδώ προσθέτω τα πεδια που θέλω να έχει η Β.Δ Employee
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }   

        public string? TaxId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateJoined { get; set; }


    }
}
