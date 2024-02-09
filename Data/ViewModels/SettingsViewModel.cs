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
    public class SettingsViewModel: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Свойства ViewModel
        private string _name;
        private string _status;
        private string _number;
        private string _email;

        public string Name_TextBox
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Status_TextBox
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Number_TextBox
        {
            get { return _email; }
            set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Email_TextBox
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Kоманды ViewModel


        private RelayCommand _gosave;
        private RelayCommand _back;


        public RelayCommand GoSave
        {
            get
            {
                return _gosave ??=
                    new RelayCommand(obj =>
                    {
                        Page page = obj as Page;
                        page.NavigationService.GoBack();
                    });
            }
        }

        public RelayCommand Back
        {
            get
            {
                return _back ??=
                    new RelayCommand(obj =>
                    {
                        Page page = obj as Page;
                        page.NavigationService.GoBack();
                    });
            }
        }

        #endregion










    }



}
