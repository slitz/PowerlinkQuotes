using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Models
{
    public class QuotingToolModel
    {
        public List<SelectListItem> ProductDataList { get; set; }
        public List<SelectListItem> KitDataList { get; set; }
        public List<string> SelectedProductsList { get; set; }
        public List<SelectListItem> SelectedKitsList { get; set; }
        public List<ItemData> SelectedProductsData { get; set; }
    }
    public class ItemData
    {
        public string OrderCode { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
    }
}