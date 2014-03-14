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
			ventas.Add(new Venta {
				Cliente = new Clientes.Models.Cliente {
					Nombre = "Prueba"
				},
				Fecha = DateTime.Now,
				/*Repuestos = new ObservableCollection<Repuesto>{
					new Repuesto{
						Codigo=1,
						Descripcion="Rueda de 20'",
						Nombre="Rueda",
						NumArticulos=5,
						Precio=25.50
					},
					new Repuesto{
						Codigo=2,
						Descripcion="Pequeños",
						Nombre="Amortiguador",
						NumArticulos=3,
						Precio=30
					}
				}*/
			});
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
