using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskApi.Models;

namespace TaskApi.Controllers
{
    [RoutePrefix("api/todo1")]
    public class Todo1Controller : ApiController
    {
       // PPLEntities db = new PPLEntities();
     
        string constr = ConfigurationManager.ConnectionStrings["PPLEntities"].ConnectionString;
        [HttpGet]
        public HttpResponseMessage findData()
        {
            SqlDataAdapter adapt;
            DataTable dt;
            adapt = new SqlDataAdapter("SELECT OrderId, OrderNo, CustomerName, CustomerMobile, ShippingAddress, CONVERT(CHAR(10), AddDate, 103) AS AddDate FROM eco.[Order]", constr);
            dt = new DataTable();
            adapt.Fill(dt);
            var serializeData = JsonConvert.SerializeObject(dt);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(serializeData);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage findData(int Id)
        {
            SqlDataAdapter adapt;
            DataTable dt;
            adapt = new SqlDataAdapter("SELECT OrderId, OrderNo, CustomerName, CustomerMobile, ShippingAddress, CONVERT(CHAR(10), AddDate, 103) AS AddDate FROM eco.[Order] WHERE (OrderId = '" + Id + "')", constr);
            dt = new DataTable();
            adapt.Fill(dt);
            var serializeData = JsonConvert.SerializeObject(dt);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(serializeData);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return response;
        }
    }
}
