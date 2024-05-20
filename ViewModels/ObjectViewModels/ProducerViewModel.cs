namespace Supermarket.ViewModels.ObjectViewModels;

public class ProducerViewModel : BaseViewModel
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
    
    private string? _name;
    public string Name
    {
        get => _name ?? "";
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }
    
    private string? _originCountry;
    public string OriginCountry
    {
        get => _originCountry ?? "";
        set
        {
            _originCountry = value;
            OnPropertyChanged();
        }
    }
}