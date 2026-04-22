using musicReporting.Models.Entities;

namespace musicReporting.Models.Interfaces
{
    public interface ISaleLineItemRepository
    {
        IEnumerable<SaleLineItem> GetAll();
        SaleLineItem? Get(int id);
        SaleLineItem Add(SaleLineItem saleLineItem);
    }
}