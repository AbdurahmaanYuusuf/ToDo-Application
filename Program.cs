using System;
using System.Collections.Generic;

namespace ToDo_Application
{
    class Program
    {
        #region Helper_Functions
        private static string[] GetCardDetailsFromUser(Dictionary<int,string> teamMembers)
        {
            Console.WriteLine("Enter card name: ");
            string name= Console.ReadLine();
            
            Console.WriteLine("Enter card content: ");
            string content = Console.ReadLine();
            
            Console.WriteLine("Choose size(1-5) -> XS(1),S(2),M(3),L(4),XL(5): ");
            int size= Convert.ToInt32(Console.ReadLine());
            string sizeString;
            switch (size)
            {
                
                case 1:
                    sizeString = "XS";
                    break;
                case 2:
                    sizeString = "XS";
                    break;
                case 3:
                    sizeString = "XS";
                    break;
                case 4:
                    sizeString = "XS";
                    break;
                default:
                    sizeString = "XL";
                    break;
            }


            string TeamMembersListString="";
            foreach (var item in teamMembers.Keys)
            {
                TeamMembersListString += "(" + item + "), ";
            }
            Console.WriteLine("Enter Task Appointee(choose form {0}): ", TeamMembersListString.Substring(0, TeamMembersListString.Length-2));
            string appointee=Console.ReadLine();
            
            return new string[] { name,content,sizeString,appointee };
        }
        #endregion


        public static void Main(string[] args)
        {
            #region creating Members Dictionary and some Default cards
            //cretaing a dictionary of team meber IDs and tehir names
            Dictionary<int, string> TeamMembers = new();
            TeamMembers.Add(1, "Ahmed");
            TeamMembers.Add(2, "Mohamed");
            TeamMembers.Add(3, "Ibrahim");
            TeamMembers.Add(4, "Hassan");
            TeamMembers.Add(5, "Ali");

            //creating by default three cards and adding them to the board
            Card DefaultCard1 = new Card(new string[] { "", "", "", "" });
            Board.TO_DO_Column.Add(DefaultCard1);
            Card DefaultCard2 = new Card(new string[] { "", "", "", "" });
            Board.TO_DO_Column.Add(DefaultCard1);
            Card DefaultCard3 = new Card(new string[] { "", "", "", "" });
            Board.IN_PROGRESS_Column.Add(DefaultCard1);
            #endregion

            

            while (true)
            {
                Console.WriteLine("Please Choose the operation you want to perform:");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Show the Board");
                Console.WriteLine("(2) Add card to the Board");
                Console.WriteLine("(3) Remove card from the Board");
                Console.WriteLine("(4) Move card to anotehr column");


                try
                {
                    int operation_to_be_performed = Convert.ToInt32(Console.ReadLine());

                    if (operation_to_be_performed == 1)
                    {
                        //REFACTOR THE FOREACH LOOPS. USE FUNCTION CALSS INSTEAD OF LOOPS.
                        #region Bard_viewing_loops
                        Console.WriteLine(" TODO Line");
                        Console.WriteLine("************************");
                        foreach (Card card in Board.TO_DO_Column)
                        {
                            Console.WriteLine("Name: {}", card.CardName);
                            Console.WriteLine("Content: {}", card.CardContent);
                            Console.WriteLine("Appointee: {}", card.TaskAppointee);
                            Console.WriteLine("Size: {}", card.CardSize);
                            Console.WriteLine("-");
                        }
                        foreach (Card card in Board.IN_PROGRESS_Column)
                        {
                            Console.WriteLine(" IN PROGRESS Line");
                            Console.WriteLine("************************");
                            Console.WriteLine("Name: {}", card.CardName);
                            Console.WriteLine("Content: {}", card.CardContent);
                            Console.WriteLine("Appointee: {}", card.TaskAppointee);
                            Console.WriteLine("Size: {}", card.CardSize);
                            Console.WriteLine("-");
                        }
                        foreach (Card card in Board.DONE_Column)
                        {
                            Console.WriteLine(" DONE Line");
                            Console.WriteLine("************************");
                            Console.WriteLine("Name: {}", card.CardName);
                            Console.WriteLine("Content: {}", card.CardContent);
                            Console.WriteLine("Appointee: {}", card.TaskAppointee);
                            Console.WriteLine("Size: {}", card.CardSize);
                            Console.WriteLine("-");
                        }
                        #endregion
                    }


                    else if (operation_to_be_performed == 2)
                    {
                        Card newCard = new Card(GetCardDetailsFromUser(TeamMembers));
                        Board.TO_DO_Column.Add(newCard);
                    }


                    else if (operation_to_be_performed == 3)
                    {
                        Console.WriteLine("Please enter the name of the card that will be deleted:");
                        string cardNameToBeDeleted = Console.ReadLine();
                    }
                    

                    else
                    {
                        
                    }
                }

                catch (FormatException e)
                {
                    Console.WriteLine(e.Message + " Please Choose a number from 1 to 4.\n");
                    continue;
                }
            }
        }
    }
}
