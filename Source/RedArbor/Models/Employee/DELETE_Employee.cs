using Newtonsoft.Json;
using RedArbor.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedArbor.Models
{
    public class DELETE_Employee : ModelBase
    {
        public const string DELETE_WHERE_IDENTITY = "DELETE [dbo].[tblEmployee]" + WHERE_IDENTITY;
    }

}
