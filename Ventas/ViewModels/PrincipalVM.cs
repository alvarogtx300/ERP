using Clientes.Logic;
using Clientes.Models;
using Clientes.ViewModels;
using Clientes.Views;
using Framework;
using Repuestos.Logic;
using Repuestos.Models;
using Repuestos.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Ventas.Logic;
using Ventas.Models;

namespace Ventas.ViewModels {
    public class PrincipalVM : ViewModelBase {
        private FacadeClientes facadeClientes;
        private FacadeRepuestos facadeRepuestos;
        private FacadeVentas facadeVentas; 
        private ObservableCollection<Cliente> clientes;
        private ObservableCollection<Repuesto> repuestos;
        private ObservableCollection<Venta> ventas;
        private Venta venta; 

        public PrincipalVM(ObservableCollection<Cliente> listaClientes, ObservableCollection<Repuesto> listaRespuestos, ObservableCollection<Venta> listaVentas) {
            clientes = listaClientes;
            repuestos = listaRespuestos;
            ventas = listaVentas; 
            facadeClientes = new FacadeClientes();
            facadeRepuestos = new FacadeRepuestos();
            venta = new Venta(); 
        }

        public IEnumerable<ClienteVM> Clientes {
            get { return clientes.Select(cliente => new ClienteVM { Model = cliente }); }
        }

        public IEnumerable<VentaVM> Ventas {
            get { return ventas.Select(venta => new VentaVM { Model = venta }); }
        }

        public IEnumerable<RepuestoVM> Repuestos {
            get { return repuestos.Select(repuesto => new RepuestoVM { Model = repuesto }); }
        }

        public VentaVM Venta {
            get { return new VentaVM { Model = venta }; }
        }

        private int indexCombo=-1; 
        public int IndexCombo {
            get {
                return indexCombo;
            }
            set {
                indexCombo = value;
            }
        }

		private int indexTab = 0;
		public int IndexTab {
			get { return indexTab; }
			set { 
				indexTab = value;
                indexCombo = -1;
			}
		}

        private int cantidadRepuesto;
        public int CantidadRepuesto {
            get { return cantidadRepuesto; }
            set {
                cantidadRepuesto = value;
            }
        }

        ICommand agregar;
        public ICommand Agregar {
            get {
                return agregar ?? (agregar = new RelayCommand(() => {
                    venta.DetallesVentas.Add(
                        new DetalleVenta {
                            Cantidad=cantidadRepuesto,
                            Repuesto=repuestos[indexCombo]
                        }
                    ); 
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
