using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.Stocks.AvailableRawStock.Command.Add
{
    public class UpdateTranaction
    {
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public decimal MRP { get; set; }
        public int Quantity { get; set; }
        public int TaxCGST { get; set; }
        public int TaxSGST { get; set; }
        public int Amount { get; set; }

    }
}
