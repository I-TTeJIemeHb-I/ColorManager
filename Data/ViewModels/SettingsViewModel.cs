using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace ColorManager.Data.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
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
        private string _jobTitle;
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
            get { return _jobTitle; }
            set
            {
                if (_jobTitle != value)
                {
                    _jobTitle = value;
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

        private RelayCommand _saveData;
        private RelayCommand _goBack;
        private RelayCommand _pageLoad;

        public RelayCommand PageLoaded
        {
            get
            {
                return _pageLoad ??=
                    new RelayCommand(obj =>
                    {
                        //Загружать данные с базы на страницу
                    });
            }
        }

        public RelayCommand SaveData
        {
            get
            {
                return _saveData ??=
                    new RelayCommand(obj =>
                    {
                        //Реализовать функцию сохранения данных 
                    });
            }
        }

        public RelayCommand GoBack
        {
            get
            {
                return _goBack ??=
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
