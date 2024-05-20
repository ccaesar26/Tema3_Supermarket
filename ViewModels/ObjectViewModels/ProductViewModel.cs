namespace Supermarket.ViewModels.ObjectViewModels;

public class ProductViewModel : BaseViewModel
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
    
    private string? _barcode;
    public string Barcode
    {
        get => _barcode ?? "";
        set
        {
            _barcode = value;
            OnPropertyChanged();
        }
    }
    
    private CategoryViewModel? _category;
    public CategoryViewModel? Category
    {
        get => _category;
        set
        {
            _category = value;
            OnPropertyChanged();
        }
    }
    
    private ProducerViewModel? _producer;
    public ProducerViewModel? Producer
    {
        get => _producer;
        set
        {
            _producer = value;
            OnPropertyChanged();
        }
    }
    
    private string? _image;
    public string Image
    {
        get => _image ?? "No image found";
        set
        {
            _image = value;
            OnPropertyChanged();
        }
    }
}