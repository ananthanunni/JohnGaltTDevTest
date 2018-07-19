using Dapper;
using JohnGaltTest.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnGaltTest.Data.Repository
{
    public class ObservationRepository : BaseRepository<Observation>, IObservationRepository
    {
	  public ObservationRepository(IDbConnection connection)
		:base(connection)
	  {
		    
	  }

	  public IEnumerable<Observation> GetObservationsForSeries(int id)
	  {
		return connection.Query<Observation>(@"SELECT 
[FK_SERIES] as SeriesId, 
[TX_PERIOD] as Period, 
[QY_SALES] as Sales, 
[QY_DEMAND] as Demand, 
[QY_SUPPLY] as Supply
FROM [tblObservations]
WHERE [FK_SERIES]=@id",new { id});
	  }
    }

    public interface IObservationRepository
    {
	  IEnumerable<Observation> GetObservationsForSeries(int id);
    }
}
