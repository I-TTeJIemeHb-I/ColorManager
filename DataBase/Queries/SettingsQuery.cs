using ColorManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ColorManager.DataBase.Queries
{
    public class SettingsQuery
    {
        public static Users LoadData()
        {
            try
            {
                using (var db = new ApplicationContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.IP == AuthorizationQuery.address[0].ToString());

                    if (user != null)
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ColorsManager: Профиль", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        //public static string[] SaveData(string[] array)
        //{
        //    try
        //    {
        //        using (var db = new ApplicationContext())
        //        {

            //        }
            //    }
            //    catch(Exception e)
            //    {
            //        MessageBox.Show(e.Message,"ColorsManager: Профиль",MessageBoxButton.OK,MessageBoxImage.Error);
            //    }
            //}
    }
}
