﻿using FolderExplorer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FolderExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {      
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new WindowViewModel(this);
            DirectoryStructure.DataContext = new DirectoryStructureViewModel();            
            FilesList.DataContext = new FileListViewModel(FilesList.FullPath ?? Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
        }
    }
}
