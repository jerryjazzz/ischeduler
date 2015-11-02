using System.Threading.Tasks;
using IScheduler.DataAccess.Dto;

namespace IScheduler.DataAccess.Repository
{
    public interface IAddressRepository
    {
        Task<Address> GetAddressAsync(string id);
        Task<Address> CreateAddressAsync(Address address);
        Task<Address> UpdateAddressAsync(Address address);
        Task<Address> DeleteAddressAsync(string id);
    }
}