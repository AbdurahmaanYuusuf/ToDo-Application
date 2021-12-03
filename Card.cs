using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_Application
{
    public class Card
    {
        public string CardName { get; set; }
        public string CardContent { get; set; }
        public string TaskAppointee { get; set; }
        public string CardSize { get; set; }

        public int BoardColumn = (int)BoardColumns.TODO;

        public Card(string[] cardDetails)
        {
            this.CardName = cardDetails[0];
            CardContent = cardDetails[1];
            TaskAppointee= cardDetails[2];
            CardSize = cardDetails[3];
        }
    }
}
