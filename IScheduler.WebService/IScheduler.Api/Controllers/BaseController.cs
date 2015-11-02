using System.Web.Http;
using IScheduler.Common.Logging;

namespace IScheduler.Api.Controllers
{
    public class BaseController : ApiController
    {
        private ILogger _logger;

        public ILogger Logger
        {
            get { return _logger ?? (_logger = new NLogger(this.GetType().Name)); }
            set { this._logger = value; }
        }
    }
}