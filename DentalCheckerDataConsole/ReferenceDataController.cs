using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace DentalCheckerDataConsole
{
    public class ReferenceDataController
    {
        private IInputView inputView = null;
        private IReferenceDataView referenceDataView = null; // Top

        private const int UPPER_REF_GRID = 1;
        private const int LOWER_REF_GRID = 2;

        private ReferenceDataController() { }

        public ReferenceDataController(IInputView inputView, IReferenceDataView referenceDataView)
        {
            this.inputView = inputView;
            this.referenceDataView = referenceDataView;
        }

        public void getTreatmentCodes()
        {
            HttpWebRequest request = RequestResponseFactory.createTreatmentCodesRequest(this.inputView.getConfiguration().getCurrentUrl(), this.inputView.getConfiguration().apiKey);
            if (null == request)
            {
                return;
            }

            // Hack/workaround for dealing with https without valid certificate
            //ServicePointManager.ServerCertificateValidationCallback = new
            //    System.Net.Security.RemoteCertificateValidationCallback
            //    (
            //        delegate { return true; }
            //    );

            HttpWebResponse response = this.inputView.getResponse(request);
            if (null == response)
            {
                return;
            }

            String content = String.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            List<TreatmentCode> treatmentCodes = null;

            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                treatmentCodes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TreatmentCode>>(content, settings);
                if (null != treatmentCodes)
                {
                    inputView.setTreatmentCodes(treatmentCodes);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void getReferenceData1(int year)
        {
            getReferenceData(UPPER_REF_GRID, referenceDataView, year, inputView.getConfiguration().getRefDataUrl(1));
        }

        public void getReferenceData2(int year)
        {
            getReferenceData(LOWER_REF_GRID, referenceDataView, year, inputView.getConfiguration().getRefDataUrl(2));
        }

        public void getReferenceData(int refGrid, IReferenceDataView referenceDataView, int year, String url)
        {
            // HttpWebRequest request = RequestResponseFactory.createReferenceDataRequest(inputView.getConfiguration().currentUrl, inputView.getConfiguration().apiKey, inputView.getRefDataYear());
            HttpWebRequest request = RequestResponseFactory.createReferenceDataRequest(url, inputView.getConfiguration().apiKey, year);
            if (null == request)
            {
                return;
            }

            // Hack/workaround for dealing with https without valid certificate
            //ServicePointManager.ServerCertificateValidationCallback = new
            //    System.Net.Security.RemoteCertificateValidationCallback
            //    (
            //        delegate { return true; }
            //    );

            HttpWebResponse response = null;
            try
            {
                response = inputView.getResponse(request);
                if (null == response)
                {
                    System.Diagnostics.Debug.WriteLine("Empty response " + request.Address);
                    MessageBox.Show("Empty response " + request.Address);
                    return;
                }
            } catch (TimeoutException e)
            {
                System.Diagnostics.Debug.WriteLine("Caught TimeoutException: " + e.Message + " address: " + request.Address);
                MessageBox.Show(e.Message + " address: " + request.Address);
                return;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Caught TimeoutException: " + e.Message + " address: " + request.Address);
                MessageBox.Show(e.Message + " address: " + request.Address);
                return;
            }

            System.Diagnostics.Debug.WriteLine("Received response for request " + request.Address);

            String content = String.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }

            List<ReferenceData> refdata = null;
            
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                refdata = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReferenceData>>(content, settings);
                if (null != refdata)
                {
                    if (refGrid == UPPER_REF_GRID)
                    {
                        referenceDataView.setReferenceDataList1(refdata);
                    }
                    if (refGrid == LOWER_REF_GRID)
                    {
                        referenceDataView.setReferenceDataList2(refdata);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}