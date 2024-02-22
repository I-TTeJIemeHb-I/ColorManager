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
        public List<Palletters> GetAll()
        {
            try
            {
                using (var db = new ApplicationContext())
                {
                    List<Palletters> palletters = new List<Palletters>();
                    

                    foreach(Palletters palletter in db.Palletters)
                    {
                        palletters.Add(palletter);
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
    }
}
