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
            int size = Convert.ToInt32(Console.ReadLine());
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
                case 5:
                    sizeString = "XL";
                    break;
                default:
                    sizeString = "Invalid sıze!";
                    Console.WriteLine("Pleas enter a valid size from 1 to 5");
                    break;
            }

            string teamMembersListString = "(";
            foreach (var member in teamMembers)
            {
                teamMembersListString +=  + member.Key + ":" + member.Value + ", ";
            }
            teamMembersListString += ")";

            
            Console.WriteLine("Enter Task Appointee(choose form {0}): ", teamMembersListString.Substring(0, teamMembersListString.Length-2));
            int appointee= Convert.ToInt32(Console.ReadLine());
            if (teamMembers.ContainsKey(appointee))
            {
                    Console.WriteLine("Pleas enter a valid size from 1 to 5");
            }

            return new string[] { name, content, sizeString, appointee.ToString() };
        }

        private static string RemoveCard(string cardNameToBeDeleted)
        {
            string methodReturnState = "unsuccessfull";
            foreach (Card card in (Board.ListOfAllCards))
            {
                if (card.CardName == cardNameToBeDeleted)
                {
                    Board.ListOfAllCards.Remove(card);

                    if (card.BoardColumn == 1)
                        Board.TO_DO_Column.Remove(card);

                    else if (card.BoardColumn == 2)
                        Board.IN_PROGRESS_Column.Remove(card);

                    else
                        Board.DONE_Column.Remove(card);

                    methodReturnState= "successfull";
                }
                methodReturnState = "unsuccesfull";
            }
            return methodReturnState;
        }

        private static void MoveCardColumn(string cardNameToBeMoved, int columnToMoveCardTo)
        {
            
            foreach (Card card in (Board.ListOfAllCards))
            {
                if (card.CardName == cardNameToBeMoved)
                {
                    
                    if (card.BoardColumn == 1)
                        Board.TO_DO_Column.Remove(card);

                    else if (card.BoardColumn == 2)
                        Board.IN_PROGRESS_Column.Remove(card);

                    else
                        Board.DONE_Column.Remove(card);

                    card.BoardColumn = columnToMoveCardTo;
                    
                    if (card.BoardColumn == 1)
                        Board.TO_DO_Column.Add(card);

                    else if (card.BoardColumn == 2)
                        Board.IN_PROGRESS_Column.Add(card);

                    else
                        Board.DONE_Column.Add(card);
                }
            }
        }

        private static bool CardExists(string cardNameToBeChecked)
        {
            //bool cardExists = false;
            foreach (Card card in (Board.ListOfAllCards))
            {
                if (card.CardName == cardNameToBeChecked)
                {
                    Console.WriteLine("Name: {}", card.CardName);
                    Console.WriteLine("Content: {}", card.CardContent);
                    Console.WriteLine("Appointee: {}", card.TaskAppointee);
                    Console.WriteLine("Size: {}", card.CardSize);
                    Console.WriteLine("-");
                    return true;
                }
            }
            return false;
        }
        #endregion


        static void Main(string[] args)
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
            Card DefaultCard1 = new Card(new string[] { "Laundry", "Do laundry by tomorrow", "1", "5" });
            Board.ListOfAllCards.Add(DefaultCard1);
            Board.TO_DO_Column.Add(DefaultCard1);

            Card DefaultCard2 = new Card(new string[] { "Garbage", "Take out the garbage", "2", "3" });
            Board.ListOfAllCards.Add(DefaultCard2);
            Board.TO_DO_Column.Add(DefaultCard1);

            Card DefaultCard3 = new Card(new string[] { "Garden", "Mow the lawn", "4", "1" });
            Board.ListOfAllCards.Add(DefaultCard3);
            Board.TO_DO_Column.Add(DefaultCard1);
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
                        #region Board_viewing_loops
                        Console.WriteLine("\n TODO Line");
                        Console.WriteLine("************************");
                        foreach (Card card in Board.TO_DO_Column)
                        {
                            Console.WriteLine("Name     :   {0}", card.CardName);
                            Console.WriteLine("Content  :   {0}", card.CardContent);
                            Console.WriteLine("Appointee:   {0}", card.TaskAppointee);
                            Console.WriteLine("Size     :   {0}", card.CardSize);
                            Console.WriteLine("-");
                        }

                        Console.WriteLine("\n IN PROGRESS Line");
                        Console.WriteLine("************************");
                        foreach (Card card in Board.IN_PROGRESS_Column)
                        {
                            Console.WriteLine("Name     :   {0}", card.CardName);
                            Console.WriteLine("Content  :   {0}", card.CardContent);
                            Console.WriteLine("Appointee:   {0}", card.TaskAppointee);
                            Console.WriteLine("Size     :   {0}", card.CardSize);
                            Console.WriteLine("-");
                        }

                        Console.WriteLine("\n DONE Line");
                        Console.WriteLine("************************");
                        foreach (Card card in Board.DONE_Column)
                        {
                            Console.WriteLine("Name     :   {0}", card.CardName);
                            Console.WriteLine("Content  :   {0}", card.CardContent);
                            Console.WriteLine("Appointee:   {0}", card.TaskAppointee);
                            Console.WriteLine("Size     :   {0}", card.CardSize);
                            Console.WriteLine("-");
                        }
                        #endregion
                    }


                    else if (operation_to_be_performed == 2)
                    {
                        Card newCard = new Card(GetCardDetailsFromUser(TeamMembers));
                        Board.ListOfAllCards.Add(newCard);
                        Board.TO_DO_Column.Add(newCard);
                    }


                    else if (operation_to_be_performed == 3)
                    {
                        
                        while (true)
                        {
                            Console.WriteLine("Please enter the name of the card that will be deleted:");
                            string cardNameToBeDeleted = Console.ReadLine();

                            if (RemoveCard(cardNameToBeDeleted) == "successfull")
                            {
                                Console.WriteLine("The Card named \"{0}\" will be deleted. Do you confirm? (y/n): ", cardNameToBeDeleted);

                                if (Console.ReadLine() == "y")
                                {
                                    Console.WriteLine("*******Card was removed successfully*********\n");
                                    break;
                                }
                                else
                                    break;
                            

                            }
                            else
                            {
                                Console.WriteLine("Sorry! We could not find any card matching your query criteria.");
                                Console.WriteLine("\n********************* CHOOSE  ************************\n " +
                                                  "(1)To go back to the main menu: \n(2) To Try again: ");
                                if (Convert.ToInt32(Console.ReadLine()) == 1)
                                    break;
                                else
                                    continue;
                            }
                        }
                    }
                    

                    else if (operation_to_be_performed == 4)
                    {
                        while (true)
                        {
                            Console.WriteLine("Please enter the name of the card to be moved to another column:");
                            string cardNameToBeMoved = Console.ReadLine();

                            if (CardExists(cardNameToBeMoved))
                            {
                                Console.WriteLine(" Card Information Found");
                                Console.WriteLine("**************************************");
                                
                                Console.WriteLine("Enter the column the card will be moved to: ");
                                Console.WriteLine("(1) TODO ");
                                Console.WriteLine("(2) IN PROGRESS ");
                                Console.WriteLine("(3) DONE ");

                                int columnToMoveCardTo=Convert.ToInt32(Console.ReadLine());
                                MoveCardColumn(cardNameToBeMoved, columnToMoveCardTo);
                            }

                            else
                            {
                                Console.WriteLine("Sorry! We could not find any card matching your query criteria.");
                                Console.WriteLine("\n********************* CHOOSE  ************************\n " +
                                                  "(1)To go back to the main menu: \n(2) To Try again: ");
                                if (Convert.ToInt32(Console.ReadLine()) == 1)
                                    break;
                                else
                                    continue;
                            }

                        }
                    }

                    else
                    {
                        Console.WriteLine("\nIncorrect Input! \nPlease Choose a number from 1 to 4.\n");
                        continue;
                    }
                }

                catch (FormatException e)
                {
                    Console.WriteLine("\n" + e.Message + " Please Choose a number from 1 to 4.\n");
                    continue;
                }
            }
        }

        
    }
}
