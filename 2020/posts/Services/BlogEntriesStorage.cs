﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace posts
{
	public class BlogEntriesStorage : IStorage<BlogEntry>
	{
		private CommentEntriesStorage commentEntriesStorage = new CommentEntriesStorage();

		public List<BlogEntry> Load()
		{
			var config = new System.Globalization.CultureInfo("ru");
			var BlogEntries = new List<BlogEntry>();
			using (var fileStream = new FileStream("Files\\file.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (var reader = new StreamReader(fileStream))
			using (var csv = new CsvReader(reader, config))
			{
				//каждую строку csv файла преобразовать в BlogEntry добавить в список
				BlogEntries = csv.GetRecords<BlogEntry>().ToList();
			}
			foreach(var blogEntry in BlogEntries)
			{
				blogEntry.CommentEntries = new List<CommentEntry>();
			}
			var comments = commentEntriesStorage.Load();
			//сопоставить посты с их комментариями
			foreach (var comment in comments)
			{
				foreach (var post in BlogEntries)
				{
					if (comment.BlogEntryId == post.Id)
					{
						post.CommentEntries.Add(comment);
						break;
					}
				}
			}
			if (BlogEntries.Count != 0)
			{
				BlogEntry.LastId = BlogEntries.Last().Id + 1;
			}
			return BlogEntries;
		}

		public void Save(BlogEntry entity)
		{
			var config = new System.Globalization.CultureInfo("ru");

			using (var fileStream = new FileStream("Files\\file.csv", FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
			using (var writer = new StreamWriter(fileStream))
			using (var csv = new CsvWriter(writer, config))
			{
				csv.WriteRecord(entity);
				csv.NextRecord();
			}
		}

		public void Remove(int id)
		{
			var posts = Load();
			foreach(var post in posts)
			{
				if(post.Id == id)
				{
					foreach(var comment in post.CommentEntries)
					{
						commentEntriesStorage.Remove(comment.Id);
					}
					posts.Remove(post);
					break;
				}
			}
			RewriteCSVFile(posts);
		}
		public void Edit(int id, BlogEntry blogEntry)
		{
			var posts = Load();
			foreach(var post in posts)
			{
				if(post.Id == id)
				{
					//заменить пост на новый
					posts[posts.IndexOf(post)] = blogEntry;
					break;
				}
			}
			
			RewriteCSVFile(posts);
		}

		private static void RewriteCSVFile(List<BlogEntry> posts)
		{
			var config = new System.Globalization.CultureInfo("ru");

			using (var writer = new StreamWriter("Files\\file.csv"))
			using (var csv = new CsvWriter(writer, config))
			{
				csv.WriteHeader<BlogEntry>();
				csv.NextRecord();
				foreach (var entity in posts)
				{
					csv.WriteRecord(entity);
					csv.NextRecord();
				}
			}
		}
		public BlogEntry GetPostById(int id)
		{
			var posts = Load();
			foreach(var post in posts)
			{
				if (post.Id == id) return post;
			}
			throw new KeyNotFoundException();
		}
	}
}