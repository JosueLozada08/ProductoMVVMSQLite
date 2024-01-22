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
    public class NuevoProductoViewModel
    {
        public string Nombre { get; set; }
        public string Cantidad  { get; set; }
        public string Descripcion { get; set; }


        public NuevoProductoViewModel()
        {

        }
        public ICommand GuardarProducto =>
            new Command(async () =>
            {
                Producto producto = new Producto
                {
                    Nombre = Nombre,
                    Descripcion = Descripcion,
                    Cantidad = Int32.Parse(Cantidad)
                   
                };
                App.productoRepository.Add(producto);
                Util.ListaProductos.Clear();
                App.productoRepository.GetAll().ForEach(Util.ListaProductos.Add);
                await App.Current.MainPage.Navigation.PopAsync();
              
            });

   }
}
