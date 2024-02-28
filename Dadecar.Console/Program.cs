// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using  Dadecar.Persistence.Repositories;
using Dadecar.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

internal class Program 
{
    static private  IFlightRepository _flightRepository;
    public Program(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository ??
            throw new ArgumentNullException(nameof(flightRepository));
    }

    private static async Task Main(string[] args)
    {
        Console.WriteLine("write your dates");
        var input = Console.ReadLine();

        var res = await _flightRepository.GetFlights(input);
        Console.WriteLine("response is Ok!");
        Console.ReadLine();

    }
}