using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dadecar.Domain.Entities;

public partial class Subscription
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int subscription_id { get; set; }

    public int agency_id { get; set; }

    public int origin_city_id { get; set; }

    public int destination_city_id { get; set; }
}
