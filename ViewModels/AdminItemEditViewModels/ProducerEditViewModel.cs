using System.Windows.Input;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.ViewModels.Commands;
using Supermarket.Views.AdminItemEditPages;
using Supermarket.Views.AdminItemPageViews;

namespace Supermarket.ViewModels.AdminItemEditViewModels;

public class ProducerEditViewModel : BaseViewModel
{
    private ProducerDTO Producer { get; set; }

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
    
    public string Name
    {
        get => Producer.Name ?? "";
        set
        {
            Producer.Name = value;
            OnPropertyChanged();
        }
    }
    
    public string OriginCountry
    {
        get => Producer.OriginCountry ?? "";
        set
        {
            Producer.OriginCountry = value;
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
    public ProducerEditViewModel()
    {
        Producer = new ProducerDTO();
        Title = "Add Producer";
        InitializeCommands();
    }
    
    public ProducerEditViewModel(ProducerDTO producer)
    {
        Producer = producer;
        Title = "Edit Producer";
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
            
            if (string.IsNullOrWhiteSpace(Producer.OriginCountry))
            {
                ErrorMessage = "Origin Country is required!";
                OriginCountryHasError = true;
                return;
            }
            
            if (Producer.Id == null)
            {
                ProducerBLL.AddProducer(Producer);
            }
            else
            {
                ProducerBLL.EditProducer(Producer);
            }

            var page = obj as ProducerEditPage;
            page?.NavigationService?.Navigate(new ProducerPage());
        });
    }
}