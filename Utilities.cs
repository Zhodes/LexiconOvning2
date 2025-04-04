using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconÖvning2
{
    class Utilities
    {
        static string invalidInputAns = "\nOgiltigt input, försök igen\n";

        public static void mainMenu()
        {

            bool exitProgram = false;
            do
            {
                Console.WriteLine("Huvudmeny:\n \n 1: Ungdom eller pensionär \n 2: Upprepa tio gånger \n 3: Det tredje ordet \n 0: Avsluta program ");  
                string menuSelection = Console.ReadLine();
                Console.WriteLine("");
                switch (menuSelection)
                {
                    case "1":
                        cinemaTicketPrice();
                        break;
                    case "2":
                        writeInputTenTimes();
                        break;
                    case "3":
                        writeThirdWord();
                        break;
                    case "0":
                        exitProgram = true;
                        break;
                    default:
                        Console.WriteLine(invalidInputAns);
                        break;
                }
                Console.WriteLine();
            }
            while (!exitProgram);
        }



        //Kod för val 1
        #region
        private static void cinemaTicketPrice()
        {
            bool validInput = false;
            do
            {
                Console.WriteLine("Hur många biljetter vill du ha?");
                if (validInput = Int32.TryParse(Console.ReadLine(), out int numberOfTickets))
                {
                    int youthAge = 19;
                    int seniorAge = 65;
                    int babyAge = 4;
                    int superSeniorAge = 100;
                    int responsibleAdultAge = 18;
                    int age = 0;
                    int totalPrice = 0;
                    bool babyIncompany = false;
                    bool adultIncompany = false;
                    for (int i = 0; i < numberOfTickets; i++)
                    {
                        age = askAge(numberOfTickets, i);
                        totalPrice += priceByAge(age, youthAge, seniorAge, babyAge, superSeniorAge);
                        if (age < babyAge) babyIncompany = true;
                        if (age >= responsibleAdultAge) adultIncompany=true;
                        
                    }
                    if (babyIncompany && !adultIncompany) Console.WriteLine($"Barn under {babyAge + 1} kan endast besöka bion i en vuxens sällskap.");
                    else if (numberOfTickets == 1) writeTicketPrice(totalPrice, age, youthAge, seniorAge, superSeniorAge);
                    else writeTicketPrice(totalPrice, numberOfTickets);
                }
                else
                {
                    Console.WriteLine(invalidInputAns);
                    cinemaTicketPrice();
                }
            }
            while (!validInput);
        }

        private static void writeTicketPrice(int totalPrice, int numberOfTickets)
        {
            Console.WriteLine($"Ni är {numberOfTickets} personer i ert sällskap och ert pris blir {totalPrice}kr");
        }

        private static void writeTicketPrice(int totalPrice, int age, int youthAge, int seniorAge, int superSeniorAge)
        {
            if (age >= superSeniorAge) Console.WriteLine("Du är över 100 år gammal, grattis! Vi bjuder på din biljett.");
            else Console.WriteLine($"{(age <= youthAge ? "Ungdomspris" : (age >= seniorAge ? "Pensionärspris" : "Standardpris"))}: {totalPrice}kr");
        }

        private static int priceByAge(int age, int youthAge, int seniorAge, int babyAge, int superSeniorAge)
        {
            int youthPrice = 80;
            int seniorPrice = 90;
            int standardPrice = 120;
            int babyPrice = 0;
            int superSeniorPrice = 0;
            if (age <= babyAge) return babyPrice;
            else if(age >= superSeniorAge) return superSeniorPrice;
            else if (age <= youthAge) return youthPrice;
            else if (age >= seniorAge) return seniorPrice;
            else return standardPrice;


        }

        private static int askAge(int numberOfTickets, int i)
        {
            bool validInput = false;
            do
            {
                Console.WriteLine($"Vilken ålder är {(numberOfTickets == 1 ? "du" : $"besökare {i+1}")}?");
                validInput = Int32.TryParse(Console.ReadLine(), out int age);
                if (validInput && age >= 0)
                {
                    return age;
                }
                else
                {
                    Console.WriteLine(invalidInputAns);
                    validInput = false;
                }
            }
            while (!validInput);
            return 0;
        }
        #endregion

        //Kod för val 2
        private static void writeInputTenTimes()
        {
            Console.WriteLine("Skriv en text så upprepar jag den 10 gånger.");
            string Input = Console.ReadLine();
            string output = "";
            for (int i = 0; i < 10; i++)
            {
                output += Input;
            }
            Console.WriteLine(output);
        }

        // Kod för val 3
        private static void writeThirdWord()
        {

            bool validInput = false;
            do
            {
                Console.WriteLine("skriv en mening med minst 3 ord så returnerar jag det tredje ordet");
                string input = Console.ReadLine();
                string[] splitInput = input.Split();
                try
                {
                    Console.WriteLine(splitInput[2]);
                    validInput = true;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("För få ord angivna, försök igen. \n");
                }
            }
            while (!validInput);

        }




    }
}
