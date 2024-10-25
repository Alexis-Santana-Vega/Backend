using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.Aggregates.Product;
public class ProductRadiusRequest
{
    [Required]
    public float Latitude { get; set; }


    [Required]
    public float Longitude { get; set; }

    [Required]
    public float RadiusKm { get; set; }
}
