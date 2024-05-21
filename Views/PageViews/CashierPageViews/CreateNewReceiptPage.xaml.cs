using System.Windows.Controls;
using Supermarket.ViewModels.PageViewModels.CashierPageViewModels;
using Wpf.Ui.Controls;

namespace Supermarket.Views.PageViews.CashierPageViews;

public partial class CreateNewReceiptPage : Page
{
    public CreateNewReceiptPage()
    {
        InitializeComponent();
    }

    private void AutoSuggestBox_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
    {
        if (DataContext is CreateNewReceiptPageViewModel viewModel && args.SelectedItem is string selectedItem)
        {
            viewModel.SuggestionChosenCommand.Execute(selectedItem);
        }
    }
}