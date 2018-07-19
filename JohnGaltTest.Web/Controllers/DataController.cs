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
	  private IObservationProvider _observationProvider;

	  public DataController(IHierarchyProvider hierarchyProvider,IObservationProvider observationProvider)
	  {
		_hierarchyProvider = hierarchyProvider;
		_observationProvider = observationProvider;
	  }

	  [HttpPost]
        public ActionResult GetChildren(int id=0)
        {
		return Json(_hierarchyProvider.GetChildren(id).ToList());
        }

	  [HttpPost]
	  public ActionResult GetObservations(int id)
	  {
		return Json(_observationProvider.GetObservationsFor(id));
	  }
    }
}