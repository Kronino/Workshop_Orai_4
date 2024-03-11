using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_Orai_4.Models;

namespace Workshop_Orai_4.Services
{
    public class SnackEditorViaWindow : ISnackEditorViaWindow
    {
        public void Edit(Food food)
        {
            new FoodEditor(food).ShowDialog();
        }
    }
}
