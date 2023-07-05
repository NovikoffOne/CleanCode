using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode
{
    class MethoodSet
    {
        public static void GenerateNewObject()
        {
            //Создание объекта на карте
        }

        public static void AssignChance()
        {
            _chance = Random.Range(0, 100);
        }

        public static int CalculateSalary(int hoursWorked)
        {
            return _hourlyRate * hoursWorked;
        }
    }
}
