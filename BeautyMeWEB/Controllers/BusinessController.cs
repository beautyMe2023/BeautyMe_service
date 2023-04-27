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
    public class BusinessController : ApiController
    {
        BeautyMeDBContext1 db = new BeautyMeDBContext1();
        // GET: Business
        [HttpGet]
        [Route("api/Business/AllBusiness")]
        public HttpResponseMessage GetAllBusiness()
        {
            List<BusinessDTO> AllBusiness = db.Businesses.Select(x => new BusinessDTO
            {
                Business_Number = x.Business_Number,
                Name = x.Name,
                AddressStreet = x.AddressStreet,
                AddressHouseNumber = x.AddressHouseNumber,
                AddressCity = x.AddressCity,
                Is_client_house = x.Is_client_house,
                Professional_ID_number = x.Professional_ID_number,
            }).ToList();
            if (AllBusiness != null)
                return Request.CreateResponse(HttpStatusCode.OK, AllBusiness);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // Post: api/Business/OneBusiness פונקציה שמקבלת מספר תור ומחזירה את התור הספציפי
        [HttpPost]
        [Route("api/Business/OneBusiness")]
        public HttpResponseMessage GetOneBusiness([FromBody] int business_num)
        {
            BusinessDTO oneBusiness = db.Businesses.Where(a => a.Business_Number == business_num).Select(x => new BusinessDTO
            {
                Business_Number = x.Business_Number,
                Name = x.Name,
                AddressStreet = x.AddressStreet,
                AddressHouseNumber = x.AddressHouseNumber,
                AddressCity = x.AddressCity,
                Is_client_house = x.Is_client_house,
                Professional_ID_number = x.Professional_ID_number,
            }).FirstOrDefault();
            if (oneBusiness != null)
                return Request.CreateResponse(HttpStatusCode.OK, oneBusiness);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // Post: api/Post
        [HttpPost]
        [Route("api/Business/NewBusiness")]

        public HttpResponseMessage PostNewBusiness([FromBody] BusinessDTO x)
        {
            try
            {
                Business newBusiness = new Business()
                {
                    //Business_Number = x.Business_Number,
                    Name = x.Name,
                    AddressStreet = x.AddressStreet,
                    AddressHouseNumber = x.AddressHouseNumber,
                    AddressCity = x.AddressCity,
                    Is_client_house = x.Is_client_house,
                    Professional_ID_number = x.Professional_ID_number
                };
                db.Businesses.Add(newBusiness);
                db.SaveChanges();
                int newBusinessId = newBusiness.Business_Number;
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "new Business added to the dataBase", businessId = newBusinessId });
            }
        
            catch (DbUpdateException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occurred while adding new bussines to the database: " + ex.InnerException.InnerException.Message);
            }
        }
    }
}


//// Post: api/Post
//[HttpPost]
//[Route("api/Business/NewBusiness")]

//public HttpResponseMessage PostNewBusiness([FromBody] BusinessDTO x)
//{
//    BeautyMeDBContext db = new BeautyMeDBContext();
//    Business newBusiness = new Business()
//    {
//        //Business_Number = x.Business_Number,
//        Name = x.Name,
//        AddressStreet = x.AddressStreet,
//        AddressHouseNumber = x.AddressHouseNumber,
//        AddressCity = x.AddressCity,
//        Is_client_house = x.Is_client_house,
//        Professional_ID_number = x.Professional_ID_number
//    };
//    if (newBusiness != null)
//    {
//        db.Business.Add(newBusiness);
//        db.SaveChanges();
//        return Request.CreateResponse(HttpStatusCode.OK, "new Business added to the dataBase");
//    }
//    else
//        return Request.CreateResponse(HttpStatusCode.NoContent);
//}



//// Post: api/Post
//[HttpPost]
//[Route("api/Business/NewBusiness")]

//public HttpResponseMessage PostNewBusiness([FromBody] BusinessDTO x)
//{
//    BeautyMeDBContext db = new BeautyMeDBContext();
//    Business newBusiness = new Business()
//    {
//        Business_Number = x.Business_Number,
//        Name = x.Name,
//        AddressStreet = x.AddressStreet,
//        AddressHouseNumber = x.AddressHouseNumber,
//        AddressCity = x.AddressCity,
//        Is_client_house = x.Is_client_house,
//        Professional_ID_number = x.Professional_ID_number
//    };
//    if (newBusiness != null)
//    {
//        db.Business.Add(newBusiness);
//        db.SaveChanges();
//        return Request.CreateResponse(HttpStatusCode.OK, "new Business added to the dataBase");
//    }
//    else
//        return Request.CreateResponse(HttpStatusCode.NoContent);
//}