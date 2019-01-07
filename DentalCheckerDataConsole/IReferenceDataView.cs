using System.Collections.Generic;

namespace DentalCheckerDataConsole
{
    public interface IReferenceDataView
    {
        void setReferenceDataList1(List<ReferenceData> referenceDataList);
        void setReferenceDataList2(List<ReferenceData> referenceDataList);

        void setVersion1(string version);
        void setVersion2(string version);
    }
}