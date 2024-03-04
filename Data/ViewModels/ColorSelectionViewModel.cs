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

        public ColorSelectionModel Model { get; set; }

        public ColorSelectionViewModel()
        {
            Model = new ColorSelectionModel();
        }


        #region Команды ViewModel


        private RelayCommand _getStockInfo;
        private RelayCommand _getProductGroup;

        public RelayCommand GetInfo
        {
            get
            {
                return _getStockInfo ??=
                    new RelayCommand(obj =>
                    {
                        PallettersQuery.GetColorValue(Model);
                    });
            }
        }

        public RelayCommand GetProductGroup
        {
            get
            {
                return _getStockInfo ??=
                    new RelayCommand(obj =>
                    {
                        PallettersQuery.GetColorValue(Model);
                    });
            }
        }


        #endregion
    }
}
