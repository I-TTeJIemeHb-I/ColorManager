using ColorManager.Data.Models;
using ColorManager.DataBase;
using ColorManager.DataBase.Queries;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
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

        SettingsModel Model { get; set; }

        public SettingsViewModel()
        {
           Model = new SettingsModel();
        }

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
                    MessageBox.Show("");
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
        private RelayCommand _logOut;
        private RelayCommand _rashet;
        private RelayCommand _izgotovka;
        private RelayCommand _podbor;
        private RelayCommand _zapros;

        public RelayCommand PageLoaded
        {
            get
            {
                return _pageLoad ??=
                    new RelayCommand(obj =>
                    {
                        using (var db = new ApplicationContext())
                        {
                            Users user = SettingsQuery.GetUserInfo();
                            Model.Name = user.Name;
                            Model.Status = user.JobTitle;
                            Model.Number = user.PhoneNumber;
                            Model.Email = user.Email;
                        }
                    });
            }
        }

        public RelayCommand LogOut
        {
            get
            {
                return _logOut ??=
                    new RelayCommand(obj =>
                    {
                        if (AuthorizationQuery.LogOut())
                        {
                            Frame frame = obj as Frame;
                            frame.Navigate(new Views.HomePage());
                        }
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
                        MessageBox.Show(Model.Name);
                        SettingsQuery.SaveData(Model);
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

        public RelayCommand Rashet
        {
            get
            {
                return _pageLoad ??=
                    new RelayCommand(obj =>
                    {
                       
                    });
            }
        }


        public RelayCommand Izgotovka
        {
            get
            {
                return _pageLoad ??=
                    new RelayCommand(obj =>
                    {
                       
                    });
            }
        }

        public RelayCommand Podbor
        {
            get
            {
                return _pageLoad ??=
                    new RelayCommand(obj =>
                    {
                       
                    });
            }
        }

        public RelayCommand Zapros
        {
            get
            {
                return _pageLoad ??=
                    new RelayCommand(obj =>
                    {
                       
                    });
            }
        }




        #endregion
    }
}
