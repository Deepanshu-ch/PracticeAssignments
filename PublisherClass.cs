namespace EventHandler
{
    public class TempratureEventArgs : EventArgs
    {
        public Temprature? Temp { get; set; }
    }
    class DetectTempratureChange  // publisher class
    {
        public delegate void DetectChange(object source, TempratureEventArgs args);

        public event DetectChange? ChangeDetected;

        public void Detect(Temprature temp)
        {
            if (temp.ChangeTempratureTo < 30)
                OnChangeDetected(temp);
        }
        protected virtual void OnChangeDetected(Temprature temp)
        {
            ChangeDetected?.Invoke(this, new TempratureEventArgs() { Temp = temp });
        }
    }
}
