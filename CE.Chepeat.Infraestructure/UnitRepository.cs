<<<<<<< HEAD
﻿using CE.Chepeat.Infraestructure.Services;
=======
﻿using CE.Chepeat.Infraestructure.Repositories;
>>>>>>> 763f78c586a87458fcac8320cc7dbdb8f418e916

namespace CE.Chepeat.Infraestructure;
public class UnitRepository:BaseDisposable, IUnitRepository
{
    private readonly ChepeatContext _context;
    private readonly IConfiguration _configuration;

    public UnitRepository(ChepeatContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    protected override void DisposeManagedResource()
    {
        try
        {
            _context.Dispose();


            //if (_context.Database.GetDbConnection != null)
            //{
            //    System.Diagnostics.Debug.WriteLine(_context.Database.GetDbConnection().State);
            //    System.Diagnostics.Debug.WriteLine(_context.Database.GetDbConnection().ConnectionTimeout);
            //}
        }
        finally
        {
            base.DisposeManagedResource();
        }
    }
    //
    public IUserInfraestructure userInfraestructure => new UserInfraestructure(_context);
    public IAuthInfraestructure authInfraestructure => new AuthInfraestructure(_context);
    public ISellerInfraestructure sellerInfraestructure => new SellerInfraestructure(_context);
    public IProductInfraestructure productInfraestructure => new ProductInfraestructure(_context);
    public IPurchaseRequestInfraestructure purchaseRequestInfraestructure => new PurchaseRequestInfraestructure(_context);
    public ITransactionInfraestructure transactionInfraestructure => new TransactionInfraestructure(_context);

    public IEmailServiceInfraestructure emailServiceInfraestructure => new EmailService(_configuration);


    public async ValueTask<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0;
    }



    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }

}
