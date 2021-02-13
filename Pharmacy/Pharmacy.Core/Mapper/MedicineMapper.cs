using Pharmacy.Core.Dtos;
using Pharmacy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Core.Mapper
{
    public class MedicineMapper
    {
        private readonly List<Medicine> _targetMedicines;

        public MedicineMapper()
        {
            _targetMedicines = new List<Medicine>();
        }
        public List<Medicine> MapToMedicines(List<MedicneFileUploadDto> sourceList)
        {
            foreach (var item in sourceList)
            {
                _targetMedicines.Add(
                new Medicine
                {
                    MedicineName = item.MedicineName,
                    UnitId = item.UnitId
                }
                                    );
            }
            return _targetMedicines;
        }
    }
}
