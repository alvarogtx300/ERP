using Repuestos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuestos.Logic {
	public class DatosRepuestos : IDAORepuestos{
		private static readonly Lazy<DatosRepuestos> instance = new Lazy<DatosRepuestos>(() => new DatosRepuestos());
		private ObservableCollection<Repuesto> repuestos;
		private ObservableCollection<Proveedor> proveedores;

		private DatosRepuestos() {
			repuestos = new ObservableCollection<Repuesto>{
				new Repuesto{
					Codigo=1,
					Descripcion="Rueda de 20'",
					Nombre="Rueda",
					NumArticulos=30,
					Precio=80
				},
				new Repuesto{
					Codigo=2,
					Descripcion="Pequeños",
					Nombre="Amortiguador",
					NumArticulos=10,
					Precio=100.50
				},
				new Repuesto{
					Codigo=3,
					Descripcion="Para coches de gasolina",
					Nombre="Filtro de gasolina",
					NumArticulos=15,
					Precio=3
				},
				new Repuesto{
					Codigo=4,
					Descripcion="Para coches de diesel",
					Nombre="Filtro de diesel",
					NumArticulos=15,
					Precio=3
				},
				new Repuesto{
					Codigo=5,
					Descripcion="Un filtro güeno güeno",
					Nombre="Filtro de aire",
					NumArticulos=50,
					Precio=5
				},
				new Repuesto{
					Codigo=6,
					Descripcion="Para alumbrado",
					Nombre="Fusibles",
					NumArticulos=200,
					Precio=0.22
				}
			};

			proveedores = new ObservableCollection<Proveedor> {
				new Proveedor{
					Cif="A04555784",
					Descripcion="Ruedas Juan",
					Nombre="Juan S.L."
				},
				new Proveedor{
					Cif="A07456357",
					Descripcion="Venta de repuestos al por mayor",
					Nombre="Repuestos Lisboa"
				},
				new Proveedor{
					Cif="L04248452",
					Descripcion="Venta de repuestos",
					Nombre="Repuestos Marquez"
				},
				new Proveedor{
					Cif="L04562112",
					Descripcion="Venta de componenetes electricos",
					Nombre="Electricidad Moreno S.L."
				}
			};
		}

		public static DatosRepuestos Instance {
			get { return instance.Value; }
		}

		public ObservableCollection<Repuesto> ListarRepuestos() {
			return repuestos;
		}

		public bool AgregarRepuesto(Repuesto r) {
			if (repuestos.Contains(r))
				return false;
			repuestos.Add(r);
			return true;			
		}

		public void EliminarRepuesto(Repuesto r) {
			repuestos.Remove(r);
		}

		public void ModificarRepuesto(Repuesto r) {
			Repuesto repuesto=repuestos[repuestos.IndexOf(r)];

			repuesto.Nombre = r.Nombre;
			repuesto.Descripcion = r.Descripcion;
			repuesto.Precio = r.Precio;
			repuesto.NumArticulos = r.NumArticulos;
		}

		public ObservableCollection<Proveedor> ListarProveedores() {
			return proveedores;
		}

		public bool AgregarProveedor(Proveedor p){
			if (proveedores.Contains(p))
				return false;
			proveedores.Add(p);
			return true;
		}

		public void EliminarProveedor(Proveedor p) {
			proveedores.Remove(p);
		}

		public void ModificarProveedor(Proveedor p) {
			Proveedor proveedor = proveedores[proveedores.IndexOf(p)];

			proveedor.Nombre = p.Nombre;
			proveedor.Descripcion = p.Descripcion;
		}
		
	}
}
