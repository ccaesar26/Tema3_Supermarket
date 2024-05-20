using System.Collections.ObjectModel;
using System.Windows.Input;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.ViewModels.Commands;
using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.Views.AdminItemEditPages;
using Supermarket.Views.AdminItemPageViews;

namespace Supermarket.ViewModels.PageViewModels.ObjectPageViewModels;

public class StockPageViewModel
{
    public ObservableCollection<StockViewModel> Stocks { get; set; } =
        new(StockBLL.GetStocks().Select(s => s.ToViewModel()));
    
    public ICommand AddNewCommand { get; }
    
    public StockPageViewModel()
    {
        AddNewCommand = new RelayCommand<object>(o =>
        {
            if (o is not StockPage currentPage)
            {
                return;
            }
            
            var stockEditPage = new StockEditPage();
            
            currentPage.NavigationService?.Navigate(stockEditPage);
        });
    }
}