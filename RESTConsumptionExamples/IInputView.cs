using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RESTConsumptionExamples
{
    public interface IInputView
    {
        String getAPIKey();
        void setAPIKey(String apiKey);

        String getSelectedURL();
        String getSelectedInvoicePublicId();

        HttpWebResponse getResponse(HttpWebRequest request);
    }
}
