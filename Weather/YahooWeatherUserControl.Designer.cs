namespace YahooWeatherPlugin
{
    partial class YahooWeatherUserControl
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanelWeather = new System.Windows.Forms.TableLayoutPanel();
            this.panelWeather = new System.Windows.Forms.Panel();
            this._Weather = new System.Windows.Forms.Label();
            this._WeatherInfo = new System.Windows.Forms.Label();
            this.panelTemperature = new System.Windows.Forms.Panel();
            this.tableLayoutPanelTemperature = new System.Windows.Forms.TableLayoutPanel();
            this._Max = new System.Windows.Forms.Label();
            this._Temperature = new System.Windows.Forms.Label();
            this._Min = new System.Windows.Forms.Label();
            this.panelLocation = new System.Windows.Forms.Panel();
            this._Location = new System.Windows.Forms.Label();
            this._Search = new System.Windows.Forms.TextBox();
            this.panelHorizontalSeparator = new System.Windows.Forms.Panel();
            this.panelVerticalSeparator = new System.Windows.Forms.Panel();
            this.tableLayoutPanelWeather.SuspendLayout();
            this.panelWeather.SuspendLayout();
            this.panelTemperature.SuspendLayout();
            this.tableLayoutPanelTemperature.SuspendLayout();
            this.panelLocation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelWeather
            // 
            this.tableLayoutPanelWeather.ColumnCount = 3;
            this.tableLayoutPanelWeather.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelWeather.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelWeather.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelWeather.Controls.Add(this.panelWeather, 0, 0);
            this.tableLayoutPanelWeather.Controls.Add(this.panelTemperature, 2, 0);
            this.tableLayoutPanelWeather.Controls.Add(this.panelLocation, 0, 2);
            this.tableLayoutPanelWeather.Controls.Add(this.panelHorizontalSeparator, 1, 0);
            this.tableLayoutPanelWeather.Controls.Add(this.panelVerticalSeparator, 0, 1);
            this.tableLayoutPanelWeather.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelWeather.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelWeather.Name = "tableLayoutPanelWeather";
            this.tableLayoutPanelWeather.RowCount = 3;
            this.tableLayoutPanelWeather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.88963F));
            this.tableLayoutPanelWeather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanelWeather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.11037F));
            this.tableLayoutPanelWeather.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelWeather.Size = new System.Drawing.Size(260, 200);
            this.tableLayoutPanelWeather.TabIndex = 1;
            // 
            // panelWeather
            // 
            this.panelWeather.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelWeather.Controls.Add(this._Weather);
            this.panelWeather.Controls.Add(this._WeatherInfo);
            this.panelWeather.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWeather.Location = new System.Drawing.Point(3, 3);
            this.panelWeather.Name = "panelWeather";
            this.panelWeather.Size = new System.Drawing.Size(121, 124);
            this.panelWeather.TabIndex = 0;
            // 
            // _Weather
            // 
            this._Weather.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Weather.Font = new System.Drawing.Font("Microsoft Sans Serif", 66F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Weather.ForeColor = System.Drawing.Color.Black;
            this._Weather.Location = new System.Drawing.Point(0, 1);
            this._Weather.Margin = new System.Windows.Forms.Padding(0);
            this._Weather.Name = "_Weather";
            this._Weather.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this._Weather.Size = new System.Drawing.Size(122, 126);
            this._Weather.TabIndex = 0;
            this._Weather.Text = "#";
            this._Weather.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Weather.Click += new System.EventHandler(this._Weather_Click);
            // 
            // _WeatherInfo
            // 
            this._WeatherInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._WeatherInfo.Font = new System.Drawing.Font("Segoe Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._WeatherInfo.ForeColor = System.Drawing.Color.Black;
            this._WeatherInfo.Location = new System.Drawing.Point(0, 0);
            this._WeatherInfo.Margin = new System.Windows.Forms.Padding(0);
            this._WeatherInfo.Name = "_WeatherInfo";
            this._WeatherInfo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this._WeatherInfo.Size = new System.Drawing.Size(122, 126);
            this._WeatherInfo.TabIndex = 1;
            this._WeatherInfo.Text = "Weather info";
            this._WeatherInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._WeatherInfo.Click += new System.EventHandler(this._Weather_Click);
            // 
            // panelTemperature
            // 
            this.panelTemperature.Controls.Add(this.tableLayoutPanelTemperature);
            this.panelTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTemperature.Location = new System.Drawing.Point(135, 3);
            this.panelTemperature.Name = "panelTemperature";
            this.panelTemperature.Size = new System.Drawing.Size(122, 124);
            this.panelTemperature.TabIndex = 4;
            // 
            // tableLayoutPanelTemperature
            // 
            this.tableLayoutPanelTemperature.ColumnCount = 2;
            this.tableLayoutPanelTemperature.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTemperature.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelTemperature.Controls.Add(this._Max, 1, 1);
            this.tableLayoutPanelTemperature.Controls.Add(this._Temperature, 0, 0);
            this.tableLayoutPanelTemperature.Controls.Add(this._Min, 0, 1);
            this.tableLayoutPanelTemperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTemperature.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTemperature.Name = "tableLayoutPanelTemperature";
            this.tableLayoutPanelTemperature.RowCount = 2;
            this.tableLayoutPanelTemperature.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanelTemperature.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelTemperature.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTemperature.Size = new System.Drawing.Size(122, 124);
            this.tableLayoutPanelTemperature.TabIndex = 0;
            // 
            // _Max
            // 
            this._Max.AutoSize = true;
            this._Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Max.Font = new System.Drawing.Font("Segoe Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Max.ForeColor = System.Drawing.Color.Black;
            this._Max.Location = new System.Drawing.Point(64, 93);
            this._Max.Name = "_Max";
            this._Max.Size = new System.Drawing.Size(55, 31);
            this._Max.TabIndex = 3;
            this._Max.Text = "Max: 0º";
            this._Max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Max.Click += new System.EventHandler(this._Temperature_Click);
            // 
            // _Temperature
            // 
            this.tableLayoutPanelTemperature.SetColumnSpan(this._Temperature, 2);
            this._Temperature.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Temperature.Font = new System.Drawing.Font("Segoe Condensed", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Temperature.ForeColor = System.Drawing.Color.Black;
            this._Temperature.Location = new System.Drawing.Point(3, 0);
            this._Temperature.Name = "_Temperature";
            this._Temperature.Size = new System.Drawing.Size(116, 93);
            this._Temperature.TabIndex = 1;
            this._Temperature.Text = "0ºC";
            this._Temperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Temperature.Click += new System.EventHandler(this._Temperature_Click);
            // 
            // _Min
            // 
            this._Min.AutoSize = true;
            this._Min.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Min.Font = new System.Drawing.Font("Segoe Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Min.ForeColor = System.Drawing.Color.Black;
            this._Min.Location = new System.Drawing.Point(3, 93);
            this._Min.Name = "_Min";
            this._Min.Size = new System.Drawing.Size(55, 31);
            this._Min.TabIndex = 2;
            this._Min.Text = "Min: 0º";
            this._Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Min.Click += new System.EventHandler(this._Temperature_Click);
            // 
            // panelLocation
            // 
            this.tableLayoutPanelWeather.SetColumnSpan(this.panelLocation, 3);
            this.panelLocation.Controls.Add(this._Location);
            this.panelLocation.Controls.Add(this._Search);
            this.panelLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLocation.Location = new System.Drawing.Point(3, 138);
            this.panelLocation.Name = "panelLocation";
            this.panelLocation.Size = new System.Drawing.Size(254, 59);
            this.panelLocation.TabIndex = 3;
            // 
            // _Location
            // 
            this._Location.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Location.Font = new System.Drawing.Font("Segoe Condensed", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Location.ForeColor = System.Drawing.Color.Black;
            this._Location.Location = new System.Drawing.Point(0, 0);
            this._Location.Name = "_Location";
            this._Location.Size = new System.Drawing.Size(254, 59);
            this._Location.TabIndex = 0;
            this._Location.Text = "Loading...";
            this._Location.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._Location.Click += new System.EventHandler(this._Location_Click);
            // 
            // _Search
            // 
            this._Search.BackColor = System.Drawing.Color.White;
            this._Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this._Search.Font = new System.Drawing.Font("Segoe Condensed", 27.75F);
            this._Search.Location = new System.Drawing.Point(0, 0);
            this._Search.Margin = new System.Windows.Forms.Padding(0);
            this._Search.Multiline = true;
            this._Search.Name = "_Search";
            this._Search.Size = new System.Drawing.Size(254, 59);
            this._Search.TabIndex = 1;
            this._Search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._Search_KeyPress);
            // 
            // panelHorizontalSeparator
            // 
            this.panelHorizontalSeparator.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelHorizontalSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHorizontalSeparator.Location = new System.Drawing.Point(130, 3);
            this.panelHorizontalSeparator.Name = "panelHorizontalSeparator";
            this.panelHorizontalSeparator.Size = new System.Drawing.Size(1, 124);
            this.panelHorizontalSeparator.TabIndex = 1;
            // 
            // panelVerticalSeparator
            // 
            this.panelVerticalSeparator.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanelWeather.SetColumnSpan(this.panelVerticalSeparator, 3);
            this.panelVerticalSeparator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVerticalSeparator.Location = new System.Drawing.Point(3, 133);
            this.panelVerticalSeparator.Name = "panelVerticalSeparator";
            this.panelVerticalSeparator.Size = new System.Drawing.Size(254, 1);
            this.panelVerticalSeparator.TabIndex = 2;
            // 
            // YahooWeatherUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelWeather);
            this.MinimumSize = new System.Drawing.Size(20, 10);
            this.Name = "YahooWeatherUserControl";
            this.Size = new System.Drawing.Size(260, 200);
            this.Resize += new System.EventHandler(this.LabelFont_Resize);
            this.tableLayoutPanelWeather.ResumeLayout(false);
            this.panelWeather.ResumeLayout(false);
            this.panelTemperature.ResumeLayout(false);
            this.tableLayoutPanelTemperature.ResumeLayout(false);
            this.tableLayoutPanelTemperature.PerformLayout();
            this.panelLocation.ResumeLayout(false);
            this.panelLocation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelWeather;
        private System.Windows.Forms.Panel panelWeather;
        private System.Windows.Forms.Label _Weather;
        private System.Windows.Forms.Label _WeatherInfo;
        private System.Windows.Forms.Panel panelTemperature;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTemperature;
        private System.Windows.Forms.Label _Max;
        private System.Windows.Forms.Label _Temperature;
        private System.Windows.Forms.Label _Min;
        private System.Windows.Forms.Panel panelLocation;
        private System.Windows.Forms.Label _Location;
        private System.Windows.Forms.TextBox _Search;
        private System.Windows.Forms.Panel panelHorizontalSeparator;
        private System.Windows.Forms.Panel panelVerticalSeparator;
    }
}
