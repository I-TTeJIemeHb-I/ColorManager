using ColorManager.Data.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
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


        // Model для данной ViewModel. Получаем её из конструктора класса
        public ColorSelectionModel selectionModel { get; private set; }
        // Конструктор класса ColorSelectionViewModel
        public ColorSelectionViewModel()
        {
            selectionModel = ColorSelectionModel.getInstance();
        }


        #region Команды ViewModel

        private RelayCommand _ProductGroupSelectionChanged; // Событие при изменении выбора в ProductGroup_ComboBox
        private RelayCommand _ColorFanSelectionChanged;     // аналогично первому
        private RelayCommand _ColorSelectionChanged;        // аналогично первому
        private RelayCommand _AddColor;                     // Событие нажатия на кнопку Apple

        public RelayCommand ProductGroupSelectionChanged
        {
            get
            {

                return _ProductGroupSelectionChanged ??=
                    new RelayCommand(obj =>
                    {
                        // Получаем из переданного команде параметра ComboBox
                        ComboBox comboBox = obj as ComboBox;
                        // Из ComboBox берём Value выбранного Item
                        string value = (string)comboBox.SelectedValue;
                        // Передаём значение в свойство модели, которая сама
                        // вызывает соответствующий метод для обновления списка
                        selectionModel.ProductGroupSelected = value;
                    });
            }
        }

        public RelayCommand ColorFanSelectionChanged
        {
            get
            {

                return _ColorFanSelectionChanged ??=
                    new RelayCommand(obj =>
                    {
                        ComboBox comboBox = obj as ComboBox;
                        string value = (string)comboBox.SelectedValue;
                        selectionModel.ColorFanSelected = value;
                    });
            }
        }

        public RelayCommand ColorSelectionChanged
        {
            get
            {

                return _ColorSelectionChanged ??=
                    new RelayCommand(obj =>
                    {
                        ComboBox comboBox = obj as ComboBox;
                        string value = (string)comboBox.SelectedValue;
                        selectionModel.ColorSelected = value;
                    });
            }
        }

        public RelayCommand AddColor
        {
            get
            {

                return _AddColor ??=
                    new RelayCommand(obj =>
                    {
                        MessageBox.Show($"Будет добавлен следующий продукт:\nProductGroup - {selectionModel.ProductGroupSelected}\nColorFan - {selectionModel.ColorFanSelected}\nColor - {selectionModel.ColorSelected}");
                    });
            }
        }


        #endregion
    }
}
