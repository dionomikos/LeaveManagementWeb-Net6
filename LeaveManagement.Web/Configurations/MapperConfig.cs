using AutoMapper;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Configurations
{
    public class MapperConfig : Profile 
    {
        // Παρακάτω δημιουργώ έναν constuctor για το MapperConfig
        // To MapperConfig μας λέει ότι είναι νόμιμο να μετατρέψουμε έναν τύπο Α  σε έναν τύπο Β
        public MapperConfig()
        {
            // The first one into the diamond represents the source and the second is the destination
            CreateMap<LeaveType,LeaveTypeVM>().ReverseMap();
        }
    }
}
