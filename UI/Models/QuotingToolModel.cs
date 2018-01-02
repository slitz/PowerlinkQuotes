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
        public List<SelectListItem> CloudPlanDataList { get; set; }
        public List<SelectListItem> AssurePlanDataList { get; set; }
        public List<SelectListItem> ActivationDataList { get; set; }
        public List<string> SelectedProductsList { get; set; }
        public List<string> SelectedKitsList { get; set; }
        public List<string> SelectedCloudPlansList { get; set; }
        public List<string> SelectedAssurePlansList { get; set; }
        public List<string> SelectedActivationItemsList { get; set; }
        public List<ItemData> SelectedProductsData { get; set; }
        public List<ItemData> SelectedKitsData { get; set; }
        public List<ItemData> SelectedCloudPlansData { get; set; }
        public List<ItemData> SelectedAssurePlansData { get; set; }
        public List<ItemData> SelectedActivationData { get; set; }
        public string NavCategory { get; set; }
    }
    public class ItemData
    {
        public string OrderCode { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
    }
}