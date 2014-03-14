using Repuestos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuestos.Logic {
	interface IDAORepuestos {
		 ObservableCollection<Repuesto> ListarRepuestos();
		 bool AgregarRepuesto(Repuesto r);
		 void EliminarRepuesto(Repuesto r);
		 void ModificarRepuesto(Repuesto r);

		 ObservableCollection<Proveedor> ListarProveedores();
		 bool AgregarProveedor(Proveedor p);
		 void EliminarProveedor(Proveedor p);
		 void ModificarProveedor(Proveedor p);
	}
}
