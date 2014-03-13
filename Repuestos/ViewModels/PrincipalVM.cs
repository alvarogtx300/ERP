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

		ICommand agregar;
		public ICommand Agregar {
			get {
				return agregar ?? (agregar = new RelayCommand(() => {
					var vm = new RepuestoVM {
						Model = new Repuesto()
					};

					var view = new DialogoRepuestos {
						DataContext = vm
					};

					if (view.ShowDialog() == true) {
						facade.AgregarRepuesto(vm.Model);
						OnPropertyChanged("Repuestos");
					}
				}));
			}
		}
	}
}
