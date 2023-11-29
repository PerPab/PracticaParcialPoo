using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practica
{
    public class Colectivo 
    {
        public List<PasajeroComun> listaPasajeroComun;
        public List<PasajeroAlumno> listaPasajeroAlumno;
        public List<RegistroPasajero> listaPasajeros;
        public List<int> total;



        public int recaudacion = 0;

        public int[] tarifa = { 50, 75, 100 };

        public Colectivo()
        { 
            this.listaPasajeroComun = new List<PasajeroComun>();
            this.listaPasajeroAlumno = new List<PasajeroAlumno>();
            this.listaPasajeros = new List<RegistroPasajero>();
            this.total = new List<int>();
         
        }

        public void cobrar()
        {
            foreach (PasajeroComun pasajero in listaPasajeroComun)
            {
                
                
                    Random random = new Random();
                    int costoRandom = random.Next(1, 3);
                    Thread.Sleep(1000);
                    int costoBoleto = tarifa[costoRandom];

                if((pasajero.tarjeta - costoBoleto) > -200)
                {
                    pasajero.tarjeta -= costoBoleto;
                    recaudacion += costoBoleto;
                    total.Add(costoBoleto);


                    listaPasajeros.Add(new RegistroPasajero
                    {
                        tipo = "C",
                        monto = costoBoleto
                    });
                
                    Console.WriteLine($"Cobro realizado ${costoBoleto} saldo siponible ${pasajero.tarjeta}");
                }
                else
                {
                    Console.WriteLine("no hay saldo disponible");
                }
                    
                
                

            }

            foreach (PasajeroAlumno pasajero in listaPasajeroAlumno)
            {
                if ((pasajero.tarjeta - 10) > -200)
                {
                    pasajero.tarjeta -= 10;
                    recaudacion += 10;
                    total.Add(10);

                    listaPasajeros.Add(new RegistroPasajero
                    {
                        tipo = "A",
                        monto = 10
                    });


                    Console.WriteLine($"Cobro realizado ${10} saldo siponible ${pasajero.tarjeta}");
                }
                else
                {
                    Console.WriteLine("no hay saldo disponible");

                }


            }
        }

        public void ConsultarRecaudacion()
        {
            Console.WriteLine("La recaudacion es de "+recaudacion);
        }

        public void ListadoOrdenado()
        {
            Console.WriteLine("Listado ordenado:");
            var ordenada = total.OrderByDescending(x=>x).ToList();
            foreach (int num in ordenada)
            {
                Console.WriteLine(num);

            }
            Console.WriteLine(recaudacion);
        }

    }
}
