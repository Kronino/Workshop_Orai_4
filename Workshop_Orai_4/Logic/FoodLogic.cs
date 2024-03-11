using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_Orai_4.Models;
using Workshop_Orai_4.Services;

namespace Workshop_Orai_4.Logic
{
    public class FoodLogic : IFoodLogic
    {
        IList<Food> Foods { get; set; }
        IList<Food> Cart { get; set; }
        IMessenger messenger { get; set; }
        ISnackEditorViaWindow editorService;

        public FoodLogic(IMessenger messenger, ISnackEditorViaWindow editorService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
        }

        public int TotalCost
        {
            get
            {
                return (int)(Foods.Count == 0 ? 0 : Cart.Sum(x => x.Price));
            }
        }

        public void SetupCollection(IList<Food> foods, IList<Food> cart)
        {
            this.Foods = foods;
            this.Cart = cart;
        }

        public void AddToCartCommand(Food food)
        {
            if (food.Quantity != 0)
            {
                if (food != null)
                {
                    this.Cart.Add(food.GetCopy());
                    if (food.Quantity > 0)
                    {
                        food.Quantity--;
                    }
                    messenger.Send("Food added", "FoodInfo");
                }
            }
        }

        public void RemoveFromFoodsCommand(Food food)
        {
            if (food != null)
            {
                this.Foods.Remove(food);
                messenger.Send("Food removed", "FoodInfo");
            }
        }

        public void AddNewFoodCommand()
        {
            var food = new Food();
            editorService.Edit(food);
            Foods.Add(food);
        }

        public void EditFoodCommand(Food food)
        {
            editorService.Edit(food);
        }

    }
}
