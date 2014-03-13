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

		private int index = -1;
		public int IndexSelected {
			get { return index; }
			set { 
				index = value; 
				OnPropertyChanged("IsSelected"); 
			}
		}

		public bool IsSelected {
			get { return index > -1; }
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
						var vm = new RepuestoVM {
							Model = new Repuesto()
						};

						var view = new DialogoRepuestos {
							DataContext = vm,
							Title = "Agregar repuesto"
						};

						if (view.ShowDialog() == true) {
							facade.AgregarRepuesto(vm.Model);
							OnPropertyChanged("Repuestos");
						}
					}
					else {
						var vm = new ProveedorVM {
							Model = new Proveedor()
						};

						var view = new DialogoProveedores {
							DataContext = vm,
							Title = "Agregar proveedor"
						};

						if (view.ShowDialog() == true) {
							facade.AgregarProveedor(vm.Model);
							OnPropertyChanged("Proveedores");
						}
					}
				}));
			}
		}

		ICommand modificar;
		public ICommand Modificar {
			get {
				return modificar ?? (modificar = new RelayCommand<RepuestoVM>((repuesto) => {
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
						Title = "Modificar repuesto"
					};

					if (view.ShowDialog() == true) {
						facade.ModificarRepuesto(vm.Model);
						OnPropertyChanged("Repuestos");
					}
				}));
			}
		}

		ICommand eliminar;
		public ICommand Eliminar {
			get {
				return eliminar ?? (eliminar = new RelayCommand<RepuestoVM>((repuesto) => {
					MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
					if (MessageBox.Show("¿Seguro que desea eliminar?", "Eliminar", btnMessageBox) == MessageBoxResult.Yes) {
						facade.EliminarRepuesto(repuesto.Model);
						OnPropertyChanged("Repuestos");
					}
				}));
			}
		}
	}
}
