using FoodChow.Domain.Entities;

namespace FoodChow.Application.Interfaces
{
    public interface IInvoiceRepository
    {
        Task SubmitDocument(EInvoiceSubmitDocumentEntity model);

        Task<dynamic> GetSubmitDocument(string shopId, string orderId);

        Task<dynamic> GetShopInvoiceMalaysia(long shopId);

        Task AddSubmitStatus(EInvoiceSubmitStatusEntity model);

        Task UpdateSubmitStatus(EInvoiceSubmitStatusEntity model);

        Task<dynamic> GetSubmitStatus(string orderId);

        Task AddInvoiceDetails(EInvoiceDetailsEntity model);

        Task<dynamic> GetInvoiceDetails(string shopId, string orderId);
    }
}