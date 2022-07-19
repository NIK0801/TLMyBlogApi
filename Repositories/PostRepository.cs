using System.Data;
using System.Data.SqlClient;
using MyBlogApi.Domain;

namespace MyBlogApi.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        private readonly string _connectionString;

        public PostRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Post> GetAll()
        {
            List<Post> posts = new List<Post>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [posts]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            posts.Add(new Post
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Title = Convert.ToString(reader["title"]),
                                Content = Convert.ToString(reader["content"]),
                                IsPublihed = Convert.ToInt32(reader["is_publihed"]),
                                CategoryId = Convert.ToInt32(reader["category_id"])
                            });
                        }
                    }
                }
            }

            return posts;
        }

        public bool Check(int id)
        {
            if (GetById(id) == null)
                return false;
            return true;
        }

        public int Create(Post post)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [posts] (title, content, category_id) VALUES (@title, @content, @category_id)";
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = post.Title;
                    cmd.Parameters.Add("@content", SqlDbType.NVarChar).Value = post.Content;
                    cmd.Parameters.Add("@category_id", SqlDbType.NVarChar).Value = post.CategoryId;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Delete(Post post)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [posts] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = post.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Post GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [posts] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Post
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Title = Convert.ToString(reader["title"]),
                                Content = Convert.ToString(reader["content"]),
                                IsPublihed = Convert.ToByte(reader["is_publihed"]),
                                CategoryId = Convert.ToInt32(reader["category_id"])
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

        public int Update(Post post)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [posts] SET [title] = @title, [content] = @content, [category_id] = @category_id
                        WHERE [id] = @id";
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = post.Title;
                    cmd.Parameters.Add("@content", SqlDbType.NVarChar).Value = post.Content;
                    cmd.Parameters.Add("@category_id", SqlDbType.NVarChar).Value = post.CategoryId;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
