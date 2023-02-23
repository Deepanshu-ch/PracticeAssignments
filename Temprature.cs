namespace EventHandler
{
    public class Temprature // Class which update Temprature
    {
        public Temprature()
        {

        }
        public Temprature(int Temp)
        {
            ChangeTempratureTo = Temp;
        }
        public int ChangeTempratureTo { get; set; }
    }
}
