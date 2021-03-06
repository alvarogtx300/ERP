﻿using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Models {
    public class Cliente : ObservableObject {
        private string nombre, apellidos, dni, direccion;
        private long telefono;

        public string Nombre {
            get { return nombre; }
            set { SetProperty(ref nombre, value, () => Nombre); }
        }

        public string Apellidos {
            get { return apellidos; }
            set { SetProperty(ref apellidos, value, () => Apellidos); }
        }

        public string Dni {
            get { return dni; }
            set { SetProperty(ref dni, value, () => Dni); }
        }

        public string Direccion {
            get { return direccion; }
            set { SetProperty(ref direccion, value, () => Direccion); }
        }

        public long Telefono {
            get { return telefono; }
            set { SetProperty(ref telefono, value, () => Telefono); }
        }

        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }

            return this.dni==((Cliente)obj).dni;
        }
    }
}
