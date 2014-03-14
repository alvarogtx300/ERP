using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Models;

namespace Ventas.Logic {
	interface IDAOVentas {
		ObservableCollection<Venta> ListarVentas();
		void AgregarVenta(Venta v);
	}
}
