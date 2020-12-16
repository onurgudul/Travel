﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Core.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(success: true, message)
        {

        }

        public SuccessResult() : base(success: true)
        {
        }
    }
}
