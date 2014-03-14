using Repuestos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuestos.Logic {
	public class FacadeRepuestos {
		IDAORepuestos datos;

		public FacadeRepuestos()
		{
			datos = DatosRepuestos.Instance;
		}

		public ObservableCollection<Repuesto> ListarRepuestos()
		{
			return datos.ListarRepuestos();
		}

		public bool AgregarRepuesto(Repuesto r)
		{
			return datos.AgregarRepuesto(r);
		}

		public void EliminarRepuesto(Repuesto r)
		{
			datos.EliminarRepuesto(r);
		}

		public void ModificarRepuesto(Repuesto r) {
			datos.ModificarRepuesto(r);
		}

		public ObservableCollection<Proveedor> ListarProveedores() {
			return datos.ListarProveedores();
		}

		public void AgregarProveedor(Proveedor p) {
			datos.AgregarProveedor(p);
		}

		public void EliminarProveedor(Proveedor p) {
			datos.EliminarProveedor(p);
		}

		public void ModificarProveedor(Proveedor p) {
			datos.ModificarProveedor(p);
		}
	}
}
