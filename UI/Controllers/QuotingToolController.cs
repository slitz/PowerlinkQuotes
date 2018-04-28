using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UI.Models;
using Business;

namespace UI.Controllers
{
    public class QuotingToolController : Controller
    {
        private readonly IDataAccess _data;

        public QuotingToolController()
            : this(null)
        {

        }

        public QuotingToolController(IDataAccess data = null)
        {
            _data = data ?? new DataAccess.DataAccess();
        }

        //
        // GET: /QuotingTool/

        public ActionResult QuotingTool()
        {
            var quoteBuilderModel = new QuotingToolModel();
            quoteBuilderModel.ProductDataList = GetData((int)ProductType.Station);
            quoteBuilderModel.KitDataList = GetData((int)ProductType.Kit);
            quoteBuilderModel.CloudPlanDataList = GetData((int)ProductType.CloudPlan);
            quoteBuilderModel.AssurePlanDataList = GetData((int)ProductType.AssurePlan);
            quoteBuilderModel.ActivationDataList = GetData((int)ProductType.Activation);
            quoteBuilderModel.SelectedProductsList = new List<string>();
            quoteBuilderModel.NavCategory = "stations"; // stations is the default category when the page loads
            return View(quoteBuilderModel);
        }

        [HttpPost]
        public ActionResult QuotingTool(QuotingToolModel model)
        {
            if (model != null)
            {
                
            }
            return View(model);
        }

        private List<SelectListItem> GetData(int productType)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (product product in _data.GetProductsByTypeId(productType))
            {
                ItemData itemData = new ItemData () { Description = product.description, OrderCode = product.order_code,  Price = product.price };
                list.Add(new SelectListItem
                {
                    Text = String.Format("{0} - {1}", product.order_code, product.description),
                    Value = JsonConvert.SerializeObject(itemData)
                });
            }
            return list;
        }

        private List<ItemData> GetSelectedItemData(List<string> selectedProducts)
        {
            List<ItemData> list = new List<ItemData>();
            if (selectedProducts != null)
            {
                foreach (string selectedProduct in selectedProducts)
                {
                    product p = _data.GetProductByOrderCode(selectedProduct);
                    list.Add(new ItemData
                    {
                        OrderCode = p.order_code,
                        Description = p.description,
                        Price = p.price
                    });
                }
            }
            return list;
        }
    }
}
