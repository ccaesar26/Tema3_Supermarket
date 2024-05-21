using System.Windows.Input;
using Supermarket.ViewModels.Commands;
using Wpf.Ui.Controls;

namespace Supermarket.ViewModels.PageViewModels.CashierPageViewModels;

public class CashierHomePageViewModel
{
    public static NavigationView? NavigationView { get; set; }
    
    public ICommand AddNewCommand { get; } = new RelayCommand<object?>(_ =>
    {
        NavigationView?.Navigate("CreateNewReceipt");
    });
}