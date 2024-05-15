using System.Collections.ObjectModel;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.DataTransferLayer;

namespace Supermarket.Models.BusinessLogicLayer;

public static class CategoryBLL
{
    public static ObservableCollection<CategoryDTO> GetCategories()
    {
        var categories = new ObservableCollection<CategoryDTO>();
        foreach (var category in CategoryDAL.GetCategories())
        {
            categories.Add(category.ToDTO());
        }
        return categories;
    }
    
    public static bool AddCategory(CategoryDTO categoryDTO)
    {
        ArgumentNullException.ThrowIfNull(categoryDTO);
        ArgumentNullException.ThrowIfNull(categoryDTO.Name);

        CategoryDAL.InsertCategory(categoryDTO.ToEntity());
        return true;
    }
    
    public static bool EditCategory(CategoryDTO categoryDTO)
    {
        ArgumentNullException.ThrowIfNull(categoryDTO);
        ArgumentNullException.ThrowIfNull(categoryDTO.Id);
        ArgumentNullException.ThrowIfNull(categoryDTO.Name);

        CategoryDAL.UpdateCategory(categoryDTO.ToEntity());
        return true;
    }
    
    public static bool DeleteCategory(CategoryDTO categoryDTO)
    {
        ArgumentNullException.ThrowIfNull(categoryDTO);
        ArgumentNullException.ThrowIfNull(categoryDTO.Id);

        CategoryDAL.DeleteCategory(categoryDTO.ToEntity());
        return true;
    }
}