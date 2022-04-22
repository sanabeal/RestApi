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
    [RoutePrefix("api/todo2")]
    public class Todo2Controller : ApiController
    {
       // PPLEntities db = new PPLEntities();
        string constr = ConfigurationManager.ConnectionStrings["PPLEntities"].ConnectionString;
        [HttpGet]
        public IHttpActionResult findAll()
        {
            SqlDataAdapter adapt;
            DataTable dt;
            adapt = new SqlDataAdapter("SELECT OrderId, OrderNo, CustomerName, CustomerMobile, ShippingAddress, CONVERT(CHAR(10), AddDate, 103) AS AddDate FROM eco.[Order]", constr);
            dt = new DataTable();
            adapt.Fill(dt);
            var tasks = dt;
            return Ok(new { Results = tasks });
        }

        [HttpGet]
        public IHttpActionResult findData(int Id)
        {
            SqlDataAdapter adapt;
            DataTable dt;
            adapt = new SqlDataAdapter("SELECT OrderId, OrderNo, CustomerName, CustomerMobile, ShippingAddress, CONVERT(CHAR(10), AddDate, 103) AS AddDate FROM eco.[Order] WHERE (OrderId = '" + Id + "')", constr);
            dt = new DataTable();
            adapt.Fill(dt);
            var tasks = dt;
            return Ok(new { Results = tasks });
        }
    }
}
