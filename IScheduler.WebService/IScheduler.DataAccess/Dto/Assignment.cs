using System.ComponentModel.DataAnnotations;

namespace IScheduler.DataAccess.Dto
{
    public class Assignment
    {
        [Key]
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string PickupDateTime { get; set; }
        public string DropOffDateTime { get; set; }
        public string PickupAddressId { get; set; }
        public string DropOffAddressId { get; set; }
        public string PatientId { get; set; }
        public string Description { get; set; }
    }
}
