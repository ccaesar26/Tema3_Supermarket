using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;

namespace Supermarket.Extensions.Mapping;

public static class ProductME
{
    public static ProductDTO ToDTO(this Product product)
    {
        return new ProductDTO
        {
            Id = product.ProductId,
            Name = product.Name,
            Barcode = product.Barcode,
            CategoryName = CategoryBLL.GetCategories()
                .First(category => category.Id == product.CategoryId).Name 
                         ?? throw new ArgumentException("Invalid category id"),
        };
    }
    
    public static Product ToEntity(this ProductDTO productDTO)
    {
        return new Product
        {
            ProductId = productDTO.Id,
            Name = productDTO.Name ?? "",
            Barcode = productDTO.Barcode ?? "",
            CategoryId = CategoryBLL.GetCategories()
                .First(category => category.Name == productDTO.CategoryName).Id 
                         ?? throw new ArgumentException("Invalid category name"),
            ProducerId = ProducerBLL.GetProducers()
                .First(producer => producer.Name == productDTO.ProducerName).Id 
                         ?? throw new ArgumentException("Invalid producer name"),
            Image = productDTO.Image ?? ""
        };
    }
}