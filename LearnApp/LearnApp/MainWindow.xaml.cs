// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using BetApp.Data;
using LearnApp.Models;
using System.Text.Json;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LearnApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }
        
        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";
            //// seeding database
            //Building A = new Building { BuildingName = "Gebouw A"};
            //Building B = new Building { BuildingName = "Gebouw A"};
            
            //Employees Employee_One = new Employees { Name = "Sam", Last_Name = "Ports", Building = A };
            //Employees Employee_Two = new Employees { Name = "Harry Potter", Last_Name = "Potter", Building = A };
            //Employees Employee_Three = new Employees { Name = "Karim", Last_Name = "Alkichouhi", Building = B };
            
            
            using (var context = new learnContext())
            {
                var LoadedBuilding = context.Building   .ToList();
                context.Employees.ToList();
                lv_building.ItemsSource = LoadedBuilding;
            }
        }
    }
}
