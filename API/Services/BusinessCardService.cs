using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class BusinessCardService(IBusinessCardRepository _repository, IMapper _mapper) : IBusinessCardService
    {
        public async Task<IEnumerable<BusinessCardDto>> GetAllBusinessCards()
        {
            var cards = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<BusinessCardDto>>(cards);
        }

        public async Task<BusinessCardDto> CreateBusinessCard(BusinessCardDto businessCardDto)
        {
            var businessCard = _mapper.Map<BusinessCard>(businessCardDto);

            await _repository.AddAsync(businessCard);
            await _repository.SaveChangesAsync();

            return businessCardDto;
        }

        public async Task<bool> DeleteBusinessCard(int id)
        {
            await _repository.DeleteAsync(id);
            return await _repository.SaveChangesAsync();
        }

    }
}