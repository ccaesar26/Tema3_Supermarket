using System.Windows.Controls;
using Supermarket.Models.DataTransferLayer;
using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.ViewModels.PageViewModels.ObjectEditPageViewModels;

namespace Supermarket.Views.AdminItemEditPages;

public partial class ProductEditPage : Page
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