﻿using System;
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
using Risk.Service.ContainerSetup;
using Microsoft.Practices.Unity;

namespace Risk.Client
{
    /// <summary>
    /// Interaction logic for RiskAnalyser.xaml
    /// </summary>
    public partial class RiskAnalyser : Window
    {
        public RiskAnalyser()
        {
            InitializeComponent();

            DataContext = Container.UnityContainer.Resolve<RiskAnalyserViewModel>();
        }

        
    }
}
