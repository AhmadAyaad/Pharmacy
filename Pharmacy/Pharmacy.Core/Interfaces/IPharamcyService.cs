using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Core.Interfaces
{
    public interface IPharamcyService
    {
        IEnumerable<Pharmacy.Domain.Entities.Pharmacy> GetParentPharamices();
    }
}
