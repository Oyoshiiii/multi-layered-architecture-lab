using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Logic
    {
        DataProsthesis data = new DataProsthesis();

        List<Prosthesis> prostheses = new List<Prosthesis>();

        List<string> bodyParts = new List<string>();
        List<string> origin = new List<string>();

        /// <summary>
        /// Инициализация нового экземпляра класса бизнес-логики <see cref="Logic"></see>
        /// </summary>
        public Logic()
        {
            prostheses = data.Prostheses;
            bodyParts = DataProsthesis.BodyParts;
            origin = DataProsthesis.Origin;
        }
        
        /// <summary>
        /// Добавление протеза в лист протезов
        /// </summary>
        /// <param name="id">ID протеза</param>
        /// <param name="modelName">Модель протеза</param>
        /// <param name="bodyPart">Часть тела на которую прикрепляется протез</param>
        /// <param name="percentOfSanityLoss">% потери рассудка</param>
        /// <param name="buffDescript">Описание баффов</param>
        /// <param name="debuffDescript">Описание дебаффов</param>
        /// <param name="origin">Локация/место нахождения</param>
        public void AddProsthesis(int id, string modelName, string bodyPart, int percentOfSanityLoss, string buffDescript, string debuffDescript, string origin)
        {
            Prosthesis prosthesis = new Prosthesis()
            {
                Id = id,
                ModelName = modelName,
                BodyPart = bodyPart,
                PercentOfSanityLoss = percentOfSanityLoss,
                BuffDescription = buffDescript,
                DebuffDescription = debuffDescript,
                Origin = origin
            };

            prostheses.Add(prosthesis);
        }

        /// <summary>
        /// Получение всех протезов
        /// </summary>
        /// <returns>Лист протезов</returns>
        public List<Prosthesis> GetAllProstheses()
        {
            return prostheses;
        }

        /// <summary>
        /// Получение протеза по ID
        /// </summary>
        /// <param name="id">ID протеза</param>
        /// <returns>Протез</returns>
        public Prosthesis GetProsthesisById(int id)
        {
            Prosthesis prosthesis = prostheses.Find(pr => pr.Id == id);
            return prosthesis;
        }

        /// <summary>
        /// Изменение протеза
        /// </summary>
        /// <param name="id">ID протеза</param>
        /// <param name="modelName">Модель протеза</param>
        /// <param name="bodyPart">Часть тела на которую прикрепляется протез</param>
        /// <param name="percentOfSanityLoss">% потери рассудка</param>
        /// <param name="buffDescript">Описание баффов</param>
        /// <param name="debuffDescript">Описание дебаффов</param>
        /// <param name="origin">Локация/место нахождения</param>
        public void ChangeProsthesis(int id, string modelName, string bodyPart, int percentOfSanityLoss, string buffDescript, string debuffDescript, string origin)
        {
            Prosthesis prosthesis = GetProsthesisById(id);

            if(prosthesis != null)
            {
                prosthesis.ModelName = modelName;
                prosthesis.BodyPart = bodyPart;
                prosthesis.PercentOfSanityLoss = percentOfSanityLoss;
                prosthesis.BuffDescription = buffDescript;
                prosthesis.DebuffDescription = debuffDescript;
                prosthesis.Origin = origin;
            }
        }

        /// <summary>
        /// Удаление протеза по ID
        /// </summary>
        /// <param name="id">ID протеза</param>
        public void DeleteProsthesis(int id)
        {
            Prosthesis prosthesis = GetProsthesisById(id);

            if(prosthesis != null)
            {
                prostheses.Remove(prosthesis);
            }
        }

        /// <summary>
        /// Получение листа всех частей тела, на которые крепятся протезы
        /// </summary>
        /// <returns>Лист частей тела</returns>
        public List<string> GetBodyPartsList()
        {
            return bodyParts;
        }

        /// <summary>
        /// Получения листа всех локаций/мест нахождения протезов
        /// </summary>
        /// <returns>Личт локаций/мест нахождения</returns>
        public List<string> GetOriginList()
        {
            return origin;
        }

        /// <summary>
        /// Группирование по всем частям тела, за которые крепятся протезы
        /// </summary>
        /// <returns>Сгруппированный лист протезов</returns>
        public List<Prosthesis> GroupByAllBodyParts()
        {
            List<Prosthesis> groupedProstheses = new List<Prosthesis>();

            foreach (string bodyPart in bodyParts)
            {
                List<Prosthesis> groupedBySpecificBodyPart = prostheses.Where(pr => pr.BodyPart ==  bodyPart).ToList();
                groupedBySpecificBodyPart = SortByPercentOfSanityLoss(groupedBySpecificBodyPart);

                groupedProstheses.AddRange(groupedBySpecificBodyPart);
            }

            return groupedProstheses;
        }

        /// <summary>
        /// Группирование по конкретному месту нахождения протезов
        /// </summary>
        /// <param name="origin">Локация/место нахождения протезов</param>
        /// <returns>Сгруппированный лист протезов</returns>
        public List<Prosthesis> GroupBySpecificOrigin(string origin)
        {
            List<Prosthesis> groupedProstheses = prostheses.Where(pr => pr.Origin == origin).ToList();
            return groupedProstheses;
        }

        /// <summary>
        /// Сортирование по возрастанию % потери рассудка
        /// </summary>
        /// <param name="prosthesesList">% потери рассудка</param>
        /// <returns>Сортированный лист протезов</returns>
        public List<Prosthesis> SortByPercentOfSanityLoss(List<Prosthesis> prosthesesList)
        {
            List<Prosthesis> sortedProstheses = prosthesesList.OrderBy(pr => pr.PercentOfSanityLoss).ToList();
            return sortedProstheses;
        }

        /// <summary>
        /// Сортирование по убыванию % потери рассудка
        /// </summary>
        /// <param name="prosthesesList">% потери рассудка</param>
        /// <returns>Сортированный лист протезов</returns>
        public List<Prosthesis> SortByPercentOfSanityLossDescending(List<Prosthesis> prosthesesList)
        {
            List<Prosthesis> sortedProstheses = prosthesesList.OrderByDescending(pr => pr.PercentOfSanityLoss).ToList();
            return sortedProstheses;
        }
    }
}
