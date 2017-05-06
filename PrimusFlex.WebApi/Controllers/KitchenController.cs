namespace PrimusFlex.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using PrimusFlex.Data.Common;
    using PrimusFlex.Data.Models;
    using PrimusFlex.WebApi.ViewModels;

    [Authorize]
    public class KitchenController : BaseController
    {
        public IDbRepository<Kitchen> kitchens;

        public KitchenController()
        {
            this.kitchens = new DbRepository<Kitchen>(this.context);
        }

        // api/kitchens
        [Route("api/kitchens")]
        public IHttpActionResult GetAll()
        {
            string fitterId = User.Identity.GetUserId();
            var kitchens = this.kitchens.All()
                                .Where(k => k.FitterId == fitterId)
                                .OrderByDescending(k => k.Date)
                                .Select(k => new KitchenViewModel()
                                {
                                    Id = k.Id,
                                    Date = k.Date,
                                    SiteName = k.Site.Name,
                                    SiteAddress = k.Site.Address,
                                    PlotNumber = k.PlotNumber,
                                    Company = k.CompanyType.ToString(),
                                    Shape = k.WorktopShape.ToString(),
                                    Note = k.Note,
                                })
                                .ToList();

            return Ok(kitchens);
        }

        [Route("api/kitchen/{id}")]
        public IHttpActionResult GetbyId(int id)
        {
            var kitchen = this.kitchens.GetById(id);

            string fitterId = User.Identity.GetUserId();
            if (kitchen == null || kitchen.FitterId != fitterId)
            {
                return BadRequest(string.Format("The requested kitchen with id:{0} for user:{1} does not exist", id, User.Identity.GetUserName()));
            }

            var kitchenModel = new KitchenViewModel()
            {
                Id = kitchen.Id,
                Date = kitchen.Date,
                SiteName = kitchen.Site.Name,
                SiteAddress = kitchen.Site.Address,
                PlotNumber = kitchen.PlotNumber,
                Company = kitchen.CompanyType.ToString(),
                Shape = kitchen.WorktopShape.ToString(),
                Note = kitchen.Note
            };

            return Ok(kitchenModel);
        }
    }
}
