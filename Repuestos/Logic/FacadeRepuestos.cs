using Repuestos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuestos.Logic {
	class FacadeRepuestos {
		IDAORepuestos repuestos;

		public FacadeRepuestos()
		{
			repuestos = DatosRepuestos.Instance;
		}

		public ObservableCollection<Repuesto> ListarRepuestos()
		{
			return repuestos.ListarRepuestos();
		}

		public void AgregarRepuesto(Repuesto r)
		{
			repuestos.AgregarRepuesto(r);
		}

		public void EliminarRepuesto(Repuesto r)
		{
			repuestos.EliminarRepuesto(r);
		}

		public void ModificarRepuesto(Repuesto r) {
			repuestos.ModificarRepuesto(r);
		}
	}
}
