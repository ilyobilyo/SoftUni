using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //6 Zadacha
            int numberOfPeople = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (personInfo.Length == 4)
                {
                    string name = personInfo[0];
                    int age = int.Parse(personInfo[1]);
                    string id = personInfo[2];
                    string birthYear = personInfo[3];

                    IBuyer citizen = new Citizen(name, age, id, birthYear);
                    buyers.Add(name, citizen);
                }
                else if (personInfo.Length == 3)
                {
                    string name = personInfo[0];
                    int age = int.Parse(personInfo[1]);
                    string group = personInfo[2];

                    IBuyer rebel = new Rebel(name, age, group);
                    buyers.Add(name, rebel);
                }
            }

            while (true)
            {
                string nameWhoBoughtFood = Console.ReadLine();
                if (nameWhoBoughtFood == "End")
                {
                    break;
                }

                if (buyers.ContainsKey(nameWhoBoughtFood))
                {
                    buyers[nameWhoBoughtFood].BuyFood();
                }
            }

            int totalFood = 0;
            foreach (var (name, buyer) in buyers)
            {
                totalFood += buyer.Food;
            }

            Console.WriteLine(totalFood);



            //5 Zadacha
            //List<Identifiable> humansAndRobots = new List<Identifiable>();
            //List<IBirthable> birtableThings = new List<IBirthable>();
            //while (true)
            //{
            //    string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //    if (input[0] == "End")
            //    {
            //        break;
            //    }

            //    if (input[0] == "Citizen")
            //    {
            //        string name = input[1];
            //        int age = int.Parse(input[2]);
            //        string id = input[3];
            //        string birthdate = input[4];

            //        Citizen citizen = new Citizen(name, age, id, birthdate);
            //        humansAndRobots.Add(citizen);
            //        birtableThings.Add(citizen);
            //    }
            //    else if (input[0] == "Pet")
            //    {
            //        string name = input[1];
            //        string birthdate = input[2];

            //        Pet pet = new Pet(name, birthdate);
            //        birtableThings.Add(pet);
            //    }
            //    else if (input[0] == "Robot")
            //    {
            //        string model = input[0];
            //        string id = input[1];

            //        Identifiable currentRobot = new Robot(model, id);
            //        humansAndRobots.Add(currentRobot);
            //    }
            //}

            //string specificYear = Console.ReadLine();

            //foreach (var birthable in birtableThings)
            //{
            //    string birthableYear = birthable.GetBirthYear();

            //    if (birthableYear == specificYear)
            //    {
            //        Console.WriteLine(birthable.Birthdate);
            //    }
            //}




            // 4 Zadacha
            //List<Identifiable> humansAndRobots = new List<Identifiable>();

            //while (true)
            //{
            //    string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //    if (input[0] == "End")
            //    {
            //        break;
            //    }

            //    if (input.Length == 3)
            //    {
            //        string name = input[0];
            //        int age = int.Parse(input[1]);
            //        string id = input[2];

            //        Identifiable currentCitizen = new Citizen(name, age, id);
            //        humansAndRobots.Add(currentCitizen);
            //    }
            //    else if (input.Length == 2)
            //    {
            //        string model = input[0];
            //        string id = input[1];

            //        Identifiable currentRobot = new Robot(model, id);
            //        humansAndRobots.Add(currentRobot);
            //    }
            //}

            //string fakeIds = Console.ReadLine();

            //foreach (var item in humansAndRobots)
            //{
            //    string currentLastThreeNumbers = item.GetLastNumbers(fakeIds.Length);

            //    if (currentLastThreeNumbers == fakeIds)
            //    {
            //        Console.WriteLine(item.Id);
            //    }
            //}
        }
    }
}
