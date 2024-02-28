using System;
using Dadecar.Domain.Entities;
using Dadecar.Application.Dtos;

namespace Dadecar.Application.Interfaces.Repositories
{
	public interface IFlightRepository
	{
        Task<IEnumerable<Flight>> GetFlights();
        Task<List<FlightStatusRes>> GetFlightStatusRes(string dates);
        Task<IEnumerable<Flight>> GetFlights(string dates);

    }
}

