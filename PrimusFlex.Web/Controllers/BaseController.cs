namespace PrimusFlex.Web.Controllers
{
    using System.Data.Entity;
    using System.Web.Mvc;

    using PrimusFlex.Data.Models;
    using PrimusFlex.Web.Common;

    public class BaseController : Controller
    {
        protected readonly DbContext context;

        public BaseController()
        {
            this.context = ApplicationDbContext.Create();
        }
    }
}