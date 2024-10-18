using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Domain.Aggregates.Seller;

namespace CE.Chepeat.Application.Presenters;
public class SellerPresenter : ISellerPresenter
{
    private readonly IUnitRepository _unitRepository;

    public SellerPresenter(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public async Task<RespuestaDB> AddSeller(SellerRequest request)
    {
        return await _unitRepository.sellerInfraestructure.AddSeller(request);
    }
}
