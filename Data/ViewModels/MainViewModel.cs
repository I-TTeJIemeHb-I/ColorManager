using ColorManager.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ColorManager.Data.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        public double MinHeight { get; }
        public double MinWidth { get; }
        public double MaxHeight { get; }
        public double MaxWidth { get; }
        public MainModel MainModel { get; set; }


        public MainViewModel()
        {
            MinHeight = 700;
            MinWidth = 1200;
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            MainModel = MainModel.getInstance();
        }


        #region Стандартные команды окна

        private RelayCommand _closeWindow;
        private RelayCommand _resizeWindow;
        private RelayCommand _hideWindow;   
        private RelayCommand _dragWindow;

        public RelayCommand CloseWindow
        {
            get
            {
                return _closeWindow ??=
                    new RelayCommand(obj =>
                    {
                        Window window = obj as Window;
                        window.Close();
                    });
            }
        }

        public RelayCommand ResizeWindow
        {
            get
            {
                return _resizeWindow ??=
                    new RelayCommand(obj =>
                    {
                        Window window = obj as Window;

                        if (window.WindowState == WindowState.Normal)
                        {
                            window.WindowState = WindowState.Maximized;
                            window.ResizeMode = ResizeMode.NoResize;
                        }
                        else
                        {
                            window.WindowState = WindowState.Normal;
                            window.ResizeMode = ResizeMode.CanResize;
                        }
                    });
            }
        }

        public RelayCommand HideWindow
        {
            get
            {
                return _hideWindow ??=
                    new RelayCommand(obj =>
                    {
                        Window window = obj as Window;
                        window.WindowState = WindowState.Minimized;
                    });
            }
        }

        public RelayCommand DragWindow
        {
            get
            {
                return _dragWindow ??=
                    new RelayCommand(obj =>
                    {
                        Window window = obj as Window;
                        window.DragMove();
                    },
                    obj => Mouse.LeftButton == MouseButtonState.Pressed);
            }
        }

        #endregion


        private RelayCommand _navigate;
        public RelayCommand FrameLoaded
        {
            get
            {
                return _navigate ??=
                    new RelayCommand(obj =>
                    {
                        Frame frame = obj as Frame;
                        frame.Navigate(new Views.Authorization.SignInPage());
                    });
            }
        }

    }
}
