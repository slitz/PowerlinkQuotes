using System;
using System.Collections.Generic;
using DataAccess;
using System.Web.Mvc;
using Business.Models;
using Newtonsoft.Json;

namespace Business
{
    public interface IProductData
    {
        List<SelectListItem> GetProductDataByProductType(int productType);
    }

    public class ProductData : IProductData
    {
        private readonly IDataAccess _data;

        public ProductData(IDataAccess data = null)
        {
            _data = data ?? new DataAccess.DataAccess();
        }

        public List<SelectListItem> GetProductDataByProductType(int productType)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (product product in _data.GetProductsByTypeId(productType))
            {
                ProductDataInfo productDataInfo = new ProductDataInfo() { Description = product.description, OrderCode = product.order_code, Price = product.price };
                list.Add(new SelectListItem
                {
                    Text = String.Format("{0} - {1}", product.order_code, product.description),
                    Value = JsonConvert.SerializeObject(productDataInfo)
                });
            }
            return list;
        }
    }
}
