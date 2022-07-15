
namespace DekitaRPG_Assessment {
    internal class MenuFunkz {

        /**
        * Private variables:
        */
        private static string main_filepath = @"race-results.txt";
        private static string main_woutpath = @"out/";
        private static List<RaceRunner> runners = new List<RaceRunner>();

        /**
        * Menu functions/helpers:
        */
        public static RaceRunner[] GetRunnersArray() {
            return runners.ToArray();
        }
        public static void PerformReadAndDisplayFile() {
            Console.WriteLine("Read and display file:");
            foreach (var runner in GetRunnersArray()){            
                Console.WriteLine(runner.ToPrintString());
            }
        }
        public static void PerformSortAndPrintTimes() {
            Console.WriteLine("Sort and print times:");
            RaceRunner[] runners = GetRunnersArray();
            Array.Sort(runners, delegate(RaceRunner a, RaceRunner b) {
                return b.seconds.CompareTo(a.seconds);
            });// reverse sort (slowest->fastest)
            foreach (var runner in runners){            
                Console.WriteLine(runner.ToPrintString());
            }
            WriteArrayToFile($"sorted-results", runners);
        }
        public static void PerformFindPrintFastest() {
            Console.WriteLine("Find fastest time:");
            RaceRunner[] runners = GetRunnersArray();
            RaceRunner fastest = runners.Min();
            Console.WriteLine("Fastest recorded runner is:");
            Console.WriteLine(fastest.ToPrintString());
            WriteRunnerToFile($"fastest-result", fastest);
        }
        public static void PerformFindPrintSlowest() {
            Console.WriteLine("Find slowest time:");
            RaceRunner[] runners = GetRunnersArray();
            RaceRunner slowest = runners.Max();
            Console.WriteLine("Slowest recorded runner is:");
            Console.WriteLine(slowest.ToPrintString());
            WriteRunnerToFile($"slowest-result", slowest);
        }
        // unused- searching for all times faster than given time seemed
        // more logical than searching for only one time ~ what if two times have
        // the same seconds, searching the seconds should return both. 
        public static void PerformSearchForSingleTime() {
            Console.WriteLine("Searching for time:");
            Console.WriteLine("Please enter a time to search for (seconds):");
            float seconds = float.Parse(Console.ReadLine());
            Console.WriteLine($"Searching for times equal to or faster than: {seconds}");
            RaceRunner? result = Array.Find(GetRunnersArray(), runner => runner.seconds <= seconds);
            if (result == null) {
                Console.WriteLine("Search result returned no results!");
            } else {
                Console.WriteLine("Search result:");
                Console.WriteLine(result.ToPrintString());
                WriteRunnerToFile($"search-single-{seconds}s", result);
            }
        }
        public static void PerformSearchForTimes() {
            Console.WriteLine("Searching for time:");
            Console.WriteLine("Please enter a time to search for (seconds):");
            float seconds = float.Parse(Console.ReadLine());
            Console.WriteLine($"Searching for times equal to or faster than: {seconds}");
            RaceRunner[] result = Array.FindAll(GetRunnersArray(), runner => runner.seconds <= seconds);
            if (result.Length == 0) {
                Console.WriteLine("Search result returned no results!");
            } else {
                Console.WriteLine("Search results:");
                Array.Sort(result, delegate(RaceRunner a, RaceRunner b) {
                    return b.seconds.CompareTo(a.seconds);
                });
                foreach (var runner in result){
                    Console.WriteLine(runner.ToPrintString());
                }
                WriteArrayToFile($"search-foe-{seconds}s", result);
            }
        }
        public static void PerformTimeOccurence() {
            Console.WriteLine("Timing occurences:");
            Console.WriteLine("Please enter a time to search for (seconds):");
            float seconds = float.Parse(Console.ReadLine());
            int count = GetRunnersArray().Count(runner => runner.seconds == seconds);
            Console.WriteLine($"Number of entries with times equal to {seconds}s: {count}");
            WriteStringToFile($"time-occurence-{seconds}s", count.ToString());
        }

        /**
        * File Reading / Writing Functions
        */

        // loads data from given file on program launch
        public static bool LoadDataFromFile() {
            if (!File.Exists(main_filepath)) {
                return false;
            }
            using (StreamReader sr = File.OpenText(main_filepath)) {
                string? line = String.Empty; // create line variable with no property
                // set line property to current line and check if 
                // its equal to null, if null, stop looping
                while ((line = sr.ReadLine()) != null) {
                    string[] racer_data = line.Split(" ");
                    // add race runner into list
                    string fn = racer_data[0];
                    string ln = racer_data[1];
                    float t = float.Parse(racer_data[2]);
                    runners.Add(new RaceRunner(fn, ln, t));
                }
            }//! using(){ scope } ensures file is closed after operations!
            return true;
        }        

        // write a single race runner object to a file. 
        // note: creates a new race runner array with only one element..
        // could use the WriteStringToFile function instead, but this is more 'fun'
        private static void WriteRunnerToFile(string filepath, RaceRunner runner) {
            // WriteStringToFile(filepath, runner.ToPrintString()));
            WriteArrayToFile(filepath, new RaceRunner[]{ runner });
        }

        // converts a RaceRunner array into a string and then writes to file
        private static void WriteArrayToFile(string filepath, RaceRunner[] runners_array) {
            var runner_strings = runners_array.Select(p => p.ToPrintString());
            WriteStringToFile(filepath, String.Join("\n", runner_strings));
        }

        // Writes a string of data to a file: 
        // note: data string is responsible for its own newlines etc. 
        private static void WriteStringToFile(string filepath, string data) {
            // ensure directory exists - does nothing if it does: 
            System.IO.Directory.CreateDirectory(main_woutpath);
            // write the actual file contents:
            string write_path = $"{main_woutpath}{filepath}.txt";
            using (StreamWriter sw = new StreamWriter(write_path)){
                sw.Write(data);
            }//! using(){ scope } ensures file is closed after operations!
        }

    } // class
} // namespace
