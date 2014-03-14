using Clientes.Logic;
using Clientes.Models;
using Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Clientes.ViewModels {
	class DetalleVehiculoVM : ViewModelBase<VehiculoVM> {
        ObservableCollection<Cliente> listaClientes;
        public int indexCombo = -1; 

        public DetalleVehiculoVM(VehiculoVM vehiculo,ObservableCollection<Cliente> listaClientes) {
            Model = vehiculo;
            this.listaClientes = listaClientes;
            indexCombo = this.listaClientes.IndexOf(vehiculo.Model.RelacionCliente); 
        }

        public IEnumerable<ClienteVM> ListaClientes {
            get {
                return listaClientes.Select(cliente => new ClienteVM { Model = cliente });
            }
        }

        public int IndexCombo {
            get {
                return indexCombo; 
            }
            set {
                indexCombo = value;
                Model.Model.RelacionCliente = listaClientes[indexCombo]; 
            }
        }

        ICommand guardar;
        public ICommand Guardar {
            get {
                return guardar ?? (guardar =
                new RelayCommand<Window>((o) => {
                    ((Window)o).DialogResult = true;
                    ((Window)o).Close();
                }));
            }
        }
	}
}
