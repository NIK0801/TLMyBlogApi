using System.Data;
using System.Data.SqlClient;
using MyBlogApi.Domain;

namespace MyBlogApi.Repositories
{
    public class TagRepository : IRepository<Tag>
    {
        private readonly string _connectionString;

        public TagRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Check(int id)
        {
            if (GetById(id) == null)
                return false;
            return true;
        }

        public List<Tag> GetAll()
        {
            List<Tag> tags = new List<Tag>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [tags]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tags.Add(new Tag
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Title = Convert.ToString(reader["title"])
                            });
                        }
                    }
                }
            }

            return tags;
        }

        public int Create(Tag tag)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [tags] (title) VALUES (@title)";
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = tag.Title;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Delete(Tag tag)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [tags] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = tag.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Tag GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [tags] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Tag
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

        public int Update(Tag tag)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [tags] SET [title] = @title
                        WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = tag.Id;
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = tag.Title;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
