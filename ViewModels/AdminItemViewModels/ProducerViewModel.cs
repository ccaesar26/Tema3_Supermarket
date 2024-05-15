using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.ViewModels.Commands;
using Supermarket.Views.AdminItemEditPages;
using Supermarket.Views.AdminItemPageViews;
using Wpf.Ui;
using MessageBox = Wpf.Ui.Controls.MessageBox;
using MessageBoxButton = Wpf.Ui.Controls.MessageBoxButton;
using MessageBoxResult = Wpf.Ui.Controls.MessageBoxResult;

namespace Supermarket.ViewModels.AdminItemViewModels;

public class ProducerViewModel : BaseViewModel
{
    public ObservableCollection<ProducerDTO> Producers { get; set; } = ProducerBLL.GetProducers();
    public ICommand AddNewCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand RemoveCommand { get; }
    
    public ProducerViewModel()
    {
        AddNewCommand = new RelayCommand<object>(AddNew);
        EditCommand = new RelayCommand<object>(Edit);
        RemoveCommand = new RelayCommand<object>(Remove);
    }
    
    private void AddNew(object? obj)
    {
        if (obj is not ProducerPage currentPage)
        {
            return;
        }
        
        var producerEditPage = new ProducerEditPage();
        
        currentPage.NavigationService?.Navigate(producerEditPage);
    }

    private void Edit(object? obj)
    {
        if (obj is not object[] values) return;

        if (values[0] is not ProducerDTO producer || values[1] is not ProducerPage currentPage)
        {
            return;
        }
        
        var producerEditPage = new ProducerEditPage(producer);
        
        currentPage.NavigationService?.Navigate(producerEditPage);
    }

    private void Remove(object? obj)
    {
        var producer = obj as ProducerDTO;
        
        if (producer == null)
        {
            return;
        }

        var dialog = new MessageBox
        {
            Title = "Confirmation",
            Content = "Are you sure you want to delete this producer?",
            PrimaryButtonText = "Yes",
            CloseButtonText = "No"
        };
        
        var result = dialog.ShowDialogAsync().Result;

        if (result != MessageBoxResult.Primary) return;
        
        if (ProducerBLL.DeleteProducer(producer))
        {
            Producers.Remove(producer);
        }
    }
}