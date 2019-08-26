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

        public IHttpActionResult Get()
        {
            var res = _db.NYSEDbs.GroupBy(s => s.stockSymbol)
                .Select(g => g.FirstOrDefault())
                .OrderBy(a => a.stockSymbol)
                .ToList();

            return Json(res);
        }

        public IHttpActionResult Get(string id)
        {
            var res = _db.NYSEDbs.Where(s => s.stockSymbol == id)
                .OrderBy(a => a.date)
                .ToList();

            return Json(res);
        }
    }
}