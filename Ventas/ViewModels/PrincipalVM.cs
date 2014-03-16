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

        //Estadisticas cliente
        private int indexRepEstadisticas=-1; 
        public int IndexRepEstadisticas {
            get {
                return indexRepEstadisticas;
            }
            set {
                indexRepEstadisticas = value;
                OnPropertyChanged("RepuestosVendidos");
                OnPropertyChanged("NumVentasRepuesto");
                OnPropertyChanged("TotalRecaudadoRepuesto");
                OnPropertyChanged("MediaRecaudadoRepuesto"); 
            }
        }

        private int repuestosVendidos; 
        public string RepuestosVendidos {
            get {
                repuestosVendidos = 0;
                if (indexRepEstadisticas >= 0) {
                    Repuesto reSelect = repuestos[indexRepEstadisticas];
                    ventas.ToList<Venta>().ForEach(ven => {
                        ven.DetallesVentas.ToList<DetalleVenta>().ForEach(detVenta => {
                            if (detVenta.Repuesto.Equals(reSelect))
                                repuestosVendidos += detVenta.Cantidad;
                        });
                    }); 
                    return Convert.ToString(repuestosVendidos); 
                }
                else
                    return "...";
            }
        }

        private int numVentasRepuesto; 
        public string NumVentasRepuesto {
            get {
                numVentasRepuesto = 0;
                if (indexRepEstadisticas >= 0) {
                    Repuesto reSelect = repuestos[indexRepEstadisticas];
                    ventas.ToList<Venta>().ForEach(ven => {
                        List<DetalleVenta> detVentas = ven.DetallesVentas.ToList();
                        if (detVentas.Any(det => det.Repuesto.Equals(reSelect)))
                            numVentasRepuesto++; 
                    });
                    return Convert.ToString(numVentasRepuesto);
                }
                else
                    return "...";
            }
        }

        private double totalRecaudadoRepuesto; 
        public string TotalRecaudadoRepuesto {
            get {
                totalRecaudadoRepuesto = 0; 
                if (indexRepEstadisticas >= 0) {
                    Repuesto reSelect = repuestos[indexRepEstadisticas];
                    ventas.ToList<Venta>().ForEach(ven => {
                        ven.DetallesVentas.ToList<DetalleVenta>().ForEach(detVenta => {
                            if (detVenta.Repuesto.Equals(reSelect))
                                totalRecaudadoRepuesto += detVenta.Cantidad * reSelect.Precio;
                        });
                    });
                    return Convert.ToString(totalRecaudadoRepuesto);
                }
                else
                    return "...";
            }
        }

        public string MediaRecaudadoRepuesto {
            get {
                if (indexRepEstadisticas >= 0) {
                    return Convert.ToString(numVentasRepuesto>0 ? totalRecaudadoRepuesto / numVentasRepuesto : 0);
                }
                else
                    return "...";
            }
        }

        //Estadisticas por cliente
        private int indexClienteEstadisticas = -1;
        public int IndexClienteEstadisticas {
            get {
                return indexClienteEstadisticas;
            }
            set {
                indexClienteEstadisticas = value;
                OnPropertyChanged("NumComprasCliente");
                OnPropertyChanged("TotalGastadoCliente");
                OnPropertyChanged("NumRepCliente");
                OnPropertyChanged("MediaGastadoCliente"); 
            }
        }

        private double totalGastadoCliente;
        public string TotalGastadoCliente {
            get {
                totalGastadoCliente = 0;
                if (indexClienteEstadisticas >= 0) {
                    Cliente clienteSelect = clientes[indexClienteEstadisticas];
                    ventas.ToList<Venta>().ForEach(ven => {
                        if (ven.Cliente.Equals(clienteSelect)) {
                            ven.DetallesVentas.ToList<DetalleVenta>().ForEach(detVenta => {
                                totalGastadoCliente += detVenta.Cantidad * detVenta.Repuesto.Precio;
                            });
                        }
                    });
                    return Convert.ToString(totalGastadoCliente);
                }
                else
                    return "...";
            }
        }

        private int numComprasCliente;
        public string NumComprasCliente {
            get {
                numComprasCliente = 0; 
                if (indexClienteEstadisticas >= 0) {
                    Cliente clienteSelect = clientes[indexClienteEstadisticas];
                    ventas.ToList<Venta>().ForEach(ven => {
                        if (ven.Cliente.Equals(clienteSelect))
                            numComprasCliente++; 
                    });
                    return Convert.ToString(numComprasCliente);
                }
                else
                    return "...";
            }
        }

        public string MediaGastadoCliente {
            get {
                if (indexClienteEstadisticas >= 0) {
                    return Convert.ToString(numComprasCliente > 0 ? totalGastadoCliente / numComprasCliente : 0);
                }
                else
                    return "...";
            }
        }

        private int numRepCliente;
        public string NumRepCliente {
            get {
                numRepCliente = 0;
                if (indexClienteEstadisticas >= 0) {
                    Cliente clienteSelect = clientes[indexClienteEstadisticas];
                    ventas.ToList<Venta>().ForEach(ven => {
                        if (ven.Cliente.Equals(clienteSelect)) {
                            ven.DetallesVentas.ToList<DetalleVenta>().ForEach(detVenta => {
                                numRepCliente += detVenta.Cantidad;
                            });
                        }
                    });
                    return Convert.ToString(numRepCliente);
                }
                else
                    return "...";
            }
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
                OnPropertyChanged("IsComboClientesOk");
                OnPropertyChanged("CombosOk");
            }
        }

		private int indexTab = 0;
		public int IndexTab {
			get { return indexTab; }
			set { 
				indexTab = value;
                if (indexTab == 2) {
                    OnPropertyChanged("NumComprasCliente");
                    OnPropertyChanged("TotalGastadoCliente");
                    OnPropertyChanged("NumRepCliente");
                    OnPropertyChanged("MediaGastadoCliente");
                    OnPropertyChanged("RepuestosVendidos");
                    OnPropertyChanged("NumVentasRepuesto");
                    OnPropertyChanged("TotalRecaudadoRepuesto");
                    OnPropertyChanged("MediaRecaudadoRepuesto"); 
                }
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

        public bool IsComboClientesOk {
            get { return indexComboClientes >= 0; }
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
					venta.Fecha = DateTime.Now;
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
                    OnPropertyChanged("IsComboClientesOk");
                    OnPropertyChanged("CombosOk");
                    OnPropertyChanged("IsCantidadOk");
                    OnPropertyChanged("Ventas");
                    OnPropertyChanged("IndexTab");
				}));
			}
		}
    }
}
