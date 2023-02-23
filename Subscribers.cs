namespace EventHandler
{
    class User1 // Subscriber Class
    {
        public void OnChangeDetected(object source, TempratureEventArgs args)
        {
            if(args.Temp!=null)
                Console.WriteLine("Temprature is Dropped to" + args.Temp.ChangeTempratureTo);
        }
    }
    public class User2
    {
        public void OnChangeDetected(object source, TempratureEventArgs args)
        {
            if (args.Temp != null)
                Console.WriteLine("Temprature is Dropped by" + (30 - args.Temp.ChangeTempratureTo) + " degree.");
        }
    }
}