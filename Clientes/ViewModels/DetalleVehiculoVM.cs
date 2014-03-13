using Clientes.Logic;
using Clientes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.ViewModels {
	class DetalleVehiculoVM {
        private ObservableCollection<Vehiculo> vehiculos;

        public DetalleVehiculoVM(ObservableCollection<Vehiculo> listaVehiculos) {
            vehiculos = listaVehiculos; 
        }

        public IEnumerable<VehiculoVM> Vehiculos {
            get {
                return vehiculos.Select(vehiculo => new VehiculoVM { Model = vehiculo });
            }
        }
	}
}
