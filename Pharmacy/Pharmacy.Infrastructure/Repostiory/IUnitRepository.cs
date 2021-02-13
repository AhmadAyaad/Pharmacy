using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.Repostiory
{
    public interface IUnitRepository
    {
        Task<int> GetUnitIdByName(object name);
    }
}
