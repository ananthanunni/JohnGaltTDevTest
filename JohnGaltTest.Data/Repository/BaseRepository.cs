using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnGaltTest.Data.Repository
{
    public abstract class BaseRepository<T>:IRepository<T>, IDisposable
	  where T:class
    {
	  protected IDbConnection connection;

	  public BaseRepository(IDbConnection connection)
	  {
		this.connection = connection;
	  }
	  
	  public void Dispose()
	  {
		this.connection.Dispose();
	  }
    }

    public interface IRepository<T>
	  where T:class
    {
	  
    }
}
