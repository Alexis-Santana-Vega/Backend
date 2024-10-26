namespace CE.Chepeat.Application.Interfaces.Controllers;
public interface IApiController
{
    IUserPresenter UserPresenter { get; }
    IAuthPresenter AuthPresenter { get; }
    ISellerPresenter SellerPresenter { get; }
    IProductPresenter ProductPresenter { get; }
<<<<<<< HEAD
=======
    IEmailPresenter EmailPresenter { get; }
    IPurchaseRequestPresenter PurchaseRequestPresenter { get; }
    ITransactionPresenter TransactionPresenter { get; }
>>>>>>> 763f78c586a87458fcac8320cc7dbdb8f418e916
}
