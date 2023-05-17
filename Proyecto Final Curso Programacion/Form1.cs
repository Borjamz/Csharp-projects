using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Proyecto_Final_Curso_Programacion
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "Seguro que desea salir?",
                "Atención",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btFutDrafts_Click(object sender, EventArgs e)
        {
            this.Hide();
            PlantillasGuardadas plantillasGuardadas = new PlantillasGuardadas();
            plantillasGuardadas.Show();
        }

        private void btNuevoFD_Click(object sender, EventArgs e)
        {
            this.Hide();
            Juego juegoScene = new Juego();
            juegoScene.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btAyuda_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "El simulador de draft es una aplicación " +
                "para crear equipos de FUT (FIFA Ultimate Team) " +
                "donde lo único que tienes que hacer es hacer " +
                "clic en las diferentes posiciones del campo y " +
                "elegir entre uno de los jugadores disponibles.",
                "Ayuda",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void Inicio_Resize(object sender, EventArgs e)
        {
        }
    }
}