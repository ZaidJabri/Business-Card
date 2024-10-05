using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Services
{
    public interface IBusinessCardRepository
    {
        Task<IEnumerable<BusinessCard>> GetAllAsync();
        Task<BusinessCard> GetByIdAsync(int id);
        Task AddAsync(BusinessCard businessCard);
        Task DeleteAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}