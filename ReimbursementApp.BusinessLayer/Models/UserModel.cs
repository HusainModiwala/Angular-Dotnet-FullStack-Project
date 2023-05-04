using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReimbursementApp.BusinessLayer.Models
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$")]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }
        [Required]
        [StringLength(10)]
        [MinLength(10)]
        public string PAN { get; set; }
        [Required]
        public string Bank { get; set; }
        [Required]
        public long BankAccNo { get; set; }
        public string UserName { get; set; }
    }
}
