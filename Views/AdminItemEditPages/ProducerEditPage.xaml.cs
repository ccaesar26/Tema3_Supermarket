using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

namespace Supermarket.Views.AdminItemEditPages;

public partial class ProducerEditPage
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