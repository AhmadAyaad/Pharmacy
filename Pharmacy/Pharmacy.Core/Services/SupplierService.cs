using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Core.IServices;
using ZPharmacy.Domain;
using ZPharmacy.Domain.Entities;
using ZPharmacy.Infrastructure.UnitOfWork;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Core.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SupplierService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> AddNewSupplierAsync(SupplierDTO supplierDTO)
        {
            var supplier = _mapper.Map<Supplier>(supplierDTO);
            if (await _unitOfWork.SupplierRepo.IsSupplierNameExistsAsync(supplier))
                return new Response(ResponseStatus.Failed, $"إسم المورد {supplier.Name} موجود بالفعل");
            if (await _unitOfWork.SupplierRepo.IsSupplierPhoneExistsAsync(supplier))
                return new Response(ResponseStatus.Failed, $"هاتف المورد {supplier.Phone} موجود بالفعل");
            await _unitOfWork.SupplierRepo.AddAsync(supplier);
            await _unitOfWork.SaveChangesAsync();
            return new Response();
        }

        public async Task<Response> DeleteSupplierAsync(int supplierId)
        {
            var existingSupplier = await _unitOfWork.SupplierRepo.GetByIdAsync(supplierId);
            if (existingSupplier is null)
                return new Response(ResponseStatus.NotFound, "لا يوجد مورد بهذا الرقم التسلسى");
            _unitOfWork.SupplierRepo.Remove(existingSupplier);
            await _unitOfWork.SaveChangesAsync();
            return new Response();
        }

        public async Task<PagedResultDTO<SupplierDTO>> GetPagedSuppliersAsync(int pageIndex, int pageSize)
        {
            var pagedSupplierResult = await _unitOfWork.SupplierRepo.GetPagedSuppliersAsync(pageIndex, pageSize);
            if (pagedSupplierResult is null)
                return new PagedResultDTO<SupplierDTO> { Items = null, RowCount = pagedSupplierResult.RowCount };
            return new PagedResultDTO<SupplierDTO> { Items = _mapper.Map<List<SupplierDTO>>(pagedSupplierResult.Items), RowCount = pagedSupplierResult.RowCount };
        }

        public async Task<Response<SupplierDTO>> GetSupplierAsync(int supplierId)
        {
            var supplier = await _unitOfWork.SupplierRepo.GetByIdAsync(supplierId);
            if (supplier is null)
                return new Response<SupplierDTO>(null, ResponseStatus.NotFound, "لايوجد موردين بهذا الرقم التسلسى");
            return new Response<SupplierDTO>(_mapper.Map<SupplierDTO>(supplier));
        }

        public async Task<Response<List<SupplierDTO>>> GetSuppliersAsync()
        {
            var suppliers = await _unitOfWork.SupplierRepo.GetAllAsync();
            if (suppliers is null)
                return new Response<List<SupplierDTO>>(null, ResponseStatus.NotFound, "لايوجد موردين");
            var suppliersDTOS = _mapper.Map<List<SupplierDTO>>(suppliers);
            return new Response<List<SupplierDTO>>(suppliersDTOS);
        }

        public Task<Response> UpdateSupplierAsync(SupplierDTO supplierDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
