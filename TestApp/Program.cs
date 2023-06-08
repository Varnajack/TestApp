using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;
using System.Threading;

namespace TestApp
{
    class Program
    {
        static void Main()
        {
            char[,] ground = new char[20, 20]
            {
                {'+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'|', ' ', ' ', ' ', ' ', ' ', ' ', 'I', '*', '*', '*', '*', 'I', ' ', ' ', ' ', ' ', ' ', ' ', '|'},
                {'+', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '+'}
            };

            Random random = new Random();

            Rabbit rabbit = new Rabbit();
            rabbit.coordinates[0] = 18;
            rabbit.coordinates[1] = 3;
            rabbit.point = 'r';

            ground[rabbit.coordinates[0], rabbit.coordinates[1]] = rabbit.point;


            while (true)
            {

                for (int i = 0; i < ground.GetLength(0); i++)
                {
                    for (int j = 0; j < ground.GetLength(1); j++)
                    {
                        Console.Write(ground[i, j]);
                    }
                    Console.WriteLine();
                }

                int pos_x = random.Next(rabbit.coordinates[0] - 1, rabbit.coordinates[0] + 2);
                int pos_y = random.Next(rabbit.coordinates[1] - 1, rabbit.coordinates[1] + 2);

                if (pos_x <= 1)
                {
                    pos_x += 2;
                }
                if (pos_y <= 1)
                {
                    pos_y += 2;
                }
                if (pos_x >= 19)
                {
                    pos_x -= 2;
                }
                if (pos_y >= 19)
                {
                    pos_y -= 2;
                }

                byte position_x = Convert.ToByte(pos_x);
                byte position_y = Convert.ToByte(pos_y);


                while (ground[position_x, position_y] == 'I')
                {
                    position_x -= 1;
                    position_y -= 1;
                }

                ground[rabbit.coordinates[0], rabbit.coordinates[1]] = ' ';
                rabbit.coordinates[0] = position_x;
                rabbit.coordinates[1] = position_y;
                ground[rabbit.coordinates[0], rabbit.coordinates[1]] = rabbit.point;





                Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
}