using Nyse.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Nyse.WebApi.Controllers
{
    public class StocksController : ApiController
    {
        private readonly nyseDataEntities _db;

        public StocksController()
        {
            _db = new nyseDataEntities();
        }

        // Gets the First Stock from each stock symbol and orders them by stock symbol
        public IHttpActionResult Get()
        {
            var res = _db.NYSEDbs.GroupBy(s => s.stockSymbol)
                .Select(g => g.FirstOrDefault())
                .OrderBy(a => a.stockSymbol)
                .ToList();

            return Json(res);
        }

        // Returns all of the stocks data for the selected stock
        public IHttpActionResult Get(string id)
        {
            var res = _db.NYSEDbs.Where(s => s.stockSymbol == id)
                .OrderBy(a => a.date)
                .ToList();

            return Json(res);
        }
    }
}