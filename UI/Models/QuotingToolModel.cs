using System.Collections.Generic;
using System.Web.Mvc;
using Business.Models;

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
        public List<ProductDataInfo> SelectedProductsData { get; set; }
        public List<ProductDataInfo> SelectedKitsData { get; set; }
        public List<ProductDataInfo> SelectedCloudPlansData { get; set; }
        public List<ProductDataInfo> SelectedAssurePlansData { get; set; }
        public List<ProductDataInfo> SelectedActivationData { get; set; }
        public string NavCategory { get; set; }
    }
}