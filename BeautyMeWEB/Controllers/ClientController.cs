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
    public class ClientController : ApiController
    {
        BeautyMeDBContext1 db = new BeautyMeDBContext1();
        // GET: Client
        [HttpGet]
        [Route("api/Client/AllClient")]
        public HttpResponseMessage GetAllClient()
        {
            List<ClientDTO> AllClient = db.Clients.Select(x => new ClientDTO
            {
                ID_number = x.ID_number,
                First_name = x.First_name,
                Last_name = x.Last_name,
                birth_date = x.birth_date,
                phone = x.phone,
                Email = x.Email,
                AddressStreet = x.AddressStreet,
                AddressHouseNumber = x.AddressHouseNumber,
                AddressCity = x.AddressCity,
                password = x.password
            }).ToList();
            if (AllClient != null)
                return Request.CreateResponse(HttpStatusCode.OK, AllClient);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // GET: api/Client/OneClient
        [HttpGet]
        [Route("api/Client/OneClient/{ID_number}/{password}")]
        public HttpResponseMessage GetOneClient(string ID_number, string password  )
        {
            ClientDTO oneClient = db.Clients.Where(a => a.ID_number == ID_number && a.password == password).Select(x => new ClientDTO
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
            if (oneClient != null)
                return Request.CreateResponse(HttpStatusCode.OK, oneClient);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // Post: api/Post
        [HttpPost]
        [Route("api/Client/NewClient")]
        public HttpResponseMessage PostNewClient([FromBody] ClientDTO x)
        {
            try
            {
                Client newClient = new Client()
                {
                    ID_number = x.ID_number,
                    First_name = x.First_name,
                    Last_name = x.Last_name,
                    birth_date = x.birth_date,
                    phone = x.phone,
                    gender = x.gender,
                    Email = x.Email,
                    AddressStreet = x.AddressStreet,
                    AddressHouseNumber = x.AddressHouseNumber,
                    AddressCity = x.AddressCity,
                    password = x.password
                };
                db.Clients.Add(newClient);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "New client added to the database");
            }
            catch (DbUpdateException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occurred while adding new client to the database: " + ex.InnerException.InnerException.Message);
            }
        }
    }
}


