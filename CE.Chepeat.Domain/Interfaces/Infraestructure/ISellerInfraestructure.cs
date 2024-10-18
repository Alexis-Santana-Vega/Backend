using CE.Chepeat.Domain.Aggregates.Seller;

namespace CE.Chepeat.Domain.Interfaces.Infraestructure;
public interface ISellerInfraestructure
{
    Task<RespuestaDB> AddSeller(SellerRequest request);
}
