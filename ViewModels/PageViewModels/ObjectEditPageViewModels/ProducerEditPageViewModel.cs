using System.Windows.Input;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.ViewModels.Commands;
using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.Views.AdminItemEditPages;
using Supermarket.Views.AdminItemPageViews;

namespace Supermarket.ViewModels.PageViewModels.ObjectEditPageViewModels;

public class ProducerEditPageViewModel : BaseViewModel
{
    public ProducerViewModel Producer { get; set; }

    private readonly string? _title;
    public string Title
    {
        get => _title ?? "";
        private init
        {
            _title = value;
            OnPropertyChanged();
        }
    }

    public ICommand? SaveCommand { get; private set; }
    public ICommand? CancelCommand { get; private set; }

    private string? _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage ?? "";
        private set
        {
            _errorMessage = value;
            OnPropertyChanged();
        }
    }

    private bool _nameHasError = false;
    public bool NameHasError
    {
        get => _nameHasError;
        private set
        {
            _nameHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _originCountryHasError = false;
    public bool OriginCountryHasError
    {
        get => _originCountryHasError;
        private set
        {
            _originCountryHasError = value;
            OnPropertyChanged();
        }
    }
    
    private string? _initialName;
    public ProducerEditPageViewModel()
    {
        Producer = new ProducerViewModel();
        Title = "Add Producer";
        InitializeCommands();
    }
    
    public ProducerEditPageViewModel(ProducerViewModel producer)
    {
        Producer = producer;
        Title = "Edit Producer";
        _initialName = producer.Name;
        InitializeCommands();
    }

    private void InitializeCommands()
    {
        CancelCommand = new RelayCommand<object>((obj) =>
        {
            var page = obj as ProducerEditPage;
            page?.NavigationService?.Navigate(new ProducerPage());
        });

        SaveCommand = new RelayCommand<object>((obj) =>
        {
            ErrorMessage = "";
            NameHasError = false;
            OriginCountryHasError = false;
            
            if (string.IsNullOrWhiteSpace(Producer.Name))
            {
                ErrorMessage = "Name is required!";
                NameHasError = true;
                return;
            }
            
            if (ProducerBLL.GetProducers().Any(p => p.Name == Producer.Name))
            {
                if (Producer.Name != _initialName)
                {
                    ErrorMessage = "Name must be unique!";
                    NameHasError = true;
                    return;
                }
            }
            
            if (string.IsNullOrWhiteSpace(Producer.OriginCountry))
            {
                ErrorMessage = "Origin Country is required!";
                OriginCountryHasError = true;
                return;
            }
            
            if (Producer.Id == null)
            {
                ProducerBLL.AddProducer(Producer.ToDTO());
            }
            else
            {
                ProducerBLL.EditProducer(Producer.ToDTO());
            }

            var page = obj as ProducerEditPage;
            page?.NavigationService?.Navigate(new ProducerPage());
        });
    }
}