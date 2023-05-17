using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Proyecto_Final_Curso_Programacion
{
    internal class Jugador
    {
        private int valoracion;
        private string posicion;
        private string rutaImgCarta;
        private string pais;
        private string club;

        public Jugador(int valoracion, string posicion, string carta, string pais, string club)
        {
            this.valoracion = valoracion;
            this.posicion = posicion;
            this.rutaImgCarta = carta;
            this.pais = pais;
            this.club = club;
        }
        public Jugador() : this(0, "", "", "", "")
        {

        }

        public string Posicion { get => posicion; set => posicion = value; }
        public string Pais { get => pais; set => pais = value; }
        public string Club { get => club; set => club = value; }
        public int Valoracion { get => valoracion; set => valoracion = value; }
        public string RutaImgCarta { get => rutaImgCarta; set => rutaImgCarta = value; }

        public override bool Equals(object? obj)
        {
            bool value = false;

            if (obj is Jugador &&
                rutaImgCarta.Equals(((Jugador)obj).rutaImgCarta))
            {
                value = true;
            }
            return value;
        }
    }
}
