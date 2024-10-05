using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;

namespace API.Services
{
    public class BusinessCardService(IBusinessCardRepository _repository) : IBusinessCardService
    {
        public async Task<IEnumerable<BusinessCardDto>> GetAllBusinessCards()
        {
            var cards = await _repository.GetAllAsync();
            return cards.Select(card => new BusinessCardDto
            {
                Name = card.Name,
                Gender = card.Gender,
                DateOfBirth = card.DateOfBirth,
                Email = card.Email,
                Phone = card.Phone,
                Address = card.Address,
                PhotoBase64 = card.PhotoBase64
            }).ToList();
        }

        public async Task<BusinessCardDto> CreateBusinessCard(BusinessCardDto businessCardDto)
        {
            var businessCard = new BusinessCard
            {
                Name = businessCardDto.Name,
                Gender = businessCardDto.Gender,
                DateOfBirth = businessCardDto.DateOfBirth,
                Email = businessCardDto.Email,
                Phone = businessCardDto.Phone,
                Address = businessCardDto.Address,
                PhotoBase64 = businessCardDto.PhotoBase64
            };

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