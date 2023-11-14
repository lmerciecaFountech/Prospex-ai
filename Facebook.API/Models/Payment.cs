using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class Payment
    {
        public string Id { get; set; }
        public User User { get; set; }
        public string RequestId { get; set; }
        public Application App { get; set; }
        public PaymentAction[] Actions { get; set; }
        public PaymentItem[] Items { get; set; }
        public string Country { get; set; }
        public TaxType Tax { get; set; }
        public string TaxCountry { get; set; }
        public string CreatedTime { get; set; }
        public double PayoutForeignExchangeRate { get; set; }
        public Dispute[] Disputes { get; set; }
        public bool Test { get; set; }
    }

    internal class PaymentAction
    {
        public PaymentActionType Type { get; set; }
        public PaymentActionStatus Status { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
        public string TaxAmount { get; set; }
    }

    internal class PaymentItem
    {
        public PaymentItemType Type { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }

    public enum PaymentActionType
    {
        CHARGE,
        REFUND,
        CHARGEBACK,
        CHARGEBACK_REVERSAL,
        DECLINE
    }

    public enum PaymentActionStatus
    {
        Initiated,
        Completed,
        Failed
    }

    public enum PaymentItemType
    {
        IN_APP_PURCHASE,
        SUBSCRIPTION
    }

    public enum TaxType
    {
        NOT_TAXED,
        ALREADY_PAID,
        TAX_REMITTED
    }

    internal class Dispute
    {
        public string UserComment { get; set; }
        public string UserEmail { get; set; }
        public DateTime TimeCreated { get; set; }
        public DisputeStatus Status { get; set; }
        public DisputeReason Reason { get; set; }
    }

    public enum DisputeStatus
    {
        RESOLVED,
        PENDING
    }

    public enum DisputeReason
    {
        PENDING,
        REFUNDED_IN_CASH,
        GRANTED_REPLACEMENT_ITEM,
        DENIED_REFUND,
        BANNED_USER,
        REFUNDED_BY_FACEBOOK
    }
}