using Clientes.ViewModels;
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

namespace Clientes.Views {
    /// <summary>
    /// Lógica de interacción para DetalleCliente.xaml
    /// </summary>
    public partial class DetalleCliente : Window {
        public DetalleCliente() {
            InitializeComponent();
			Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

		void MainWindow_Loaded(object sender, RoutedEventArgs e) {
			if (((ClienteVM)DataContext).Dni != null)
				txDni.IsEnabled = false;
		}

		private void Guardar(object sender, RoutedEventArgs e) {
			DialogResult = true;
			Close(); 
		}

		private void Cancelar(object sender, RoutedEventArgs e) {
			DialogResult = false;
			Close(); 
		}
    }
}
