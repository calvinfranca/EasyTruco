using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class Carta
    {
        #region PROPRIEDADES
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
        public Int32 Largura { get; set; }
        public Int32 Altura { get; set; }
        public Int32 Valor { get; set; }
        public Int32 Naipe { get; set; }
        public bool Manilha { get; set; }
        public bool Tornou { get; set; }
        public Int32 Image { get; set; }
        public bool Clicada { get; set; }
        public bool Descoberta { get; set; }
        public int offsetX = 200;
        public int offsetY = 50;
        #endregion

        #region CONSTRUTORES
        public Carta(Int32 x1, Int32 y1, Int32 Valor, Int32 Naipe, Int32 Img)
        {
            this.X = x1; this.Y = y1;
            this.Largura = 78; this.Altura = 100;
            this.Valor = Valor;
            this.Image = Img;
            this.Clicada = false;
            this.Manilha = false;
            this.Tornou = false;
            this.Descoberta = false;
        }

     //public Carta(Int32 x1, Int32 y1,
     //             Int32 Larg, Int32 Alt, Int32 Valor, Int32 Naipe, Int32 Img)
     //{
     //    this.X = x1;
     //    this.Y = y1;
     //
     //    this.Largura = Larg;
     //    this.Altura = Alt;
     //    this.Valor = Valor;
     //    this.Naipe = Naipe;
     //    this.Image = Img;
     //    this.Clicada = false;
     //    this.Manilha = false;
     //    this.Tornou = false;
     //    this.Descoberta = false;
     //}
        #endregion


        #region MÉTODOS
        public void VerificarClique(Int32 x1, Int32 y1)
        {
            
                if (x1 > (X * Largura) + offsetX && x1 < (X * Largura + Largura) + offsetX &&
                    y1 > (Y * Altura) + offsetY && y1 < (Y * Altura + Altura) + offsetY)
                {
                    Clicada = !Clicada;
                }
            
        }

        internal bool Igual(Carta carta2)
        {
            bool ok = false;

            if (this.Valor == carta2.Valor) ok = true;

            return ok;
        }

        internal bool Euvenci(Carta crt)
        {
            bool ok = false;
            if (this.Valor == 99 && crt.Valor ==99)
            {
                if (this.Naipe > crt.Naipe) ok = true;
            }
            if (this.Valor > crt.Valor) ok = true;
            return ok;
        }
        #endregion
    }
}
