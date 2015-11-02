using System;
using System.Threading.Tasks;
using System.Web.Http;
using IScheduler.DataAccess.Dto;
using IScheduler.DataAccess.Repository;

namespace IScheduler.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Address")]
    public class AddressController : BaseController
    {
        private readonly IAddressRepository _repository;

        public AddressController(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<IHttpActionResult> GetAddress(string id)
        {
            try
            {
                var addresses = await _repository.GetAddressAsync(id);
                if (addresses == null) return NotFound();
                return Ok(addresses);
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception.ToString());
                return InternalServerError();
            }
        }

        [Route("Register")]
        public async Task<IHttpActionResult> PostAddress(Address address)
        {
            try
            {
                if (address == null) return BadRequest();
                address = await _repository.CreateAddressAsync(address);
                if (address == null) return InternalServerError();
                return Ok(address);
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception.ToString());
                return InternalServerError();
            }
        }

        [Route("Update")]
        public async Task<IHttpActionResult> PutAddressAsync(Address address)
        {
            try
            {
                if (address == null) return BadRequest();
                address = await _repository.UpdateAddressAsync(address);
                if (address == null) return InternalServerError();
                return Ok(address);
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception.ToString());
                return InternalServerError();
            }
        }

        [Route("Delete")]
        public async Task<IHttpActionResult> DeleteAddressAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return BadRequest();
                var address = await _repository.DeleteAddressAsync(id);
                if (address == null) return InternalServerError();
                return Ok(address);
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception.ToString());
                return InternalServerError();
            }
        }
    }
}