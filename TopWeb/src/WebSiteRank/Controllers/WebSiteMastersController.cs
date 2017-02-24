using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using ASPNET5WEBAPIAngularJS.Models;

namespace ASPNET5WEBAPIAngularJS.Controllers
{
    [Produces("application/json")]
    [Route("api/WebSiteMasters")]
    public class WebSiteMastersController : Controller
    {
        private WebSiteMastersAppContext _context;

        public WebSiteMastersController(WebSiteMastersAppContext context)
        {
            _context = context;
        }

        // GET: api/WebSiteMasters TOP 5
        [HttpGet]
        public IEnumerable<WebSiteMasters> GetWebSites()
        {
            var list = (from t in _context.WebSites
              orderby t.VisitDate descending
           select t).Take(5);        
            return list;
        }

              
        
        // GET: api/WebSiteMasters/5 - TOP 5 with date, from drop down
        [HttpGet("{id}", Name = "GetWebSiteMasters")]
        public IActionResult GetWebSiteMasters([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }
             var list = (from t in _context.WebSites
              orderby t.VisitDate descending
           select t).Take(5); 
            WebSiteMasters WebSiteMasters = _context.WebSites.Single(m => m.WebID == id);

            if (WebSiteMasters == null)
            {
                return HttpNotFound();
            }

            return Ok(WebSiteMasters);
        }

        // PUT: api/WebSiteMasters/5
        [HttpPut("{id}")]
        public IActionResult PutWebSiteMasters(int id, [FromBody] WebSiteMasters WebSiteMasters)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != WebSiteMasters.WebID)
            {
                return HttpBadRequest();
            }

            _context.Entry(WebSiteMasters).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebSiteMastersExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/WebSiteMasters
        [HttpPost]
        public IActionResult PostWebSiteMasters([FromBody] WebSiteMasters WebSiteMasters)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.WebSites.Add(WebSiteMasters);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (WebSiteMastersExists(WebSiteMasters.WebID))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetWebSiteMasters", new { id = WebSiteMasters.WebID }, WebSiteMasters);
        }

        // DELETE: api/WebSiteMasters/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWebSiteMasters(int id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            WebSiteMasters WebSiteMasters = _context.WebSites.Single(m => m.WebID == id);
            if (WebSiteMasters == null)
            {
                return HttpNotFound();
            }

            _context.WebSites.Remove(WebSiteMasters);
            _context.SaveChanges();

            return Ok(WebSiteMasters);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WebSiteMastersExists(int id)
        {
            return _context.WebSites.Count(e => e.WebID == id) > 0;
        }
    }
}