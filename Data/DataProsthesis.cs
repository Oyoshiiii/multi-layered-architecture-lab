using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataProsthesis
    {
        //заполнить данными, ~5 протезов записать 
        public List<Prosthesis> Prostheses { get; } = new List<Prosthesis>() 
        {
            new Prosthesis()
            {

            },
            new Prosthesis()
            {

            },
            new Prosthesis()
            {

            },
            new Prosthesis()
            {

            },
            new Prosthesis()
            {

            }
        };

        public readonly List<string> BodyParts = new List<string>()
        {
            "Руки", "Ноги", "Спина", "Торс", "Голова"
        };

        public readonly List<string> OriginLocation = new List<string>()
        {
            "Без привязки к локации", "Шахта", "Склад запчастей", "Цех тяжелой сборки",
            "Лаборатория", "Экспериментальный цех", "Пустоши", "Наземная часть станции",
            "Станция"
        };
    }
}
