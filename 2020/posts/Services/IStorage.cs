using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace posts
{
    interface IStorage<T>
    {
        public void Save(T entity);

        public List<T> Load();

        public void Remove(int id);

        public void Edit(int id, T entity);

    }
}
