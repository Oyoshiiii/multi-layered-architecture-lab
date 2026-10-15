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
        public List<Prosthesis> Prostheses { get; } = new List<Prosthesis>() 
        {
            new Prosthesis()
            {
                Id = 1,
                ModelName = "VIS-IND-04 «Крот»",
                BodyPart = BodyParts[4],
                PercentOfSanityLoss = 2,
                BuffDescription = "Ночное зрение",
                DebuffDescription = "Базовый протез для рабочих, вред незначителен",
                Origin = Origin[2]
            },
            new Prosthesis()
            {
                Id = 2,
                ModelName = "LOC-IND-88 «Тягач»",
                BodyPart = BodyParts[2],
                PercentOfSanityLoss = 20,
                BuffDescription = "Грузоподъемность: +2 слота в инвентаре; устойчивость к отбрасыванию",
                DebuffDescription = "Скорость бега снижена на 10%; громкость при стелсе на 10% увеличивается",
                Origin = Origin[3]
            },
            new Prosthesis()
            {
                Id = 3,
                ModelName = "MOT-P-45 «Атлант»",
                BodyPart = BodyParts[2],
                PercentOfSanityLoss = 10,
                BuffDescription = "Грузоподъемность: +4 слота в инвентаре",
                DebuffDescription = "Скорость бега снижена на 15%",
                Origin = Origin[3]
            },
            new Prosthesis()
            {
                Id = 4,
                ModelName = "COR-MIL-02 «Панцирь»",
                BodyPart = BodyParts[3],
                PercentOfSanityLoss = 12,
                BuffDescription = "Поглощение 25% физического урона",
                DebuffDescription = "Расход энергии увеличивается на 15%",
                Origin = Origin[0]
            },
            new Prosthesis()
            {
                Id = 5,
                ModelName = "MAN-MIL-61 «Тесла»",
                BodyPart = BodyParts[0],
                PercentOfSanityLoss = 27,
                BuffDescription = "Встроенный шокер (слабых врагов убивает с одного выстрела, у сильных перегружает щиты)",
                DebuffDescription = "Психоз (раз в несколько убийств врагов появляются галлюцинации, точность удара падает на 15%",
                Origin = Origin[5]
            }
        };

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
