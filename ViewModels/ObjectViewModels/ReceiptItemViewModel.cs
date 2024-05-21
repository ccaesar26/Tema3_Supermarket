namespace Supermarket.ViewModels.ObjectViewModels;

public class ReceiptItemViewModel : BaseViewModel
{
    private int? _receiptId;
    public int ReceiptId
    {
        get => _receiptId ?? 0;
        set
        {
            _receiptId = value;
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
    
    public float Price => Subtotal / Quantity;
    
    private OfferViewModel? _offer;
    public OfferViewModel Offer
    {
        get => _offer ?? new OfferViewModel();
        set
        {
            _offer = value;
            OnPropertyChanged();
        }
    }

    private float? _subtotal;
    public float Subtotal
    {
        get => (float)Math.Round(_subtotal ?? 0);
        set
        {
            _subtotal = value;
            OnPropertyChanged();
        }
    }

    public float Discount => (float)Math.Round(Offer.DiscountPercentage * Subtotal / 100 * -1, 2);
}