using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataAccess
    {
        product GetProductByOrderCode(string code);
        List<product> GetProductsByCategoryId(Int32 id);
        List<product> GetProductsByTypeId(Int32 id);
    }

    public class DataAccess : IDataAccess
    {
        public DataAccess()
        {
        }

        public product GetProductByOrderCode(string code)
        {
            product entity = new product();

            using (chargepointEntities dbContext = new chargepointEntities())
            {
                try
                {
                    entity = dbContext.products.FirstOrDefault(row => row.order_code == code);
                }
                catch (Exception)
                {
                    string.Format("unable to retrieve products by order code: {0}", code);
                }
            }

            return entity;
        }

        public List<product> GetProductsByCategoryId(Int32 id)
        {
            var list = new List<product>();

            using (chargepointEntities dbContext = new chargepointEntities())
            {
                try
                {
                    var query = from p in dbContext.products
                                where p.product_category_id == id
                                select p;

                    list = query.ToList();
                }
                catch (Exception)
                {
                    string.Format("unable to retrieve products by category id: {0}", id);
                }
            }

            return list;
        }

        public List<product> GetProductsByTypeId(Int32 id)
        {
            var list = new List<product>();

            using (chargepointEntities dbContext = new chargepointEntities())
            {
                try
                {
                    var query = from p in dbContext.products
                                where p.product_type_id == id
                                select p;

                    list = query.ToList();
                }
                catch (Exception)
                {
                    string.Format("unable to retrieve products by type id: {0}", id);
                }
            }

            return list;
        }
    }
}
