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

    public async Task<RespuestaDB> DeleteSeller(Guid Id)
    {
        return await _unitRepository.sellerInfraestructure.DeleteSeller(Id);
    }

    public async Task<Seller> SelectSellerById(Guid id)
    {
        return await _unitRepository.sellerInfraestructure.SelectSellerById(id);
    }

    public async Task<List<Seller>> SelectSellersByRadius(SellerRadiusRequest request)
    {
        return await _unitRepository.sellerInfraestructure.SelectSellersByRadius(request);
    }

    public async Task<RespuestaDB> UpdateSeller(SellerRequest request)
    {
        return await _unitRepository.sellerInfraestructure.UpdateSeller(request);
    }
}
