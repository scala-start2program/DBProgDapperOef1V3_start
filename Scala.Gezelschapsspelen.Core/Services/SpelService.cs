using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scala.Gezelschapsspelen.Core.Entities;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Scala.Gezelschapsspelen.Core.Services
{
    public class SpelService
    {
        public List<Spel> GetSpelen()
        {
            using (SqlConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    List<Spel> spelen = connection.GetAll<Spel>().ToList();
                    spelen = spelen.OrderBy(p => p.Titel).ToList();
                    return spelen;
                }
                catch
                {
                    return null;
                }
            }
        }
        public List<Spel> GetSpelen(string catId)
        {
            List<Spel> spelen = new List<Spel>();
            string sql = "select * from spelen where catId = @catId order by titel desc";
            using (SqlConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                connection.Open();
                spelen = connection.Query<Spel>(sql, new { catId = catId }).ToList();
            }
            return spelen;


        }
        public List<Categorie> GetCategorieën()
        {
            using (SqlConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    List<Categorie> categorieën = connection.GetAll<Categorie>().ToList();
                    categorieën = categorieën.OrderBy(p => p.Naam).ToList();
                    return categorieën;
                }
                catch
                {
                    return null;
                }
            }
        }

        public bool AddSpel(Spel spel)
        {
            using (SqlConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    connection.Insert(spel);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool UpdateSpel(Spel spel)
        {
            using (SqlConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    connection.Update(spel);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool DeleteSpel(Spel spel)
        {
            using (SqlConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                try
                {
                    connection.Open();
                    connection.Delete(spel);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
