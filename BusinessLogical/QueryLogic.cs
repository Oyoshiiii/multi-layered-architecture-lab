using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class QueryLogic
    {
        IRepository<Prosthesis> repository;

        /// <summary>
        /// Инициализация экземпляра класса, отвечающего за сложные запросы (сортировка, группировка)
        /// </summary>
        /// <param name="repository">Репозиторий для доступа к данным протезов</param>
        public QueryLogic(IRepository<Prosthesis> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Группирование по всем частям тела, за которые крепятся протезы
        /// </summary>
        /// <returns>Сгруппированный лист протезов</returns>
        public List<Prosthesis> GroupByAllBodyParts(List<string> bodyParts)
        {
            List<Prosthesis> groupedProstheses = new List<Prosthesis>();
            List<Prosthesis> prostheses = repository.ReadAll().ToList();

            foreach (string bodyPart in bodyParts)
            {
                List<Prosthesis> groupedBySpecificBodyPart = prostheses.Where(pr => pr.BodyPart == bodyPart).ToList();
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
            List<Prosthesis> prostheses = repository.ReadAll().ToList();
            List<Prosthesis> groupedProstheses = prostheses.Where(pr => pr.Origin == origin).ToList();

            return groupedProstheses;
        }

        /// <summary>
        /// Сортирование по возрастанию % потери рассудка
        /// </summary>
        /// <param name="prosthesesList">% потери рассудка</param>
        /// <returns>Сортированный лист протезов</returns>
        public List<Prosthesis> SortByPercentOfSanityLoss(List<Prosthesis> prosthesesList = null)
        {
            List<Prosthesis> sortedProstheses;
            if (prosthesesList == null) sortedProstheses = repository.ReadAll().ToList().OrderBy(pr => pr.PercentOfSanityLoss).ToList();
            else sortedProstheses = prosthesesList.OrderBy(pr => pr.PercentOfSanityLoss).ToList();

            return sortedProstheses;
        }

        /// <summary>
        /// Сортирование по убыванию % потери рассудка
        /// </summary>
        /// <param name="prosthesesList">% потери рассудка</param>
        /// <returns>Сортированный лист протезов</returns>
        public List<Prosthesis> SortByPercentOfSanityLossDescending()
        {
            List<Prosthesis> prostheses = repository.ReadAll().ToList();
            List<Prosthesis> sortedProstheses = prostheses.OrderByDescending(pr => pr.PercentOfSanityLoss).ToList();

            return sortedProstheses;
        }
    }
}
