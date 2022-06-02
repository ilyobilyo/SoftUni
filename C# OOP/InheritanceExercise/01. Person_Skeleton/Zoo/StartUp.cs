using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Gorilla gorilla = new Gorilla("gorge");
            Bear bear = new Bear("mecho");
            Snake snake = new Snake("zmiq");
            Lizard lizard = new Lizard("rango");
            Reptile reptile = new Reptile("reptilche");
            Mammal mammal = new Mammal("bozainik");
            Animal animal = new Animal("jivotno");
        }
    }
}