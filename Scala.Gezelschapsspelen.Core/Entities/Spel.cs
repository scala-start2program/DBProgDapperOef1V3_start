using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Scala.Gezelschapsspelen.Core.Entities
{
    [Table("Spelen")]
    public class Spel
    {
        [ExplicitKey]
        public string Id { get; private set; }
        public string Titel { get; set; }
        public int MinimumLeeftijd { get; set; }
        public int MaximumSpelers { get; set; }
        public int Spelduur { get; set; }
        public string CatId { get; set; }

        public Spel()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Spel(string titel, int minimumLeeftijd,
            int maximumSpelers, int spelduur, string catId)
        {
            Id = Guid.NewGuid().ToString();
            Titel = titel;
            MinimumLeeftijd = minimumLeeftijd;
            MaximumSpelers = maximumSpelers;
            Spelduur = spelduur;
            CatId = catId;

        }
        internal Spel(string id, string titel, int minimumLeeftijd,
            int maximumSpelers, int spelduur, string catId)
        {
            Id = id;
            Titel = titel;
            MinimumLeeftijd = minimumLeeftijd;
            MaximumSpelers = maximumSpelers;
            Spelduur = spelduur;
            CatId = catId;
        }
        public override string ToString()
        {
            return $"{Titel}";
        }

    }
}
