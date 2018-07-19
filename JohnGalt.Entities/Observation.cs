using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnGaltTest.Entities
{
    [Table("tblObservations")]
    public class Observation
    {
	  [Column("FK_SERIES")]
	  public int SeriesId { get; set; }

	  [Column("TX_PERIOD")]
	  public string Period { get; set; }

	  [Column("QY_SALES")]
	  public double? Sales { get; set; }

	  [Column("QY_DEMAND")]
	  public double? Demand { get; set; }

	  [Column("QY_SUPPLY")]
	  public double? Supply { get; set; }
    }
}
