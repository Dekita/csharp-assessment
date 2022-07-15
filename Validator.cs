
namespace DekitaRPG_Assessment {
    internal class UserValidator {

        //! password data is not properly protected !
        //! should use some cryptographic hash comparison instead !
        private static string known_password = "clyderunners";

        /**
        * Define async main function:
        */
        public static void RequestUserCredentials(ref string? username, ref string? password) {
            Console.WriteLine("Please enter username:");
            username = Console.ReadLine();
            Console.WriteLine($"Please enter password for {username}:");
            password = Console.ReadLine();
            Console.WriteLine($"Please wait for validation:..");
        }

        public static bool CheckIfPasswordValid(string? username, string? password) {
            return password == known_password;
        }

    }
}
