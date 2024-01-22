using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Input;
using ProductoMVVMSQLite.Models;
using ProductoMVVMSQLite.Utils;
using ProductoMVVMSQLite.Services;
using ProductoMVVMSQLite.Views;
using PropertyChanged;

namespace ProductoMVVMSQLite.ViewModels

    
{
    [AddINotifyPropertyChangedInterface]
    internal class EliminarVIewModel
    {
        public Producto ProductoSeleccionado { get; set; }
        public ICommand EliminarProducto =>
    new Command(async () =>
    {
        if (ProductoSeleccionado != null)
        {
            bool confirmacion = await App.Current.MainPage.DisplayAlert("Confirmación", "¿Estás seguro de que quieres eliminar este producto?", "Sí", "No");

            if (confirmacion)
            {
                App.productoRepository.Delete(ProductoSeleccionado);

                Util.ListaProductos.Clear();
                App.productoRepository.GetAll().ForEach(Util.ListaProductos.Add);
                await App.Current.MainPage.Navigation.PopAsync();


            }
        }
    });

    }

   
}
