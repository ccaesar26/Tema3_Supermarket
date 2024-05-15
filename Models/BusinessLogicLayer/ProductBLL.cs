using System.Collections.ObjectModel;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;

namespace Supermarket.Models.BusinessLogicLayer;

public static class ProductBLL
{
    public static ObservableCollection<ProductDTO> GetProducts()
    {
        var products = new ObservableCollection<ProductDTO>();
        foreach (var product in ProductDAL.GetProducts())
        {
            products.Add(product.ToDTO());
        }
        return products;
    }
    
    public static bool AddProduct(ProductDTO productDTO)
    {
        ArgumentNullException.ThrowIfNull(productDTO);
        ArgumentNullException.ThrowIfNull(productDTO.Name);
        ArgumentNullException.ThrowIfNull(productDTO.Barcode);
        ArgumentNullException.ThrowIfNull(productDTO.Category);
        ArgumentNullException.ThrowIfNull(productDTO.Producer);
        
        ProductDAL.InsertProduct(productDTO.ToEntity());
        return true;
    }
    
    public static bool EditProduct(ProductDTO productDTO)
    {
        ArgumentNullException.ThrowIfNull(productDTO);
        ArgumentNullException.ThrowIfNull(productDTO.Id);
        ArgumentNullException.ThrowIfNull(productDTO.Name);
        ArgumentNullException.ThrowIfNull(productDTO.Barcode);
        ArgumentNullException.ThrowIfNull(productDTO.Category);
        ArgumentNullException.ThrowIfNull(productDTO.Producer);
        
        ProductDAL.UpdateProduct(productDTO.ToEntity());
        return true;
    }
    
    public static bool DeleteProduct(ProductDTO productDTO)
    {
        ArgumentNullException.ThrowIfNull(productDTO);
        ArgumentNullException.ThrowIfNull(productDTO.Id);
        
        ProductDAL.DeleteProduct(productDTO.ToEntity());
        return true;
    }
}