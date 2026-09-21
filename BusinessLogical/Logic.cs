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
        List<Prosthesis> Prostheses = new List<Prosthesis>();

        public Logic()
        {
            Prostheses = data.Prostheses;
        }
        
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

            Prostheses.Add(prosthesis);
        }

        public List<Prosthesis> GetAllProstheses()
        {
            return Prostheses;
        }

        public Prosthesis GetProsthesisById(int id)
        {
            Prosthesis prosthesis = Prostheses.Find(pr => pr.Id == id);
            return prosthesis;
        }

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

        public void DeleteProsthesis(int id)
        {
            Prosthesis prosthesis = GetProsthesisById(id);

            if(prosthesis != null)
            {
                Prostheses.Remove(prosthesis);
            }
        }

        //сделать группировку по частям тела с выводом всех групп + % по возрастанию
        //сделать поиск (по сути группировку) по месту нахождения 
        //сделать получение листов с частями тела и местами нахождения протезов

        //эти группировку и сортировки убрать/изменить
        public List<Prosthesis> GroupByBodyPart(string bodyPart)
        {
            List<Prosthesis> groupedProstheses = Prostheses.Where(pr =>  pr.BodyPart == bodyPart).ToList();
            return groupedProstheses;
        }

        public List<Prosthesis> SortByPercentOfSanityLoss()
        {
            List<Prosthesis> sortedProstheses = Prostheses.OrderBy(pr => pr.PercentOfSanityLoss).ToList();
            return sortedProstheses;
        }

        public List<Prosthesis> SortByPercentOfSanityLossDescending()
        {
            List<Prosthesis> sortedProstheses = Prostheses.OrderByDescending(pr => pr.PercentOfSanityLoss).ToList();
            return sortedProstheses;
        }
    }
}
