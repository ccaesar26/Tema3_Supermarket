using System.Collections.ObjectModel;

namespace Supermarket.ViewModels.ObjectViewModels;

public class ReceiptViewModel : BaseViewModel
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
    
    private readonly UserViewModel? _cashier;
    public UserViewModel Cashier
    {
        get => _cashier ?? new UserViewModel();
        init
        {
            _cashier = value;
            OnPropertyChanged();
        }
    }
    
    private string? _issueDate;
    public string IssueDate
    {
        get => _issueDate ?? "";
        set
        {
            _issueDate = value;
            OnPropertyChanged();
        }
    }
    
    private ObservableCollection<ReceiptItemViewModel>? _receiptItems;
    public ObservableCollection<ReceiptItemViewModel> ReceiptItems
    {
        get => _receiptItems ?? [];
        set
        {
            _receiptItems = value;
            OnPropertyChanged();
        }
    }
    
    private float? _amountReceived;
    public float AmountReceived
    {
        get => _amountReceived ?? 0;
        set
        {
            _amountReceived = value;
            OnPropertyChanged();
        }
    }
}