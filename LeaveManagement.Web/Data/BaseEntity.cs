// Δημιουργούμε αυτήν την ενδιάμεση abstract κλάση για να μην επαναλαμβάνουμε κώδικα στις κλάσεις μας
// Τα κοινά κομμάτια τα περιλαμβάνουμε εδώ

namespace LeaveManagement.Web.Data
{
    // Abstract Class σημαίνει ότι απαγορεύεται σε κάποιον να φτιάξει στιγμιότυπα αυτής της κλάσης
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }    
    
    }
}
