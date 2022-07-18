using System.Data;
using System.Data.SqlClient;
using MyBlogApi.Domain;

namespace MyBlogApi.Repositories
{
    public class CategoriesRepository : IRepository<Categories>
    {
        private readonly string _connectionString;

        public CategoriesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Categories> GetAll()
        {
            List<Categories> categories = new List<Categories>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [categories]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new Categories
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Title = Convert.ToString(reader["title"])
                            });
                        }
                    }
                }
            }

            return categories;
        }

        public bool Check(int id)
        {
            if (GetById(id) == null)
                return false;
            return true;
        }

        public int Create(Categories category)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [categories] (title) VALUES (@title)";
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = category.Title;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Delete(Categories category)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [categories] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = category.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Categories GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [categories] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Categories
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Title = Convert.ToString(reader["title"])
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public int Update(Categories category)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [categories] SET [title] = @title
                        WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = category.Id;
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = category.Title;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
