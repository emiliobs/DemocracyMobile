using DemocracyApp.Classes;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemocracyMobile.Classes 
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();

            connection = new SQLiteConnection(config.Platform, System.IO.Path.Combine(config.DirectoryDB, "DemocracyMobile.db3"));

            connection.CreateTable<UserPassword>();
        }

        public  T Insert<T>(T model)
        {
            connection.Insert(model);
            return model;
        }

        public T Update<T>(T model)
        {
            connection.Update(model);
            return model;
        }

        public bool Delete<T>(T model)
        {
            int response = connection.Delete(model);
            return response == 1;
        }

        public List<T> GetList<T>(bool withChildren) where T : class
        {
            if (withChildren)
            {
                 return connection.GetAllWithChildren<T>().ToList();
            }
            return connection.Table<T>().ToList();
        }

        //public List<T> GetListWithChildren<T>() where T : class
        //{
        //    return connection.GetAllWithChildren<T>().ToList();
        //}

       
        public T Find<T>(int pk, bool withChildChildren) where T : class
        {
            if (withChildChildren)
            {
                return connection.GetAllWithChildren<T>().FirstOrDefault(m => m.GetHashCode() == pk); 
            }

            return connection.Table<T>().FirstOrDefault(m => m.GetHashCode() == pk); 
                
        }



        //public T FindWithChildren<T>(int pk) where T : class
        //{
        //    return connection.Table<T>().FirstOrDefault(m => m.GetHashCode() == pk);

        //}

        public T First<T>(bool withChildren) where T : class
        {
            if (withChildren)
            {
                return this.connection.GetAllWithChildren<T>().FirstOrDefault();
            }

            return this.connection.Table<T>().FirstOrDefault();
        }

        public void Dispose()
        {
            this.connection.Dispose();
        }
    }
}
