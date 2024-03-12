using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Workshop_Orai_4.Logic;
using Workshop_Orai_4.Models;

namespace Workshop_Orai_4.ViewModel
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public ObservableCollection<Food> Foods { get; set; }
        public ObservableCollection<Food> Cart { get; set; }

        private IFoodLogic logic;

        public ICommand AddToCartCommand { get; set; }
        public ICommand AddNewFoodCommand { get; set; }
        public ICommand RemoveFromFoodsCommand { get; set; }
        public ICommand EditFoodCommand { get; set; }

        private Food selectedFood;
        public Food SelectedFood
        {
            get { return selectedFood; }
            set
            {
                if (selectedFood != value)
                {
                    if (selectedFood != null)
                    {
                        selectedFood.PropertyChanged -= SelectedFood_PropertyChanged;
                    }

                    SetProperty(ref selectedFood, value);

                    if (selectedFood != null)
                    {
                        selectedFood.PropertyChanged += SelectedFood_PropertyChanged;
                    }

                    (AddToCartCommand as RelayCommand).NotifyCanExecuteChanged();
                    (RemoveFromFoodsCommand as RelayCommand).NotifyCanExecuteChanged();
                    (EditFoodCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private void SelectedFood_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Food.Quantity))
            {
                (AddToCartCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public int TotalCost
        {
            get => logic.TotalCost;
        }

        public static bool IsInDesingMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
            : this(IsInDesingMode ? null : Ioc.Default.GetService<IFoodLogic>())
        {

        }

        public MainWindowViewModel(IFoodLogic logic)
        {
            this.logic = logic;
            Cart = new ObservableCollection<Food>();
            Foods = new ObservableCollection<Food>()
            {
                new Food{ Name = "Twix", Price = 300, Quantity = 20},
                new Food{ Name = "Mars", Price = 300, Quantity = 16},
                new Food{ Name = "BalatonSzelet", Price = 250, Quantity= 4},
                new Food{ Name = "SportSzelet", Price = 200, Quantity = 9},
                new Food{ Name = "Waffelini", Price = 260, Quantity = 15},
                new Food{ Name = "KitKat", Price = 350, Quantity = 2},
                new Food{ Name = "3Bit", Price = 340, Quantity = 15}
            };

            logic.SetupCollection(Foods, Cart);

            AddToCartCommand = new RelayCommand
            (
                () => logic.AddToCartCommand(SelectedFood),
                () => selectedFood != null && SelectedFood.Quantity > 0
            );

            AddNewFoodCommand = new RelayCommand
            (
                () => logic.AddNewFoodCommand()
            );

            RemoveFromFoodsCommand = new RelayCommand
            (
                () => logic.RemoveFromFoodsCommand(SelectedFood),
                () => selectedFood != null
            );

            EditFoodCommand = new RelayCommand
            (
                () => logic.EditFoodCommand(SelectedFood),
                () => selectedFood != null
            );

            Messenger.Register<MainWindowViewModel, string, string>(this, "FoodInfo", (recipient, msg) =>
            {
                OnPropertyChanged("TotalCost");
            });
        }
    }
}
