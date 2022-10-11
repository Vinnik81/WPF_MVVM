﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp_MVVM.Models;
using WpfApp_MVVM.ViewModels;

namespace WpfApp_MVVM.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
       MainViewModel viewModel;
       
        public MainView()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            DataContext = viewModel;
        }
                
        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            viewModel.AddTask();             
        }

        private void OnRemoveClick(object sender, RoutedEventArgs e)
        {
            viewModel.RemoveTask();
        }
    }
}

