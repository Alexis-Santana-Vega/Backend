using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.DTOs;
public class Seller
{
    [Key]
    public Guid Id { get; set; }
    public string StoreName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid IdUser { get; set; }
}
