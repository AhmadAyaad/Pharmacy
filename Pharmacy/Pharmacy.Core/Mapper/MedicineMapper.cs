using System.Collections.Generic;
using ZPharmacy.Core.Dtos;
using ZPharmacy.Domain.Entities;

namespace ZPharmacy.Core.Mapper
{
    public class MedicineMapper
    {
        private readonly List<Product> _targetMedicines;

        public MedicineMapper()
        {
            _targetMedicines = new List<Product>();
        }
        public List<Product> MapToMedicines(List<MedicneFileUploadDto> sourceList)
        {
            foreach (var item in sourceList)
            {
                _targetMedicines.Add(
                new Product
                {
                    Name = item.MedicineName,
                    UnitId = item.UnitId
                }
                                    );
            }
            return _targetMedicines;
        }
    }
}
