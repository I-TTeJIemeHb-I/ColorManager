using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorManager.Data.Models
{
    public class CalculatorModel
    {
        public static string? NameProduct;
        public static string? FanOfColor;
        public static SolidColorBrush? Color;
        public static bool? Availability;
        public static string? ColorSpectrum;
        public static string? Name_FanOfColor_Color;


        public CalculatorModel(string name, string fanOfColor,SolidColorBrush color)
        {
            NameProduct = name;
            FanOfColor = fanOfColor;
            Color = color;

            Name_FanOfColor_Color = $"{NameProduct}, {FanOfColor}, {Color}";
        }
       
    }
}
