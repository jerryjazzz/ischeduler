using System.ComponentModel.DataAnnotations;

namespace IScheduler.DataAccess.Dto
{
    public class Address
    {
        [Key]
        public string Id { get; set; }
        public string PlaceName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}
