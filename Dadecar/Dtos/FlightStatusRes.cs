using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dadecar.Application.Dtos;

public partial class FlightStatusRes
{

    public long flight_id { get; set; }

    public int? origin_city_id { get; set; }

    public int? destination_city_id { get; set; }

    public DateTime departure_time { get; set; }

    public DateTime arrival_time { get; set; }

    public int? airline_id { get; set; }

    public string status { get; set; }
}
