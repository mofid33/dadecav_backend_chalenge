using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dadecar.Domain.Entities;

public partial class Flight
{
    [Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long flight_id { get; set; }

    public long route_id { get; set; }

    public DateTime departure_time { get; set; }

    public DateTime arrival_time { get; set; }

    public int? airline_id { get; set; }

    [ForeignKey("route_id")]
    public virtual Route? Route { get; set; } 
}
