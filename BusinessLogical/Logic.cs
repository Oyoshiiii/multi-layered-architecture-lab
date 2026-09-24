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

        public Logic()
        {
            prostheses = data.Prostheses;
            bodyParts = data.BodyParts;
            origin = data.Origin;
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

            prostheses.Add(prosthesis);
        }

        public List<Prosthesis> GetAllProstheses()
        {
            return prostheses;
        }

        public Prosthesis GetProsthesisById(int id)
        {
            Prosthesis prosthesis = prostheses.Find(pr => pr.Id == id);
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
                prostheses.Remove(prosthesis);
            }
        }

        public List<string> GetBodyPartsList()
        {
            return bodyParts;
        }

        public List<string> GetOriginList()
        {
            return origin;
        }

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

        public List<Prosthesis> GroupBySpecificOrigin(string origin)
        {
            List<Prosthesis> groupedProstheses = prostheses.Where(pr => pr.Origin == origin).ToList();
            return groupedProstheses;
        }

        List<Prosthesis> SortByPercentOfSanityLoss(List<Prosthesis> prosthesesList)
        {
            List<Prosthesis> sortedProstheses = prosthesesList.OrderBy(pr => pr.PercentOfSanityLoss).ToList();
            return sortedProstheses;
        }
    }
}
