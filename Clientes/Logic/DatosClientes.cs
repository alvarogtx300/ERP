using Clientes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Clientes.Logic {
    class DatosClientes : IDAOClientes {
        private static readonly Lazy<DatosClientes> instance = new Lazy<DatosClientes>(() => new DatosClientes());
        private ObservableCollection<Cliente> clientes;
        private ObservableCollection<Vehiculo> vehiculos;

        private DatosClientes() {
            clientes = new ObservableCollection<Cliente> {
				new Cliente {
					Dni = "111111111A",
                    Nombre = "Cristian", 
                    Apellidos = "Gonzalez Morante", 
                    Direccion = "C/Falsa 123", 
                    Telefono = 123456789
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}, 
                new Cliente {
					Dni = "22222222B",
                    Nombre = "Alvaro", 
                    Apellidos = "Manzanas", 
                    Direccion = "Av. Falsa 321", 
                    Telefono = 987654321
				}
			};

            vehiculos = new ObservableCollection<Vehiculo> {
                new Vehiculo {
                    Matricula = "56748-A", 
                    Modelo = "Focus", 
                    RelacionCliente = clientes[0]
                },
                new Vehiculo {
                    Matricula = "56748-B", 
                    Modelo = "Opel", 
                    RelacionCliente = clientes[1]
                }
            }; 
        }

        public static DatosClientes Instance {
            get {
                return instance.Value;
            }
        }

        public bool AgregarCliente(Cliente c) {
			if (clientes.Contains(c))
				return false;
            clientes.Add(c);
			return true;
        }

        public void EliminarCliente(Cliente c) {
            clientes.Remove(c);
        }

        public void ModificarCliente(Cliente c) {
            Cliente cliente = clientes[clientes.IndexOf(c)];
            cliente.Nombre = c.Nombre;
            cliente.Apellidos = c.Apellidos;
            cliente.Telefono = c.Telefono; 
        }

        public ObservableCollection<Cliente> ListarClientes() {
            return clientes;
        }

        public bool AgregarVehiculo(Vehiculo v) {
			if (vehiculos.Contains(v))
				return false;
			vehiculos.Add(v);
			return true;
        }

        public void ModificarVehiculo(Vehiculo v) {
            Vehiculo vehiculo = vehiculos[vehiculos.IndexOf(v)];
            vehiculo.Modelo = v.Modelo;
            vehiculo.RelacionCliente = v.RelacionCliente; 
        }

        public void EliminarVehiculo(Vehiculo v) {
            vehiculos.Remove(v);
        }

        public ObservableCollection<Vehiculo> ListarVehiculos() {
            return vehiculos;
        }
    }
}
