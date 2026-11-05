using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DataLogic
    {
        /// <summary>
        /// Получение листа всех частей тела, на которые крепятся протезы
        /// </summary>
        /// <returns>Лист частей тела</returns>
        public List<string> GetBodyParts()
        {
            return DataProsthesis.BodyParts;
        }

        /// <summary>
        /// Получения листа всех локаций/мест нахождения протезов
        /// </summary>
        /// <returns>Личт локаций/мест нахождения</returns>
        public List<string> GetOrigin() 
        {
            return DataProsthesis.Origin;
        }
    }
}
