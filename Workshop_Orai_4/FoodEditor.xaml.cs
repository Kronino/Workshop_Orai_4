using System;
using System.Collections;
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
using Workshop_Orai_4.Models;
using Workshop_Orai_4.ViewModel;

namespace Workshop_Orai_4
{
    /// <summary>
    /// Interaction logic for FoodEditor.xaml
    /// </summary>
    public partial class FoodEditor : Window
    {
        public FoodEditor(Food food)
        {
            InitializeComponent();
            this.DataContext = new SnackEditorWindowViewModel();
            (this.DataContext as SnackEditorWindowViewModel).Setup(food);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stack.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
            this.DialogResult = true;
        }
    }
}
