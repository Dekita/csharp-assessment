
namespace DekitaRPG_Assessment {
    internal class RaceRunner : IComparable<RaceRunner> {
        // object variables:
        public string first_name;
        public string last_name;
        public float seconds;
        // main race runner constructor:
        public RaceRunner(string fn, string ln, float t) {
            first_name = fn;
            last_name = ln;
            seconds = t;
        }
        // helper function to format print string for data
        public string ToPrintString() {
            return $"{first_name} {last_name}: {seconds}s";
        }
        // required for being able to call comparible functions like .Min(). 
        int IComparable<RaceRunner>.CompareTo(RaceRunner? other){
            if (other.seconds > seconds) return -1;
            else if (other.seconds == seconds) return 0;
            else return 1;
        }
    }
}
