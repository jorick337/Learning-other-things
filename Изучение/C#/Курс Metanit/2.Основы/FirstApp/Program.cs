#region СТРУКТУРА ПРОГРАММЫ

// Я простой коментарий
// {
//     Console.WriteLine("Я единый");
//     Console.WriteLine("блок");
// }

/*
    Первая программа на С#
*/
// {
//     Console.WriteLine("Я первый блок");
//     {
//         Console.WriteLine("Я второй блок");
//     }
// }

#endregion

#region ПЕРЕМЕННЫЕ И КОНСТАНТЫ


// {
//     string name;
//     const string Name = "Kostya";   // Обязательная инициализация(не изменяется)

//     name = "Kostya";
//     Console.WriteLine(name);

//     name = "Bob";                   // Можно менять сколько угодно
//     Console.WriteLine(name);

//     // Name = "Bob"; - НЕЛЬЗЯ
//     Console.WriteLine(Name);
// }

#endregion

#region ЛИТЕРАЛЫ

// // Логические:
// {
//     Console.WriteLine(true);
//     Console.WriteLine(false);
// }

// // Целочисленные:
// {
//     Console.WriteLine(5);       // Простое

//     Console.WriteLine(0b11);    // Двоичная форма(3)

//     Console.WriteLine(0x0A);    // Шестанадцатиричная фррма(10)
// }

// // Вещественные:
// {
//     Console.WriteLine(3.14);    // Простое

//     Console.WriteLine(3.2e3);   // 3.2 * 10^3 = 3.2 * 1000 = 3200

//     Console.WriteLine(1.2E-1);  // 1.2 * 10^-1 = 1.2 * 0,1 = 0,12
// }

// // Символьные:
// {
//     Console.WriteLine('K');     // Простые

//     Console.WriteLine("A\nB");  // '\n' - перевод строки

//     Console.WriteLine("\tA");   // '\t' - табуляция

//     Console.WriteLine("\\");    // '\\' - сам слеш(\)

//     // https://www.asciitable.com/ - коды ASCII
//     Console.WriteLine('\x78');  // '\x78' -символ x
//     Console.WriteLine('\x5A');  // '\x5A' -символ z

//     // https://symbl.cc/ru/ - коды Unicode
//     Console.WriteLine('\u0420');  // P
//     Console.WriteLine('\u0421');  // C
// }

// // Строковые:
// {
//     Console.WriteLine("Kostya");    // Обычные

//     Console.WriteLine("Kostya \"Cool\"");   // '\"' - кавычка в кавычках
// }

#endregion

#region ТИПЫ ДАННЫХ

// {
//     bool True = true;
//     bool False = false;

//     byte bit1 = 1;      // от 0 до 255
//     byte bit2 = 102;    // 1 байт

//     sbyte bit3 = -101;  // от 128 до 127
//     sbyte bit4 = 102;   // 1 байт

//     short n1 = 1;       // от -32768 до 32767
//     short n2 = 102;     // 2 байта

//     ushort n3 = 1;      // от 0 65535
//     ushort n4 = 102;    // 2 байта

//     int a = 1000;       // от -2147483648 до 2147483648, 4 байта
//     uint b = 1000u;      // от 0 до 4294967295, 4 байта

//     long l = 1000L;      // от –9 223 372 036 854 775 808 до 9 223 372 036 854 775 807, 8 байт
//     ulong L = 1000ul;     // от 0 до 18 446 744 073 709 551 615, 8 байт

//     float f = 1.2f;     // от -3.4*10^38 до 3.4*10^38, 4 байта
//     double d = 1.2f;    // от ±5.0*10^-324 до ±1.7*10^308, 8 байт
//     decimal D = 1.5m;   // ±1.0*10^-28 до ±7.9228*10^28, 16 байт

//     char h = 'K';       // 2 байта
//     string s = "Kostya";

//     // Хранит любой тип данных
//     object O = 22;      // 4 байта если 32 разрядная
//     O = 3.14;           // 8 байт если 64
//     O = "Kostya";

//     Console.WriteLine($"{s} + {O} + {a} + {d}");

//     var name = "Kostya";    // автоматически находит тип
//     Console.WriteLine(name.GetType());  // System.String

//     // var c; - нельзя просто инициализировать тип без типа
//     // var c = null; - так же ошибка
// }

#endregion

#region 



#endregion

#region 



#endregion