/**
* YahooWeatherPlugin v0.1
* Yahoo Weather Plugin - released under MIT License
* Author: Javi Filella <txusko@gmail.com>
* http://github.com/txusko/YahooWeatherPlugin
* Copyright (c) 2016 Javi Filella
*
* Permission is hereby granted, free of charge, to any person
* obtaining a copy of this software and associated documentation
* files (the "Software"), to deal in the Software without
* restriction, including without limitation the rights to use,
* copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the
* Software is furnished to do so, subject to the following
* conditions:
*
* The above copyright notice and this permission notice shall be
* included in all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
* OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
* NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
* HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
* WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
* FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
* OTHER DEALINGS IN THE SOFTWARE.
*
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Device.Location;
using System.Drawing.Text;
using System.Xml.Linq;
using System.Net;
using System.Runtime.InteropServices;

namespace YahooWeatherPlugin
{
    /// <summary>
    /// Yahoo Weather Plugin (Usercontrol) based on Yahoo Weather API (https://developer.yahoo.com/weather/).
    /// Released under MIT License
    /// Author: Javi Filella <txusko@gmail.com>
    /// http://github.com/txusko/YahooWeatherPlugin
    /// Copyright (c) 2016 Javi Filella
    /// </summary>
    public partial class YahooWeatherUserControl : UserControl
    {

        #region WEATHER PROPERTIES
        #region Yahoo Weather Codes to Metacons Webfonf

        /// <summary>
        /// Equivalence between Yahoo Weather Codes anad Meteocons_webfont.ttf
        /// Yahoo Weathe Codes : https://developer.yahoo.com/weather/documentation.html#codes
        /// Metacons Webfont : http://www.alessioatzeni.com/meteocons/
        /// </summary>
        private Dictionary<int, string> WeatherCode2Meteocon = new Dictionary<int, string>()
        {
            { 0, "F" },//TORNADO,
            { 1, "F" },//TROPICAL_STORM,
            { 2, "F" },//HURRICANE,
            { 3, "&" },//SEVERE_THUNDERSTOMS,
            { 4, "&" },//THUNDERSTOMS,
            { 5, "#" },//MIXED_RAIN_AND_SNOW,
            { 6, "#" },//MIXED_RAIN_AND_SLEET,
            { 7, "#" },//MIXED_SNOW_AND_SLEET,
            { 8, "Q" },//FREEZING_DRIZZLE,
            { 9, "Q" },//DRIZZLE,
            { 10, "R" },//FREEZING_RAIN,
            { 11, "R" },//SHOWERS1,
            { 12, "R" },//SHOWERS2,
            { 13, "X" },//SNOW_FLURRIES,
            { 14, "X" },//LIGHT_SNOW_SHOWERS,
            { 15, "X" },//BLOWING_SNOW,
            { 16, "X" },//SNOW,
            { 17, "$" },//HAIL,
            { 18, "8" },//SLEET,
            { 19, "M" },//DUST,
            { 20, "L" },//FOGGY,
            { 21, "A" },//HAZE,
            { 22, "L" },//SMOKY,
            { 23, "F" },//BLUSTERY,
            { 24, "F" },//WINDY,
            { 25, "G" },//COLD,
            { 26, "N" },//CLOUDY,
            { 27, "I" },//MOSTLY_CLOUDY_NIGHT,
            { 28, "H" },//MOSTLY_CLOUDY_DAY,
            { 29, "4" },//PARTLY_CLOUDY_NIGHT,
            { 30, "3" },//PARTLY_CLOUDY_DAY,
            { 31, "C" },//CLEAR_NIGHT,
            { 32, "B" },//SUNNY,
            { 33, "2" },//FAIR_NIGHT,
            { 34, "1" },//FAIR_DAY,
            { 35, "!" },//MIXED_RAIN_AND_HAIL,
            { 36, "'" },//HOT,
            { 37, "6" },//ISOLATED_THUNDERSTORMS,
            { 38, "6" },//SCATTERED_THUNDERSTORMS1,
            { 39, "6" },//SCATTERED_THUNDERSTORMS2,
            { 40, "8" },//SCATTERED_SHOWERS,
            { 41, "$" },//HEAVY_SNOW1,
            { 42, "$" },//SCATTERD_SNOW_SHOWERS,
            { 43, "$" },//HEAVY_SNOW2,
            { 44, "%" },//PARTLY_CLOUDY,
            { 45, "&" },//THUNDERSHOWERS,
            { 46, "$" },//SNOW_SHOWERS,
            { 47, "&" },//ISOLATED_THUNDERSHOWERS,
            { 3200, ")" }//NOT_AVAILABLE = 3200
        };

        #endregion Yahoo Weather Codes to Metacons Webfonf

        /// <summary>
        /// Longitud (en automatico)
        /// </summary>
        private string _Longitude = "";

        /// <summary>
        /// Latitud (en automatico)
        /// </summary>
        private string _Latitude = "";

        /// <summary>
        /// Yahoo current weather code
        /// </summary>
        private string _WeatherCode = "";

        /// <summary>
        /// Yahoo current weather text
        /// </summary>
        private string _WeatherText = "";

        /// <summary>
        /// Current temperature
        /// </summary>
        private string _Temp = "";

        /// <summary>
        /// Current location
        /// </summary>
        private string _City = "";

        /// <summary>
        /// Today's lower temperature
        /// </summary>
        private string _MinTemp = "";

        /// <summary>
        /// Today's higher temperature
        /// </summary>
        private string _MaxTemp = "";

        #endregion WEATHER PROPERTIES

        #region PRIVATE PROPERTIES

        /// <summary>
        /// For recover client's geolocation
        /// </summary>
        private static GeoCoordinateWatcher _Watcher = new GeoCoordinateWatcher();

        /// <summary>
        /// Timer for update label's properties
        /// </summary>
        private System.Windows.Forms.Timer _Timer = new System.Windows.Forms.Timer();

        /// <summary>
        /// Custom font (for weather icons according to yahoo weather codes)
        /// </summary>
        private PrivateFontCollection privateFontCollection = new PrivateFontCollection();

        /// <summary>
        /// Initial Usercontrol Width
        /// </summary>
        private int initialWidth;

        /// <summary>
        /// Initial Usercontrol Height
        /// </summary>
        private int initialHeight;

        /// <summary>
        /// Initial Font Size of the label elements to take into account.
        /// </summary>
        private Dictionary<string, float> initialFontSize = new Dictionary<string, float>();

        #endregion PRIVATE PROPERTIES

        #region CONFIG PROPERTIES

        /// <summary>
        /// Temperature types : Celsius or Farenheit
        /// </summary>
        public enum TemperatureTypes
        {
            Celsius,
            Farenheit
        }

        /// <summary>
        /// Weather automatic service : based on geolocalization
        /// </summary>
        [Description("Automatic set to True retrieve weather based on geolocation. Automatic set to False retrieve weather based on \"Location\" string."),
        Category("Weather Plugin"), DisplayName("Automatic")]
        public bool Automatic
        {
            get { return this._Automatic; }
            set 
            {
                if (this._Automatic != value)
                {
                    this._Automatic = value;
                    if (value)
                    {
                        this._Search.Text = "";
                        _Watcher.Start();
                    }
                    else
                    {
                        _Watcher.Stop();
                    }
                    this._GetLocation();
                }
            }
        }
        private bool _Automatic = true;

        /// <summary>
        /// Searched string for the weather service When _Automatic is set to False.
        /// </summary>
        [Description("Default location when \"Automatic\" is set to False"), 
        Category("Weather Plugin"), DisplayName("Location")]
        public string SearchLocation
        {
            get { return this._Search.Text; }
            set 
            { 
                this._Search.Text = value;
                if (!string.IsNullOrWhiteSpace(value) || this._Search.Text != value)
                {
                    this._Automatic = false;
                    this._GetLocation();
                }
            }
        }

        /// <summary>
        /// Type of temperature to show
        /// </summary>
        [Description("Scales of temperature: Celsius or Farhenheit."), 
        Category("Weather Plugin"), DisplayName("Scale of temperature")]
        public TemperatureTypes TemperatureType
        {
            get { return this._TemperatureType; }
            set 
            {
                if (this._TemperatureType != value)
                {
                    this._TemperatureType = value;
                    this._GetLocation();
                }
            }
        }
        private TemperatureTypes _TemperatureType = TemperatureTypes.Celsius;

        #endregion CONFIG PROPERTIES

        #region CONSTRUCTORS

        /// <summary>
        /// Constructor
        /// </summary>
        public YahooWeatherUserControl()
        {
            this._Init();
        }

        #endregion CONSTRUCTORS

        #region METHODS

        /// <summary>
        /// Initialize compontents and environement
        /// </summary>
        private void _Init()
        {
            InitializeComponent();

            //Geolocation
            _Watcher.StatusChanged += Watcher_StatusChanged;
            if (Automatic)
                _Watcher.Start();

            //Enable timer for the automatic update of the content
            _Timer.Enabled = false;
            _Timer.Tick += new EventHandler(_Timer_Tick);
            _InitTimer();

            //Load "metocon" font in _Whether label
            _LoadFont(this._Weather);
        }

        /// <summary>
        /// Initialize timer to tnMiliseconds and start it.
        /// If the timer is started, it will stop it and re-start it.
        /// </summary>
        /// <param name="tnMiliseconds"></param>
        private void _InitTimer(int tnMiliseconds = 500)
        {
            //Stop the timer before changing the Interval
            if (this._Timer.Enabled)
            {
                _Timer.Stop();
                _Timer.Enabled = false;
            }
            //Start timer
            _Timer.Interval = tnMiliseconds;
            _Timer.Start();
            _Timer.Enabled = true;
        }

        /// <summary>
        /// Load "meteocons_webfont" resource and set to _Weather label
        /// </summary>
        private void _LoadFont(Label toLabel)
        {
            //Select your font from the resources.
            //My font here is "Digireu.ttf"
            int fontLength = global::YahooWeatherPlugin.Properties.Resources.meteocons_webfont.Length;

            // create a buffer to read in to
            byte[] fontdata = global::YahooWeatherPlugin.Properties.Resources.meteocons_webfont;

            // create an unsafe memory block for the font data
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            privateFontCollection.AddMemoryFont(data, fontLength);

            // free up the unsafe memory
            Marshal.FreeCoTaskMem(data);

            //After that we can create font and assign font to label
            toLabel.Font = new Font(privateFontCollection.Families[0], this._Weather.Font.Size);
            toLabel.Text = this.WeatherCode2Meteocon[3200];

            //Load autoresize vars
            _LoadAutoResize();
        }

        /// <summary>
        /// Load autoresize needed vars
        /// </summary>
        private void _LoadAutoResize()
        {
            //We don't need autoscale
            AutoScaleMode = AutoScaleMode.None;

            // Sets the initial size of the usercontrol
            initialWidth = Width;
            initialHeight = Height;

            // Sets the initial size of the labels
            initialFontSize["_Weather"] = this._Weather.Font.Size;
            initialFontSize["_WeatherInfo"] = this._WeatherInfo.Font.Size;
            initialFontSize["_Location"] = this._Location.Font.Size;
            initialFontSize["_Search"] = this._Search.Font.Size;
            initialFontSize["_Temperature"] = this._Temperature.Font.Size;
            initialFontSize["_Min"] = this._Min.Font.Size;
            initialFontSize["_Max"] = this._Max.Font.Size;
        }

        /// <summary>
        /// Timer tick : update the labels with the recovered info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Timer_Tick(object sender, EventArgs e)
        {
            bool llPaso = false;
            //_Wheather : icon
            if (!string.IsNullOrWhiteSpace(_WeatherCode) && (this.panelWeather.Tag == null || this.panelWeather.Tag.ToString() != _WeatherCode))
            {
                this._Weather.Text = this.WeatherCode2Meteocon[Convert.ToInt32(_WeatherCode)];
                this._WeatherInfo.Text = this._WeatherText;
                this.panelWeather.Tag = _WeatherCode;
                llPaso = true;
            }

            //Current temperature
            if (!string.IsNullOrWhiteSpace(_Temp) && this._Temperature.Text != _Temp)
            {
                this._Temperature.Text = _Temp;
                llPaso = true;
            }

            //Today's lowest temperature
            if (!string.IsNullOrWhiteSpace(_MinTemp) && (this._Min.Tag == null || this._Min.Tag.ToString() != _MinTemp || string.IsNullOrWhiteSpace(this._Min.Text)))
            {
                this._Min.Text = "Min: " + _MinTemp + "º";
                this._Min.Tag = _MinTemp;
                llPaso = true;
            }

            //Today's highest temperature
            if (!string.IsNullOrWhiteSpace(_MaxTemp) && (this._Max.Tag == null || this._Max.Tag.ToString() != _MaxTemp || string.IsNullOrWhiteSpace(this._Max.Text)))
            {
                this._Max.Text = "Max: " + _MaxTemp + "º";
                this._Max.Tag = _MaxTemp;
                llPaso = true;
            }

            //Searched location
            if (!string.IsNullOrWhiteSpace(_City) && this._Location.Text != _City)
            {
                this._Location.Text = _City;
                llPaso = true;
            }

            //Reset the timer
            if (llPaso)
                _InitTimer(60000); //to 60 seconds
        }

        /// <summary>
        /// Watcher_StatusChanged : update the client geolocation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            //Check for Reasy status
            if (e.Status == GeoPositionStatus.Ready)
            {
                //Check for a known location
                if (!_Watcher.Position.Location.IsUnknown)
                {
                    //Store location
                    _Latitude = _Watcher.Position.Location.Latitude.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture);
                    _Longitude = _Watcher.Position.Location.Longitude.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture);
                    //Refresh info
                    _GetLocation();
                }
            }
        }

        /// <summary>
        /// Recover the weather info taking acount of the class params
        /// </summary>
        private void _GetLocation()
        {
            //Automatic mode
            if (this.Automatic && !string.IsNullOrWhiteSpace(this._Latitude) && !string.IsNullOrWhiteSpace(this._Longitude))
                this._GetLocationLatLon(this._Latitude, this._Longitude);
            //Search mode
            else if (!this.Automatic && !string.IsNullOrWhiteSpace(this.SearchLocation))
                this._GetSearch(this.SearchLocation);
            //Forze refresh
            this._Timer_Tick(null, null);
        }

        /// <summary>
        /// Recover weather info based on Lattitude + Longitude from Yahoo Weather API
        /// </summary>
        /// <param name="tcLat"></param>
        /// <param name="tcLon"></param>
        private void _GetLocationLatLon(string tcLat, string tcLon)
        {
            // Form Actual URL - REST API call
            StringBuilder sbURL = new StringBuilder();
            sbURL.Append(@"https://query.yahooapis.com/v1/public/yql?q=");
            // YQL 
            sbURL.Append(@"select%20*%20from%20weather.forecast%20where%20woeid%20in%20(SELECT%20woeid%20FROM%20geo.places%20WHERE%20text=%22(" + tcLat + "," + tcLon + ")%22)");
            //Celsius
            sbURL.Append(@" and u='" + (TemperatureType == TemperatureTypes.Celsius ? "c" : "f") + "'");
            // Prevent cross site scripting
            sbURL.Append(@"&diagnostics=true");

            // Initialize Web Client and set its encoding to UTF8
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;

            // Download string (XML data) from REST API response
            string XMLresult = wc.DownloadString(sbURL.ToString());
            this._ParseXmlResult(XMLresult);
        }

        /// <summary>
        /// Recover weather info based on a search string from Yahoo Weather API
        /// </summary>
        /// <param name="tcSearch"></param>
        private void _GetSearch(string tcSearch)
        {
            // Form Actual URL - REST API call
            StringBuilder sbURL = new StringBuilder();
            sbURL.Append(@"https://query.yahooapis.com/v1/public/yql?q=");
            // YQL 
            sbURL.Append(@"select%20*%20from%20weather.forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text%3D%22" + tcSearch + "%22)");
            //Celsius
            sbURL.Append(@" and u='" + (TemperatureType == TemperatureTypes.Celsius ? "c" : "f") + "'");
            // Prevent cross site scripting
            sbURL.Append(@"&diagnostics=true");

            // Initialize Web Client and set its encoding to UTF8
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;

            // Download string (XML data) from REST API response
            string XMLresult = wc.DownloadString(sbURL.ToString());
            this._ParseXmlResult(XMLresult);
        }

        /// <summary>
        /// Parse recovered XML from Yahoo Weather API
        /// </summary>
        /// <param name="XMLresult"></param>
        private void _ParseXmlResult(string XMLresult)
        {
            //Parsew XML String
            XDocument xdoc = XDocument.Parse(XMLresult);
            XNamespace yWeather = "http://xml.weather.yahoo.com/ns/rss/1.0";
            //Location
            var locationNode = xdoc.Descendants(yWeather + "location").FirstOrDefault();
            if (locationNode != null)
            {
                _City = locationNode.Attribute("city").Value.ToString();
                //Temperature
                locationNode = xdoc.Descendants(yWeather + "condition").FirstOrDefault();
                _Temp = locationNode.Attribute("temp").Value.ToString() + "º";
                _WeatherCode = locationNode.Attribute("code").Value.ToString();
                _WeatherText = locationNode.Attribute("text").Value.ToString();
                //Forecast
                locationNode = xdoc.Descendants(yWeather + "forecast").FirstOrDefault();
                _MinTemp = locationNode.Attribute("low").Value.ToString();
                _MaxTemp = locationNode.Attribute("high").Value.ToString();
                //Type
                locationNode = xdoc.Descendants(yWeather + "units").FirstOrDefault();
                _Temp += locationNode.Attribute("temperature").Value.ToString();
            }
        }

        /// <summary>
        /// Click event on _Temperature label.
        /// It will toggle the type of temperature shown between Celsius and Farenheit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Temperature_Click(object sender, EventArgs e)
        {
            if (TemperatureType == TemperatureTypes.Celsius)
                TemperatureType = TemperatureTypes.Farenheit;
            else
                TemperatureType = TemperatureTypes.Celsius;

            //Reset label values
            this._Temperature.Text = "";
            this._Min.Text = "";
            this._Max.Text = "";
            //Refresh information
            Application.DoEvents();
            _GetLocation();
        }

        /// <summary>
        /// Click event on _Loaction label.
        /// Show an editable textbox where user can set manually the desired location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Location_Click(object sender, EventArgs e)
        {
            //Show search textbox
            this._Search.Text = this._Location.Text;
            this._Search.BringToFront();
            this._Location.Visible = false;
        }

        /// <summary>
        /// Keypress event on _Search textbox.
        /// Enter or Tab : Apply changes
        /// Esc : Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            //On escape, restore previous location
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this._Location.BringToFront();
                this._Location.Visible = true;
            }

            //On Enter or Tab, apply the changes
            if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Tab))
            {
                //Change visibility
                this._Location.BringToFront();
                this._Location.Visible = true;
                this._Location.Text = this._Search.Text;

                //Check for search string
                if (!string.IsNullOrWhiteSpace(this._Search.Text))
                {
                    //Reload content
                    this.SearchLocation = this._Location.Text;
                }
                else if (!this.Automatic)
                {
                    //If no search string is provided and the _Automatic is set to off, reactivate _Automatic
                    this.Automatic = true;
                }
            }
        }

        /// <summary>
        /// Usercontrol resize : responsive font-size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelFont_Resize(object sender, EventArgs e)
        {
            //Check needed properties
            if (privateFontCollection.Families.Length <= 0 || initialFontSize.Count <= 0)
                return;

            SuspendLayout();

            // Get the proportionality of the resize
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            // Calculate the current font size for all the labels
            this._Weather.Font = new Font(privateFontCollection.Families[0], initialFontSize["_Weather"] *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                this._Weather.Font.Style);
            this._WeatherInfo.Font = new Font(this._WeatherInfo.Font.Name, initialFontSize["_WeatherInfo"] *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                this._WeatherInfo.Font.Style);
            this._Location.Font = new Font(this._Location.Font.Name, initialFontSize["_Location"] *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                this._Location.Font.Style);
            this._Search.Font = new Font(this._Search.Font.Name, initialFontSize["_Search"] *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                this._Search.Font.Style);
            this._Temperature.Font = new Font(this._Temperature.Font.Name, initialFontSize["_Temperature"] *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                this._Temperature.Font.Style);
            this._Min.Font = new Font(this._Min.Font.Name, initialFontSize["_Min"] *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                this._Min.Font.Style);
            this._Max.Font = new Font(this._Max.Font.Name, initialFontSize["_Max"] *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                this._Max.Font.Style);

            ResumeLayout();
        }

        /// <summary>
        /// Click on _Weather or _WeatherInfo label. Toogle between the ttwo labels.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Weather_Click(object sender, EventArgs e)
        {
            if (this._Weather.Visible)
            {
                this._Weather.Visible = false;
                this._WeatherInfo.Visible = true;
            }
            else
            {
                this._Weather.Visible = true;
                this._WeatherInfo.Visible = false;
            }
        }

        #endregion METHODS

    }
}
