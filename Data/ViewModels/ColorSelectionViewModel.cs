using ColorManager.Data.Models;
using ColorManager.DataBase.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ColorManager.Data.ViewModels
{
    public class ColorSelectionViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public List<string> ProductGroup;
        public List<string> ColorFan;
        public List<string> Color;
        public string SelectedItemProductGroup;
        public string SelectedItemColorFan;
        public string SelectedItemColor;

        #region Команды ViewModel

        private RelayCommand _getStockInfo;
        private RelayCommand _windowLoaded;
        private RelayCommand _getColorFan;
        private RelayCommand _getColor;

        public RelayCommand GetInfo
        {
            get
            {
                return _getStockInfo ??=
                    new RelayCommand(obj =>
                    {
                       
                    });
            }
        }

        public RelayCommand WindowLoaded
        {
            get
            {

                return _windowLoaded ??=
                    new RelayCommand(obj =>
                    {
                        ProductGroup = PallettersQuery.GetProductGroup();
                    });
            }
        }

        public RelayCommand GetColorFan
        {
            get
            {

                return _getColorFan ??=
                    new RelayCommand(obj =>
                    {
                        ColorFan = PallettersQuery.GetColorFan(SelectedItemProductGroup);
                    });
            }
        }

        public RelayCommand GetColor
        {
            get
            {

                return _getColor ??=
                    new RelayCommand(obj =>
                    {
                        Color = PallettersQuery.GetColor(SelectedItemProductGroup, SelectedItemColorFan);
                    });
            }
        }


        #endregion
    }
}
