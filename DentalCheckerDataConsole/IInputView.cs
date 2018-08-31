using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DentalCheckerDataConsole
{
    public interface IInputView
    {
        Configuration getConfiguration();
        void setConfiguration(Configuration configuration);

        HttpWebResponse getResponse(HttpWebRequest request);
        int getRefDataYear();
        DateRangeRequest getDateRange();
        void setTreatmentCodes(List<TreatmentCode> treatmentCodes);
    }
}
