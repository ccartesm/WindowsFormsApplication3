using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication3.Modelos
{
    public class Animal
    {
        private String tipo;
        private String diio;
        private DateTime fechaIngreso;
        private DateTime fechaNac;
        private String origen;
        private String genetica;
        private int peso;
        private String comentario;

        public Animal()
        {

        }

        public String Tipo
        {
            get {return tipo;}
            set {Tipo = value;}
        }

        public String Diio
        {
            get {return diio;}
            set {Diio = value;}
        }

        public DateTime FechaIngreso
        {
            get {return fechaIngreso;}
            set {FechaIngreso = value;}
        }

        public DateTime FechaNac
        {
            get {return fechaNac;}
            set {FechaNac = value;}
        }

        public String Origen
        {
            get {return origen;}
            set {Origen = value;}
        }

        public String Genetica
        {
            get {return genetica;}
            set {Genetica = value;}
        }

        public int Peso
        {
            get {return peso;}
            set {Peso = value;}
        }

        public String Comentario
        {
            get {return comentario;}
            set {Comentario = value;}
        }

        //public void leer()
        //{
        //    Animal ani = new Animal();
        //    ani.diio = Diio;
        //    conexion.leer(ani);
        //    _Nombre = ani.Nombre;
        //    _Direccion = ani.Direccion;
        //    _MensajeBD = ani.MensajeBD;
        //    _EstadoBD = ani.EstadoBD;
        //    _EstadoOP = ani.EstadoOP;

        //}

        }
}
