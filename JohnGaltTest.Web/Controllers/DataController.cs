using JohnGaltTest.Services.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JohnGaltTest.Web.Controllers
{
    [Route("api")]
    public class DataController : Controller
    {
	  private IHierarchyProvider _hierarchyProvider;

	  public DataController(IHierarchyProvider hierarchyProvider)
	  {
		_hierarchyProvider = hierarchyProvider;
	  }

	  [HttpPost]
        public ActionResult GetChildren(int id=0)
        {
		return Json(_hierarchyProvider.GetChildren(id).ToList());
        }
    }
}