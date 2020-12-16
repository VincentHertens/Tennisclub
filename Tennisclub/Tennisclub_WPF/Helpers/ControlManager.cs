using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tennisclub_WPF.Helpers
{
    public static class ControlManager
    {
        public static void LoopVisualTree(DependencyObject obj, string value)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                if (obj is TextBox)
                    ((TextBox)obj).Text = value;
                if (obj is DatePicker)
                    ((DatePicker)obj).SelectedDate = null;
                if (obj is ComboBox)
                    ((ComboBox)obj).SelectedIndex = 0;
                LoopVisualTree(VisualTreeHelper.GetChild(obj, i), value);
            }
        }
    }
}
