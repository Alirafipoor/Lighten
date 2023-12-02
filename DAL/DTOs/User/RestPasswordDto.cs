using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs.User
{
    public class RestPasswordDto
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
