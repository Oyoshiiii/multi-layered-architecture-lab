using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Prosthesis : IDomainObject
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string BodyPart { get; set; }
        public int PercentOfSanityLoss { get; set; }
        public string BuffDescription { get; set; }
        public string DebuffDescription { get; set; }
        public string Origin {  get; set; }
    }
}
