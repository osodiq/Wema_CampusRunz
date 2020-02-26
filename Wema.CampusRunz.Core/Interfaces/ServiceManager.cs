using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wema.CampusRunz.Core.Models;

namespace Wema.CampusRunz.Core.Interfaces
{
    public class ServiceManager : IServiceManager
    {
        private readonly ApplicationDbContext _context;

        public ServiceManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateService(Service service)
        {
            try
            {
                await _context.Services.AddAsync(service);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
