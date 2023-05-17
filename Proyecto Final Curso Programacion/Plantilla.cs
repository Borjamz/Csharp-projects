using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Proyecto_Final_Curso_Programacion
{
    internal class Plantilla
    {
        private Dictionary<string, Jugador> jugadores;
        private int quimica;
        private int valoracion;
        private string nombre;

        public Dictionary<string, Jugador> Jugadores { get => jugadores; set => jugadores = value; }
        public int Quimica { get => quimica; set => quimica = value; }
        public int Valoracion { get => valoracion; set => valoracion = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public Plantilla()
        {
            this.jugadores = new Dictionary<string, Jugador>();
            this.quimica = 0;
            this.valoracion = 0;
            this.nombre = "Undefined";
        }

        

        public void ActualizarValoracion()
        {
            int media = 0;
            
            if (jugadores.Count > 0)
            {
                foreach (KeyValuePair<string, Jugador> pair in jugadores)
                {
                    media += pair.Value.Valoracion;
                }

                media /= 11;

                valoracion = media;
            }   
        }
        public void ActualizarQuimica()
        {
            int quimicaTotal = 0, quimicaJugador = 0;
            foreach (KeyValuePair<string, Jugador> pair in jugadores)
            {
                int mismoPais = 0, mismoClub = 0;
                quimicaJugador = 0;

                for (int i = 0; i < jugadores.Count; i++)
                {
                    if (pair.Value != jugadores.ElementAt(i).Value)
                    {
                        if (pair.Value.Pais == jugadores.ElementAt(i).Value.Pais ||
                            pair.Value.Club == "all" ||
                            jugadores.ElementAt(i).Value.Club == "all")
                        {
                            mismoPais++;
                        }
                        if (pair.Value.Club == jugadores.ElementAt(i).Value.Club)
                        {
                            mismoClub++;
                        }
                    }
                }

                quimicaJugador = mismoPais / 2 + mismoClub;

                if (quimicaJugador > 3)
                {
                    quimicaJugador = 3;
                }
                
                quimicaTotal += quimicaJugador;
            }

            quimica = quimicaTotal;
        }
        public void AddJugador(Jugador jugador, string posicion)
        {
            jugadores.Add(posicion, jugador);
        }
        public int NumeroJugadores()
        {
            return jugadores.Count;
        }
        public string EstrellasPlantilla()
        {
            string estrellasImgRuta = "";

            if (valoracion < 85)
            {
                estrellasImgRuta = "estrellas/4estrellas.png";
            }
            else if (valoracion < 87)
            {
                estrellasImgRuta = "estrellas/4.5estrellas.png";
            }
            else
            {
                estrellasImgRuta = "estrellas/5estrellas.png";
            }

            return estrellasImgRuta;
        }
    }
}
