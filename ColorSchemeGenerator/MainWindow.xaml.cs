using System;
using System.Windows;
using ColorPicker.Models;

namespace ColorScheme.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = ((App)Application.Current).Model;
            ((App)Application.Current).Model.Update();
            
        }

        private void PickerControlBase_OnColorChanged(object sender, RoutedEventArgs e)
        {
            
            //Model.Update();
        }
    }
}
