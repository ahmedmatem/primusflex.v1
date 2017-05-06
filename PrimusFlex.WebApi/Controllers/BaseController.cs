namespace PrimusFlex.WebApi.Controllers
{
    using System.Data.Entity;
    using System.Web.Http;

    using PrimusFlex.Data.Models;

    public class BaseController : ApiController
    {
        protected readonly DbContext context;

        public BaseController()
        {
            this.context = ApplicationDbContext.Create();
        }
    }
}