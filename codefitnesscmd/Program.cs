using codefitnessbl.Controller;
using codefitnessbl.model;
using System;
using System.Globalization;
using System.Resources;

namespace codefitnesscmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("codefitnesscmd.Languages.Messages", typeof(Program).Assembly);
            
            Console.WriteLine(resourceManager.GetString("Hello", culture));
            
            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("дата рождения");
                var weight = ParseDouble("вес ");
                var heigth = ParseDouble("рост ");

                userController.SetNewUserData(gender, birthDate, weight, heigth);

            }
            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести прием пищи ");
                Console.WriteLine("A - ввести упражнение ");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:

                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);


                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии");

            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("конец упражнения");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность ");
            var prots = ParseDouble("белки ");
            var fats = ParseDouble("жиры ");
            var carbs = ParseDouble("углеводы ");
            var weight = ParseDouble("вес порции ");

            var product = new Food(food, calories, prots, fats, carbs);

            return (Food : product, Weight : weight);
            
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}.");
                }
            }
            return birthDate;
        }
        private static double ParseDouble(string name) 
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (Double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}.");
                }
            }
        }
    }
}
