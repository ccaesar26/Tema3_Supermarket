using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

namespace Supermarket.Views.AdminItemEditPages;

public partial class ProductEditPage
{
    public ProductEditPage()
    {
        InitializeComponent();
    }
    
    public ProductEditPage(ProductViewModel product)
    {
        InitializeComponent();
        DataContext = new ProductEditPageViewModel(product);
    }
}