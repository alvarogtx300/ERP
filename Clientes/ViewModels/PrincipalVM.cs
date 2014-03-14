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
using System.Windows;
using System.Windows.Input;

namespace Clientes.ViewModels {
    public class PrincipalVM : ViewModelBase {
        private FacadeClientes facade;
        private ObservableCollection<Cliente> clientes;
        private ObservableCollection<Vehiculo> vehiculos;

        public PrincipalVM(ObservableCollection<Cliente> listaClientes, ObservableCollection<Vehiculo> listaVehiculos) {
            clientes = listaClientes;
            vehiculos = listaVehiculos; 
            facade = new FacadeClientes();
        }

        public IEnumerable<ClienteVM> Clientes {
            get { return clientes.Select(cliente => new ClienteVM { Model = cliente }); }
        }

        public IEnumerable<VehiculoVM> Vehiculos {
            get { return vehiculos.Select(vehiculo => new VehiculoVM { Model = vehiculo }); }
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
					if (indexTab==0) {
						var vm = new ClienteVM {
							Model = new Cliente()
						};

						DetalleCliente view;
						bool duplicado = true;
						while (duplicado) {
							vm.Model.Dni = null;
							view = new DetalleCliente {
								DataContext = vm,
								Title = "Agregar cliente"
							};
							if (view.ShowDialog() == true) {
								if (facade.AgregarCliente(vm.Model)) {
									duplicado = false;
									OnPropertyChanged("Clientes");
								}
								else
									MessageBox.Show("Error, DNI duplicado", "Error");
							}
							else
								duplicado = false;
						}
					}
					else if(indexTab==1) {
                        var vm = new DetalleVehiculoVM(
                            new VehiculoVM {
                                Model = new Vehiculo()
                            }, clientes
                        ); 

						DetalleVehiculo view;
						bool duplicado = true;
						while (duplicado) {
							vm.Model.Model.Matricula = null;
							view = new DetalleVehiculo {
								DataContext = vm,
								Title = "Agregar vehiculo"
							};
							if (view.ShowDialog() == true) {
								if (facade.AgregarVehiculo(vm.Model.Model)) {
									duplicado = false;
									OnPropertyChanged("Vehiculos");
								}
								else
									MessageBox.Show("Error, matrícula duplicada", "Error");
							}
							else
								duplicado = false;
						}
					}
                }));
            }
        }

		ICommand modificar;
		public ICommand Modificar {
			get {
				return modificar ?? (modificar = new RelayCommand(() => {
                    if (objetoSeleccionado is ClienteVM) {
                        ClienteVM cliente = (ClienteVM)objetoSeleccionado; 
                        var vm = new ClienteVM {
                            Model = new Cliente {
                                Direccion = cliente.Model.Direccion,
                                Apellidos = cliente.Model.Apellidos
                            },
                            Dni = cliente.Dni,
                            Nombre = cliente.Nombre,
                            Telefono = cliente.Telefono
                        };
                        var view = new DetalleCliente {
                            DataContext = vm,
                            Title = "Modificar Cliente"
                        };
                        if (view.ShowDialog() == true) {
                            facade.ModificarCliente(vm.Model);
                            OnPropertyChanged("Clientes");
                        }
                    }
                    else if (objetoSeleccionado is VehiculoVM) {
                        VehiculoVM vehiculo = (VehiculoVM)objetoSeleccionado;
                        var vm = new DetalleVehiculoVM(
                            new VehiculoVM {
                                Model=new Vehiculo {
                                    RelacionCliente=vehiculo.Model.RelacionCliente
                                },
                                Matricula=vehiculo.Matricula,
                                Modelo=vehiculo.Modelo,
                            }, clientes); 

                        var view = new DetalleVehiculo {
                            DataContext = vm,
                            Title = "Modificar Vehiculo"
                        };
                        if (view.ShowDialog() == true) {
                            facade.ModificarVehiculo(vm.Model.Model);
                            OnPropertyChanged("Vehiculos");
                        }
                    }
				}));
			}
		}

		ICommand eliminar;
		public ICommand Eliminar {
			get {
				return eliminar ?? (eliminar = new RelayCommand(() => {
                    MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                    if (MessageBox.Show("¿Seguro que desea eliminar?", "Eliminar", btnMessageBox) == MessageBoxResult.Yes) {
                        if (objetoSeleccionado is ClienteVM) {
                            facade.EliminarCliente(((ClienteVM)objetoSeleccionado).Model);
                            OnPropertyChanged("Clientes");
                        }
                        else if (objetoSeleccionado is VehiculoVM) {
                            facade.EliminarVehiculo(((VehiculoVM)objetoSeleccionado).Model);
                            OnPropertyChanged("Vehiculos");
                        }
                    }
				}));
			}
		}
    }
}
