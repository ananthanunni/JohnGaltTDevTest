using JohnGaltTest.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace JohnGaltTest.Data.Repository
{
    public class HierarchyRepository:BaseRepository<Hierarchy>,IHierarchyRepository
    {
	  public HierarchyRepository(IDbConnection connection):base(connection)
	  {

	  }

	  public IEnumerable<Hierarchy> GetByParentKey(int id=0)
	  {
		var collection = connection.Query<Hierarchy>(@"SELECT 
		    FK_SERIES as SeriesId,
		    TS.TX_DESCRIPTION as Description
		    FROM tblHierarchy TH
		    INNER JOIN tblSeries TS ON (TS.KY_ID=TH.FK_SERIES)
		    WHERE TH.FK_PARENT_SERIES=@id", new { id });

		return collection;
	  }
    }

    public interface IHierarchyRepository: IRepository<Hierarchy>
    {
	  IEnumerable<Hierarchy> GetByParentKey(int key=0);
    }
}
