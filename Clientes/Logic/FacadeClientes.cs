﻿using Clientes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Logic {
    class FacadeClientes {
        IDAOClientes datos;

        public FacadeClientes() {
            datos = DatosClientes.Instance;
        }

        public ObservableCollection<Cliente> ListarClientes() {
            return datos.ListarClientes();
        }

        public void AgregarCliente(Cliente c) {
            datos.AgregarCliente(c);
        }

        public void EliminarCliente(Cliente c) {
            datos.EliminarCliente(c);
        }

        public void AgregarVehiculo(Vehiculo v) {
            datos.AgregarVehiculo(v);
        }

        public void EliminarVehiculo(Vehiculo v) {
            datos.EliminarVehiculo(v);
        }

        public ObservableCollection<Vehiculo> ListarVehiculos() {
            return datos.ListarVehiculos(); 
        }
    }
}
