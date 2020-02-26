using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace posts
{
    public class CommentEntriesStorage : IStorage<CommentEntry>
    {
		public List<CommentEntry> Load()
		{
			var config = new System.Globalization.CultureInfo("ru");
			var CommentEntries = new List<CommentEntry>();
			using (var fileStream = new FileStream("Files\\comment.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (var reader = new StreamReader(fileStream))
			using (var csv = new CsvReader(reader, config))
			{
				//каждую строку csv файла преобразовать в СommentEntry добавить в список
				CommentEntries = csv.GetRecords<CommentEntry>().ToList();
			}
			if (CommentEntries.Count != 0)
			{
				CommentEntry.LastId = CommentEntries.Last().Id+1;
			}
			return CommentEntries;
		}

		public void Remove(int id)
		{
			var comments = Load();
			foreach (var comment in comments)
			{
				if (comment.Id == id)
				{
					comments.Remove(comment);
					break;
				}
			}
			RewriteCSVFile(comments);
		}

		private static void RewriteCSVFile(List<CommentEntry> comments)
		{
			var config = new System.Globalization.CultureInfo("ru");

			using (var writer = new StreamWriter("Files\\comment.csv"))
			using (var csv = new CsvWriter(writer, config))
			{
				csv.WriteHeader<CommentEntry>();
				csv.NextRecord();
				foreach (var entity in comments)
				{
					csv.WriteRecord(entity);
					csv.NextRecord();
				}
			}
		}

		public void Save(CommentEntry entity)
		{
			var config = new System.Globalization.CultureInfo("ru");

			using (var fileStream = new FileStream("Files\\comment.csv", FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
			using (var writer = new StreamWriter(fileStream))
			using (var csv = new CsvWriter(writer, config))
			{
				csv.WriteRecord(entity);
				csv.NextRecord();
			}
		}
		public void Edit(int id, CommentEntry entity)
		{
			throw new NotImplementedException();
		}
	}
}
