using System;
using System.Collections.Generic;
using System.Linq;

namespace codefitnessbl.model
{
    [Serializable]
    /// <summary>
    /// Прием пищи.
    /// </summary>
    public class Eating
    {
        /// <summary>
        /// Когда поел.
        /// </summary>
        public DateTime Moment { get; }
        /// <summary>
        /// Что поел.
        /// </summary>
        public Dictionary<Food, double> Foods { get; }
        /// <summary>
        /// Кто поел.
        /// </summary>
        public User User { get; }
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым",nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();

        }

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if(product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
