using System;
using System.ComponentModel.DataAnnotations;

namespace ReserveitAPI.Model
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string StudentId { get; set; }

        
    }
}
