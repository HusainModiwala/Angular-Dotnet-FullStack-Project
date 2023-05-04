using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReimbursementApp.DataAccessLayer.Entities
{
    public class Claim
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string ReimbursementType { get; set; }
        [Required]
        public double RequestedValue { get; set; }
        public double ApprovedValue { get; set; } = 0;
        [Required]
        public string Currency { get; set; }
        public string RequestPhase { get; set; } = "To be processed";
        [Required]
        public bool ReceiptAttached { get; set; } = false;
        public string Email { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string? InternalNotes { get; set; }
        public string ApprovedBy { get; set; }
        public string ReceiptUrl { get; set; }
    }
}
