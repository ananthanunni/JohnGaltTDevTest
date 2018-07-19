using JohnGaltTest.Data.Repository;
using JohnGaltTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnGaltTest.Services.Series
{
    public class ObservationProvider : IObservationProvider
    {
	  private IObservationRepository _observationRepository;

	  public ObservationProvider(IObservationRepository observationRepo)
	  {
		_observationRepository = observationRepo;
	  }

	  public IEnumerable<Observation> GetObservationsFor(int id)
	  {
		return _observationRepository.GetObservationsForSeries(id);
	  }
    }

    public interface IObservationProvider
    {
	  IEnumerable<Observation> GetObservationsFor(int id);
    }
}
