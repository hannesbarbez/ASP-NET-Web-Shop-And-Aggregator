using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using app0.App_Data;
namespace app0.App_Logic
{
    internal static class SearchEngine
    {
        internal static Expression<Func<T, bool>> True<T>() { return f => true; }
        internal static Expression<Func<T, bool>> False<T>() { return f => false; }

        internal static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        internal static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

        internal static IQueryable<CpProduct> SearchProducts(params string[] keywords)
        {
            var predicate = SearchEngine.False<CpProduct>();
            CpDataContext db = new CpDataContext();

            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.Or(p => p.prod_name.Contains(temp) || p.prod_model.Contains(temp) ||
                        p.prod_desc.Contains(temp) || p.CpManufacter.man_name.Contains(temp));
            }

            return db.CpProducts.Where(predicate).OrderBy(p => p.prod_price);
        }

        internal static IQueryable<CpManufacter> SearchManufacters(params int[] ids)
        {
            var predicate = SearchEngine.False<CpManufacter>();
            CpDataContext db = new CpDataContext();

            foreach (int id in ids)
            {
                int temp = id;
                predicate = predicate.Or(x => x.man_id.Equals(temp));
            }

            return db.CpManufacters.Where(predicate).OrderBy(x => x.man_name);
        }

        internal static IQueryable<CpCategory> SearchCategories(params int[] ids)
        {
            var predicate = SearchEngine.False<CpCategory>();
            CpDataContext db = new CpDataContext();

            foreach (int id in ids)
            {
                int temp = id;
                predicate = predicate.Or(x => x.cat_id.Equals(temp));
            }

            return db.CpCategories.Where(predicate).OrderBy(x => x.cat_name);
        }

        internal static IQueryable<CpProduct> SearchProductsByIdWithoutOne(int[] ids, int notThisOne, byte limitResult)
        {
            var predicate = SearchEngine.False<CpProduct>();
            CpDataContext db = new CpDataContext();

            foreach (int id in ids)
            {
                int temp = id;
                predicate = predicate.Or(x => x.prod_id.Equals(temp) && x.prod_id != notThisOne);
            }

            //orderby stock to get more variety!
            return db.CpProducts.Where(predicate).OrderByDescending(p => p.prod_stock).Take(limitResult);
        }

        internal static IQueryable<CpProduct> FilterProductsByCategoryAndManufacter(string[] keywords, int cid, int mid)
        {
            var predicate = SearchEngine.False<CpProduct>();
            CpDataContext db = new CpDataContext();

            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.Or(p => (p.prod_name.Contains(temp) || p.prod_model.Contains(temp) ||
                    p.prod_desc.Contains(temp) || p.CpManufacter.man_name.Contains(temp)) && (p.cat_id == cid) && (p.man_id == mid));
            }

            return db.CpProducts.Where(predicate).OrderBy(p => p.prod_price);
        }

        internal static IQueryable<CpProduct> FilterProductsByCategory(string[] keywords, int cid)
        {
            var predicate = SearchEngine.False<CpProduct>();
            CpDataContext db = new CpDataContext();

            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.Or(p => (p.prod_name.Contains(temp) || p.prod_model.Contains(temp) ||
                    p.prod_desc.Contains(temp) || p.CpManufacter.man_name.Contains(temp)) && (p.cat_id == cid));
            }

            return db.CpProducts.Where(predicate).OrderBy(p => p.prod_price); 
        }

        internal static IQueryable<CpProduct> FilterProductsByManufacter(string[] keywords, int mid)
        {
            var predicate = SearchEngine.False<CpProduct>();
            CpDataContext db = new CpDataContext();

            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.Or(p => (p.prod_name.Contains(temp) || p.prod_model.Contains(temp) ||
                    p.prod_desc.Contains(temp) || p.CpManufacter.man_name.Contains(temp)) && (p.man_id == mid));
            }

            return db.CpProducts.Where(predicate).OrderBy(p => p.prod_price);
        }
    }
}