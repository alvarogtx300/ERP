using Clientes.Logic;
using Clientes.Models;
using Clientes.Views;
using Framework;
using Repuestos.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ventas.ViewModels {
    public class PrincipalVM : ViewModelBase {
        private FacadeClientes facadeClientes;
        private FacadeRepuestos facadeRepuestos; 
        public ObservableCollection<Cliente> clientes;
        private ObservableCollection<Vehiculo> vehiculos;

        public PrincipalVM(ObservableCollection<Cliente> listaClientes, ObservableCollection<Vehiculo> listaVehiculos) {
            clientes = listaClientes;
            vehiculos = listaVehiculos; 
            facadeClientes = new FacadeClientes();
            facadeRepuestos = new FacadeRepuestos(); 
        }

        private Object objetoSeleccionado;
        public Object ObjetoSeleccionado {
            get { return objetoSeleccionado; }
			set { 
				objetoSeleccionado = value;
                OnPropertyChanged("IsSelected"); 
			}
        }

		public bool IsSelected {
			get { return objetoSeleccionado != null; }
		}

		private int indexTab = 0;
		public int IndexTab {
			get { return indexTab; }
			set { 
				indexTab = value;
				objetoSeleccionado=null;
				OnPropertyChanged("ObjetoSeleccionado"); 
				OnPropertyChanged("IsSelected"); 
			}
		}

        ICommand agregar;
        public ICommand Agregar {
            get {
                return agregar ?? (agregar = new RelayCommand(() => {
					
                }));
            }
        }

		ICommand modificar;
		public ICommand Modificar {
			get {
				return modificar ?? (modificar = new RelayCommand(() => {
                    
				}));
			}
		}

		ICommand eliminar;
		public ICommand Eliminar {
			get {
				return eliminar ?? (eliminar = new RelayCommand(() => {
                    MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                    if (MessageBox.Show("¿Seguro que desea eliminar?", "Eliminar", btnMessageBox) == MessageBoxResult.Yes) {
                        
                    }
				}));
			}
		}
    }
}
