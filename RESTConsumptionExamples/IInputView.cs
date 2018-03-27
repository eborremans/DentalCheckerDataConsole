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
        Configuration getConfiguration();
        void setConfiguration(Configuration configuration);

        HttpWebResponse getResponse(HttpWebRequest request);
    }
}
