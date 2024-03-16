using System;
using Dadecar.Persistence.Contexts;
using Dadecar.Application.Interfaces.Repositories;
using Dadecar.Application.Dtos;
using Dadecar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Dadecar.Persistence.Repositories
{
	public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _context;


        public FlightRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
         
        }
        public async Task<IEnumerable<Flight?>> GetFlights()
        {
            try
            {
                return await _context.Flights.Include(c=>c.Route).
                                        //Take(300)
                    AsNoTracking()
                    .ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        public async Task<IEnumerable<Subscription?>> GetSubscriptions(int agnencyid)
        {
            try
            {
                return await _context.Subscriptions.Where(t=>t.agency_id==agnencyid).ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        public async Task<List<FlightStatusRes?>> GetFlightStatusRes(string dates)
        {
            try
            {
                var flights=  await GetFlights(dates);
                var subscriptions = await GetSubscriptions(Convert.ToInt32(dates.Split(" ")[2]));
                List<FlightStatusRes> _FlightStatusRes = new List<FlightStatusRes>();
                foreach (var fli in flights)
                {
                    foreach (var subs in subscriptions)
                    {
                        if (fli.Route.origin_city_id==subs.origin_city_id && fli.Route.destination_city_id==subs.destination_city_id)

                        {
                            FlightStatusRes _flightStatusRes = new FlightStatusRes();
                            _flightStatusRes.flight_id = fli.flight_id;
                            _flightStatusRes.origin_city_id = fli.Route.origin_city_id;
                            _flightStatusRes.destination_city_id = fli.Route.destination_city_id;
                            _flightStatusRes.airline_id = fli.airline_id;
                            _flightStatusRes.origin_city_id = fli.Route.origin_city_id;
                            _flightStatusRes.departure_time = fli.departure_time;
                            _flightStatusRes.arrival_time = fli.arrival_time;
                            _flightStatusRes.status = DetectFlight(fli, flights).ToString();
                            _FlightStatusRes.Add(_flightStatusRes);
                        }
                            }
                }

                return _FlightStatusRes;
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
    



                public async Task<IEnumerable<Flight?>> GetFlights(string dates)
        {
            try
            {
                var startDate =Convert.ToDateTime(dates.Split(" ")[0]);
                var endDate = Convert.ToDateTime(dates.Split(" ")[1]);
        
                return await _context.Flights.Include(c => c.Route)
                    //.Skip(6000000).Take(2000)
                    
                    .Where(t => t.departure_time.CompareTo(startDate) > 0 && t.arrival_time.CompareTo(endDate) < 0)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        public string DetectFlight(Flight item,IEnumerable<Flight> flights)
        {
            try
            {
                var newflight = item.departure_time.AddDays(-7);
                var discontinuedflight = item.departure_time.AddDays(+7);
              //var dtect=   _context.Flights
                    //.Skip(6000000).Take(2000)
              var dtect=   flights
                    .Where(t =>t.airline_id==item.airline_id && (t.departure_time.CompareTo(newflight) > 0 || t.departure_time.CompareTo(discontinuedflight) < 0))
                    //.AsNoTracking()
                           .First();
                string res = "";
                if (dtect.airline_id != 0)
                {
                    res = "Discontinued and New";
                }
                if(dtect.departure_time.CompareTo(item.departure_time) > 0)
                {
                    res = "New";
                }
                else if(dtect.departure_time.CompareTo(item.departure_time) < 0)
                {
                    res = "Discontinued";
                }
                    return res;
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
    }
}

