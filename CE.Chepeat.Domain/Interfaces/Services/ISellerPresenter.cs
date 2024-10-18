using CE.Chepeat.Domain.Aggregates.Seller;

namespace CE.Chepeat.Domain.Interfaces.Services;
public interface ISellerPresenter
{
    Task<RespuestaDB> AddSeller(SellerRequest request);
}
