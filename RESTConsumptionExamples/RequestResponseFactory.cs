using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.IO;

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

        public static HttpWebRequest createInvoicePublicIdsRequest(String url, String apiKey, DateRangeRequest dateRangeRequest)
        {
            return createRequest(url + "invoices/publicIds", "", apiKey, dateRangeRequest);
        }

        public static HttpWebRequest createReferenceDataRequest(String url, String apiKey, int year)
        {
            return createRequest(url + "refdata/" + year, "", apiKey);
        }

        public static HttpWebRequest createCustomerExternalIdsRequest(String url, String apiKey)
        {
            return createRequest(url + "customer/customerExternalIds", "", apiKey);
        }
  
        public static HttpWebRequest createRequest(String url, String callerID, String apiKey, DateRangeRequest dateRangeRequest = null)
        {
            HttpWebRequest request = null;
            try {
                request = (HttpWebRequest)WebRequest.Create(url);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error creating web request: " + e.Message + " for url " + url);
                return null;
            }
            request.Headers.Add("CallerID", callerID);
            request.Headers.Add("api_key", apiKey);

            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;


            if (null != dateRangeRequest)
            {
                String requestData = Newtonsoft.Json.JsonConvert.SerializeObject(dateRangeRequest);
                var data = Encoding.ASCII.GetBytes(requestData);

                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                try
                {
                    // Hack/workaround for dealing with https without valid certificate
                    //ServicePointManager.ServerCertificateValidationCallback = new
                    //    System.Net.Security.RemoteCertificateValidationCallback
                    //    (
                    //        delegate { return true; }
                    //    );
                    // System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                        stream.Close();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error obtaining request stream: " + e.Message);
                    return null;
                }
            }
            return request;
        }
    }

    public class DateRangeRequest
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
