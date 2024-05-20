using System.Collections.ObjectModel;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer.Enums;

namespace Supermarket.Models.BusinessLogicLayer;

public static class ReportQueries
{
    public static ObservableCollection<ProductDTO> GetProductsByProducerName(ProducerDTO selectedProducer)
    {
        var products = ProductBLL.GetProducts();
        var producers = ProducerBLL.GetProducers();
        var query = from product in products
            join producer in producers
                on product.Producer.Id equals producer.Id
            where producer.Name == selectedProducer.Name
            select product;
        
        return new ObservableCollection<ProductDTO>(query);
    }

    public static ObservableCollection<Tuple<CategoryDTO, float>> GetValueOfCategories()
    {
        var categories = CategoryBLL.GetCategories();
        var products = ProductBLL.GetProducts();
        var stocks = StockBLL.GetStocks();
    
        var query = from category in categories
            join product in products
                on category.Id equals product.Category.Id
            join stock in stocks
                on product.Id equals stock.Product.Id
            group stock by category
            into g
            select Tuple.Create(g.Key, g.Sum(s => s.SellingPrice * s.Quantity ?? 0));
    
        return new ObservableCollection<Tuple<CategoryDTO, float>>(query);
    }
    
    public static ObservableCollection<Tuple<DateOnly, float>> GetIncomeForMonth(UserDTO selectedUser, EMonth month)
    {
        var users = UserBLL.GetUsers();
        var receipts = ReceiptBLL.GetReceipts();
    
        var query = from user in users
            join receipt in receipts on user.Id equals receipt.Cashier.Id
            where DateTime.Parse(receipt.IssueDate).Month == (int) month
            where user.Id == selectedUser.Id
            group receipt by DateTime.Parse(receipt.IssueDate).Date into g
            select Tuple.Create(DateOnly.FromDateTime(g.Key), g.Sum(r => r.AmountReceived ?? 0));

        return new ObservableCollection<Tuple<DateOnly, float>>(query);
    }

    public static ReceiptDTO GetMostValuableReceiptByDate(DateTime date)
    {
        var receipts = ReceiptBLL.GetReceipts();
        
        var targetDateOnly = date.Date;

        var query = receipts
            .Where(receipt => DateTime.Parse(receipt.IssueDate ?? string.Empty).Date == targetDateOnly)
            .MaxBy(receipt => receipt.AmountReceived);
        
        return query ?? new ReceiptDTO();
    }
}