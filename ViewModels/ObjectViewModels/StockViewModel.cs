using Supermarket.Services;

namespace Supermarket.ViewModels.ObjectViewModels;

public class StockViewModel : BaseViewModel
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
    
    private int? _quantity;
    public int Quantity
    {
        get => _quantity ?? 0;
        set
        {
            _quantity = value;
            OnPropertyChanged();
        }
    }
    
    private float? _purchasePrice;
    public float PurchasePrice
    {
        get => _purchasePrice ?? 0;
        set
        {
            _purchasePrice = value;
            OnPropertyChanged();
        }
    }
    
    public float? SellingPrice => (float)Math.Round(PurchasePrice * float.Parse(ConfigurationManager.GetSetting("ProfitPercentage") ?? "1.0"), 2);

    private string? _supplyDate;
    public string SupplyDate
    {
        get => _supplyDate ?? "";
        set
        {
            _supplyDate = value;
            OnPropertyChanged();
        }
    }
    
    private string? _expiryDate;
    public string ExpiryDate
    {
        get => _expiryDate ?? "";
        set
        {
            _expiryDate = value;
            OnPropertyChanged();
        }
    }
    
    private string? _unit;
    public string Unit
    {
        get => _unit ?? "";
        set
        {
            _unit = value;
            OnPropertyChanged();
        }
    }
}