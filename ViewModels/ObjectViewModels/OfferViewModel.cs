namespace Supermarket.ViewModels.ObjectViewModels;

public class OfferViewModel : BaseViewModel
{
    private readonly int? _id;
    public int? Id
    {
        get => _id;
        init
        {
            _id = value;
            OnPropertyChanged();
        }
    }
    
    private ProductViewModel? _product;
    public ProductViewModel Product
    {
        get => _product ?? new ProductViewModel();
        set
        {
            _product = value;
            OnPropertyChanged();
        }
    }
    
    private int? _discountPercentage;
    public int DiscountPercentage
    {
        get => _discountPercentage ?? 0;
        set
        {
            _discountPercentage = value;
            OnPropertyChanged();
        }
    }
    
    private string? _startDate;
    public string StartDate
    {
        get => _startDate ?? "";
        set
        {
            _startDate = value;
            OnPropertyChanged();
        }
    }
    
    private string? _endDate;
    public string EndDate
    {
        get => _endDate ?? "";
        set
        {
            _endDate = value;
            OnPropertyChanged();
        }
    }
    
    private string? _reason;
    public string Reason
    {
        get => _reason ?? "";
        set
        {
            _reason = value;
            OnPropertyChanged();
        }
    }
}