using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Assignment3
{
	public class BlogDBRepository : IDataEntityRepository<BlogPost>
	{
		private readonly IConfiguration _configuration;
		public BlogDBRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		BlogPost IDataEntityRepository<BlogPost>.Get(int id)
		{
			string? connectionString = _configuration["ConnectionStrings:DB_BlogPosts"];
			if (connectionString == null)
			{
				throw new Exception();
			}
			string query = "SELECT * FROM [dbo].[BlogPost] WHERE ID = @id";
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					if (conn.State == System.Data.ConnectionState.Open)
					{
						using (SqlCommand cmd = conn.CreateCommand())
						{
							cmd.CommandText = query;
							cmd.Parameters.AddWithValue("@id", id);
							using (SqlDataReader reader = cmd.ExecuteReader())
							{
								BlogPost model = new BlogPost();
								if (reader.Read())
								{
									model.ID = reader.GetInt32(0);
									model.Title = reader.GetString(1);
									model.Content = reader.GetString(2);
									model.Author = reader.GetString(3);
									model.Timestamp = reader.GetDateTime(4);
								}
								return model;
							}
						}
					}
				}
			}
			catch (Exception eSql)
			{
				Debug.WriteLine("Exception: " + eSql.Message);
			}
			throw new Exception();
		}

		void IDataEntityRepository<BlogPost>.Save(BlogPost entity)
		{
			string? connectionString = _configuration["ConnectionStrings:DB_BlogPosts"];
			if (connectionString == null)
			{
				throw new Exception();
			}
			string query = "INSERT INTO [dbo].[BlogPost] (ID, Title, Content, Author, Timestamp) VALUES(@id, @title, @content, @author, @timestamp)";
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					if (conn.State == System.Data.ConnectionState.Open)
					{
						using (SqlCommand cmd = conn.CreateCommand())
						{
							cmd.CommandText = query;
							cmd.Parameters.AddWithValue("@id", entity.ID);
							cmd.Parameters.AddWithValue("@title", entity.Title);
							cmd.Parameters.AddWithValue("@content", entity.Content);
							cmd.Parameters.AddWithValue("@author", entity.Author);
							cmd.Parameters.AddWithValue("@timestamp", entity.Timestamp);
							cmd.ExecuteNonQuery();
						}
					}
				}
			}
			catch (Exception eSql)
			{
				Debug.WriteLine("Exception: " + eSql.Message);
			}
			throw new Exception();
		}

		List<BlogPost> IDataEntityRepository<BlogPost>.GetList()
		{
			string? connectionString = _configuration["ConnectionStrings:DB_BlogPosts"];
			if (connectionString == null)
			{
				throw new Exception();
			}
			string query = "SELECT * FROM [dbo].[BlogPost]";
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					if (conn.State == System.Data.ConnectionState.Open)
					{
						using (SqlCommand cmd = conn.CreateCommand())
						{
							cmd.CommandText = query;
							using (SqlDataReader reader = cmd.ExecuteReader())
							{
								List<BlogPost> bloglist = new List<BlogPost>();
								while (reader.Read())
								{
									BlogPost blog = new()
									{
										ID = reader.GetInt32(0),
										Title = reader.GetString(1),
										Content = reader.GetString(2),
										Author = reader.GetString(3),
										Timestamp = reader.GetDateTime(4),
									};
									bloglist.Add(blog);

								}
								return bloglist;
							}
						}
					}
				}
			}
			catch (Exception eSql)
			{
				Debug.WriteLine("Exception: " + eSql.Message);
			}
			throw new Exception();
		}
	}
}
