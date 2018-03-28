using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RESTConsumptionExamples
{
    public static class RequestResponseFactory
    {
        public static HttpWebRequest createVersionRequest(String url, String apiKey)
        {
            return createRequest(url + "version", "TESTING", apiKey);
        }

        public static HttpWebRequest createTreatmentListRequest(String url, String apiKey)
        {
            return createRequest(url + "performancecodes", "", apiKey);
        }

        public static HttpWebRequest createInvoiceRequest(String url, String apiKey, String invoicePublicID)
        {
            return createRequest(url + "invoices/" + invoicePublicID, "", apiKey);
        }

        public static HttpWebRequest createCustomerMessageRequest(String url, String apiKey, String invoicePublicID)
        {
            return createRequest(url + "checker/" + invoicePublicID, "", apiKey);
        }

        public static HttpWebRequest createInvoicePublicIdsRequest(String url, String apiKey)
        {
            return createRequest(url + "invoices/publicIds", "", apiKey);
        }

        public static HttpWebRequest createReferenceDataRequest(String url, String apiKey, int year)
        {
            return createRequest(url + "refdata/" + year, "", apiKey);
        }

        public static HttpWebRequest createRequest(String url, String callerID, String apiKey)
        {
            HttpWebRequest request = null; 
            try { 
                request = (HttpWebRequest)WebRequest.Create(url);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            request.Headers.Add("CallerID", callerID);
            request.Headers.Add("api_key", apiKey);

            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            return request;
        }
    }
}
