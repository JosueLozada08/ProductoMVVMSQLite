using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class EditarProductoPage : ContentPage
{
	public EditarProductoPage()
	{
        InitializeComponent();
       
    }
    public EditarProductoPage(int IdProducto)
    {
        InitializeComponent();
        BindingContext = new EditarProductoViewModel();
    }
}

