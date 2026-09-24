using Dapper;
using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;
using System.Data;

using FoodChow.Infrastructure.DALC;
namespace FoodChow.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly MySqlDalc _dalc;

        public InvoiceRepository(MySqlDalc dalc)
        {
            _dalc = dalc;
        }

        public async Task SubmitDocument(EInvoiceSubmitDocumentEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_insert_einvoicesubmitdocument",
                new
                {
                    shop_id = model.shop_id,
                    order_id = model.order_id,
                    submissionuid = model.submissionuid,
                    uuid = model.uuid,
                    invoicecodenumber = model.invoicecodenumber,
                    rejecteddocuments = model.rejecteddocuments
                },
                commandType: CommandType.StoredProcedure
            );
        }
        public async Task<dynamic> GetSubmitDocument(string shopId, string orderId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_get_einvoicesubmitdocument",
                new
                {
                    shop_id = shopId,
                    order_id = orderId
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> GetShopInvoiceMalaysia(long shopId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_Get_food_shop_einvoice_malaysia",
                new
                {
                    shop_id = shopId
                },
                commandType: CommandType.StoredProcedure);
        }

        public async Task AddSubmitStatus(EInvoiceSubmitStatusEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_insert_einvoicesubmitstatus",
                new
                {
                    shop_id = model.shop_id,
                    order_id = model.order_id,
                    submissionUid = model.submissionUid,
                    documentCount = model.documentCount,
                    dateTimeReceived = model.dateTimeReceived,
                    overallStatus = model.overallStatus,
                    documentSummary = model.documentSummary,
                    longId = model.longId,
                    uuid = model.uuid
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task UpdateSubmitStatus(EInvoiceSubmitStatusEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_update_einvoicesubmitstatus",
              new
              {
                  shop_id = model.shop_id,
                  order_id = model.order_id,
                  submissionUid = model.submissionUid,
                  documentCount = model.documentCount,
                  dateTimeReceived = model.dateTimeReceived,
                  overallStatus = model.overallStatus,
                  documentSummary = model.documentSummary,
                  longId = model.longId,
                  uuid = model.uuid
              },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<dynamic> GetSubmitStatus(string orderId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_Get_einvoicesubmitstatus",
                new
                {
                    order_id = orderId
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task AddInvoiceDetails(EInvoiceDetailsEntity model)
        {
            await _dalc.CreateConnection().ExecuteAsync(
                "USP_insert_einvoicedetails",
                new
                {
                    shop_id = model.shop_id,
                    order_id = model.order_id,
                    uuid = model.uuid,
                    submissionUid = model.submissionUid,
                    longId = model.longId,
                    typeName = model.typeName,
                    typeVersionName = model.typeVersionName,
                    issuerTin = model.issuerTin,
                    issuerName = model.issuerName,
                    receiverId = model.receiverId,
                    receiverName = model.receiverName,
                    dateTimeReceived = model.dateTimeReceived,
                    dateTimeValidated = model.dateTimeValidated,
                    totalExcludingTax = model.totalExcludingTax,
                    totalDiscount = model.totalDiscount,
                    totalNetAmount = model.totalNetAmount,
                    totalPayableAmount = model.totalPayableAmount,
                    status = model.status,
                    createdByUserId = model.createdByUserId,
                    documentStatusReason = model.documentStatusReason,
                    cancelDateTime = model.cancelDateTime,
                    rejectRequestDateTime = model.rejectRequestDateTime,
                    inVoiceId = model.inVoiceId,
                    dateTimeIssued = model.dateTimeIssued,
                    Cust_brn = model.Cust_brn,
                    Cust_mob_no = model.Cust_mob_no,
                    Cust_City = model.Cust_City,
                    Cust_Address = model.Cust_Address,
                    Cust_Email = model.Cust_Email
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<dynamic> GetInvoiceDetails(string shopId, string orderId)
        {
            return await _dalc.CreateConnection().QueryAsync(
                "USP_get_einvoicedetails",
                new
                {
                    shop_id = shopId,
                    order_id = orderId
                },
                commandType: CommandType.StoredProcedure
            );
        }
    }
}