using ShopeBride.Models;
using ShopeBride.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopeBride.Controllers
{
    public class InventoryController : ApiController
    {
        InventoryService objInventoryService = null;
        public InventoryController()
        {
            objInventoryService = new InventoryService();
        }
        
        [HttpPost, Route("api/Inventory/GetInventoryDetails")]
        public IHttpActionResult GetInventoryDetails()
        {
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, objInventoryService.GetInventoryDetails()));
        }

        [HttpPost, Route("api/Inventory/SaveInventoryDetails")]
        public IHttpActionResult SaveInventoryDetails(InventoryRequestBO objRequest)
        {
            if (objRequest == null)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Request "));
            else if (string.IsNullOrEmpty(objRequest.InventoryName))
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "InventoryName is Mandatory "));
            else if (string.IsNullOrEmpty(objRequest.Description))
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Description is Mandatory "));
            else if (objRequest.Price <= 0)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Price is Mandatory "));

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, objInventoryService.SaveInventoryDetails(objRequest)));
        }

        [HttpPost, Route("api/Inventory/UpdateInventoryDetails")]
        public IHttpActionResult UpdateInventoryDetails(InventoryRequestBO objRequest)
        {
            if (objRequest == null)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Request "));
            else if (objRequest.InventoryId <= 0)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "InventoryId is Mandatory "));
            else if (string.IsNullOrEmpty(objRequest.InventoryName))
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "InventoryName is Mandatory "));
            else if (string.IsNullOrEmpty(objRequest.Description))
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Description is Mandatory "));
            else if (objRequest.Price <= 0)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Price is Mandatory "));

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, objInventoryService.UpdateInventoryDetails(objRequest)));
        }

        [HttpPost, Route("api/Inventory/DeleteInventoryDetails")]
        public IHttpActionResult DeleteInventoryDetails(DeleteInvetoryRequestBO objRequest)
        {
            if (objRequest == null)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Request "));
            else if (objRequest.InventoryId <= 0)
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "InventoryId is Mandatory "));

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, objInventoryService.DeleteInventoryDetails(objRequest)));
        }
    }
}
