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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrinkChoice
{
    /// <summary>
    /// Interaction logic for RestaurantControl.xaml
    /// </summary>
    public partial class RestaurantControl : UserControl
    {
        public RestaurantControl()
        {
            InitializeComponent();
        }

        public void LoadChoices()
        {
            if(DataContext is Restaurant r)
            {
                StackPanel stack = new();
                foreach(SodaChoice choice in r.PossibleSodas)
                {
                    CheckBox box = new CheckBox();
                    box.DataContext = choice;
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath(nameof(choice.Chosen));
                    binding.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(box, CheckBox.IsCheckedProperty, binding);
                    TextBlock block = new();
                    block.Text = choice.ToString();
                    box.Content = block;
                    stack.Children.Add(box);
                }
                restDock.Children.Add(stack);
            }
        }
    }
}
