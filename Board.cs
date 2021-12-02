using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Application
{
    public static class Board
    {
        public static List<Card> ListOfAllCards = new();

        public static List<Card> TO_DO_Column = new();
        public static List<Card> IN_PROGRESS_Column = new();
        public static List<Card> DONE_Column = new();
        

    }      
}
