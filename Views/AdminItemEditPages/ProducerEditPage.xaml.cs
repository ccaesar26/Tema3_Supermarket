using System.Windows.Controls;
using Supermarket.Models.DataTransferLayer;
using Supermarket.ViewModels.AdminItemEditViewModels;

namespace Supermarket.Views.AdminItemEditPages;

public partial class ProducerEditPage : Page
{
    public ProducerEditPage()
    {
        InitializeComponent();
    }
    
    public ProducerEditPage(ProducerDTO producer)
    {
        InitializeComponent();
        DataContext = new ProducerEditViewModel(producer);
    }
}