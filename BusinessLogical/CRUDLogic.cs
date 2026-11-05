using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CRUDLogic
    {
        IRepository<Prosthesis> repository;

        /// <summary>
        /// Инициализация экземпляра класса отвечающего за логику crud операций
        /// </summary>
        /// <param name="repository">Репозиторий для доступа к данным протезов</param>
        public CRUDLogic(IRepository<Prosthesis> repository)
        {
            this.repository = repository;
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
        public void AddProsthesis(string modelName, string bodyPart, int percentOfSanityLoss, string buffDescript, string debuffDescript, string origin)
        {
            Prosthesis prosthesis = new Prosthesis()
            {
                ModelName = modelName,
                BodyPart = bodyPart,
                PercentOfSanityLoss = percentOfSanityLoss,
                BuffDescription = buffDescript,
                DebuffDescription = debuffDescript,
                Origin = origin
            };

            repository.Add(prosthesis);
        }

        /// <summary>
        /// Получение всех протезов
        /// </summary>
        /// <returns>Лист протезов</returns>
        public List<Prosthesis> GetAllProstheses()
        {
            return repository.ReadAll().ToList();
        }

        /// <summary>
        /// Получение протеза по ID
        /// </summary>
        /// <param name="id">ID протеза</param>
        /// <returns>Протез</returns>
        public Prosthesis GetProsthesisById(int id)
        {
            return repository.ReadById(id);
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

            if (prosthesis != null)
            {
                prosthesis.ModelName = modelName;
                prosthesis.BodyPart = bodyPart;
                prosthesis.PercentOfSanityLoss = percentOfSanityLoss;
                prosthesis.BuffDescription = buffDescript;
                prosthesis.DebuffDescription = debuffDescript;
                prosthesis.Origin = origin;

                repository.Update(prosthesis);
            }
        }

        /// <summary>
        /// Удаление протеза по ID
        /// </summary>
        /// <param name="id">ID протеза</param>
        public void DeleteProsthesis(int id)
        {
            Prosthesis prosthesis = GetProsthesisById(id);

            if (prosthesis != null)
            {
                repository.Delete(prosthesis);
            }
        }
    }
}
