using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalCheckerDataConsole
{
    public class ReferenceData
    {
        public String      codeRule                        {get; set; }
        public String      code                            {get; set; }
        public String      addendum                        {get; set; } //
        public Boolean     ignorePrice                     {get; set; } //
        public Decimal     cost                           { get; set; }
        public Boolean     hasCost                         {get; set; }
        public decimal     price                           {get; set; }
        public String      description                     {get; set; }
        public String      conflictsWithExpr               {get; set; }
        public String      conflictsOnElementWithExpr      {get; set; } //
        public String      mandatoryWithExpr               {get; set; }
        public String      onlyWithExpr                    {get; set; } //
        public int         nrOfSurfaces                    {get; set; }
        public int         maxNr                           {get; set; }
        public String      maxNrOfPerformancesOnObjectType {get; set; }
        public int         periodLengthInDays              {get; set; }
        public Boolean     alarm                           {get; set; }
        public Boolean     elementRequired                 {get; set; }
        public String      conflictsInGroup                {get; set; } //
        public String      conflictsInGroupExpr            {get; set; } //
        public String      conflictObjectType              {get; set; }
        public String      mandatoryObjType                {get; set; }
        public String      elementGroups                   {get; set; }
        public String      validFrom                       {get; set; } //
        public String      validTo                         {get; set; }
        public Boolean     inputFileId                     {get; set; } //
        public String      maxCountOnObjectType            {get; set; }
        public Boolean     deleted                         {get; set; } //
    }
}
