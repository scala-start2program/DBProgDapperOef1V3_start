using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Scala.Gezelschapsspelen.Core.Entities
{
    [Table("Categorieën")]
    public class Categorie
    {
        [ExplicitKey]
        public string Id { get; private set; }
        public string Naam { get; set; }
        public Categorie()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Categorie(string naam)
        {
            Id = Guid.NewGuid().ToString();
            Naam = naam;
        }
        internal Categorie(string id, string naam)
        {
            Id = id;
            Naam = naam;
        }
        public override string ToString()
        {
            return $"{Naam}";
        }
    }
}
