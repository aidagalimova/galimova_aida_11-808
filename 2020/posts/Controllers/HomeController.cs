using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Http;

namespace posts
{
	public class HomeController
	{
		private BlogEntriesStorage BlogEntriesStorage = new BlogEntriesStorage();
		public async Task GetForm(HttpContext context)
		{
			await context.Response.WriteAsync(File.ReadAllText("Views\\index.html"));
		}
		public async Task AddEntry(HttpContext context)
		{
			var entity = CreateBlogEntity(context);
			BlogEntriesStorage.Save(entity);
			await context.Response.WriteAsync("Post added");
		}

		public async Task GetPosts(HttpContext context)
		{
			var id = 0;
			StringBuilder htmlCode = new StringBuilder();
			htmlCode.Append(@"<!DOCTYPE html>
			<html>
			<head>
			<meta charset = ""utf-8""/>
			<title> Cписок постов </title>
			</head>
			<body> <div> ");
			
			//загрузить посты из csv файла на страницу
			var posts = BlogEntriesStorage.Load();
			foreach (var post in posts)
			{
				htmlCode.Append(@$"<span>{post.Name}</span><br><hr>
			<span>{post.Text}</span>
			<br>");
				if(post.FileName != "")
				{
					htmlCode.Append(@$"<img src=""Files/images/{post.FileName}"" style='width:150px'>");
				}
				htmlCode.Append($"<span>{post.CurrentTime}</span><br>");
				htmlCode.Append($@"<a type='button' href='/Edit'>Редактировать</a>");
				htmlCode.Append($@"<a type='button' href='/Remove?id={id}'>Удалить</a><br><br>");
				id++;
			}
			htmlCode.Append(@"</div>  <a type='button' href='/'>Добавить новый пост</a> </body> </html>");
			await context.Response.WriteAsync(htmlCode.ToString());
		}
	
		public async Task RemovePost(HttpContext context)
		{
			var id = context.Request.Query["id"];
			BlogEntriesStorage.Remove(Convert.ToInt32(id));
			context.Response.Redirect("/GetPosts");
		}

		public async Task EditPost(HttpContext context)
		{
			var id = Convert.ToInt32(context.Request.Query["id"]);
			var post = BlogEntriesStorage.Load()[id];
			var htmlCode = @$"<!DOCTYPE html>
			<html>
			<head>
			<meta charset=""utf-8""/>
			<title> Редактировать </title>
			</head>
			<body>
			<form action=""/savePost?id={id}"" method=""post"" enctype=""multipart / form - data"">
			<input name = ""name"" value=""{post.Name}""/>
			<br/>
			<textarea name =""text"">{post.Text}</textarea>
			<br/>
			<input id =""photo"" name =""image"" type = ""file"" accept = ""image/*""/>
			<br/>
			<input type =""submit""/>
		    </form></body></html>";
			await context.Response.WriteAsync(htmlCode);
		}

		public async Task SavePost(HttpContext context)
		{
			var id = Convert.ToInt32(context.Request.Query["id"]);
			BlogEntry entity = CreateBlogEntity(context);
			BlogEntriesStorage.Edit(id, entity);
			context.Response.Redirect("/GetPosts");
		}

		private static BlogEntry CreateBlogEntity(HttpContext context)
		{
			string name = context.Request.Form["name"];
			string text = context.Request.Form["text"];
			
			// если фото загружено, присвоить его имя FileName и сохранить фото в Files\\images
			var fileName = "";
			if (context.Request.Form.Files.Count != 0)
			{
				var photo = context.Request.Form.Files[0];
				fileName = ContentDispositionHeaderValue.Parse(photo.ContentDisposition).FileName.Trim('"');
				using (var stream = new FileStream(Path.Combine("Files\\images", fileName), FileMode.Create))
				{
					photo.CopyTo(stream);
				}
			}

			BlogEntry entity = new BlogEntry
			{
				Name = name,
				Text = text,
				CurrentTime = DateTime.Now,
				FileName = fileName
			};
			return entity;
		}
	}
}