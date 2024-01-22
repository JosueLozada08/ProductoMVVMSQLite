using ProductoMVVMSQLite.ViewModels;

namespace ProductoMVVMSQLite.Views;

public partial class EliminarProductoage : ContentPage
{
	public EliminarProductoage()
	{
        InitializeComponent();
        BindingContext = new EliminarVIewModel();
    }
}
