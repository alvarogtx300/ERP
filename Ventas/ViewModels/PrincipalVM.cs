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
            facadeVentas = new FacadeVentas(); 
            venta = new Venta(); 
        }

        public IEnumerable<ClienteVM> Clientes {
            get { return clientes.Select(cliente => new ClienteVM { Model = cliente }); }
        }

        public IEnumerable<VentaVM> Ventas {
            get { return ventas.Select(v => new VentaVM { Model = v }); }
        }

        public IEnumerable<RepuestoVM> Repuestos {
            get { return repuestos.Select(repuesto => new RepuestoVM { Model = repuesto }); }
        }

        public VentaVM Venta {
            get { return new VentaVM { Model = venta }; }
        }

        private int indexComboRepuestos=-1; 
        public int IndexComboRepuestos {
            get {
                return indexComboRepuestos;
            }
            set {
                indexComboRepuestos = value;
				cantidadRepuesto = 0;
				OnPropertyChanged("CantidadRepuesto");
                OnPropertyChanged("CombosOk");
                OnPropertyChanged("StockRepuesto");
                OnPropertyChanged("IsCantidadOk");
            }
        }

        private int indexComboClientes = -1;
        public int IndexComboClientes {
            get {
                return indexComboClientes;
            }
            set {
                indexComboClientes = value;
                venta.Cliente = clientes[indexComboClientes]; 
                venta.DetallesVentas.Clear();
                cantidadRepuesto = 0; 
                indexComboRepuestos = -1;
                OnPropertyChanged("CantidadRepuesto");
                OnPropertyChanged("IndexComboRepuestos");
                OnPropertyChanged("StockRepuesto");
                OnPropertyChanged("IsCantidadOk");
                OnPropertyChanged("CombosOk");
            }
        }

		private int indexTab = 0;
		public int IndexTab {
			get { return indexTab; }
			set { 
				indexTab = value;
                indexComboRepuestos = -1;
			}
		}

        public string StockRepuesto {
            get { return indexComboRepuestos >= 0 ? Convert.ToString(repuestos[indexComboRepuestos].NumArticulos) : "..."; }
        }

        private int cantidadRepuesto;
        public string CantidadRepuesto {
            get { return cantidadRepuesto == 0 ? "" : Convert.ToString(cantidadRepuesto); }
            set {
                int cant = 0;
                if (int.TryParse(value, out cant))
                    if (cant > 0 && cant<=int.Parse(StockRepuesto)) {
                        cantidadRepuesto = cant;
                        OnPropertyChanged("IsCantidadOk");
                    }
                    else {
                        cantidadRepuesto = 0;
                        OnPropertyChanged("IsCantidadOk");
                        throw new ArgumentException();
                    }
                else {
                    cantidadRepuesto = 0;
                    OnPropertyChanged("IsCantidadOk");
                    throw new ArgumentException();
                }
            }
        }

        public bool CombosOk {
            get { return indexComboClientes>=0 && indexComboRepuestos>=0; }
        }

        public bool IsCantidadOk {
            get { return  cantidadRepuesto > 0; }
        }

        ICommand agregar;
        public ICommand Agregar {
            get {
                return agregar ?? (agregar = new RelayCommand(() => {
                    Repuesto re = repuestos[indexComboRepuestos];                     
                    re.NumArticulos = re.NumArticulos - cantidadRepuesto; 
                    venta.DetallesVentas.Add(
                        new DetalleVenta {
                            Cantidad = cantidadRepuesto,
                            Repuesto = repuestos[indexComboRepuestos]
                        }
                    );
					cantidadRepuesto = 0;
					OnPropertyChanged("IsCantidadOk");
					OnPropertyChanged("CantidadRepuesto");
                    OnPropertyChanged("StockRepuesto");
                    OnPropertyChanged("Venta");
                    
                }));
            }
        }
        
        ICommand guardarVenta;
        public ICommand GuardarVenta {
			get {
                return guardarVenta ?? (guardarVenta = new RelayCommand(() => {
                    facadeVentas.AgregarVenta(venta);
                    venta = new Venta();
                    indexComboRepuestos = -1;
                    indexComboClientes = -1;
                    cantidadRepuesto = 0;
                    indexTab = 0;
                    OnPropertyChanged("Venta");
                    OnPropertyChanged("CantidadRepuesto");
                    OnPropertyChanged("IndexComboClientes");
                    OnPropertyChanged("IndexComboRepuestos");
                    OnPropertyChanged("StockRepuesto");
                    OnPropertyChanged("CombosOk");
                    OnPropertyChanged("IsCantidadOk");
                    OnPropertyChanged("Ventas");
                    OnPropertyChanged("IndexTab");
				}));
			}
		}
    }
}
