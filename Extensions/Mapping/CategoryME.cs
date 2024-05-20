using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.ViewModels.ObjectViewModels;

namespace Supermarket.Extensions.Mapping;

public static class CategoryME
{
    public static CategoryDTO ToDTO(this Category category)
    {
        return new CategoryDTO
        {
            Id = category.CategoryId,
            Name = category.Name,
            Image = category.Image
        };
    }
    
    public static CategoryDTO ToDTO(this CategoryViewModel categoryViewModel)
    {
        return new CategoryDTO
        {
            Id = categoryViewModel.Id,
            Name = categoryViewModel.Name,
            Image = categoryViewModel.Image == "No image found" ? null : categoryViewModel.Image
        };
    }
    
    public static Category ToEntity(this CategoryDTO categoryDTO)
    {
        return new Category
        {
            CategoryId = categoryDTO.Id,
            Name = categoryDTO.Name,
            Image = categoryDTO.Image
        };
    }
    
    public static CategoryViewModel ToViewModel(this CategoryDTO categoryDTO)
    {
        return new CategoryViewModel
        {
            Id = categoryDTO.Id ?? 0,
            Name = categoryDTO.Name ?? "",
            Image = categoryDTO.Image ?? ""
        };
    }
}