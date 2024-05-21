using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

namespace Supermarket.Views.AdminItemEditPages;

public partial class CategoryEditPage
{
    public CategoryEditPage()
    {
        InitializeComponent();
    }
    
    public CategoryEditPage(CategoryViewModel category)
    {
        InitializeComponent();
        
        DataContext = new CategoryEditPageViewModel(category);
    }
}