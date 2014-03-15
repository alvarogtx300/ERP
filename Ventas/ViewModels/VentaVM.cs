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
        public ObservableCollection<DetalleVenta> DetallesVentas {
            get { return Model.DetallesVentas; }
        }

        public bool IsVentaOk {
            get { return Model.DetallesVentas.Count>0; }
        }
    }
}
