﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.Interfaces.Services
{
    public interface IPurchaseRequestPresenter
    {
        /// <summary>
        /// Solicitud de compra
        /// </summary>
        Task<RespuestaDB> CreatePurchaseRequest(PurchaseRequestAggregate request);
        /// <summary>
        /// Mostrar solicitud - Vendedor
        /// </summary>
        Task<List<PurchaseRequestDto>> GetRequestsBySeller(Guid idSeller);
        /// <summary>
        ///Mostrar solicitud - Comprador
        /// </summary>
        Task<List<PurchaseRequestDto>> GetRequestsByBuyer(Guid idBuyer);
        /// <summary>
        /// Rechazar solicitud
        /// </summary>
        Task<RespuestaDB> RejectRequest(Guid idRequest);
        /// <summary>
        /// Cancelar solicitud
        /// </summary>
        Task<RespuestaDB> CancelRequest(Guid idRequest);

    }
}