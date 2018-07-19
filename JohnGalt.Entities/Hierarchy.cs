using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnGaltTest.Entities
{
    public class Hierarchy
    {
	  public int SeriesId { get; set; }
	  
	  public int ParentSeriesId { get; set; }

	  public string Description { get; set; }
    }
}
