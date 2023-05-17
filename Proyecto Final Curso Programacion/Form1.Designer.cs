namespace Proyecto_Final_Curso_Programacion
{
    partial class Inicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.btNuevoFD = new System.Windows.Forms.Button();
            this.btFutDrafts = new System.Windows.Forms.Button();
            this.btAyuda = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btNuevoFD
            // 
            this.btNuevoFD.BackColor = System.Drawing.Color.CadetBlue;
            this.btNuevoFD.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btNuevoFD.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btNuevoFD.Location = new System.Drawing.Point(340, 105);
            this.btNuevoFD.Name = "btNuevoFD";
            this.btNuevoFD.Size = new System.Drawing.Size(167, 62);
            this.btNuevoFD.TabIndex = 0;
            this.btNuevoFD.Text = "Nuevo Fut Draft";
            this.btNuevoFD.UseVisualStyleBackColor = false;
            this.btNuevoFD.Click += new System.EventHandler(this.btNuevoFD_Click);
            // 
            // btFutDrafts
            // 
            this.btFutDrafts.BackColor = System.Drawing.Color.CadetBlue;
            this.btFutDrafts.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btFutDrafts.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btFutDrafts.Location = new System.Drawing.Point(340, 198);
            this.btFutDrafts.Name = "btFutDrafts";
            this.btFutDrafts.Size = new System.Drawing.Size(167, 62);
            this.btFutDrafts.TabIndex = 1;
            this.btFutDrafts.Text = "Plantillas Guardadas";
            this.btFutDrafts.UseVisualStyleBackColor = false;
            this.btFutDrafts.Click += new System.EventHandler(this.btFutDrafts_Click);
            // 
            // btAyuda
            // 
            this.btAyuda.BackColor = System.Drawing.Color.CadetBlue;
            this.btAyuda.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btAyuda.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btAyuda.Location = new System.Drawing.Point(340, 289);
            this.btAyuda.Name = "btAyuda";
            this.btAyuda.Size = new System.Drawing.Size(167, 62);
            this.btAyuda.TabIndex = 2;
            this.btAyuda.Text = "Ayuda";
            this.btAyuda.UseVisualStyleBackColor = false;
            this.btAyuda.Click += new System.EventHandler(this.btAyuda_Click);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.CadetBlue;
            this.btExit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btExit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btExit.Location = new System.Drawing.Point(12, 360);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(78, 59);
            this.btExit.TabIndex = 3;
            this.btExit.Text = "<--";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(42, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 108);
            this.label1.TabIndex = 4;
            this.label1.Text = "LaLiga\r\n    Fut Draft";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Proyecto_Final_Curso_Programacion.Properties.Resources.backgroundImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(832, 431);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btAyuda);
            this.Controls.Add(this.btFutDrafts);
            this.Controls.Add(this.btNuevoFD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.Resize += new System.EventHandler(this.Inicio_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btNuevoFD;
        private Button btFutDrafts;
        private Button btAyuda;
        private Button btExit;
        private Label label1;
    }
}