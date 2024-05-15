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
            Category = CategoryBLL.GetCategories()
                .First(category => category.Id == product.CategoryId),
            Producer = ProducerBLL.GetProducers()
                .First(producer => producer.Id == product.ProducerId),
            Image = product.Image
        };
    }
    
    public static Product ToEntity(this ProductDTO productDTO)
    {
        return new Product
        {
            ProductId = productDTO.Id,
            Name = productDTO.Name ?? "",
            Barcode = productDTO.Barcode ?? "",
            CategoryId = productDTO.Category?.Id 
                         ?? throw new ArgumentException("Invalid category"),
            ProducerId = productDTO.Producer?.Id 
                         ?? throw new ArgumentException("Invalid producer"),
            Image = productDTO.Image ?? ""
        };
    }
}