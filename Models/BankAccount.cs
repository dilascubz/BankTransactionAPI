using System;
using System.Collections.Generic;

namespace EvaluationTest.Models
{
    public partial class BankAccount
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string AccId { get; set; } = null!;
        public decimal BankAmount { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }
}
