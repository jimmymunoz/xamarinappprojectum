using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SeniorAssistance.Model;
using System.Linq;

namespace SeniorAssistance.Database
{
    public abstract class CrudDatabase
    {

        public SQLiteConnection Connection { get; }
        public static string Root { get; set; } = String.Empty;

        protected abstract void initDababase();

        public CrudDatabase()
        {
            var location = "xamarincrud9.db3";
            location = System.IO.Path.Combine(Root, location);
            Connection = new SQLiteConnection(location);
            initDababase();  //  Connection.CreateTable<Contact>();

        }
        public int SaveItem<T>(T item) where T : ITable
        { 
            if (item.ID > 0)
            {
                System.Diagnostics.Debug.WriteLine("Update: " + item.ToString());
                return Connection.Update(item);
            }
            System.Diagnostics.Debug.WriteLine("Insert: " + item.ToString());
            return Connection.Insert(item);
        }

        public int UpdateItem<T>(T item) where T : ITable
        {
            if (item.ID > 0)
            {
                System.Diagnostics.Debug.WriteLine("Update: " + item.ToString());
                return Connection.Update(item);
            }
            return -1;
        }

        public T GetItem<T>(int id) where T : ITable, new()
        {
            return (from i in Connection.Table<T>()
                    where i.ID == id
                    select i).FirstOrDefault();
        }
        public IEnumerable<T> GetItems<T>() where T : ITable, new()
        {
           return (from i in Connection.Table<T>()
                       select i);
            
        }
        public int GetCount<T>() where T : ITable, new()
        {
            int count =  Connection.Table<T>().Count();
            return count;
        }
       
        
        public int DeleteItem<T>(T item) where T : ITable
        {
            return Connection.Delete(item);
        }
    }
}
