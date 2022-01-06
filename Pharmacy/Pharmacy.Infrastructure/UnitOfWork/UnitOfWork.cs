using System.Threading.Tasks;
using ZPharmacy.Domain.IRepository;
using ZPharmacy.Infrastructure.Data;
using ZPharmacy.Infrastructure.Repostiory;

namespace ZPharmacy.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PharmacyDbContext _context;
        private readonly ApplicationUserManager _applicationUserManager;
        private IPharmacyRepository _pharmacyRepo;
        private IUnitRepository _unitRepo;
        private IProductRepository _productRepo;
        private ISupplierRepository _supplierRepo;
        private IProductQuantityRepository _productQuantityRepo;
        private ISupplierOrderRepository _supplierOrderRepo;
        private ISupplierOrderDetailsRepository _supplierOrderDetailsRepo;
        private IAccountRepository _accountRepository;
        public UnitOfWork(PharmacyDbContext context, ApplicationUserManager applicationUserManager)
        {
            _context = context;
            _applicationUserManager = applicationUserManager;
        }
        public ISupplierRepository SupplierRepo
        {
            get
            {
                if (_supplierRepo == null)
                    _supplierRepo = new SupplierRepository(_context);
                return _supplierRepo;
            }
        }
        public IProductRepository ProductRepo
        {
            get
            {
                if (_productRepo == null)
                    _productRepo = new ProductRepoistory(_context);
                return _productRepo;
            }
        }
        public IUnitRepository UnitRepo
        {
            get
            {
                if (_unitRepo == null)
                    _unitRepo = new UnitReposiotry(_context);
                return _unitRepo;
            }
        }
        public IPharmacyRepository PharmacyRepo
        {
            get
            {
                if (_pharmacyRepo == null)
                    _pharmacyRepo = new PharmacyRepository(_context);
                return _pharmacyRepo;
            }
        }
        public IProductQuantityRepository ProductQuantityRepo
        {

            get
            {
                if (_productQuantityRepo == null)
                    _productQuantityRepo = new ProductQuantityRepository(_context);
                return _productQuantityRepo;
            }

        }
        public ISupplierOrderRepository SupplierOrderRepo
        {
            get
            {
                if (_supplierOrderRepo == null)
                    _supplierOrderRepo = new SupplierOrdersRepository(_context);
                return _supplierOrderRepo;
            }
        }

        public ISupplierOrderDetailsRepository SupplierOrderDetailsRepo
        {
            get
            {
                if (_supplierOrderDetailsRepo == null)
                    _supplierOrderDetailsRepo = new SupplierOrderDetailsDeReposiotry(_context);
                return _supplierOrderDetailsRepo;
            }
        }

        public IAccountRepository AccountRepo
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository(_context, _applicationUserManager);
                return _accountRepository;
            }
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
