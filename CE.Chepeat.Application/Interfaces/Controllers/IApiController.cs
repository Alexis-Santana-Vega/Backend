using CE.Chepeat.Application.Presenters;

namespace CE.Chepeat.Application.Interfaces.Controllers;
public interface IApiController
{
    IUserPresenter UserPresenter { get; }
    IAuthPresenter AuthPresenter { get; }
    ISellerPresenter SellerPresenter { get; }
    IProductPresenter ProductPresenter { get; }
<<<<<<< HEAD
    IPurchaseRequestPresenter PurchaseRequestPresenter { get; }
    ITransactionPresenter TransactionPresenter { get; }
=======
    IEmailPresenter EmailPresenter { get; }
>>>>>>> 338fefee81e048b7bb74a4181ea65eed8348a27b
}
