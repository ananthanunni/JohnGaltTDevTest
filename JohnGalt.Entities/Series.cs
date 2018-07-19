using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnGaltTest.Entities
{
    [Table("tblSeries")]
    public class Series
    {
	  [Column("KY_ID")]
	  public int SeriesId { get; set; }

	  [Column("TX_DESCRIPTION")]
	  public string Description { get; set; }

	  [Column("TX_SKU")]
	  public string SKU { get; set; }

	  [Column("TX_COUNTRY")]
	  public string Country { get; set; }

	  [Column("TX_CUSTOMER")]
	  public string Customer { get; set; }

	  [Column("TX_CATEGORY")]
	  public string Category { get; set; }
    }
}
