namespace FoodChow.Domain.Entities
{
    public class EInvoiceSubmitDocumentEntity
    {
        public long id { get; set; }

        public int? shop_id { get; set; }

        public string? order_id { get; set; }

        public string? submissionuid { get; set; }

        public string? uuid { get; set; }

        public string? invoicecodenumber { get; set; }

        public string? rejecteddocuments { get; set; }

        public DateTime created_date { get; set; }
    }

   
    public class EInvoiceSubmitStatusEntity
    {
        public long id { get; set; }

        public int? shop_id { get; set; }

        public string? order_id { get; set; }

        public string? submissionUid { get; set; }

        public string? documentCount { get; set; }

        public string? dateTimeReceived { get; set; }

        public string? overallStatus { get; set; }

        public string? documentSummary { get; set; }

        public string? longId { get; set; }

        public string? uuid { get; set; }

        public DateTime created_date { get; set; }
    }

    public class EInvoiceDetailsEntity
    {
        public long id { get; set; }

        public string? shop_id { get; set; }

        public string? order_id { get; set; }

        public string? uuid { get; set; }

        public string? submissionUid { get; set; }

        public string? longId { get; set; }

        public string? typeName { get; set; }

        public string? typeVersionName { get; set; }

        public string? issuerTin { get; set; }

        public string? issuerName { get; set; }

        public string? receiverId { get; set; }

        public string? receiverName { get; set; }

        public string? dateTimeReceived { get; set; }

        public string? dateTimeValidated { get; set; }

        public string? totalExcludingTax { get; set; }

        public string? totalDiscount { get; set; }

        public string? totalNetAmount { get; set; }

        public string? totalPayableAmount { get; set; }

        public string? status { get; set; }

        public string? createdByUserId { get; set; }

        public string? documentStatusReason { get; set; }

        public string? cancelDateTime { get; set; }

        public string? rejectRequestDateTime { get; set; }

        public string? inVoiceId { get; set; }

        public string? dateTimeIssued { get; set; }

        public string? Cust_brn { get; set; }

        public string? Cust_mob_no { get; set; }

        public string? Cust_City { get; set; }

        public string? Cust_Address { get; set; }

        public string? Cust_Email { get; set; }
    }
    



}