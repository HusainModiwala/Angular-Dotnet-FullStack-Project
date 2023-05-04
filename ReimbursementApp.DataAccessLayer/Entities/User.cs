using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReimbursementApp.DataAccessLayer.Entities
{
    public class User: IdentityUser
    {
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }
        [Key]
        [StringLength(10)]
        [Required]
        public string PAN { get; set; }
        [Required]
        public string Bank { get; set; }
        [Required]
        [Key]
        [MinLength(12)]
        [MaxLength(12)]
        public long BankAccNo { get; set; }
        public bool? isApprover { get; set; }
        List<Claim> claims { get; set; }
    }
}
