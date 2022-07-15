
namespace DekitaRPG_Assessment {
    internal class Program {
        // request the user to input their menu selection
        // recursive when incorrect data entered.
        static void RequestUserMenuChoice(ref int? menuchoice) {
            try {
                menuchoice = Int32.Parse(Console.ReadLine());
                if (menuchoice <= 0 || menuchoice > 7) {
                    throw new ArgumentException();
                }
            } catch {
                Console.WriteLine("Invalid Input, please try again!!");
                RequestUserMenuChoice(ref menuchoice);
            }
        }
        // the main program loop that runs
        static void RunDemProgramLewp(ref bool can_exit){
            // display menu and get user choice: 
            int? menuchoice = null;
            Console.WriteLine("\n\nMain Menu:");
            Console.WriteLine("1: Read & Display File");
            Console.WriteLine("2: Sort & Print Times");
            Console.WriteLine("3: Print Fastest Time");
            Console.WriteLine("4: Print Slowest Time");
            Console.WriteLine("5: Search For Time");
            Console.WriteLine("6: Time Occurence");
            Console.WriteLine("7: Exit Program");
            Console.WriteLine("Please Enter Your Choice: (1-7)");
            RequestUserMenuChoice(ref menuchoice);
            Console.WriteLine("\n");
            // act on user choice
            switch (menuchoice) {
                case 1: MenuFunkz.PerformReadAndDisplayFile(); break;
                case 2: MenuFunkz.PerformSortAndPrintTimes(); break;
                case 3: MenuFunkz.PerformFindPrintFastest(); break;
                case 4: MenuFunkz.PerformFindPrintSlowest(); break;
                case 5: MenuFunkz.PerformSearchForTimes(); break;
                case 6: MenuFunkz.PerformTimeOccurence(); break;
                // set can_exit to true here when can exit:
                case 7: can_exit = true; break;
            }
            // wait for input before next iteration/exit app
            string next_text = can_exit ? "exit" : "continue";
            Console.WriteLine($"Press any key to {next_text}:..");
            Console.ReadKey();
        }
        // the main entry point into the application. 
        static void Main(string[] args) {
            // username stored here so we can access it after login
            string? username = null;
            // boolean to flag when a user has successfully logged in
            bool logged_in = false;
            // determines if the app can continue looping, or exit
            bool can_exit = false;
            // stores number of password attempts made since boot
            int attempts = 0;
            // while not logged in, and have remaining attempts:
            while (!logged_in && ++attempts <= 3) {
                // password is within this while block to ensure that 
                // its contents (user password - secure information)
                // is not held in memory after the login process.
                // a real app would/should use some auth token. 
                string? password = null; 
                // pass user/pass by ref to modify contents from user input
                UserValidator.RequestUserCredentials(ref username, ref password);
                // validate the user input data against known user/pass data
                if (UserValidator.CheckIfPasswordValid(username, password)) { // logged in
                    // tell the user that they have logged in correctly
                    Console.WriteLine($"Successfully logged in as: {username}");
                    logged_in = true; // set logged in flag
                    break; // stop the while lewp
                } else { // notify user of their failure and ask them to repeat
                    Console.WriteLine($"Attempts Remaining: {3-attempts}");
                    if (attempts == 3) { // close app after attemt limit reached
                        Console.WriteLine("Incorrect password limit reached: Exiting...");
                        can_exit = true; // disallow app from running main loop
                    }
                }
            }
            // prepare racer data from file:
            if (!MenuFunkz.LoadDataFromFile()) {
                Console.WriteLine("Could not find race-results.txt!!\nPlease ensure this file is located within the same folder as assessment.exe and try again!");
                can_exit = true;
            };
            // run the actual program loop:
            while (!can_exit) {
                RunDemProgramLewp(ref can_exit);
            }
        }

    } // program class
}// namespace
