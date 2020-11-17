using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tennisclub_UI.Helpers
{
    public static class APIHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            string apiUrl = ConfigurationManager.AppSettings["Tennisclub_api"];
            ApiClient.BaseAddress = new Uri(apiUrl);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void LoopVisualTree(DependencyObject obj)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                if (obj is TextBox)
                    ((TextBox)obj).Text = null;
                if (obj is DatePicker)
                    ((DatePicker)obj).SelectedDate = null;
                if (obj is ComboBox)
                    ((ComboBox)obj).SelectedIndex = 0;
                LoopVisualTree(VisualTreeHelper.GetChild(obj, i));
            }
        }
    }
}
