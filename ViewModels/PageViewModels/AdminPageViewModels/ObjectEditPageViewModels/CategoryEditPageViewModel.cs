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

public class CategoryEditPageViewModel : BaseViewModel
{
    public CategoryViewModel Category { get; set; }
    
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

    public string? SelectedImagePath
    {
        get => Category.Image is "" or null ? "No image selected" : Category.Image;
        set
        {
            Category.Image = value ?? "";
            ImageVisibility = Category.Image is "" or null ? Visibility.Collapsed : Visibility.Visible;
            OnPropertyChanged();
        }
    }
    
    public ICommand? BrowseForImageCommand { get; private set; }

    public Visibility ImageVisibility
    {
        get => Category.Image is "" or "No image found" or null ? Visibility.Collapsed : Visibility.Visible;
        private set => OnPropertyChanged();
    }

    private string? _initialName;
    public CategoryEditPageViewModel()
    {
        Category = new CategoryViewModel();
        Title = "Add Category";
        SelectedImagePath = null;
        InitializeCommands();
    }
    
    public CategoryEditPageViewModel(CategoryViewModel category)
    {
        Category = category;
        Title = "Edit Category";
        SelectedImagePath = category.Image;
        _initialName = category.Name;
        InitializeCommands();
    }
    
    private void InitializeCommands()
    {
        SaveCommand = new RelayCommand<object>(o =>
        {
            ErrorMessage = "";
            NameHasError = false;

            if (string.IsNullOrWhiteSpace(Category.Name))
            {
                ErrorMessage = "Name is required!";
                NameHasError = true;
                return;
            }
            
            if (CategoryBLL.GetCategories().Any(c => c.Name == Category.Name))
            {
                if (Category.Name != _initialName)
                {
                    ErrorMessage = "Name must be unique!";
                    NameHasError = true;
                    return;
                }
            }

            if (Category.Id == null)
            {
                CategoryBLL.AddCategory(Category.ToDTO());
            }
            else
            {
                CategoryBLL.EditCategory(Category.ToDTO());
            }
            
            var page = o as CategoryEditPage;
            page?.NavigationService?.Navigate(new CategoryPage());
        });
        
        CancelCommand = new RelayCommand<object>(o =>
        {
            var page = o as CategoryEditPage;
            page?.NavigationService?.Navigate(new CategoryPage());
        });
        
        BrowseForImageCommand = new RelayCommand<object>(o =>
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