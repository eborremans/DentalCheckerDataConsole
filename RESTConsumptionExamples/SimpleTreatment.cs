﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTConsumptionExamples
{
    public class SimpleTreatment
    {
        private String _code;
        public String code {
            get { return _code; }
            set {
                this._code = value;
                //Debug.WriteLine("Code: " + this.code);
            }
        }
        public String description { get; set; }
        public String addendum { get; set; }

        public SimpleTreatment(string code, string description, string addendum)
        {
            this.code = code;
            this.description = description;
            this.addendum = addendum;
        }

        public override String ToString()
        {
            StringBuilder text = new StringBuilder();

            text.Append("code              :" + code);
            text.AppendLine();
            text.Append("description       :" + description);
            text.AppendLine();
            text.Append("addendum          :" + addendum);
            text.AppendLine();

            return text.ToString();
        }
    }
}
