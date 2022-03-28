using System;

namespace codefitnessbl.model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калории за 100 грамм продукта.
        /// </summary>
        public double Calories { get; }
        public Food(string name) : this(name, 0, 0, 0, 0)
        {
        }
        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            //проверка
            Calories = calories / 100.0;
            Fats = fats / 100.0;
            Proteins = proteins / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Name = name;

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
