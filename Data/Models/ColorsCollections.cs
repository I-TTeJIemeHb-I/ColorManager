using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ColorManager.Data.Models
{
    public static class ColorsCollections
    { 
        public static ObservableCollection<ColorSelectionModel> SelectionColors;

        public static ObservableCollection<ColorSelectionModel> InStockColors;

        public static ObservableCollection<ColorSelectionModel> OutStockColors;
    }
}
