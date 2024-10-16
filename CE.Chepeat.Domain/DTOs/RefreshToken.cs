using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.DTOs;
public class RefreshToken
{
    [Key]
    public Guid RefreshTokenId { get; set; }
    public string RefreshTokenValue { get; set; }
    public bool Active { get; set; }
    public DateTime Creation {  get; set; }
    public DateTime Expiration { get; set; }
    public bool Used { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
}
