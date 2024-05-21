using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.ViewModels.Commands;
using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.Views.AdminItemEditPages;
using Supermarket.Views.AdminItemPageViews;

namespace Supermarket.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

public class ProductEditPageViewModel : BaseViewModel
{
    public ProductViewModel Product { get; set; }
    public ObservableCollection<string> Categories { get; set; } 
        = new ObservableCollection<string>(CategoryBLL.GetCategories().Select(c => c.Name ?? ""));
    
    public ObservableCollection<string> Producers { get; set; }
        = new ObservableCollection<string>(ProducerBLL.GetProducers().Select(p => p.Name ?? ""));
    
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
    
    public string Category
    {
        get => Product.Category.Name;
        set
        {
            Product.Category = (from category in CategoryBLL.GetCategories().Select(c => c.ToViewModel())
                where category.Name == value
                select category).FirstOrDefault() ?? new CategoryViewModel();
            OnPropertyChanged();
        }
    }
    
    public string Producer
    {
        get => Product.Producer.Name;
        set
        {
            Product.Producer = (from producer in ProducerBLL.GetProducers().Select(p => p.ToViewModel())
                where producer.Name == value
                select producer).FirstOrDefault() ?? new ProducerViewModel();
            OnPropertyChanged();
        }
    }
    
    public string? SelectedImagePath
    {
        get => Product.Image is "" or null ? "No image selected" : Product.Image;
        set
        {
            Product.Image = value ?? "";
            ImageVisibility = Product.Image is "" or null ? Visibility.Collapsed : Visibility.Visible;
            OnPropertyChanged();
        }
    }
    
    public Visibility ImageVisibility
    {
        get => Product.Image is "" or "No image found" or null ? Visibility.Collapsed : Visibility.Visible;
        private set => OnPropertyChanged();
    }
    
    public ICommand? SaveCommand { get; private set; }
    public ICommand? CancelCommand { get; private set; }
    public ICommand? BrowseForImageCommand { get; private set; }
    
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
    
    private bool _nameHasError;
    public bool NameHasError
    {
        get => _nameHasError;
        private set
        {
            _nameHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _barcodeHasError;
    public bool BarcodeHasError
    {
        get => _barcodeHasError;
        private set
        {
            _barcodeHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _categoryHasError;
    public bool CategoryHasError
    {
        get => _categoryHasError;
        private set
        {
            _categoryHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _producerHasError;
    public bool ProducerHasError
    {
        get => _producerHasError;
        private set
        {
            _producerHasError = value;
            OnPropertyChanged();
        }
    }
    
    private readonly string? _initialBarcode;
    public ProductEditPageViewModel()
    {
        Product = new ProductViewModel();
        Title = "Add Product";
        InitializeCommands();
    }
    
    public ProductEditPageViewModel(ProductViewModel product)
    {
        Product = product;
        Title = "Edit Product";
        _initialBarcode = product.Barcode;
        InitializeCommands();
    }
    
    private void InitializeCommands()
    {
        SaveCommand = new RelayCommand<object>(o =>
        {
            ErrorMessage = "";
            NameHasError = false;
            BarcodeHasError = false;
            CategoryHasError = false;
            ProducerHasError = false;
            
            if (string.IsNullOrWhiteSpace(Product.Name))
            {
                ErrorMessage = "Name is required";
                NameHasError = true;
                return;
            }
            
            if (string.IsNullOrWhiteSpace(Product.Barcode))
            {
                ErrorMessage = "Barcode is required";
                BarcodeHasError = true;
                return;
            }
            
            if (ProductBLL.GetProducts().Any(p => p.Barcode == Product.Barcode))
            {
                if (Product.Barcode != _initialBarcode)
                {
                    ErrorMessage = "Barcode must be unique";
                    BarcodeHasError = true;
                    return;
                }
            }
            
            if (Product.Category.Name == "")
            {
                ErrorMessage = "Category is required";
                CategoryHasError = true;
                return;
            }
            
            if (Product.Producer.Name == "")
            {
                ErrorMessage = "Producer is required";
                ProducerHasError = true;
                return;
            }

            if (Product.Id == null)
            {
                ProductBLL.AddProduct(Product.ToDTO());
            }
            else
            {
                ProductBLL.EditProduct(Product.ToDTO());
            }
            
            var page = o as ProductEditPage;
            page?.NavigationService?.Navigate(new ProductPage());
        });
        
        CancelCommand = new RelayCommand<object>(o =>
        {
            var page = o as ProductEditPage;
            page?.NavigationService?.Navigate(new ProductPage());
        });
        
        BrowseForImageCommand = new RelayCommand<object>(_ =>
        {
            var dialog = new OpenFileDialog
            {
                Title = "Select an image",
                Filter = "Image files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*"
            };
            
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            if (!File.Exists(dialog.FileName))
            {
                return;
            }
            
            SelectedImagePath = dialog.FileName;
        });
    }


}