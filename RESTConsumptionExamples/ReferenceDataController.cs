using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace RESTConsumptionExamples
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

        public void getReferenceData1(int year)
        {
            getReferenceData(UPPER_REF_GRID, referenceDataView, year, inputView.getConfiguration().refDataUrl1);
        }

        public void getReferenceData2(int year)
        {
            getReferenceData(LOWER_REF_GRID, referenceDataView, year, inputView.getConfiguration().refDataUrl2);
        }

        public void getReferenceData(int refGrid, IReferenceDataView referenceDataView, int year, String url)
        {
            // HttpWebRequest request = RequestResponseFactory.createReferenceDataRequest(inputView.getConfiguration().currentUrl, inputView.getConfiguration().apiKey, inputView.getRefDataYear());
            HttpWebRequest request = RequestResponseFactory.createReferenceDataRequest(url, inputView.getConfiguration().apiKey, year);
            if (null == request)
            {
                return;
            }

            HttpWebResponse response = inputView.getResponse(request);
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