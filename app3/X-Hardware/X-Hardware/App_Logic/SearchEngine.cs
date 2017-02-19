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

        internal static IQueryable<XhProduct> SearchProducts(params string[] keywords)
        {
            var predicate = SearchEngine.False<XhProduct>();
            XhDataContext db = new XhDataContext();

            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.Or(p => p.prod_name.Contains(temp) || p.prod_model.Contains(temp) ||
                        p.prod_desc.Contains(temp) || p.XhManufacter.man_name.Contains(temp));
            }

            return db.XhProducts.Where(predicate).OrderBy(p => p.prod_price);
        }

        internal static IQueryable<XhManufacter> SearchManufacters(params int[] ids)
        {
            var predicate = SearchEngine.False<XhManufacter>();
            XhDataContext db = new XhDataContext();

            foreach (int id in ids)
            {
                int temp = id;
                predicate = predicate.Or(x => x.man_id.Equals(temp));
            }

            return db.XhManufacters.Where(predicate).OrderBy(x => x.man_name);
        }

        internal static IQueryable<XhCategory> SearchCategories(params int[] ids)
        {
            var predicate = SearchEngine.False<XhCategory>();
            XhDataContext db = new XhDataContext();

            foreach (int id in ids)
            {
                int temp = id;
                predicate = predicate.Or(x => x.cat_id.Equals(temp));
            }

            return db.XhCategories.Where(predicate).OrderBy(x => x.cat_name);
        }

        internal static IQueryable<XhProduct> SearchProductsByIdWithoutOne(int[] ids, int notThisOne, byte limitResult)
        {
            var predicate = SearchEngine.False<XhProduct>();
            XhDataContext db = new XhDataContext();

            foreach (int id in ids)
            {
                int temp = id;
                predicate = predicate.Or(x => x.prod_id.Equals(temp) && x.prod_id != notThisOne);
            }

            //orderby stock to get more variety!
            return db.XhProducts.Where(predicate).OrderByDescending(p => p.prod_stock).Take(limitResult);
        }

        internal static IQueryable<XhProduct> FilterProductsByCategoryAndManufacter(string[] keywords, int cid, int mid)
        {
            var predicate = SearchEngine.False<XhProduct>();
            XhDataContext db = new XhDataContext();

            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.Or(p => (p.prod_name.Contains(temp) || p.prod_model.Contains(temp) ||
                    p.prod_desc.Contains(temp) || p.XhManufacter.man_name.Contains(temp)) && (p.cat_id == cid) && (p.man_id == mid));
            }

            return db.XhProducts.Where(predicate).OrderBy(p => p.prod_price);
        }

        internal static IQueryable<XhProduct> FilterProductsByCategory(string[] keywords, int cid)
        {
            var predicate = SearchEngine.False<XhProduct>();
            XhDataContext db = new XhDataContext();

            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.Or(p => (p.prod_name.Contains(temp) || p.prod_model.Contains(temp) ||
                    p.prod_desc.Contains(temp) || p.XhManufacter.man_name.Contains(temp)) && (p.cat_id == cid));
            }

            return db.XhProducts.Where(predicate).OrderBy(p => p.prod_price); 
        }

        internal static IQueryable<XhProduct> FilterProductsByManufacter(string[] keywords, int mid)
        {
            var predicate = SearchEngine.False<XhProduct>();
            XhDataContext db = new XhDataContext();

            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.Or(p => (p.prod_name.Contains(temp) || p.prod_model.Contains(temp) ||
                    p.prod_desc.Contains(temp) || p.XhManufacter.man_name.Contains(temp)) && (p.man_id == mid));
            }

            return db.XhProducts.Where(predicate).OrderBy(p => p.prod_price);
        }
    }
}