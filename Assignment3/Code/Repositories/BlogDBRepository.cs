using System;
using System.Configuration;
using System.Data;
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
			using SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:DB_BlogPosts"]);
			using SqlCommand command = new SqlCommand();
			command.CommandText = "SELECT * FROM BlogPost WHERE ID = @id";
			command.Parameters.AddWithValue("@id", id);
			command.Connection.Open();

			using SqlDataReader reader = command.ExecuteReader();

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

		void IDataEntityRepository<BlogPost>.Save(BlogPost entity)
		{
			
			using SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:DB_BlogPosts"]);
			using SqlCommand command = new SqlCommand("BlogPost_InsertUpdate", connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Connection.Open();

			command.Parameters.AddWithValue("@ID", entity.ID);
			command.Parameters.AddWithValue("@Title", entity.Title);
			command.Parameters.AddWithValue("@Content", entity.Content);
			command.Parameters.AddWithValue("@Author", entity.Author);
			command.Parameters.AddWithValue("@Timestamp", entity.Timestamp);

			command.ExecuteNonQuery();
		}

		List<BlogPost> IDataEntityRepository<BlogPost>.GetList()
		{
			List<BlogPost> blogPosts = new List<BlogPost>();
			using SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:DB_BlogPosts"]);
			using SqlCommand command = new SqlCommand("BlogPost_GetList", connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Connection.Open();
			using SqlDataReader reader = command.ExecuteReader();

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
				blogPosts.Add(blog);
			}

			return blogPosts;
		}

	}
}
