using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Proyecto_Final_Curso_Programacion
{
    public partial class PlantillasGuardadas : Form
    {
        private List<Plantilla> plantillasGuardadas;
        private int primeroAntPag;
        private int primeroSigPag;
        private const string FICHERO_PLANTILLAS = "plantillasGuardadas.json";

        public PlantillasGuardadas()
        {
            InitializeComponent();

            btAntPag.Hide();

            BajarPlantillas();

            EsconderPlantillas();

            if (plantillasGuardadas.Count < 6)
            {
                btSigPag.Hide();
            }

            primeroSigPag = 0;

            Mostrar5(primeroSigPag);

            primeroAntPag = -5;
            primeroSigPag = 5;
        }

        internal List<Plantilla> Plantillas { get => plantillasGuardadas; set => plantillasGuardadas = value; }

        private void BajarPlantillas()
        {
            string jsonString = "";
            if (File.Exists(FICHERO_PLANTILLAS))
            {
                jsonString = File.ReadAllText(FICHERO_PLANTILLAS);
                plantillasGuardadas = JsonSerializer.Deserialize<List<Plantilla>>(jsonString);
            }
        }
        private void SubirPlantillas()
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(plantillasGuardadas, opciones);

            File.WriteAllText(FICHERO_PLANTILLAS, jsonString);
        }

        private void EsconderPlantillas()
        {
            plantilla1.Hide();
            plantilla2.Hide();
            plantilla3.Hide();
            plantilla4.Hide();
            plantilla5.Hide();
        }
        private void Mostrar5(int primerIndice)
        {
            List<Plantilla> siguientesCinco = new List<Plantilla>();

            for (int i = primerIndice; i < primerIndice + 5 && i < plantillasGuardadas.Count; i++)
            {
                siguientesCinco.Add(plantillasGuardadas[i]);
            }

            EsconderPlantillas();

            for (int i = 0; i < siguientesCinco.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        plantilla1.Show();
                        lbNombre1.Text = siguientesCinco[i].Nombre;
                        lbNumQuim1.Text = siguientesCinco[i].Quimica.ToString();
                        lbNumVal1.Text = siguientesCinco[i].Valoracion.ToString();
                        estrellas1.ImageLocation = siguientesCinco[i].EstrellasPlantilla();
                        break;
                    case 1:
                        plantilla2.Show();
                        lbNombre2.Text = siguientesCinco[i].Nombre;
                        lbNumQuim2.Text = siguientesCinco[i].Quimica.ToString();
                        lbNumVal2.Text = siguientesCinco[i].Valoracion.ToString();
                        estrellas2.ImageLocation = siguientesCinco[i].EstrellasPlantilla();
                        break;
                    case 2:
                        plantilla3.Show();
                        lbNombre3.Text = siguientesCinco[i].Nombre;
                        lbNumQuim3.Text = siguientesCinco[i].Quimica.ToString();
                        lbNumVal3.Text = siguientesCinco[i].Valoracion.ToString();
                        estrellas3.ImageLocation = siguientesCinco[i].EstrellasPlantilla();
                        break;
                    case 3:
                        plantilla4.Show();
                        lbNombre4.Text = siguientesCinco[i].Nombre;
                        lbNumQuim4.Text = siguientesCinco[i].Quimica.ToString();
                        lbNumVal4.Text = siguientesCinco[i].Valoracion.ToString();
                        estrellas4.ImageLocation = siguientesCinco[i].EstrellasPlantilla();
                        break;
                    case 4:
                        plantilla5.Show();
                        lbNombre5.Text = siguientesCinco[i].Nombre;
                        lbNumQuim5.Text = siguientesCinco[i].Quimica.ToString();
                        lbNumVal5.Text = siguientesCinco[i].Valoracion.ToString();
                        estrellas5.ImageLocation = siguientesCinco[i].EstrellasPlantilla();
                        break;
                }
            }
        }

        private void Borrar_Click(string nombre)
        {
            bool encontrado = false;

            for (int i = 0; i < plantillasGuardadas.Count && !encontrado; i++)
            {
                if (plantillasGuardadas[i].Nombre == nombre)
                {
                    plantillasGuardadas.RemoveAt(i);
                }
            }

            if (primeroSigPag - 5 >= plantillasGuardadas.Count &&
                !(primeroAntPag < 0))
            {
                AntPag();

                if (primeroAntPag < 0)
                {
                    btAntPag.Hide();
                }
            }
            else if (!(primeroSigPag - 5 >= plantillasGuardadas.Count) &&
                       primeroSigPag >= plantillasGuardadas.Count)
            {
                RefrescarPag();

                if (btSigPag.Visible)
                {
                    btSigPag.Hide();
                }
            }
            else
            {
                RefrescarPag();
            }
        }
        private void PlantillaNombre_Click(string nombrePlantilla)
        {
            this.Hide();
            
            Juego juego = new Juego(nombrePlantilla);

            juego.Show();
        }

        private void RefrescarPag()
        {
            Mostrar5(primeroSigPag - 5);
        }
        private void SigPag()
        {
            Mostrar5(primeroSigPag);
            primeroSigPag += 5;
            primeroAntPag += 5;

            if (primeroSigPag >= plantillasGuardadas.Count)
            {
                btSigPag.Hide();
            }
        }
        private void AntPag()
        {
            Mostrar5(primeroAntPag);
            primeroSigPag -= 5;
            primeroAntPag -= 5;

            if (primeroAntPag < 0)
            {
                btAntPag.Hide();
            }
        }


        private void lbTitulo_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btSigPag_Click(object sender, EventArgs e)
        {
            SigPag();

            if (!btAntPag.Visible)
            {
                btAntPag.Show();
            }
        }
        private void btAntPag_Click(object sender, EventArgs e)
        {
            AntPag();

            if (!btSigPag.Visible)
            {
                btSigPag.Show();
            }
        }

        private void plantilla1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void plantilla2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void plantilla3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void plantilla4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void plantilla5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btSalir_Click(object sender, EventArgs e)
        {
            SubirPlantillas();
            this.Hide();
            Inicio inicio = new Inicio();
            inicio.Show();
        }

        private void btBorrar1_Click(object sender, EventArgs e)
        {
            Borrar_Click(lbNombre1.Text);
        }

        private void btBorrar2_Click(object sender, EventArgs e)
        {
            Borrar_Click(lbNombre2.Text);
        }

        private void btBorrar3_Click(object sender, EventArgs e)
        {
            Borrar_Click(lbNombre3.Text);
        }

        private void btBorrar4_Click(object sender, EventArgs e)
        {
            Borrar_Click(lbNombre4.Text);
        }

        private void btBorrar5_Click(object sender, EventArgs e)
        {
            Borrar_Click(lbNombre5.Text);
        }

        private void lbNombre1_Click(object sender, EventArgs e)
        {
            PlantillaNombre_Click(lbNombre1.Text);
        }

        private void lbNombre2_Click(object sender, EventArgs e)
        {
            PlantillaNombre_Click(lbNombre2.Text);
        }

        private void lbNombre3_Click(object sender, EventArgs e)
        {
            PlantillaNombre_Click(lbNombre3.Text);
        }

        private void lbNombre4_Click(object sender, EventArgs e)
        {
            PlantillaNombre_Click(lbNombre4.Text);
        }

        private void lbNombre5_Click(object sender, EventArgs e)
        {
            PlantillaNombre_Click(lbNombre5.Text);
        }

        private void PlantillasGuardadas_Resize(object sender, EventArgs e)
        {
        }
    }
}
