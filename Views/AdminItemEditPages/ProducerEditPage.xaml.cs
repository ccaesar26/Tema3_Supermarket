using System.Windows.Controls;
using Supermarket.Models.DataTransferLayer;
using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

namespace Supermarket.Views.AdminItemEditPages;

public partial class ProducerEditPage : Page
{
    public ProducerEditPage()
    {
        InitializeComponent();
    }
    
    public ProducerEditPage(ProducerViewModel producer)
    {
        InitializeComponent();
        DataContext = new ProducerEditPageViewModel(producer);
    }
}