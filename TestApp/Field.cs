using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    internal class Field
    {
        Cell cell = new Cell();

        public static byte InputFieldSizeX()
        {
            Console.WriteLine("Введите размер поля по x: ");
            byte x = Convert.ToByte(Console.ReadLine());
            if (x < 10)
            {
                Console.WriteLine("Значение должно быть больше 10!");
                return 0;
            }

            return x;
        }

        public static byte InputFieldSizeY()
        {
            Console.WriteLine("Введите размер поля по y: ");
            byte y = Convert.ToByte(Console.ReadLine());
            if (y < 10)
            {
                Console.WriteLine("Значение должно быть больше 10!");
                return 0;
            }

            return y;
        }

        public static bool RiverOnMap()
        {
            Console.WriteLine("Созданим реку? (Да/Нет) ");
            string may_river = Console.ReadLine().ToLower();
            if (may_river == "нет")
            {
                return false;
            }
            if (may_river == "да")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Иди нахуй не делай так");
                return false;
            }
        }

        public static char[,] FillFieldGround(byte x, byte y, bool river)
        {

            char[,] ground = new char[x, y];
            for (byte i = 0; i < x; i++)
            {
                for (byte j = 0; j < y; j++)
                {
                    if (river && (j == y/2 || j == (y/2) + 1))
                        ground[i, j] = Cell.water;
                    else
                        ground[i, j] = Cell.dirt;
                }
            }
            return ground;
        }
    }
}
