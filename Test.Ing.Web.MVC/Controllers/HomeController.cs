using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Ing.DAO;
using Test.Ing.DTO;

namespace Test.Ing.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<CategorieDTO> categorieDTOs = new List<CategorieDTO>();
            
            try
            {
                BaseDao baseDao = new BaseDao(new SqlServerDatabase());               
                List<ViewListResult> viewListResult = baseDao.GetAllData().ToList();
                var results = from vlr in viewListResult
                              group new { vlr.ID_Element, vlr.ElementName } by new { vlr.ID_Categorie, vlr.CategorieName } into g
                              select new { g.Key.ID_Categorie, g.Key.CategorieName, Elements = g.ToList() };
                foreach (var item in results)
                {
                    List<ElementDTO> elementDTOs = new List<ElementDTO>();
                    foreach (var itt in item.Elements)
                    {
                        elementDTOs.Add(new ElementDTO { ID = itt.ID_Element, Name = itt.ElementName });
                    }

                    categorieDTOs.Add(new CategorieDTO
                    {
                        ID = item.ID_Categorie,
                        Name = item.CategorieName,
                        ElementDTOs = elementDTOs
                    });
                }
            }
            catch (SqlException ex)
            {
                //TODO need to catch exception properly
                throw;               
            }

            return View(categorieDTOs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}