using System;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using IScheduler.DataAccess.Context;
using IScheduler.DataAccess.Dto;

namespace IScheduler.DataAccess.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IAppDbContext _dbContext;

        public AddressRepository(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Address> GetAddressAsync(string id)
        {
            return Task.Run(() =>
            {
                Address address = _dbContext.Addresses.Find(id);
                return address;
            });
        }

        public Task<Address> CreateAddressAsync(Address address)
        {
            return Task.Run(() =>
            {
                address.Id = Guid.NewGuid().ToString();
                _dbContext.Addresses.Add(address);
                return address;
            });
        }

        public Task<Address> UpdateAddressAsync(Address address)
        {
            return Task.Run(() =>
            {
                if (string.IsNullOrEmpty(address.Id)) address.Id = Guid.NewGuid().ToString();
                _dbContext.Addresses.AddOrUpdate(address);
                return address;
            });
        }

        public Task<Address> DeleteAddressAsync(string id)
        {
            return Task.Run(() =>
            {
                Address address = _dbContext.Addresses.Find(id);
                if (address == null) return null;
                _dbContext.Addresses.Remove(address);
                return address;
            });
        }
    }
}