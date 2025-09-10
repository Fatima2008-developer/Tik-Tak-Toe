using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tik_Tak_Toe
{
    class Apptheme
    {
        public static void Changetheme(Uri themeuri)
        {
            try
            {
                ResourceDictionary Theme = new ResourceDictionary()
                {
                    Source = themeuri,
                };
                App.Current.Resources.Clear();
                App.Current.Resources.MergedDictionaries.Add(Theme);
            }
            catch (Exception ex)
            {
                MessageBox.Show("error showing:" + ex.Message);
            }
        }









    }
}
