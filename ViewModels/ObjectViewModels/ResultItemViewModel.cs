﻿namespace Supermarket.ViewModels.ObjectViewModels;

public class ResultItemViewModel : BaseViewModel
{
    private StockViewModel? _stock;
    public StockViewModel Stock
    {
        get => _stock ?? new StockViewModel();
        set
        {
            _stock = value;
            OnPropertyChanged();
        }
    }
    
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
    
    private int? _quantity;
    public int Quantity
    {
        get => _quantity ?? 1;
        set
        {
            _quantity = value;
            TotalPrice = (float)Math
                .Round(Quantity * Stock.SellingPrice * (1 - Offer.DiscountPercentage / 100f) ?? 0, 2);
            OnPropertyChanged();
        }
    }
    
    private float? _totalPrice;
    public float TotalPrice
    {
        get => _totalPrice ?? (float)Math
            .Round(Quantity * Stock.SellingPrice * (1 - Offer.DiscountPercentage / 100f) ?? 0, 2);
        private set
        {
            _totalPrice = value;
            OnPropertyChanged();
        }
    }

    public static Func<ResultItemViewModel, string>? ToStringFunc { get; set; }

    public override string ToString()
    {
        return ToStringFunc?.Invoke(this) ?? Stock.Product.Name;
    }
}