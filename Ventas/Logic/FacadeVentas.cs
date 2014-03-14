using Clientes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Models;

namespace Ventas.Logic {
    public class FacadeVentas {
        IDAOVentas datos;

        public FacadeVentas() {
            datos = DatosVentas.Instance;
        }

        public ObservableCollection<Venta> ListarVentas() {
            return datos.ListarVentas();
        }

        public void AgregarVenta() {
            datos.AgregarVenta(); 
        }
    }
}
