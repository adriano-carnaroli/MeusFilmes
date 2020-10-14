using System;
using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using MeusFilmes.Servico.Modelo;

namespace MeusFilmes.Servico.Database
{
    public class FilmeDatabase
    {
        readonly SQLiteAsyncConnection database;

        public FilmeDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Filme>().Wait();
        }

        public Task<Filme> GetItemAsync(int id)
        {
            return database.Table<Filme>().Where(i => i.id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Filme item)
        {
            Filme filme = GetItemAsync(item.id).Result;
            if (filme == null)
            {
                return database.InsertAsync(item);
            }
            return database.UpdateAsync(item);
        }
    }
}
