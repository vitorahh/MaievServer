using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maiev.Swagger
{
    public class BadRequestResponseErrors
    {
        public string type { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string traceId { get; set; }

        public ErrorsExample Errors { get; set; }
    }
}
