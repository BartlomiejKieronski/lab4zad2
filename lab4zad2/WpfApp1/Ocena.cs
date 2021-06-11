namespace WpfApp1
{
    public partial class MainWindow
    {
        public class Ocena
        {
            public int Oceny { get; set; }

            public Ocena(int ocena)
            {
                this.Oceny = ocena;
            }
            public Ocena() 
                : this(0) { }
        }
    }
}