using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClaimAdjuster;
namespace Claim_Manager
{
    
    class Program
    {             
        static Queue<ClaimItem> _listOfClaims = new Queue<ClaimItem>();
        static void Main(string[] args)
        {
            _listOfClaims.Enqueue(new ClaimItem(1, "f", "ty", 400, Convert.ToDateTime("12/21/2021 1:48:48"), Convert.ToDateTime("12/21/2021"), true));
            _listOfClaims.Enqueue(new ClaimItem(2, "t", "fire", 300, Convert.ToDateTime("2/13/2021"), Convert.ToDateTime("2/28/2021"), true));


            
            MainMenuManager();
            ConsoleKeyInfo keypressed;
            //char cKeyPressed;
            bool bRun = true;

            while (bRun)
            {
                keypressed = Console.ReadKey();
                int iKeyPressed = Convert.ToInt32(keypressed.KeyChar.ToString());
                HandleAgentSelection(iKeyPressed);                     
                int iPressed = 0;
            }
        }      
            public static void HandleAgentSelection(int iKeyPressed)
        {
            switch ((MainMenu)iKeyPressed)
            {
                case MainMenu.SeeAllClaims:
                    Console.WriteLine("CONSOLIDATED LIST OF CLAIMS");
                    Console.WriteLine("______________________________________________________________");

                    foreach (ClaimItem ci in _listOfClaims)
                        Console.WriteLine("Claim number={0}, ClaimType={1}, Description={2},Claim Amount={3}, Date of Incident={4}, Date of Claim={5}, Is Valid={6} ",
                            ci.ClaimID, ci.ClaimType, ci.Description, ci.ClaimAmount, ci.DateOfIncident, ci.DateOfClaim, ci.IsValid);
                    
                    
                    break;

                case MainMenu.TakeCareOfNextClaim:
                    MainMenuManager();
                    Console.WriteLine("To take care of next claim select y or n and hit enter");
                    char input = Console.ReadKey().KeyChar;
                    if (input == 'y')
                    {
                        Console.Clear();
                        Console.WriteLine(_listOfClaims.Dequeue().ClaimID);                       
                        break;
                    }
                    else if(input == 'n')
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input recieved.");
                        break;
                    }

                case MainMenu.EnterNewClaim:
                    Console.WriteLine("Enter CLAIM ID, CLAIM TYPE, DESCRIPTION, Claim Amount, DATE OF INCIDENT, DATE OF CLAIM, VALID and press enter");
                    string sInput = Console.ReadLine();
                    string[] aInput = sInput.Split(',');
                    if (aInput.Length == 7)
                    {
                        ClaimItem ci = new ClaimItem(Convert.ToInt32(aInput[0]), aInput[1], aInput[2], Convert.ToDouble(aInput[3]), Convert.ToDateTime(aInput[4]), Convert.ToDateTime(aInput[5]), Convert.ToBoolean(aInput[6]));
                        _listOfClaims.Enqueue(ci);
                        Console.WriteLine("Claim has been added.");
                    }
                    else
                    {
                        Console.WriteLine("You didnt provide enough data. Operation Cancelled.");
                    }
                    break;
            }

        }
        public static void MainMenuManager()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Claim Manager");
            Console.WriteLine();
            Console.WriteLine("Please make a selection below:");
            Console.WriteLine("_________________________________________");
            Console.WriteLine("1. See all claims");
            Console.WriteLine("2. Take care of next claim");
            Console.WriteLine("3. Enter new caim");
            Console.WriteLine("0. Exit");           
        }               
    }
}
