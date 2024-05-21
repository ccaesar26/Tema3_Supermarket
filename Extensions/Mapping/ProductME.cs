using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.ViewModels.ObjectViewModels;

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
            Category = product.Category?.ToDTO(),
            Producer = product.Producer?.ToDTO(),
            Image = product.Image,
            Offer = product.Offer?.ToDTO()
        };
    }
    
    public static ProductDTO ToDTO(this ProductViewModel productViewModel)
    {
        return new ProductDTO
        {
            Id = productViewModel.Id,
            Name = productViewModel.Name,
            Barcode = productViewModel.Barcode,
            Category = productViewModel.Category.ToDTO(),
            Producer = productViewModel.Producer.ToDTO(),
            Image = productViewModel.Image == "No image found" ? null : productViewModel.Image
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
            Image = productDTO.Image 
                    ?? throw new ArgumentException("Invalid image"),
            Category = productDTO.Category?.ToEntity(),
            Producer = productDTO.Producer?.ToEntity(),
            Offer = productDTO.Offer?.ToEntity()
        };
    }
    
    public static ProductViewModel ToViewModel(this ProductDTO productDTO)
    {
        return new ProductViewModel
        {
            Id = productDTO.Id ?? 0,
            Name = productDTO.Name ?? "",
            Barcode = productDTO.Barcode ?? "",
            Category = productDTO.Category?.ToViewModel() ?? new CategoryViewModel(),
            Producer = productDTO.Producer?.ToViewModel() ?? new ProducerViewModel(),
            Image = productDTO.Image ?? ""
        };
    }
}