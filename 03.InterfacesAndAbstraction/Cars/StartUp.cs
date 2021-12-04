using System;

namespace Cars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Seat seat = new Seat("Leon", "Grey");
            Tesla tesla = new Tesla(2, "Model 3", "Red");

            Console.WriteLine(seat);
            Console.WriteLine(tesla);
            
        }
    }
}
