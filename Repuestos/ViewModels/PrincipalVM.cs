using Framework;
using Repuestos.Logic;
using Repuestos.Models;
using Repuestos.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Repuestos.ViewModels {
	public class PrincipalVM : ViewModelBase{
		private ObservableCollection<Proveedor> proveedores;
		private ObservableCollection<Repuesto> repuestos;
		private FacadeRepuestos facade;

		public PrincipalVM(ObservableCollection<Proveedor> p, ObservableCollection<Repuesto> r) {
			proveedores = p;
			repuestos = r;
			facade = new FacadeRepuestos();
		}
		
		public IEnumerable<ProveedorVM> Proveedores{
			get {
				return proveedores.Select(proveedor =>	new ProveedorVM { Model = proveedor });
			}
		}

		public IEnumerable<RepuestoVM> Repuestos {
			get {
				return repuestos.Select(repuesto => new RepuestoVM { Model = repuesto });
			}
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
				objetoSeleccionado = null;
				OnPropertyChanged("ObjetoSeleccionado");
				OnPropertyChanged("IsSelected");
			}
		}

		ICommand agregar;
		public ICommand Agregar {
			get {
				return agregar ?? (agregar = new RelayCommand(() => {
					if (indexTab == 0) {
						var vm = new RepuestoVM {
							Model = new Repuesto()
						};

						DialogoRepuestos view;
						bool duplicado = true;
						while (duplicado) {
							vm.Model.Codigo = 0;
							view = new DialogoRepuestos {
								DataContext = vm,
								Title = "Agregar Repuesto"
							};
							if (view.ShowDialog() == true) {
								if (facade.AgregarRepuesto(vm.Model)) {
									duplicado = false;
									OnPropertyChanged("Repuestos");
								}
								else
									MessageBox.Show("Error, código de repuesto duplicado", "Error");
							}
							else
								duplicado = false;
						}
					}
					else {
						var vm = new ProveedorVM {
							Model = new Proveedor()
						};

						DialogoProveedores view;
						bool duplicado = true;
						while (duplicado) {
							vm.Model.Cif = null;
							view = new DialogoProveedores {
								DataContext = vm,
								Title = "Agregar Proveedor"
							};
							if (view.ShowDialog() == true) {
								if (facade.AgregarProveedor(vm.Model)) {
									duplicado = false;
									OnPropertyChanged("Proveedores");
								}
								else
									MessageBox.Show("Error, CIF duplicado", "Error");
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
					if (objetoSeleccionado is RepuestoVM) {
						RepuestoVM repuesto = (RepuestoVM)objetoSeleccionado;
						var vm = new RepuestoVM {
							Model = new Repuesto{
								Descripcion=repuesto.Model.Descripcion
							},
							Nombre=repuesto.Nombre,
							Codigo=repuesto.Codigo,
							Precio=repuesto.Precio,
							NumArticulos=repuesto.NumArticulos
						};

						var view = new DialogoRepuestos {
							DataContext = vm,
							Title = "Modificar Repuesto"						
						};

						if (view.ShowDialog() == true) {
							facade.ModificarRepuesto(vm.Model);
							OnPropertyChanged("Repuestos");
						}
					}
					else if (objetoSeleccionado is ProveedorVM) {
						ProveedorVM proveedor = (ProveedorVM)objetoSeleccionado;
						var vm = new ProveedorVM {
							Model = new Proveedor {
								Descripcion = proveedor.Model.Descripcion
							},
							Nombre = proveedor.Nombre,
							Cif=proveedor.Cif
						};

						var view = new DialogoProveedores {
							DataContext = vm,
							Title = "Modificar Proveedor"
						};

						if (view.ShowDialog() == true) {
							facade.ModificarProveedor(vm.Model);
							OnPropertyChanged("Proveedores");
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
						if (objetoSeleccionado is RepuestoVM) {
							facade.EliminarRepuesto(((RepuestoVM)objetoSeleccionado).Model);
							OnPropertyChanged("Repuestos");
						}
						else if (objetoSeleccionado is ProveedorVM) {
							facade.EliminarProveedor(((ProveedorVM)objetoSeleccionado).Model);
							OnPropertyChanged("Proveedores");
						}
						
					}
				}));
			}
		}
	}
}
