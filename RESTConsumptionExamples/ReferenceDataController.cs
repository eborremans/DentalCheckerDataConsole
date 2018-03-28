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
        private IReferenceDataView referenceDataView = null;

        private ReferenceDataController() { }

        public ReferenceDataController(IInputView inputView, IReferenceDataView referenceDataView)
        {
            this.inputView = inputView;
            this.referenceDataView = referenceDataView;
        }
        public void getReferenceData(int year)
        {
            HttpWebRequest request = RequestResponseFactory.createReferenceDataRequest(inputView.getConfiguration().currentUrl, inputView.getConfiguration().apiKey, inputView.getRefDataYear());
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
                    referenceDataView.setReferenceDataList(refdata);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}