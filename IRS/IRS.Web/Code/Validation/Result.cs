using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRS.Web.Code.Validation
{
    public class Result
    {
        public Result()
        {
            Success = true;
            Errors = new List<string>();
        }
        public IEnumerable<string> Errors { get; set; }
        public bool Success { get; set; }
    }
}