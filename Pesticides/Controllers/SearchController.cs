using Newtonsoft.Json;
using Pesticides.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pesticides.Controllers
{
    public class SearchController : Controller
    {
        private PesticidesDBEntities db = new PesticidesDBEntities();

        // GET: Search
        public ActionResult Index()
        {
            var SearchViewModel = new Pesticides.ViewModels.SearchViewModel();

            SearchViewModel.pesticideTypes = db.PesticideTypes.ToList();
            SearchViewModel.activeIngredients = db.ActiveIngredients.ToList();
            SearchViewModel.crops = db.Crops.ToList();
            SearchViewModel.pests = db.Pests.ToList();
            SearchViewModel.PesticidesInfoes = db.PesticidesInfoes.ToList();
            ViewBag.LastModifiedDate = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/DataFile.txt"));
            return View(SearchViewModel);
        }

        public ActionResult Search(Pesticides.ViewModels.SearchViewModel SearchViewModel)
        {
            //searchViewModel.PesticidesInfoes = db.PesticidesInfoes.Where(m => m.fkCrop.Equals(2)).ToList();
            SearchViewModel.pesticideTypes = db.PesticideTypes.ToList();
            SearchViewModel.activeIngredients = db.ActiveIngredients.ToList();
            SearchViewModel.crops = db.Crops.ToList();
            SearchViewModel.pests = db.Pests.ToList();

            if(SearchViewModel.selectedTypes != null)
                SearchViewModel.PesticidesInfoes = filterByTypes(SearchViewModel.selectedTypes);
            else SearchViewModel.PesticidesInfoes = db.PesticidesInfoes.ToList();

            if (SearchViewModel.selectedCrops != null && SearchViewModel.selectedCrops.Count > 0)
                SearchViewModel.PesticidesInfoes = filterByCrops(SearchViewModel.selectedCrops, SearchViewModel.PesticidesInfoes.ToList());
            if (SearchViewModel.selectedPests != null && SearchViewModel.selectedPests.Count > 0)
                SearchViewModel.PesticidesInfoes = filterByPests(SearchViewModel.selectedPests, SearchViewModel.PesticidesInfoes.ToList());
            if (SearchViewModel.selectedActIngredients != null && SearchViewModel.selectedActIngredients.Count > 0)
                SearchViewModel.PesticidesInfoes = filterByActiveIngredients(SearchViewModel.selectedActIngredients, SearchViewModel.PesticidesInfoes.ToList());


            //SearchViewModel.PesticidesInfoes = db.PesticidesInfoes.Where(m => (m.fkPesticideType == SearchViewModel.PesticideTypefk || SearchViewModel.PesticideTypefk == 0)
            //&& (m.fkActiveIngredient == SearchViewModel.ActiveIngredientfk || SearchViewModel.ActiveIngredientfk == 0)
            //&& (m.fkCrop == SearchViewModel.Cropfk || SearchViewModel.Cropfk == 0)
            //&& (m.fkPest == SearchViewModel.Pestfk || SearchViewModel.Pestfk == 0)).ToList();

            ViewBag.LastModifiedDate = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/DataFile.txt"));
            return View("Index", SearchViewModel);
        }

        private List<PesticidesInfo> filterByTypes(List<int> selectedTypes)
        {
            List<PesticidesInfo> result = new List<PesticidesInfo>();
            if(selectedTypes == null || selectedTypes.Count == 0)
            {
                result = db.PesticidesInfoes.ToList();
                return result;
            }
            foreach(int id in selectedTypes)
            {
                result.AddRange(db.PesticidesInfoes.Where(p => p.fkPesticideType == id).ToList());
            }
            return result;
        }
        private List<PesticidesInfo> filterByCrops(List<int> selectedCrops, List<PesticidesInfo> pesticidesInfos)
        {
            List<PesticidesInfo> result = new List<PesticidesInfo>();
            foreach (int id in selectedCrops)
            {
                result.AddRange(pesticidesInfos.Where(p => p.fkCrop == id).ToList());
            }
            return result;
        }
        private List<PesticidesInfo> filterByPests(List<int> selectedPests, List<PesticidesInfo> pesticidesInfos)
        {
            List<PesticidesInfo> result = new List<PesticidesInfo>();
            foreach(int id in selectedPests)
            {
                result.AddRange(pesticidesInfos.Where(p => p.fkPest == id).ToList());
            }
            return result;
        }
        private List<PesticidesInfo> filterByActiveIngredients(List<int> selectedActiveIngredients, List<PesticidesInfo> pesticidesInfos)
        {
            List<PesticidesInfo> result = new List<PesticidesInfo>();
            foreach (int id in selectedActiveIngredients)
            {
                result.AddRange(pesticidesInfos.Where(p => p.fkActiveIngredient == id).ToList());
            }
            return result;
        }

        public ActionResult ExportToExcel(Pesticides.ViewModels.SearchViewModel SearchViewModel)
        {
            SearchViewModel.pesticideTypes = db.PesticideTypes.ToList();
            SearchViewModel.activeIngredients = db.ActiveIngredients.ToList();
            SearchViewModel.crops = db.Crops.ToList();
            SearchViewModel.pests = db.Pests.ToList();
          //  SearchViewModel.PesticidesInfoes = db.PesticidesInfoes.Where(m => m.fkPesticideType == SearchViewModel.PesticideTypefk && m.fkActiveIngredient == SearchViewModel.ActiveIngredientfk).ToList();
            //SearchViewModel.PesticidesInfoes = db.PesticidesInfoes.Where(m => m.fkPesticideType == SearchViewModel.PesticideTypefk) & m => m.fkCrop == SearchViewModel.Cropfk).ToList();
            SearchViewModel.PesticidesInfoes = db.PesticidesInfoes.Where(m => (m.fkPesticideType == SearchViewModel.PesticideTypefk || SearchViewModel.PesticideTypefk == 0)
                && (m.fkActiveIngredient == SearchViewModel.ActiveIngredientfk || SearchViewModel.ActiveIngredientfk == 0)
                && (m.fkCrop == SearchViewModel.Cropfk || SearchViewModel.Cropfk == 0)
                && (m.fkPest == SearchViewModel.Pestfk || SearchViewModel.Pestfk == 0)).ToList();

            var gv = new GridView();
            gv.DataSource = ToDataTable<PesticidesInfo>(SearchViewModel.PesticidesInfoes.ToList());
            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Pesticides.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            gv.RenderControl(objHtmlTextWriter);

            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();

            return View("Index",SearchViewModel);
        }

        //Generic method to convert List to DataTable
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public List<PesticidesInfo> getListForExport()
        {
            return db.PesticidesInfoes.ToList();
        }

        [AllowAnonymous]
        public ActionResult VisitMOASite()
        {
            return Redirect("http://www.agriculture.gov.lb");
        }

    }
}