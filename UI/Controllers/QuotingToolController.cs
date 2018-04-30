using System.Collections.Generic;
using System.Web.Mvc;
using UI.Models;
using Business;

namespace UI.Controllers
{
    public class QuotingToolController : Controller
    {
        private readonly IProductData _productData;
        private readonly IQuoteDocument _quoteDocument;

        public QuotingToolController()
            : this(null)
        {

        }

        public QuotingToolController(IProductData productData = null, IQuoteDocument quoteDocument = null)
        {
            _productData = productData ?? new ProductData();
            _quoteDocument = quoteDocument ?? new QuoteDocument();
        }

        //
        // GET: /QuotingTool/

        public ActionResult QuotingTool()
        {
            var quoteBuilderModel = new QuotingToolModel();
            quoteBuilderModel.ProductDataList = _productData.GetProductDataByProductType((int)ProductType.Station);
            quoteBuilderModel.KitDataList = _productData.GetProductDataByProductType((int)ProductType.Kit);
            quoteBuilderModel.CloudPlanDataList = _productData.GetProductDataByProductType((int)ProductType.CloudPlan);
            quoteBuilderModel.AssurePlanDataList = _productData.GetProductDataByProductType((int)ProductType.AssurePlan);
            quoteBuilderModel.ActivationDataList = _productData.GetProductDataByProductType((int)ProductType.Activation);
            quoteBuilderModel.SelectedProductsList = new List<string>();
            quoteBuilderModel.NavCategory = "stations"; // stations is the default category when the page loads
            return View(quoteBuilderModel);
        }

        [HttpPost]
        public void QuotingTool(QuotingToolModel model)
        {
            if (model != null)
            {
                _quoteDocument.GenerateQuoteDocument();
            }
        }
    }
}
