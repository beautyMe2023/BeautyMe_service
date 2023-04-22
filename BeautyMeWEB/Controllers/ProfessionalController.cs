using BeautyMe;
using BeautyMeWEB.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace BeautyMeWEB.Controllers
{
    public class ProfessionalController : ApiController
    {
        BeautyMeDBContext1 db = new BeautyMeDBContext1();
        // GET: Professional
        [HttpGet]
        [Route("api/Professional/AllProfessional")]
        public HttpResponseMessage GetAllProfessional()
        {
            List<ProfessionalDTO> AllProfessionals = db.Professionals.Select(x => new ProfessionalDTO
            {
                ID_number = x.ID_number,
                First_name = x.First_name,
                Last_name = x.Last_name,
                birth_date = x.birth_date,
                gender = x.gender,
                phone = x.phone,
                Email = x.Email,
                AddressStreet = x.AddressStreet,
                AddressHouseNumber = x.AddressHouseNumber,
                AddressCity = x.AddressCity,
                password = x.password
            }).ToList();
            if (AllProfessionals != null)
                return Request.CreateResponse(HttpStatusCode.OK, AllProfessionals);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // GET: api/Professional/OneProfessional
        [HttpPost]
        [Route("api/Professional/OneProfessional")]
        public HttpResponseMessage GetOneProfessional([FromBody] ProfessionalDTO v)
        {
            ProfessionalDTO oneProfessional = db.Professionals.Where(a => a.ID_number == v.ID_number && a.password == v.password).Select(x => new ProfessionalDTO
            {
                ID_number = x.ID_number,
                First_name = x.First_name,
                Last_name = x.Last_name,
                birth_date = x.birth_date,
                gender = x.gender,
                phone = x.phone,
                Email = x.Email,
                AddressStreet = x.AddressStreet,
                AddressHouseNumber = x.AddressHouseNumber,
                AddressCity = x.AddressCity,
                password = x.password
            }).FirstOrDefault();
            if (oneProfessional != null)
                return Request.CreateResponse(HttpStatusCode.OK, oneProfessional);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        //[HttpPost]
        //[Route("api/Professional/GetProfessional")]
        //public IHttpActionResult GetProfessional([FromBody] ProfessionalDTO user)
        //{
        //    try
        //    {
        //        var userD = db.Professionals.Where(x => x.ID_number == user.ID_number && x.password == user.password).FirstOrDefault();
        //        if (userD == null)
        //        {
        //            return NotFound();
        //        }
        //        ProfessionalDTO newUser = new ProfessionalDTO();
        //        newUser.ID_number = userD.ID_number;
        //        newUser.First_name = userD.First_name;
        //        newUser.Last_name = userD.Last_name;
        //        newUser.birth_date = userD.birth_date;
        //        newUser.gender = userD.gender;
        //        newUser.phone = userD.phone;
        //        newUser.Email = userD.Email;
        //        newUser.AddressStreet = userD.AddressStreet;
        //        newUser.AddressHouseNumber = userD.AddressHouseNumber;
        //        newUser.AddressCity = userD.AddressCity;
        //        return Ok(newUser);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        // Post: api/Post
        [HttpPost]
        [Route("api/Professional/NewProfessional")]
        public HttpResponseMessage PostNewProfessional([FromBody] ProfessionalDTO x)
        {
            try
            {
                Professional newProfessional = new Professional()
                {
                    ID_number = x.ID_number,
                    First_name = x.First_name,
                    Last_name = x.Last_name,
                    birth_date = x.birth_date,
                    gender = x.gender,
                    phone = x.phone,
                    Email = x.Email,
                    AddressStreet = x.AddressStreet,
                    AddressHouseNumber = x.AddressHouseNumber,
                    AddressCity = x.AddressCity,
                    password = x.password
                };
                db.Professionals.Add(newProfessional);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "new Professional added to the dataBase");
            }
            catch (DbUpdateException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occurred while adding new Professional to the database: " + ex.InnerException.InnerException.Message);
            }
        }
    }
}

