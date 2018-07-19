using JohnGaltTest.Data.Repository;
using JohnGaltTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnGaltTest.Services.Series
{
    public class HierarchyProvider:IHierarchyProvider
    {
	  private IHierarchyRepository _hierarchyRepo;

	  public HierarchyProvider(IHierarchyRepository hierarchyRepo)
	  {
		_hierarchyRepo = hierarchyRepo;
	  }

	  public IEnumerable<Hierarchy> GetChildren(int id=0)
	  {
		return _hierarchyRepo.GetByParentKey(id);
	  }
    }

    public interface IHierarchyProvider
    {
	  IEnumerable<Hierarchy> GetChildren(int id=0);
    }
}
