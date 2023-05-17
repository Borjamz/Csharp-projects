using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_Curso_Programacion
{
    public partial class Juego : Form
    {
        private List<Jugador> todosLosJugadores;
        private Plantilla plantilla;
        private string ultimaPosicionPulsada;
        private bool enEleccion;

        private const string FICHERO_PLANTILLAS = "plantillasGuardadas.json";
        private const string FICHERO_JUGADORES = "ficheroJugadores.txt";

        public Juego()
        {
            InitializeComponent();

            plResumen.Hide();
            plIntrNombre.Hide();
            btFinalizarFD.Hide();

            todosLosJugadores = new List<Jugador>();
            plantilla = new Plantilla();

            CargarJugadores();

            enEleccion = true;

            RandomPlayerPick(todosLosJugadores);
        }
        public Juego(string nombrePlantilla)
        {
            InitializeComponent();

            plResumen.Hide();
            panelEleccion.Hide();
            plIntrNombre.Hide();
            btFinalizarFD.Hide();

            Plantilla plantilla = new Plantilla();

            foreach (Plantilla p in BajarPlantillas())
            {
                if (p.Nombre == nombrePlantilla)
                {
                    plantilla = p;
                }
            }

            lbValoracion.Text = "VALORACIÓN: " + plantilla.Valoracion;
            lbQuimica.Text = plantilla.Quimica + "/33";

            ColocarPlantilla(plantilla);
        }

        private void ColocarPlantilla(Plantilla plantilla)
        {
            foreach (KeyValuePair<string, Jugador> pair in plantilla.Jugadores)
            {
                switch (pair.Key)
                {
                    case "ST1":
                        ST1.ImageLocation = pair.Value.RutaImgCarta;
                        break;
                    case "ST2":
                        ST2.ImageLocation = pair.Value.RutaImgCarta;
                        break;
                    case "LM":
                        LM.ImageLocation = pair.Value.RutaImgCarta;
                        break;
                    case "CM1":
                        CM1.ImageLocation = pair.Value.RutaImgCarta;
                        break;
                    case "CM2":
                        CM2.ImageLocation = pair.Value.RutaImgCarta;
                        break;
                    case "RM":
                        RM.ImageLocation = pair.Value.RutaImgCarta;
                        break;
                    case "LB":
                        LB.ImageLocation = pair.Value.RutaImgCarta;
                        break;
                    case "CB1":
                        CB1.ImageLocation = pair.Value.RutaImgCarta;
                        break;
                    case "CB2":
                        CB2.ImageLocation = pair.Value.RutaImgCarta;
                        break;
                    case "RB":
                        RB.ImageLocation = pair.Value.RutaImgCarta;
                        break;
                    case "GK":
                        GK.ImageLocation = pair.Value.RutaImgCarta;
                        break;
                }
            }
        }

        private void MostrarEleccionJugador()
        {
            LimpiarJugadoresPanel();
            panelEleccion.Show();
        }

        private void SubirPlantillas(List<Plantilla> plantillasGuardadas)
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(plantillasGuardadas, opciones);

            File.WriteAllText(FICHERO_PLANTILLAS, jsonString);
        }
        private List<Plantilla> BajarPlantillas()
        {
            List<Plantilla> plantillasGuardadas = new List<Plantilla>();

            string jsonString = "";
            if (File.Exists(FICHERO_PLANTILLAS))
            {
                jsonString = File.ReadAllText(FICHERO_PLANTILLAS);

                plantillasGuardadas = JsonSerializer.Deserialize<List<Plantilla>>(jsonString);
            }

            return plantillasGuardadas;
        }
        private void CargarJugadores()
        {
            string[] lineas = new string[0];

            if (File.Exists(FICHERO_JUGADORES))
            {
                lineas = File.ReadAllLines(FICHERO_JUGADORES);
            }

            for (int i = 0; i < lineas.Length; i++)
            {
                string[] split = lineas[i].Split(';');

                int valoracion = Convert.ToInt32(split[0]);
                Jugador jugador = new Jugador(valoracion, split[1], "futCards/" + split[2], split[3], split[4]);

                todosLosJugadores.Add(jugador);
            }
        }

        private void LimpiarJugadoresPanel()
        {
            Jugador1.ImageLocation = "";
            Jugador2.ImageLocation = "";
            Jugador3.ImageLocation = "";
            Jugador4.ImageLocation = "";
            Jugador5.ImageLocation = "";
        }
        private void RandomPlayerPick(List<Jugador> jugadores)
        {
            Random rd = new Random();
            int[] indices = new int[5];
            for (int i = 0; i < indices.Length; i++)
            {
                indices[i] = -1;
            }

            for (int i = 0; i < 5; i++)
            {
                int numRandom = 0;
                do
                {
                    numRandom = rd.Next(0, jugadores.Count);

                } while (indices.Contains(numRandom));

                indices[i] = numRandom;

                switch (i)
                {
                    case 0:
                        Jugador1.ImageLocation = jugadores[indices[i]].RutaImgCarta;
                        break;
                    case 1:
                        Jugador2.ImageLocation = jugadores[indices[i]].RutaImgCarta;
                        break;
                    case 2:
                        Jugador3.ImageLocation = jugadores[indices[i]].RutaImgCarta;
                        break;
                    case 3:
                        Jugador4.ImageLocation = jugadores[indices[i]].RutaImgCarta;
                        break;
                    case 4:
                        Jugador5.ImageLocation = jugadores[indices[i]].RutaImgCarta;
                        break;
                }
            }
        }
        private void AnadirJugador(Jugador jugador, string posicion)
        {
            todosLosJugadores.Remove(jugador);

            switch (posicion)
            {
                case "ST":
                case "CF":
                case "all":
                case "ST1":
                    ST1.ImageLocation = jugador.RutaImgCarta;
                    posicion = "ST1";
                    break;
                case "ST2":
                    ST2.ImageLocation = jugador.RutaImgCarta;
                    posicion = "ST2";
                    break;
                case "LW":
                case "LWB":
                case "LM":
                    LM.ImageLocation = jugador.RutaImgCarta;
                    posicion = "LM";
                    break;
                case "CM":
                case "CAM":
                case "CDM":
                case "CM1":
                    CM1.ImageLocation = jugador.RutaImgCarta;
                    posicion = "CM1";
                    break;
                case "CM2":
                    CM2.ImageLocation = jugador.RutaImgCarta;
                    posicion = "CM2";
                    break;
                case "RW":
                case "RWB":
                case "RM":
                    RM.ImageLocation = jugador.RutaImgCarta;
                    posicion = "RM";
                    break;
                case "LB":
                    LB.ImageLocation = jugador.RutaImgCarta;
                    posicion = "LB";
                    break;
                case "RB":
                    RB.ImageLocation = jugador.RutaImgCarta;
                    posicion = "RB";
                    break;
                case "CB":
                case "CB1":
                    CB1.ImageLocation = jugador.RutaImgCarta;
                    posicion = "CB1";
                    break;
                case "CB2":
                    CB2.ImageLocation = jugador.RutaImgCarta;
                    posicion = "CB2";
                    break;
                case "GK":
                    GK.ImageLocation = jugador.RutaImgCarta;
                    posicion = "GK";
                    break;
            }

            plantilla.AddJugador(jugador, posicion);
        }

        private void Jugador_Click(string rutaImgCarta)
        {
            panelEleccion.Hide();

            bool encontrado = false;
            Jugador jugador = new Jugador();
            for (int i = 0; i < todosLosJugadores.Count && !encontrado; i++)
            {
                if (todosLosJugadores[i].RutaImgCarta == rutaImgCarta)
                {
                    encontrado = true;
                    jugador = todosLosJugadores[i];
                }
            }

            if (plantilla.NumeroJugadores() == 0)
            {
                AnadirJugador(jugador, jugador.Posicion);
            }
            else
            {
                AnadirJugador(jugador, ultimaPosicionPulsada);
            }

            plantilla.ActualizarValoracion();
            plantilla.ActualizarQuimica();
            lbValoracion.Text = "VALORACIÓN: " + plantilla.Valoracion;
            lbQuimica.Text = plantilla.Quimica + "/33";

            if (plantilla.NumeroJugadores() == 11)
            {
                btFinalizarFD.Show();
            }
            else
            {
                enEleccion = false;
            }
        }
        private void Posicion_Click(List<Jugador> jugadores)
        {
            enEleccion = true;

            MostrarEleccionJugador();
            RandomPlayerPick(jugadores);
        }

        private void VolverAInicio()
        {
            this.Hide();
            Inicio inicio = new Inicio();
            inicio.Show();
        }
        private void VolverAPlantillas()
        {
            this.Hide();
            PlantillasGuardadas plantillasGuardadas = new PlantillasGuardadas();
            plantillasGuardadas.Show();
        }

        private void GuardarPlantilla(List<Plantilla> plantillasGuardadas)
        {
            plantillasGuardadas.Add(plantilla);

            SubirPlantillas(plantillasGuardadas);

            MessageBox.Show("Plantilla guardada con éxito", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

            VolverAInicio();
        }

        private bool NombreNoDisp(List<Plantilla> plantillasGuardadas)
        {
            bool nombreNoDisp = false;
            int number = 0;

            if (txtIntrNombre.Text == "" ||
                txtIntrNombre.Text.Length >= 11 &&
                txtIntrNombre.Text.Substring(0, 10) == "Plantilla " &&
                Int32.TryParse(txtIntrNombre.Text.Substring(10), out number))
            {
                nombreNoDisp = true;
            }

            for (int i = 0; i < plantillasGuardadas.Count && !nombreNoDisp; i++)
            {
                if (plantillasGuardadas[i].Nombre == txtIntrNombre.Text)
                {
                    nombreNoDisp = true;
                }
            }

            return nombreNoDisp;
        }
        private void GenerarNombre(List<Plantilla> plantillasGuardadas)
        {
            int number, maxNumber = 0;

            foreach (Plantilla plantilla in plantillasGuardadas)
            {
                if (plantilla.Nombre.Length >= 11 &&
                    plantilla.Nombre.Substring(0, 10) == "Plantilla ")
                {
                    if (Int32.TryParse(plantilla.Nombre.Substring(10), out number) &&
                        number > maxNumber)
                    {
                        maxNumber = number;
                    }
                }
            }

            plantilla.Nombre = "Plantilla " + (maxNumber + 1);
        }

        private List<Jugador> Delanteros()
        {
            return todosLosJugadores
                .Where(jugador => jugador.Posicion == "ST" || jugador.Posicion == "CF")
                .ToList();
        }
        private List<Jugador> ExtremosIzquierdos()
        {
            return todosLosJugadores
                .Where(jugador => jugador.Posicion == "LM" ||
                                  jugador.Posicion == "LW" ||
                                  jugador.Posicion == "LWB")
                .ToList();
        }
        private List<Jugador> ExtremosDerechos()
        {
            return todosLosJugadores
                .Where(jugador => jugador.Posicion == "RM" ||
                                  jugador.Posicion == "RW" ||
                                  jugador.Posicion == "RWB")
                .ToList();
        }
        private List<Jugador> Centrocampistas()
        {
            return todosLosJugadores
                .Where(jugador => jugador.Posicion == "CM" ||
                                  jugador.Posicion == "CAM" ||
                                  jugador.Posicion == "CDM")
                .ToList();
        }
        private List<Jugador> LateralesIzquierdos()
        {
            return todosLosJugadores
                .Where(jugador => jugador.Posicion == "LB")
                .ToList();
        }
        private List<Jugador> LateralesDerechos()
        {
            return todosLosJugadores
                .Where(jugador => jugador.Posicion == "RB")
                .ToList();
        }
        private List<Jugador> Centrales()
        {
            return todosLosJugadores
                .Where(jugador => jugador.Posicion == "CB")
                .ToList();
        }
        private List<Jugador> Porteros()
        {
            return todosLosJugadores
                .Where(jugador => jugador.Posicion == "GK")
                .ToList();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Jugador_Click(Jugador1.ImageLocation);
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (CM2.ImageLocation == "" && !enEleccion)
            {
                ultimaPosicionPulsada = "CM2";
                Posicion_Click(Centrocampistas());
            }
        }
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            if (RB.ImageLocation == "" && !enEleccion)
            {
                ultimaPosicionPulsada = "RB";
                Posicion_Click(LateralesDerechos());
            }
        }

        private void ST1_Click(object sender, EventArgs e)
        {
            if (ST1.ImageLocation == "" && !enEleccion)
            {
                ultimaPosicionPulsada = "ST1";
                Posicion_Click(Delanteros());
            }
        }
        private void ST2_Click(object sender, EventArgs e)
        {
            if (ST2.ImageLocation == "" && !enEleccion)
            {
                ultimaPosicionPulsada = "ST2";
                Posicion_Click(Delanteros());
            }
        }
        private void LM_Click(object sender, EventArgs e)
        {
            if (LM.ImageLocation == "" && !enEleccion)
            {
                ultimaPosicionPulsada = "LM";
                Posicion_Click(ExtremosIzquierdos());
            }
        }
        private void CM1_Click(object sender, EventArgs e)
        {
            if (CM1.ImageLocation == "" && !enEleccion)
            {
                ultimaPosicionPulsada = "CM1";
                Posicion_Click(Centrocampistas());
            }
        }
        private void RM_Click(object sender, EventArgs e)
        {
            if (RM.ImageLocation == "" && !enEleccion)
            {
                ultimaPosicionPulsada = "RM";
                Posicion_Click(ExtremosDerechos());
            }
        }
        private void LB_Click(object sender, EventArgs e)
        {
            if (LB.ImageLocation == "" && !enEleccion)
            {
                ultimaPosicionPulsada = "LB";
                Posicion_Click(LateralesIzquierdos());
            }
        }
        private void CB1_Click(object sender, EventArgs e)
        {
            if (CB1.ImageLocation == "" && !enEleccion)
            {
                ultimaPosicionPulsada = "CB1";
                Posicion_Click(Centrales());
            }
        }
        private void CB2_Click(object sender, EventArgs e)
        {
            if (CB2.ImageLocation == "" && !enEleccion)
            {
                ultimaPosicionPulsada = "CB2";
                Posicion_Click(Centrales());
            }
        }
        private void GK_Click(object sender, EventArgs e)
        {
            if (GK.ImageLocation == "" && !enEleccion)
            {
                ultimaPosicionPulsada = "GK";
                Posicion_Click(Porteros());
            }
        }

        private void Jugador2_Click(object sender, EventArgs e)
        {
            Jugador_Click(Jugador2.ImageLocation);
        }
        private void Jugador3_Click(object sender, EventArgs e)
        {
            Jugador_Click(Jugador3.ImageLocation);
        }
        private void Jugador4_Click(object sender, EventArgs e)
        {
            Jugador_Click(Jugador4.ImageLocation);
        }
        private void Jugador5_Click(object sender, EventArgs e)
        {
            Jugador_Click(Jugador5.ImageLocation);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btFinalizarFD_Click(object sender, EventArgs e)
        {
            lbValoracionResumen2.Text = plantilla.Valoracion.ToString();
            
            estrellasResumen.ImageLocation = plantilla.EstrellasPlantilla();
            
            lbQuimicaResumen2.Text = plantilla.Quimica.ToString();

            int quimMasVal = plantilla.Quimica + plantilla.Valoracion;
            lbQuimMasVal2.Text = quimMasVal.ToString();

            plResumen.Show();

            btSalir.Hide();
        }

        private void btVolverInicio_Click(object sender, EventArgs e)
        {
            VolverAInicio();
        }


        private void btGuardarPlantilla_Click(object sender, EventArgs e)
        {
            plResumen.Hide();

            plIntrNombre.Show();
        }
        private void btGuardar_Click(object sender, EventArgs e)
        {
            List<Plantilla> plantillasGuardadas = BajarPlantillas();
            

            if (NombreNoDisp(plantillasGuardadas))
            {
                GenerarNombre(plantillasGuardadas);
            }
            else
            {
                if (txtIntrNombre.Text.Length < 18)
                {
                    plantilla.Nombre = txtIntrNombre.Text;
                }
                else
                {
                    plantilla.Nombre = txtIntrNombre.Text.Substring(0, 17);
                }
            }

            plIntrNombre.Hide();

            GuardarPlantilla(plantillasGuardadas);
        }

        private void plResumen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            if (todosLosJugadores == null)
            {
                VolverAPlantillas();
            }
            else
            {
                VolverAInicio();
            }
        }

        private void Juego_Resize(object sender, EventArgs e)
        {
        }
    }
}
