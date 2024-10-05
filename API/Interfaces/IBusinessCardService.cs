using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Interfaces
{
    public interface IBusinessCardService
    {
        Task<IEnumerable<BusinessCardDto>> GetAllBusinessCards();
        Task<BusinessCardDto> CreateBusinessCard(BusinessCardDto businessCardDto);
        Task<bool> DeleteBusinessCard(int id);
    }
}