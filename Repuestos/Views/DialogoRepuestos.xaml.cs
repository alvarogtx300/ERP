using Repuestos.ViewModels;
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
using System.Windows.Shapes;

namespace Repuestos.Views {
	/// <summary>
	/// Lógica de interacción para Dialogo.xaml
	/// </summary>
	public partial class DialogoRepuestos : Window {
		public DialogoRepuestos() {
			InitializeComponent();
			Loaded += new RoutedEventHandler(MainWindow_Loaded);
		}

		void MainWindow_Loaded(object sender, RoutedEventArgs e) {
			if(((RepuestoVM)DataContext).Codigo!="")
				txCodigo.IsEnabled = false;
		}

		private void Guardar(object sender, RoutedEventArgs e) {
			DialogResult = true;
			Close();
		}
	}
}
