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

    [Authorize]
    public class ImageController : BaseController
    {
        private IDbRepository<KitchenImage> kitchenImages;

        public ImageController()
        {
            this.kitchenImages = new DbRepository<KitchenImage>(context);
        }

        //// api/image/save
        //[Route("api/image/save")]
        //[HttpPost]
        //public IHttpActionResult SaveImageDetails([FromBody] KitchenImage image)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    this.kitchenImages.Add(image);
        //    this.kitchenImages.Save();

        //    return Ok();
        //}
    }
}