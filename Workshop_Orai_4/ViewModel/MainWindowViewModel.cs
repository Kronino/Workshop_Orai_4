using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_Orai_4.Models;

namespace Workshop_Orai_4.ViewModel
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public ObservableCollection<Food> Foods { get; set; }
        public ObservableCollection<Food> Cart { get; set; }

        private IFoodLogic logic;

        private Food selectedFood;

        public Food SelectedFood
        {
            get { return selectedFood; }
            set 
            {
                SetProperty(ref selectedFood, value);

            }
        }



        public MainWindowViewModel() 
        {

        }
    }
}
