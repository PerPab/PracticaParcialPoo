using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica
{
    public class Program
    {
        static void Main(string[] args)
        {
            Colectivo colectivo = new Colectivo();
            Conexion conexion = new Conexion("LAPTOP-URAUHA04\\SQLTEST", "sa","123456", "Prueba"); //Conexion SQL
            //conexion.CrearTabla();

            PasajeroAlumno alumno1= new PasajeroAlumno();
            PasajeroAlumno alumno2= new PasajeroAlumno();
            PasajeroAlumno alumno3= new PasajeroAlumno();
            PasajeroAlumno alumno4= new PasajeroAlumno();
            PasajeroAlumno alumno5= new PasajeroAlumno();

            PasajeroComun pasajero1 = new PasajeroComun();
            PasajeroComun pasajero2 = new PasajeroComun();
            PasajeroComun pasajero3 = new PasajeroComun();
            PasajeroComun pasajero4 = new PasajeroComun();
            PasajeroComun pasajero5 = new PasajeroComun();

            colectivo.listaPasajeroAlumno.Add(alumno1);
            colectivo.listaPasajeroAlumno.Add(alumno2);
            colectivo.listaPasajeroAlumno.Add(alumno3);
            colectivo.listaPasajeroAlumno.Add(alumno4);
            colectivo.listaPasajeroAlumno.Add(alumno5);

            colectivo.listaPasajeroComun.Add(pasajero1);
            colectivo.listaPasajeroComun.Add(pasajero2);
            colectivo.listaPasajeroComun.Add(pasajero3);
            colectivo.listaPasajeroComun.Add(pasajero4);
            colectivo.listaPasajeroComun.Add(pasajero5);

            colectivo.cobrar(); //Cobra los boletos a las dos listas de pasajeros
            colectivo.ConsultarRecaudacion(); //Muestra lo recaudado hasta el momento
            colectivo.ListadoOrdenado(); //Muestra la lista de pagos

            foreach (RegistroPasajero pasajero in colectivo.listaPasajeros) //Inserta datos en la BD
            {
                conexion.InsertarCobros(pasajero.tipo, pasajero.monto);
            }

            Console.ReadKey();




        }
    }
}
