using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dadecar.Application.Interfaces.Repositories;
using Dadecar.Domain.Entities;
using Dadecar.Application.Dtos;
using CsvHelper;
using CsvHelper.Configuration;
using System.Text;
using Microsoft.Extensions.Hosting.Internal;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dedecar.Api.Controllers
{
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        // GET: /<controller>/


        public FlightController(IFlightRepository flightRepository, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _flightRepository = flightRepository ??
                throw new ArgumentNullException(nameof(flightRepository));
            _hostingEnvironment = hostingEnvironment ??
             throw new ArgumentNullException(nameof(hostingEnvironment));
        }
        //[HttpGet]
        //[Route("GetFlights")]
        //public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        //{
        //    var workgroup = await _flightRepository.GetFlights();
        //    if (workgroup == null)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(workgroup);
        //}
     
        [HttpGet]
        [Route("GetFlightStatusRes")]
        public async Task<ActionResult<IEnumerable<FlightStatusRes>>> GetFlightStatusRes(string dates)
        {
            var workgroup = await _flightRepository.GetFlightStatusRes(dates);
           var csv= export(workgroup);
            if (workgroup == null)
            {
                return BadRequest();
            }
            return Ok(csv);
        }
        public FileContentResult export(List<FlightStatusRes> flightStatus)
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, $"export_{DateTime.UtcNow.Ticks}.csv");

            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(filePath,false, encoding: new UTF8Encoding(true)))
                //using (var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true)))
                {
                    using (var cw = new CsvWriter(sw, cc))
                    {
                        cw.WriteRecords(flightStatus);
                    }// The stream gets flushed here.
                    return File(ms.ToArray(), "text/csv", $"export_{DateTime.UtcNow.Ticks}.csv");
                    //return $"export_{DateTime.UtcNow.Ticks}.csv";
                }
            }
        }

    }
}

