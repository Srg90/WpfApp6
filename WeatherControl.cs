using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp6
{
    enum rainfall { Sunny, Cloudy, Rain, Snow }

    class WeatherControl:DependencyObject
    {

        private string wind;
        int speedWind;
        public static readonly DependencyProperty TemperatureProperty; 
      

        public string Wind
        {
            get => wind;
            set => wind = value;
        }
        public int SpeedWind
        {
            get { return speedWind; }

            set
            {
                if (value > 0 && value < 25)
                { speedWind = value; }
                else
                { speedWind = 0; }
            }
        }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        public WeatherControl(string wind, int speedwind)
        {
            this.Wind = wind;
            this.SpeedWind = speedwind;
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                    new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return 0;
        }
    }
}
