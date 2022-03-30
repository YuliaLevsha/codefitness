using System;

namespace codefitnessbl.model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; }
        public double CaloiesPerMinute  { get; }
        public Activity(string name, double caloriesPerMinute)
        {
            //проверка

            Name = name;
            CaloiesPerMinute = caloriesPerMinute;

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
