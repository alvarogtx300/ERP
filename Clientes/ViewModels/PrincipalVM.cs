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
            clientes = listaClientes;
            vehiculos = listaVehiculos; 
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

		private int index=-1; 
		public int IndexSelected {
			get { return index; }
			set { 
				index = value; 
				OnPropertyChanged("IsSelected"); 
			}
		}

		public bool IsSelected {
			get { return index>-1; }
		}

		private int indexTab = 0;
		public int IndexTab {
			get { return indexTab; }
			set { 
				indexTab = value;
				index = -1;
				OnPropertyChanged("IndexSelected"); 
				OnPropertyChanged("IsSelected"); 
			}
		}

        ICommand agregar;
        public ICommand Agregar {
            get {
                return agregar ?? (agregar = new RelayCommand(() => {
					if (indexTab == 0) {
						var vm = new ClienteVM {
							Model = new Cliente()
						};
						var view = new DetalleCliente {
							DataContext = vm,
							Title = "Agregar Cliente"
						};
						if (view.ShowDialog() == true) {
							facade.AgregarCliente(vm.Model);
							OnPropertyChanged("Clientes");
						}
					}
					else {
						var vm = new VehiculoVM {
							Model = new Vehiculo()
						};
						var view = new DetalleVehiculo {
							DataContext = vm,
							Title = "Agregar Vehiculo"
						};
						if (view.ShowDialog() == true) {
							facade.AgregarVehiculo(vm.Model);
							OnPropertyChanged("Vehiculos");
						}
					}
                }));
            }
        }

		ICommand modificar;
		public ICommand Modificar {
			get {
				return modificar ?? (modificar = new RelayCommand<ClienteVM>((cliente) => {
					var vm = new ClienteVM {
						Model = new Cliente {
							Direccion=cliente.Model.Direccion,
							Apellidos=cliente.Model.Apellidos
						}, 
						Dni=cliente.Dni,
						Nombre=cliente.Nombre,
						Telefono=cliente.Telefono
					};
					var view = new DetalleCliente {
						DataContext = vm, 
						Title="Modificar Cliente"
					};
					if (view.ShowDialog() == true) {
						facade.ModificarCliente(vm.Model); 
						OnPropertyChanged("Clientes");
					}
				}));
			}
		}

		ICommand eliminar;
		public ICommand Eliminar {
			get {
				return eliminar ?? (eliminar = new RelayCommand<ClienteVM>((clienteVM) => {
					facade.EliminarCliente(clienteVM.Model);
					OnPropertyChanged("Clientes");
				}));
			}
		}
    }
}
