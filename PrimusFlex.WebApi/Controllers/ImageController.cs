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
    public class ImageController : BaseController
    {
        private IDbRepository<KitchenImage> kitchenImages;

        public ImageController()
        {
            this.kitchenImages = new DbRepository<KitchenImage>(this.context);
        }

        // api/image/save
        [Route("api/image/save")]
        public IHttpActionResult SaveKitchenDetails(KitchenImage image)
        {
            this.kitchenImages.Add(image);
            this.kitchenImages.Save();

            return Ok();
        }

        // api/image/delete/
        [Route("api/image/delete/{publicId}")]
        public IHttpActionResult Delete(string publicId)
        {
            KitchenImage image = this.kitchenImages.All()
                                    .FirstOrDefault(i => i.PublicId == publicId);
            if(image == null)
            {
                return BadRequest();
            }

            this.kitchenImages.HardDelete(image);
            this.kitchenImages.Save();

            return Ok();
        }
    }
}