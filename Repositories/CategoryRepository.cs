﻿using System.Data;
using System.Data.SqlClient;
using MyBlogApi.Domain;

namespace MyBlogApi.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly string _connectionString;

        public CategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [category]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new Category
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

        public int Create(Category category)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [category] (title) VALUES (@title)";
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = category.Title;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Delete(Category category)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [category] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = category.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Category GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [category] WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Category
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

        public int Update(Category category)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE [category] SET [title] = @title
                        WHERE [id] = @id";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = category.Id;
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = category.Title;

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}
