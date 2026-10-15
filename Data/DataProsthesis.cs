using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataProsthesis
    {
        public static readonly List<string> BodyParts = new List<string>()
        {
            "Руки", "Ноги", "Спина", "Торс", "Голова"
        };

        public static readonly List<string> Origin = new List<string>()
        {
            "Без привязки к локации/снят с охраны", "Шахта", "Склад запчастей", "Цех тяжелой сборки",
            "Лаборатория", "Экспериментальный цех", "Пустоши", "Наземная часть станции",
            "Станция"
        };
    }
}
