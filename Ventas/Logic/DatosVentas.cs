using Repuestos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Models;

namespace Ventas.Logic {
	public class DatosVentas : IDAOVentas{
		private static readonly Lazy<DatosVentas> instance = new Lazy<DatosVentas>(() => new DatosVentas());
		private ObservableCollection<Venta> ventas;

		private DatosVentas() {
			ventas = new ObservableCollection<Venta>();
		}

		public static DatosVentas Instance {
			get { return instance.Value; }
		}

		public void AgregarVenta(Venta v) {
			ventas.Add(v);
		}

		public ObservableCollection<Venta> ListarVentas() {
			return ventas;
		}
	}
}
