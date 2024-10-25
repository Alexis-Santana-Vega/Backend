using CE.Chepeat.Domain.Aggregates.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Application.Presenters
{
    public class TransactionPresenter : ITransactionPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public TransactionPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<RespuestaDB> AddTransaction(TransactionAggregate transactionAggregate)
        {
            return await _unitRepository.transactionInfraestructure.AddTransaction(transactionAggregate);
        }

        public async Task<RespuestaDB> GetTransactionStatus(Guid idTransaction)
        {
            return await _unitRepository.transactionInfraestructure.GetTransactionStatus(idTransaction);
        }
    }
}
