using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class BusinessCardRepository(DataContext _context) : IBusinessCardRepository
    {
       

        public async Task<IEnumerable<BusinessCard>> GetAllAsync()
        {
            return await _context.BusinessCards.ToListAsync();
        }

        public async Task<BusinessCard> GetByIdAsync(int id)
        {
            return await _context.BusinessCards.FindAsync(id);
        }

        public async Task AddAsync(BusinessCard businessCard)
        {
            await _context.BusinessCards.AddAsync(businessCard);
        }

        public async Task DeleteAsync(int id)
        {
            var businessCard = await GetByIdAsync(id);
            if (businessCard != null)
            {
                _context.BusinessCards.Remove(businessCard);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}