using Clientes.Models;
using Framework;
using Repuestos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Models {
	public class Venta : ObservableObject{
		private Cliente cliente;
		private ObservableCollection<Repuesto> repuestos;
		private DateTime fecha;

		public Cliente Cliente {
			get { return cliente; }
			set { SetProperty(ref cliente, value, () => Cliente); }
		}

		public ObservableCollection<Repuesto> Repuestos {
			get { return repuestos; }
			set { SetProperty(ref repuestos, value, () => Repuestos); }
		}

		public DateTime Fecha {
			get { return fecha; }
			set { SetProperty(ref fecha, value, () => Fecha); }
		}
	}
}
