using System.ComponentModel.DataAnnotations;

namespace IScheduler.DataAccess.Dto
{
    public class Patient
    {
        [Key]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressId { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
    }
}