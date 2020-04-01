using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class Baralho
    {
        public List<Carta> cartas;
        public List<Carta> cartasjogador;
        public List<int> auxiliar;
        public List<Carta> cartascpu;
        public List<Carta> cartastornadas;
        public List<Carta> cartasmesa;

        int Quantidade;

        public Baralho(int nCartas)
        {
            this.cartas = new List<Carta>();
            this.Quantidade = nCartas;



            int i = 0;


            for (int Valor = 0; Valor < 10; Valor++)
            {
                for (int Naipe = 0; Naipe < 4; Naipe++)
                {
                    Carta carta1 = new Carta(0, 0, Valor, Naipe, i);
                    cartas.Add(carta1);
                    i++;


                }

            }

            this.Embaralhar();

            //this.Forca();



        }
        public void Forca()
        {
            List<Carta> aux = new List<Carta>();
            List<Carta> aux1 = new List<Carta>();
            List<Carta> aux2 = new List<Carta>();
            this.cartasmesa = new List<Carta>();
            this.auxiliar = new List<int>();
                 auxiliar.Add(0);
                 auxiliar.Add(1);
                 auxiliar.Add(2);
            //cartasjogador
            aux.Add(cartas[0]);
            aux.Add(cartas[3]);
            aux.Add(cartas[8]);
            //cartascpu
            aux1.Add(cartas[10]);
            aux1.Add(cartas[1]);
            aux1.Add(cartas[11]);
            //durr
            aux2.Add(cartas[20]);




            cartasjogador = aux;
            cartascpu = aux1;
            cartastornadas = aux2;

           




            

            cartasjogador[0].Descoberta = true;
            cartasjogador[1].Descoberta = true;
            cartasjogador[2].Descoberta = true;
            cartastornadas[0].Descoberta = true;

            cartasjogador[0].X = 1;
            cartasjogador[1].X = 2;
            cartasjogador[2].X = 3;

            cartasjogador[0].Y = 3;
            cartasjogador[1].Y = 3;
            cartasjogador[2].Y = 3;

            cartascpu[0].X = 1;
            cartascpu[1].X = 2;
            cartascpu[2].X = 3;

            cartascpu[0].Y = 1;
            cartascpu[1].Y = 1;
            cartascpu[2].Y = 1;

            cartastornadas[0].X = 4;
            cartastornadas[0].Y = 2;

            cartasmesa.Add(cartasjogador[0]);
            cartasmesa.Add(cartasjogador[1]);
            cartasmesa.Add(cartasjogador[2]);
            cartasmesa.Add(cartascpu[0]);
            cartasmesa.Add(cartascpu[1]);
            cartasmesa.Add(cartascpu[2]);
            cartasmesa.Add(cartastornadas[0]);



        }

       public void Embaralhar()
       {
           this.auxiliar = new List<int>();
           auxiliar.Add(0);
           auxiliar.Add(1);
           auxiliar.Add(2);
           this.cartasmesa = new List<Carta>();
           Random rnd = new Random();
           List<Carta> aux = new List<Carta>();
           List<Carta> aux2 = new List<Carta>();
           List<Carta> aux3 = new List<Carta>();
           int x = 1;
           
           while (cartas.Count > 37)
           {
               int i = rnd.Next(0, cartas.Count);
               Carta c = cartas[i];
               c.X = x;
               c.Y = 3;
               c.Descoberta = true;
               aux.Add(c);
               cartasmesa.Add(c);
               cartas.RemoveAt(i);
               x++;
             
           }
           cartasjogador = aux;
           x = 1;
           while (cartas.Count > 34)
           {
               int i = rnd.Next(0, cartas.Count);
               Carta c = cartas[i];
               c.X = x;
               c.Y = 1;
               aux2.Add(c);
               cartasmesa.Add(c);
               cartas.RemoveAt(i);
               x++;
       
           }
           cartascpu = aux2;
           while (cartas.Count > 33)
           {
               int i = rnd.Next(0, cartas.Count);
               Carta c = cartas[i];
               c.Tornou = true;
               c.X = 4;
               c.Y = 2;
               c.Descoberta = true;
               aux3.Add(c);
               cartasmesa.Add(c);
               cartas.RemoveAt(i);
                          
           }
           cartastornadas = aux3;  
       }

    }
}
