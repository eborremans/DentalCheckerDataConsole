using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTConsumptionExamples
{
    public class RestErrorResponse
    {
        public String timestamp { get; set; } // "timestamp": "2018-08-29T14:49:51.347+0000",
        public String status    { get; set; }    // "status": 500,
        public String error     { get; set; }     // "error": "Internal Server Error",
        public String exception { get; set; } // "exception": "nl.billinghouse.dental.invoice.check.InvoiceException",
        public String message   { get; set; }   // "message": "Invoice with invoice-number: invoiceNumber and Customer-Id: 2 already exists",
  
        /* "errors": [
            {
              "codes": [
                "invoice.already.exists"
              ],
              "arguments": null,
              "defaultMessage": null,
              "objectName": "",
              "code": "invoice.already.exists"
            }
          ],
          String path; //  "path": "/invoices/"
       */
    }
}
