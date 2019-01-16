using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AdidasNew.Models.DomainModels;
using AdidasNew.Models.ApiModel;


namespace AdidasNew.Controllers
{
    public class AdidasApiController : ApiController
    {
        DatabaseContext db = new DatabaseContext();

        [HttpGet]
        [Route("people")]
        public List<PersonMobile> GetAllPerson()
        {


            var yy = db.People.ToList();

            List<PersonMobile> people = new List<PersonMobile>();
            foreach (var item in yy)
            {
                people.Add(new PersonMobile(item.Id, item.Name, item.LastName, item.Marriage, item.BirthDay.Value, item.Mobile));
            }
            return people;
        }

        [HttpGet]
        [Route("person/{id}")]
        public InformationPerson GetPerson(int id)
        {

            var person = db.People.FirstOrDefault(p=>p.Id==id); 
            if(person.MilitaryService==null)
            {
                person.MilitaryService =0;
            }
            InformationPerson per = new InformationPerson(person.Marriage, person.BirthDay.Value, person.Gender, person.MilitaryService.Value)
            {
                Id = person.Id,
                FirstName = person.Name,
                LastName = person.LastName,
                Father = person.Father,
                Mobil = person.Mobile,
                Tell = person.Tell,
                Email = person.Email,
                Address = person.Address,
                Image = person.image
            };
       
            return per;
        }

        [HttpGet]
        [Route("picperson/{id}")]
        public byte[] GetPicPerson(int id)
        {

            var person = db.People.FirstOrDefault(p => p.Id == id).image;            
       
            return person;
        }
    }
}
