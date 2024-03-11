using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_Orai_4.Models;

namespace Workshop_Orai_4.ViewModel
{
    public class SnackEditorWindowViewModel
    {
        public Food Actual { get; set; }

        public void Setup(Food food)
        {
            this.Actual = food;
        }

        public SnackEditorWindowViewModel()
        {

        }
    }
}
