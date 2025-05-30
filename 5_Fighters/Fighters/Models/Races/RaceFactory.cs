﻿using Fighters.UserIO;

namespace Fighters.Models.Races
{
    public class RaceFactory
    {
        public static IRace GetRaceType( int number )
        {
            switch ( number )
            {
                case 1:
                    return new Angel();

                case 2:
                    return new Demon();

                case 3:
                    return new Human();

                case 4:
                    return new Ghoul();

                case 5:
                    return new Ork();

                case 6:
                    return new Undead();

                case 7:
                    return new God();

                default:
                    return null;
            }
        }

        public static string GetRaceDescription()
        {
            return "Выберите рассу персонажа." +
                "\n1 - Ангел {Здоровье: 777, Защита: 777, Урон: 777, Инициатива: 10}" +
                "\n2 - Демон {Здоровье: 666, Защита: 666, Урон: 666, Инициатива: 666}" +
                "\n3 - Человек {Здоровье: 100, Защита: 0, Урон: 1, Инициатива: 50}" +
                "\n4 - Гуль {Здоровье: 1000 - 7, Защита: 1000 - 7, Урон: 1000 - 7, Инициатива: 1000 - 7}" +
                "\n5 - Орк {Здоровье: 150, Защита: 30, Урон: 10, Инициатива: 50}" +
                "\n6 - Нежить {Здоровье: 110, Защита: 0, Урон: 10, Инициатива: 60}" +
                "\n7 - Божество {Здоровье: 1000000000, Защита: 1000000000, Урон: 1000000000, Инициатива: 0}";
        }
    }
}