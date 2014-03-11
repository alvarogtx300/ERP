using Repuestos.Logic;
using Clientes.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inicio {
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
		}

		private void clientes(object sender, RoutedEventArgs e) {
			var facade = new FacadeClientes();

			var vm = new Clientes.ViewModels.PrincipalVM(facade.ListarClientes(), facade.ListarVehiculos());
			var view = new Clientes.Views.Principal {
				DataContext=vm
			};
			view.Show();
		}

		private void repuestos(object sender, RoutedEventArgs e) {
			var facade = new FacadeRepuestos();

			var vm = new Repuestos.ViewModels.PrincipalVM(facade.ListarProveedores(), facade.ListarRepuestos());
			var view =new Repuestos.Views.Principal{
				DataContext=vm
			};
			view.Show();
		}
	}
}
