using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Core.IServices;
using ZPharmacy.Infrastructure.UnitOfWork;
using ZPharmacy.Shared.Models;

namespace ZPharmacy.Core.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public async Task<int> GetUnitIdByName(object name)
        //{
        //    return await _unitOfWork.UnitRepo.GetUnitIdByNameAsync(name);
        //}

        //public async Task<Unit> GetUnit(int id)
        //{
        //    try
        //    {
        //        var unit = await _unitOfWork.UnitRepo.GetByIdAsync(id);
        //        if (unit != null)
        //            return unit;
        //    }
        //    catch (Exception e)
        //    {
        //        Trace.WriteLine(e.Message);
        //    }

        //    return new Unit();
        //}

        public async Task<Response<List<UnitDTO>>> GetUnits()
        {
            var units = await _unitOfWork.UnitRepo.GetAllAsync();
            if (units is null)
                return new Response<List<UnitDTO>>(null, ResponseStatus.NotFound, "There is no units");
            var unitsDTOS = _mapper.Map<List<UnitDTO>>(units);
            return new Response<List<UnitDTO>>(unitsDTOS);
        }
    }
}
