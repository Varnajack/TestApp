using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    // он и должен быть internal у тебя? Вообще лучше явно указывать модификаторы доступа
    // разве ты можешь создать класс Animal? Что это будет, просто животное? Какое при этом это будет животное?
    // не ясно. Сделай его абстрактным, чтобы нельзя было создавать экземпляры.
    class Animal
    {
        // обычно андерскоры в шарпе никто не использует, используй PascalCase для полей и свойств
        // иногда приватные члены класса пишут так - _camelCase. Но это вкусовщина твоего тимлида
        // вот конвенция нейминга по шарпу от майкрософта https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions
        // если будешь делать пол, то его стоит бахнуть Enum'кой. А не писать что-то в string.
        public string gender;
        // от некоторых этих признаков можно избавиться с помощью интерфейсов. Будет красивше
        public bool is_swim;
        public bool is_predator;
        public bool is_herbivore;
        public bool is_eaten;
        public bool is_only_water;
        public byte[] coordinates = new byte[2];
    }

    // классы стоит разносить по разным файлам. Это сильно путает, т.к. твой файл называется Animal.cs, класс Rabbit здесь никто не ожидает увидеть
    class Rabbit : Animal
    {
        // публичные поля плохая практика. Почитай тут https://softwareengineering.stackexchange.com/questions/161303/is-it-bad-practice-to-use-public-fields
        public string name;
        // во-первых, странный нейминг. Почему point (точка, место) у тебя это символ указывающий животное? Это должно быть что-то вроде DrawingSymbol.
        // во-вторых, почему он находится в классе наследнике? Если ты добавишь новое животное (Cow), то ему тоже придется добавлять это поле.
        // для этого и есть наследование, чтобы общие характеристики для групп объектов выносить в родительских класс.
        // в третьих, почему оно не readonly или еще как-то не ограничено? Если ты собираешься в ходе программы менять символ, которых отображает кролика, то вопросов ноль.
        // И последнее, это поле можно вообще убрать и сделать определение символа отрисовки объекта через словарь. Написал об этом в Program.cs 23 строка.
        public char point;
    }
}
