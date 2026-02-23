using Microsoft.EntityFrameworkCore;
using SiteManagementApp.DataAccess.Abstract;
using SiteManagementApp.Entities.Concrete;
using SiteManagementApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteManagementApp.DataAccess.Concrete
{
    public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(SiteManagementDbContext context) : base(context)
        {
        }

        public async Task<List<Apartment>> GetAvailableAsync()
        {
            return await _context.Apartments
                .Where(a => a.Status == ApartmentStatus.Empty)
                .ToListAsync();
        }

        public Task<List<Apartment>> GetByBlockAsync(string blockName)
        {
            return _context.Apartments
                .Include(a => a.Block)
                .Where(a => a.Block.Name == blockName)
                .ToListAsync();
        }
    }
}
