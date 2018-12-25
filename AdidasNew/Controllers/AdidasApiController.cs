using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdidasNew.Models.DomainModels;


namespace AdidasNew.Controllers
{
    public class AdidasApiController : ApiController
    {
        DatabaseContext db = new DatabaseContext();
        [HttpGet]
        [AllowAnonymous]
        [Route("hi")]
        public string Get()
        {
            return "Hello World";
        }
        //public IEnumerable<Person> list()
        //{
        //    return db.People.ToList();
        //}
    }
}
