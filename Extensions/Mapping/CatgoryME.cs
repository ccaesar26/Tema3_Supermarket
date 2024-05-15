using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;

namespace Supermarket.Extensions.Mapping;

public static class CatgoryME
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
    
    public static Category ToEntity(this CategoryDTO categoryDTO)
    {
        return new Category
        {
            CategoryId = categoryDTO.Id,
            Name = categoryDTO.Name,
            Image = categoryDTO.Image
        };
    }
}