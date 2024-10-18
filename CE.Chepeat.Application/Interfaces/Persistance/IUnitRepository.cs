
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Application.Interfaces.Persistance
{
    public interface IUnitRepository
    {
        ValueTask<bool> Complete();
        bool HasChanges();

        IUserInfraestructure userInfraestructure {  get; }
        IAuthInfraestructure authInfraestructure { get; }
        ISellerInfraestructure sellerInfraestructure { get; }
    }
}
