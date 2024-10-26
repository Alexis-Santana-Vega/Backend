using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Domain.DTOs;

namespace CE.Chepeat.Domain.Aggregates.Email;
public class WelcomeModel
{
    public DTOs.User user { get; set; }
}
