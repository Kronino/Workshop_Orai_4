using Workshop_Orai_4.Models;

namespace Workshop_Orai_4.Logic
{
    public interface IFoodLogic
    {
        int TotalCost { get; }

        void AddNewFoodCommand();
        void AddToCartCommand(Food food);
        void EditFoodCommand(Food food);
        void RemoveFromFoodsCommand(Food food);
        void SetupCollection(IList<Food> snacks, IList<Food> cart);
    }
}