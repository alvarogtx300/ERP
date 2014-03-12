using Clientes.Logic;
using Clientes.Models;
using Clientes.Views;
using Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Clientes.ViewModels {
    public class PrincipalVM : ViewModelBase {
        private FacadeClientes facade;
        public ObservableCollection<Cliente> clientes;
        private ObservableCollection<Vehiculo> vehiculos;

        public PrincipalVM(ObservableCollection<Cliente> listaClientes, ObservableCollection<Vehiculo> listaVehiculos) {
            clientes = new ObservableCollection<Cliente>(listaClientes);
            vehiculos = new ObservableCollection<Vehiculo>(listaVehiculos); 
            facade = new FacadeClientes();
        }

        public IEnumerable<ClienteVM> Clientes {
            get {
                return clientes.Select(cliente => new ClienteVM { Model = cliente });
            }
        }

        public IEnumerable<VehiculoVM> Vehiculos {
            get {
                return vehiculos.Select(vehiculo => new VehiculoVM { Model = vehiculo });
            }
        }

        ICommand agregar;
        public ICommand Agregar {
            get {
                return agregar ?? (agregar = new RelayCommand(() => {
                    var view = new DetalleCliente();
                    view.Show();
                }));
            }
        }
    }
}
