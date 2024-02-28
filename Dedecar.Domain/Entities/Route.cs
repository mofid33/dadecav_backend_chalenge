using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dadecar.Domain.Entities;

public partial class Route
{
    [Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long route_id { get; set; }

    public int? origin_city_id { get; set; }

    public int? destination_city_id { get; set; }

    public DateTime departure_date { get; set; }

    //public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}
