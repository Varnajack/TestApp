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
            Field field = new Field();

            byte x = Field.InputFieldSizeX();
            byte y = Field.InputFieldSizeY();
            bool river_on_map = Field.RiverOnMap();
            char[,] ground = Field.FillFieldGround(x, y, river_on_map);


            for (int i = 0; i < ground.GetLength(0); i++)
                {
                    for (int j = 0; j < ground.GetLength(1); j++)
                    {
                        Console.Write(ground[i, j]);
                    }
                    Console.WriteLine();
                }


            Console.ReadKey();

            Random random = new Random();

            Rabbit rabbit = new Rabbit();
            // задание координат очень страшное. Никаких проверок на границы массива, сэтаем хрен пойми что. Что из этого ось x,
            // а что y тоже с первого взгляда не понятно.
            // создай структуру в которой будет два поля, x и y. Добавь в свой класс Animal поле с типом этой структуры. 
            rabbit.coordinates[0] = 18;
            rabbit.coordinates[1] = 3;
            rabbit.point = 'r';

            //это получается каждый раз нужно текущую позицию животного заполнять символом поверхности, которая там была. 
            //Создай список, в котором будут объекты на поле. И сделай механизм отрисовки, типа послойно, сначала поверхность, потом следующий слой объекты.
            //Послойно конечно не получится из-за того, что это консоль, но ты мою логику надеюсь понял. 
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

                // механизм перемещения стоит конкретно переделать. Создай отдельный класс под логику перемещения животных.
                // Дальше с помощью агрегации внедри этот функционал в Animal.
                // всё усложнится, когда появятся всякие препятствия или животные, которые могут и ходить, и плавать.

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




                // так делать нельзя. Переделай без усыпления потока.
                Thread.Sleep(500);
                Console.Clear();
            }

            /* 
            Кроме того что написал, можешь еще это поделать:

            Добавь здоровье у живых объектов.
            Еще можешь добавить неживые объекты.Например камень какой - нибудь, через него нельзя пройти. Колючки или кактус, будет сниматься хп.
            Капусту какую-нибудь например, будет хилить.
            */
        }
    }
}