using DvdService.Data;
using DvdService.Data.Interfaces;
using DvdService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DvdService.Controllers
{
    public class DvdController : ApiController
    {
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            IDvdRepository DvdRepo = DvdRepositoryFactory.Create();
            return Ok(DvdRepo.GetAll());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(int id)
        {
            IDvdRepository DvdRepo = DvdRepositoryFactory.Create();
            return Ok(DvdRepo.GetById(id));
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            IDvdRepository DvdRepo = DvdRepositoryFactory.Create();
            return Ok(DvdRepo.GetByTitle(title));
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByReleaseYear(int releaseYear)
        {
            IDvdRepository DvdRepo = DvdRepositoryFactory.Create();
            return Ok(DvdRepo.GetByReleaseYear(releaseYear));
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirectorName(string directorName)
        {
            IDvdRepository DvdRepo = DvdRepositoryFactory.Create();
            return Ok(DvdRepo.GetByDirector(directorName));
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            IDvdRepository DvdRepo = DvdRepositoryFactory.Create();
            return Ok(DvdRepo.GetByRating(rating));
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddDvd(Dvd dvd)
        {
            //validate add 
            if (ModelState.IsValid)
            {
                IDvdRepository DvdRepo = DvdRepositoryFactory.Create();
                DvdRepo.Add(dvd);

                //return route
                return Created($"/dvd{dvd.DvdId}", dvd);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "Model state invalid");
            }
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("OPTIONS")]
        public IHttpActionResult Options(int id)
        {
            return Ok();
        }

        [Route("dvd")]
        [AcceptVerbs("OPTIONS")]
        public IHttpActionResult Options()
        {
            return Ok();
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void EditDvd(int id, Dvd dvd)
        {
            //validate edit 
            if (ModelState.IsValid)
            {
                IDvdRepository DvdRepo = DvdRepositoryFactory.Create();
                DvdRepo.Edit(dvd);
            }
            else
            {
                Content(HttpStatusCode.BadRequest, "Model state invalid");
            }
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void DeleteDvd(int id)
        {
            IDvdRepository DvdRepo = DvdRepositoryFactory.Create();
            DvdRepo.Delete(id);
        }
    }
}
