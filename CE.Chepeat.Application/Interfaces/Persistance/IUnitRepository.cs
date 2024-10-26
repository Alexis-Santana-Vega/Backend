
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
        IProductInfraestructure productInfraestructure { get; }
<<<<<<< HEAD
        IEmailServiceInfraestructure emailServiceInfraestructure { get; }
=======
        IPurchaseRequestInfraestructure purchaseRequestInfraestructure { get; }
        ITransactionInfraestructure transactionInfraestructure { get; }
>>>>>>> 763f78c586a87458fcac8320cc7dbdb8f418e916
    }
}
