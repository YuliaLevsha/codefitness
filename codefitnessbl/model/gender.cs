﻿using System;

namespace codefitnessbl.model
{
    /// <summary>
    /// Пол
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создать новый пол
        /// </summary>
        /// <param name="name">Имя пола</param>
        public Gender (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
