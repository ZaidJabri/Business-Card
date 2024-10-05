using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class BusinessCard
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]

        public required string Gender { get; set; }
        [Required]

        public required DateTime DateOfBirth { get; set; }
        [Required]

        public required string Email { get; set; }
        [Required]

        public required string Phone { get; set; }
        [Required]

        public required string Address { get; set; }

        public string? PhotoBase64 { get; set; }
    }
}