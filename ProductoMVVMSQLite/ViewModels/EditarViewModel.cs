using System.Windows.Input;
using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using ProductoMVVMSQLite.Services;
using ProductoMVVMSQLite.Views;
using PropertyChanged;

namespace ProductoMVVMSQLite.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class EditarProductoViewModel
    {
        public Producto ProductoSeleccionado { get; set; }

        public ICommand EditarProducto =>
            new Command(async () =>
            {
                if (ProductoSeleccionado != null)
                {
                    bool confirmacion = await App.Current.MainPage.DisplayAlert("Confirmación", "¿Estás seguro de que quieres editar este producto?", "Sí", "No");

                    if (confirmacion)
                    {
                        App.productoRepository.Update(ProductoSeleccionado);

                        Util.ListaProductos.Clear();
                        App.productoRepository.GetAll().ForEach(Util.ListaProductos.Add);
                        await App.Current.MainPage.Navigation.PopAsync();
                    }
                }
            });
    }
}
