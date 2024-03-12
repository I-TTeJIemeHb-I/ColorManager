using ColorManager.Data.Models;
using ColorManager.DataBase.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ColorManager.DataBase.Queries
{
    public class PallettersQuery
    {
        /// <summary>
        /// Возвращает все элементы таблицы Palletters
        /// </summary>
        /// <returns>palletters при успешном поиске эелементов/null при не нахождении эелементов</returns>
        public static List<Palettes> GetAll()
        {
            try
            {
                using (var db = new ApplicationContext())
                {
                    List<Palettes> palletters = new List<Palettes>();

                    foreach (Palettes palletter in db.Palettes)
                    {
                        foreach (Palettes palletter1 in palletters)
                        {
                            if (palletter1 == palletter) break;
                            else
                            {
                                palletters.Add(palletter);
                                break;
                            }
                        }
                    }
                    return palletters;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }


        /// <summary>
        /// Возвращает имя продукта
        /// </summary>
        /// <returns>List строковых значений с именем продукта</returns>
        public static ObservableCollection<string> GetProductGroup()
        {
            try
            {
                ObservableCollection<string> strings = new ObservableCollection<string>();

                using (var db = new ApplicationContext())
                {
                    // Перебираем все возможные варианты
                    foreach (Palettes palettes in db.Palettes)
                    {
                        // Проверяем значение на null, чтобы в списке ComboBox не было пустых ячеек
                        if (palettes.ProductGroup != null)
                        {
                            // Проверяем список на наличие аналогичного значения
                            // если такового нет - добавляем в список.
                            // Тем самым исключаем дубликаты.\
                            if (!strings.Contains(palettes.ProductGroup))
                            {
                                strings.Add(palettes.ProductGroup);
                            }
                        }
                    }
                }

                return strings;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                return new ObservableCollection<string>();
            }
        }


        /// <summary>
        /// Возвращает цветовую гамму продукта
        /// </summary>
        /// <param name="productGroup">Имя продукта</param>
        /// <returns>List строковых значений по имени продукта</returns>
        public static void GetColorFan(string productGroup)
        {
            // Здесь логику добавления цвета усложняем для того чтобы интерфейс автоматически обновлялся
            // Обращаемся к списку, находящемуся в ColorSelectionModel и добавляем цвета в него напрямую
            try
            {
                using (var db = new ApplicationContext())
                {
                    foreach (Palettes palettes in db.Palettes)
                    {
                        if (palettes.ProductGroup == productGroup)
                        {
                            if (palettes.ColorFan != null)
                            {
                                if (!ColorSelectionModel.getInstance().ColorFan.Contains(palettes.ColorFan))
                                {
                                    ColorSelectionModel.getInstance().ColorFan.Add(palettes.ColorFan);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        /// <summary>
        /// Возвращает цвета продукта
        /// </summary>
        /// <param name="productGroup">Имя продукта</param>
        /// <param name="colorFan">Цветовая гамма</param>
        /// <returns>List строковых значений по имени и цветовой гамме продукта</returns>
        public static void GetColor(string productGroup, string colorFan)
        {
            // Здесь логику добавления цвета усложняем для того чтобы интерфейс автоматически обновлялся
            // Обращаемся к списку, находящемуся в ColorSelectionModel и добавляем цвета в него напрямую
            try
            {
                using (var db = new ApplicationContext())
                {
                    foreach (Palettes palettes in db.Palettes)
                    {
                        if (palettes.ProductGroup == productGroup && palettes.ColorFan == colorFan)
                        {
                            if (palettes.Color != null)
                            {
                                if (!ColorSelectionModel.getInstance().Color.Contains(palettes.Color))
                                {
                                    ColorSelectionModel.getInstance().Color.Add(palettes.Color);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        /// <summary>
        /// Возвращает величену цвета
        /// </summary>
        /// <param name="productGroup">Имя продукта</param>
        /// <param name="colorFan">Цветовая гамма</param>
        /// <param name="color">Цвет продукта</param>
        /// <returns>Строка с величиной цвета</returns>
        public static ColorSelectionModel GetColorValue(ColorSelectionModel model)
        {
            //try
            //{
            //    using (var db = new ApplicationContext())
            //    {
            //        foreach (Palettes palletter in db.Palettes)
            //        {
            //            if (palletter.ProductGroup == model.ProductGroup && palletter.ColorFan == model.ColorFan && palletter.Color == model.Color)
            //            {
            //                model.ColorValue = palletter.Color;
            //                break;
            //            }
            //        }
            //        return model;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return null;
            //}
            return null;
        }


        /// <summary>
        /// Возвращает наличие продукта
        /// </summary>
        /// <param name="productGroup">Имя продукта</param>
        /// <param name="colorFan">Цветовая гамма</param>
        /// <param name="color">Цвет продукта</param>
        /// <param name="colorValue">Величина цвета</param>
        /// <returns>true при наличии продукта/false при его отсутствии</returns>
        public static ColorSelectionModel GetInStockInfo(ColorSelectionModel model)
        {
            //try
            //{
            //    using (var db = new ApplicationContext())
            //    {
            //        bool inStockInfo = false;
            //        foreach (Palettes palletter in db.Palettes)
            //        {
            //            if (palletter.ProductGroup == model.ProductGroup && palletter.ColorFan == model.ColorFan && palletter.Color == model.Color && palletter.ColorValue == model.ColorValue)
            //            {
            //                model.InStockInfo = palletter.InStock;
            //                break;
            //            }
            //        }
            //        return model;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return null;
            //}
            return null;
        }
    }
}
