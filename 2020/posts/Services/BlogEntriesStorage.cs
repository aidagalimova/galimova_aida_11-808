using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace posts
{
	public class BlogEntriesStorage
	{
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
			return BlogEntries;
		}

		public void Save(BlogEntry entity)
		{
			var config = new System.Globalization.CultureInfo("ru");

			using (var fileStream = new FileStream("Files\\file.csv", FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
			using (var writer = new StreamWriter(fileStream))
			using (var csv = new CsvWriter(writer, config))
			{
				csv.WriteField(entity.Name);
				csv.WriteField(entity.Text);
				csv.WriteField(entity.CurrentTime);
				csv.WriteField(entity.FileName);
				csv.NextRecord();
			}
		}

		public void Remove(int id)
		{
			var posts = Load();
			posts.RemoveAt(id);

			RewriteCSVFile(posts);
		}
		public void Edit(int id, BlogEntry blogEntry)
		{
			var posts = Load();
			posts[id] = blogEntry;
			
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
					csv.WriteField(entity.Name);
					csv.WriteField(entity.Text);
					csv.WriteField(entity.CurrentTime);
					csv.WriteField(entity.FileName);
					csv.NextRecord();
				}
			}
		}
	}
}