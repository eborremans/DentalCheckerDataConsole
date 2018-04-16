using System.Collections.Generic;

namespace RESTConsumptionExamples
{
    public interface IReferenceDataView
    {
        void setReferenceDataList1(List<ReferenceData> referenceDataList);
        void setReferenceDataList2(List<ReferenceData> referenceDataList);
    }
}