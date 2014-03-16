using Framework;
using Repuestos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Models;

namespace Ventas.ViewModels {
    public class VentaVM : ViewModelBase<Venta> {
        public IEnumerable<DetalleVentaVM> DetallesVentas {
            get {
                return Model.DetallesVentas.Select(
                    det => new DetalleVentaVM {
                        Model = det
                    }
                );
            }
        }

		public String Fecha {
			get {
				return String.Format("{0:d/M/yyyy HH:mm}", Model.Fecha);
			}
		}

        public bool IsVentaOk {
            get { return Model.DetallesVentas.Count>0; }
        }
    }
}
