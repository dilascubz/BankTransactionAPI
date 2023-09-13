using System;
using System.Collections.Generic;

namespace EvaluationTest.Models
{
    public partial class BankTransaction
    {
        public int TransactionId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public decimal TransferAmount { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
    }
}
