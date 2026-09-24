using FoodChow.Application.Interfaces;
using FoodChow.Domain.Entities;

namespace FoodChow.Application.Services
{
    public class InvoiceService
    {
        private readonly IInvoiceRepository _repo;

        public InvoiceService(IInvoiceRepository repo)
        {
            _repo = repo;
        }

        public async Task SubmitDocument(EInvoiceSubmitDocumentEntity model)
            => await _repo.SubmitDocument(model);

        public async Task<dynamic> GetSubmitDocument(string shopId, string orderId)
            => await _repo.GetSubmitDocument(shopId, orderId);

        public async Task<dynamic> GetShopInvoiceMalaysia(long shopId)
            => await _repo.GetShopInvoiceMalaysia(shopId);

        public async Task AddSubmitStatus(EInvoiceSubmitStatusEntity model)
            => await _repo.AddSubmitStatus(model);

        public async Task UpdateSubmitStatus(EInvoiceSubmitStatusEntity model)
            => await _repo.UpdateSubmitStatus(model);

        public async Task<dynamic> GetSubmitStatus(string orderId)
            => await _repo.GetSubmitStatus(orderId);

        public async Task AddInvoiceDetails(EInvoiceDetailsEntity model)
            => await _repo.AddInvoiceDetails(model);

        public async Task<dynamic> GetInvoiceDetails(string shopId, string orderId)
     => await _repo.GetInvoiceDetails(shopId, orderId);
    }
}