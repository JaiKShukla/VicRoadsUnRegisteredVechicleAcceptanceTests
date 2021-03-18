using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameWork.Helpers
{
    public static class  DateTimeHelper
    {

        public static string GetDate(string expression)
        {
            var date = DateTime.MaxValue;
            if (expression == "today")
            {
                 date = DateTime.Today;
            }

            else
            {
                //TO :DO Support more expressions

            }

            return date.ToString("dd/MM/yyyy");
        }

    }
}
