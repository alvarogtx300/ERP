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
		private ObservableCollection<DetalleVenta> detallesVentas;
		private DateTime fecha;

        public Venta() {
            detallesVentas = new ObservableCollection<DetalleVenta>(); 
        }

		public Cliente Cliente {
			get { return cliente; }
			set { SetProperty(ref cliente, value, () => Cliente); }
		}

        public ObservableCollection<DetalleVenta> DetallesVentas {
            get { return detallesVentas; }
            set { SetProperty(ref detallesVentas, value, () => DetallesVentas); }
		}

		public DateTime Fecha {
			get { return fecha; }
			set { SetProperty(ref fecha, value, () => Fecha); }
		}
	}
}
