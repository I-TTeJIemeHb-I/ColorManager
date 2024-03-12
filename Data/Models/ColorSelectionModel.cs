using ColorManager.DataBase.Queries;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

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


        #region Synglton

        private static ColorSelectionModel instance;
        private static object syncRoot = new Object();

        public static ColorSelectionModel getInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new ColorSelectionModel();
                }
            }
            return instance;
        }

        #endregion


        private string productGroupSelected;
        private string colorFanSelected;
        private string colorSelected;

        public ObservableCollection<string> ProductGroup {get; set;}
        public ObservableCollection<string> ColorFan { get; set; }
        public ObservableCollection<string> Color { get; set; }

        public string ProductGroupSelected
        {
            get { return productGroupSelected; }
            set
            {
                if (productGroupSelected != value)
                {
                    productGroupSelected = value;
                    OnPropertyChanged();
                    GetColorFans();
                }
            }
        }
        public string ColorFanSelected
        {
            get { return colorFanSelected; }
            set
            {
                if (colorFanSelected != value)
                {
                    colorFanSelected = value;
                    OnPropertyChanged();
                    GetColors();
                }
            }
        }
        public string ColorSelected
        {
            get { return colorSelected; }
            set
            {
                if (colorSelected != value)
                {
                    colorSelected = value;
                    OnPropertyChanged();
                }
            }
        }


        // Класс модели. Заполняет первый ComboBox автоматически.
        // Для последующих просто выделяет место в памяти.
        public ColorSelectionModel()
        {
            ProductGroup = PallettersQuery.GetProductGroup();
            ColorFan = new ObservableCollection<string>();
            Color = new ObservableCollection<string>();
        }

        // Метод для обновления списка Вееров. Вызывается при изменении свойства ProductGroupSelected
        private void GetColorFans()
        {
            ColorFan.Clear();
            PallettersQuery.GetColorFan(ProductGroupSelected);
        }

        // Метод для обновления списка Цветов. Вызывается при изменении свойства ColorFanSelected
        private void GetColors()
        {
            Color.Clear();
            PallettersQuery.GetColor(ProductGroupSelected, ColorFanSelected);
        }
    }
}
