using ColorManager.DataBase.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ColorManager.DataBase.Queries
{
    public class PallettersQuery
    {
        /// <summary>
        /// Возвращает все элементы таблицы Palletters
        /// </summary>
        /// <returns>palletters при успешном поиске эелементов/null при не нахождении эелементов</returns>
        public List<Palletters> GetAll()
        {
            try
            {
                using (var db = new ApplicationContext())
                {
                    List<Palletters> palletters = new List<Palletters>();
                    bool repeat = false;

                    foreach (Palletters palletter in db.Palletters)
                    {
                        foreach (Palletters palletter1 in palletters)
                        {
                            if (palletter == palletter1)
                            {
                                repeat = true;
                                continue;
                            }
                        }
                        if (repeat) continue;
                        else
                        {
                            repeat = false;
                            palletters.Add(palletter);
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
       /// Возвращает цветовую гамму продукта
       /// </summary>
       /// <param name="productGroup">Имя продукта</param>
       /// <returns>List строковых значений по имени продукта</returns>
        public List<string> GetColorFan(string productGroup)
        {
            try
            {
                using (var db = new ApplicationContext())
                {
                    List<string> colorFan = new List<string>();

                    foreach (Palletters palletter in db.Palletters)
                    {
                        if (palletter.ProductGroup == productGroup)
                        {
                            colorFan.Add(palletter.ColorFan);
                        }
                    }
                    return colorFan;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }


        /// <summary>
        /// Возвращает цвета продукта
        /// </summary>
        /// <param name="productGroup">Имя продукта</param>
        /// <param name="colorFan">Цветовая гамма</param>
        /// <returns>List строковых значений по имени и цветовой гамме продукта</returns>
        public List<string> GetColor(string productGroup, string colorFan)
        {
            try
            {
                using (var db = new ApplicationContext())
                {
                    List<string> color = new List<string>();

                    foreach (Palletters palletter in db.Palletters)
                    {
                        if (palletter.ProductGroup == productGroup && palletter.ColorFan == colorFan)
                        {
                            color.Add(palletter.Color);
                        }
                    }
                    return color;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }


        /// <summary>
        /// Возвращает наличие продукта
        /// </summary>
        /// <param name="id">ID продукта</param>
        /// <returns>true при наличии продукта/false при его отсутствии</returns>
        public bool GetInStockInfo(int id)
        {
            try
            {
                using (var db = new ApplicationContext())
                {
                    var palletter = db.Palletters.FirstOrDefault(p => p.ID == id);

                    if (palletter != null)
                    {
                        if (palletter.InStock) return true;
                        else return false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        } // НЕ ДОДЕЛАНО
    }
}
