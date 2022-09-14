namespace LeaveManagement.Web.Data

    // Κανόνας Νο1: Θα πρέπει πάντα να έχω primary key
    // Κανόνας Νο2: Να κάνω append ή prepend το όνομα του table
{
    public class LeaveType : BaseEntity
    {

        public string Name { get; set; }

        public  int DefaultDays { get; set; }


    }
}
