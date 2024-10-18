namespace CE.Chepeat.Application.Interfaces.Controllers;
public interface IApiController
{
    IUserPresenter UserPresenter { get; }
    IAuthPresenter AuthPresenter { get; }
    ISellerPresenter SellerPresenter { get; }
}
