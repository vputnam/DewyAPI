
namespace Dewy
{
    public class OneCallResponse
    {
        public int Lat { get; set; }
        public int Long { get; set; }
        public Current? current { get; set; }

    }

    public class Current 
    {
        public int UVI { get; set; }
        public int Humidity { get; set; }
        public int Temp { get; set; }
    }
}