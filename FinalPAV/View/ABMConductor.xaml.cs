﻿using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalPAV.View
{
    /// <summary>
    /// Interaction logic for ABMConductor.xaml
    /// </summary>
    public partial class ABMConductor : MetroWindow
    {
        public ABMConductor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb_nombre.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            tb_apellido.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            tb_cuit.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            dp_nacimiento.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
        }
    }
}
