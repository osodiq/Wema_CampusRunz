using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wema.CampusRunz.Core.Models;

namespace Wema.CampusRunz.Core.Interfaces
{
    public interface IServiceManager
    {
        Task<bool> CreateService(Service service);
    }
}
