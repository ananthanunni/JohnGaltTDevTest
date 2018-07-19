using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnGaltTest.Entities
{
    [Table("tblLockedPeriods")]
    public class LockedPeriod
    {
	  [Column("FK_SERIES")]
	  public int SeriesId { get; set; }

	  [Column("TX_PERIOD")]
	  public string Period { get; set; }

	  [Column("TX_OPINION")]
	  public string Opinion { get; set; }
    }
}
