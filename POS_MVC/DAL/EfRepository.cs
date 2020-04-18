﻿using System;
using System.Linq;
using System.Data.Entity;
using Core.Interface.Repository;

namespace Data.Repository
{
    public class EfRepository<T> : IRepository<T>
         where T : class
    {
        protected DbContext Context;
        protected DbSet<T> DbSet;

        //EfRepository(DbContext context) : this(context, false) { }
        //EfRepository(DbContext context, bool sharedContext)
        //{
        //    Context = context;
        //    ShareContext = sharedContext;
        //}

        //public static IQueryable<T> Include<T>
        //    (this IQueryable<T> source, string path)
        //{
        //    var objectQuery = source as System.Data.Objects.ObjectQuery<T>;
        //    if (objectQuery != null)
        //    {
        //        return objectQuery.Include(path);
        //    }
        //    return source;
        //}

        public EfRepository()
        {
            DbContext context = new DbContext("Entities");
            if (context == null)
                throw new ArgumentException("context");

            Context = context;
            DbSet = Context.Set<T>();
        }
        public IQueryable<T> All()
        {
            return DbSet.AsQueryable();
        }

        public bool Any(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public int Count
        {
            get { return DbSet.Count(); }
        }

        public T Create(T t)
        {
            DbSet.Add(t);

            Context.SaveChanges();

            return t;
        }

        public int Delete(T t)
        {
            DbSet.Remove(t);

            return Context.SaveChanges();

        }

        public int Delete(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var records = FindAll(predicate);

            foreach (var record in records)
            {
                DbSet.Remove(record);
            }

            return Context.SaveChanges();
        }

        public T Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public T Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }

        public IQueryable<T> FindAll()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<T> FindAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable();
        }

        public IQueryable<T> FindAll(System.Linq.Expressions.Expression<Func<T, bool>> predicate, int index, int size)
        {
            var skip = index * size;

            IQueryable<T> query = DbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (skip != 0)
            {
                query = query.Skip(skip);
            }

            return query.Take(size).AsQueryable();

        }

        public int Update(T t)
        {
            var entry = Context.Entry(t);
            var pkey = Context.Set<T>().Create().GetType().GetProperty("Id").GetValue(t);

            if (entry.State == EntityState.Detached)
            {
                T attachedEntity = Context.Set<T>().Find(pkey);

                if (attachedEntity != null)
                {
                    var attachedEntry = Context.Entry(attachedEntity);

                    attachedEntry.CurrentValues.SetValues(t);

                }
                else
                {
                    DbSet.Attach(t);

                    entry.State = EntityState.Modified;
                }
            }
            return Context.SaveChanges();
        }


        public void Dispose()
        {
            if (Context != null)
            {
                try
                {
                    Context.Dispose();
                }
                catch { }
            }
        }
    }
}