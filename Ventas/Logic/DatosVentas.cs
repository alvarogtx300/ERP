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
				DetallesVentas = new ObservableCollection<DetalleVenta>{
					new DetalleVenta {
                        Repuesto=new Repuesto{
						    Codigo=1,
						    Descripcion="Rueda de 20'",
						    Nombre="Rueda",
						    NumArticulos=5,
						    Precio=25.50
					    },
                        Cantidad=4
                    },
					new DetalleVenta {
                        Repuesto=new Repuesto{
						    Codigo=1,
						    Descripcion="Rueda de 20'",
						    Nombre="Rueda",
						    NumArticulos=5,
						    Precio=25.50
					    },
                        Cantidad=2
                    }
				}
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
