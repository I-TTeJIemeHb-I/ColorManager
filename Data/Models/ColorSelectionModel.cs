using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ColorManager.Data.Models
{
    public class ColorSelectionModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Свойства класса

        private string _productGroup;
        private string _colorFan;
        private string _color;
        private string _colorValue;
        private bool _inStock;

        public string ProductGroup
        {
            get { return _productGroup; }
            set
            {
                if (_productGroup != value)
                {
                    _productGroup = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ColorFan
        {
            get { return _colorFan; }
            set
            {
                if (_colorFan != value)
                {
                    _colorFan = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ColorValue
        {
            get { return _colorValue; }
            set
            {
                if (_colorValue != value)
                {
                    _colorValue = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool InStockInfo
        {
            get { return _inStock; }
            set
            {
                if (_inStock != value)
                {
                    _inStock = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion
    }
}
