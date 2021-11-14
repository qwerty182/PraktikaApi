using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPraktika.Models;

namespace ApiPraktika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private praktikaVarvaninContext _context;

        public InfoController (praktikaVarvaninContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<User> AutorizationUser(User userDb)
        {
            var result = (from user in _context.Users
                          where user.Login == userDb.Login && user.Password == userDb.Password
                          select user).FirstOrDefault();

            if (result == null)
            {
                return NotFound();
            }

            return new ObjectResult(result);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<User> RegistrationUser(User userDb)
        {
            var result = (from user in _context.Users
                          where user.Login == userDb.Login
                          select user).FirstOrDefault();

            if (result != null)
            {
                return NotFound();
            }

            _context.Users.Add(userDb);
            _context.SaveChanges();

            return new ObjectResult (new { is_success = true });
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<object> BuildingList()
        {
            var result = (from build in _context.Buildings
                          select new String(build.Name)).ToList();
            return result;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<Cabinet> CabinetList(String cabinetNumberDb)
        {
            var cabinetList = (from cabinetSearch in _context.Cabinets
                              where cabinetSearch.CabinetNumber.ToLower().Contains(cabinetNumberDb.ToLower().Trim())
                              select new 
                              { 
                                  id = cabinetSearch.IdCabinet, 
                                  image = cabinetSearch.CabinetImage, 
                                  number = cabinetSearch.CabinetNumber 
                              }).FirstOrDefault();
            if (cabinetList == null)
            {
                return NotFound();
            }

            return new ObjectResult(cabinetList);
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<object> InfoCabinetItem(int id)
        {
            var result = (from cabinet in _context.CabinetCompositions
                          where cabinet.CabinetId == id
                          select new
                          {
                              idCabineta = cabinet.CabinetId,
                              cabinetNumber = cabinet.Cabinet.CabinetNumber,
                              cabinetImage = cabinet.Cabinet.CabinetImage,
                              cabinetInfo = cabinet.Cabinet.GeneralInformation,

                              cabinetSostavId = cabinet.IdCabinetCompositions,
                              value = cabinet.Value,

                              cabinetAttributeId = cabinet.AttributeId,
                              cabinetAttribute = cabinet.Attribute.Name,
                          }).FirstOrDefault();
            return new ObjectResult(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<object> ReportTypeList()
        {
            var result = (from reportType in _context.ReportTypes
                          select new String(reportType.Name)).ToList();
            return result;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Report> ReportItem(Report reportDb)
        {
            var result = (from report in _context.Reports
                          select report).FirstOrDefault();

            if (result != null)
            {
                return NotFound();
            }

            _context.Reports.Add(reportDb);
            _context.SaveChanges();

            return new ObjectResult(new { is_success = true });
        }
    }
}
