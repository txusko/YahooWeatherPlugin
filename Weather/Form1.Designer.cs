namespace YahooWeatherPlugin
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.yahooWeatherUserControl1 = new YahooWeatherPlugin.YahooWeatherUserControl();
            this.SuspendLayout();
            // 
            // yahooWeatherUserControl1
            // 
            this.yahooWeatherUserControl1.Automatic = true;
            this.yahooWeatherUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yahooWeatherUserControl1.Location = new System.Drawing.Point(0, 0);
            this.yahooWeatherUserControl1.MinimumSize = new System.Drawing.Size(20, 10);
            this.yahooWeatherUserControl1.Name = "yahooWeatherUserControl1";
            this.yahooWeatherUserControl1.SearchLocation = "";
            this.yahooWeatherUserControl1.Size = new System.Drawing.Size(263, 173);
            this.yahooWeatherUserControl1.TabIndex = 0;
            this.yahooWeatherUserControl1.TemperatureType = YahooWeatherPlugin.YahooWeatherUserControl.TemperatureTypes.Celsius;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 173);
            this.Controls.Add(this.yahooWeatherUserControl1);
            this.Name = "Form1";
            this.Text = "Yahoo Weather Plugin";
            this.ResumeLayout(false);

        }

        #endregion

        private YahooWeatherUserControl yahooWeatherUserControl1;



    }
}

