using Newtonsoft.Json;
using RedArbor.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedArbor.Models
{
    public class PUT_Employee : POST_Employee
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        public const string UPDATE_ALL_WHERE_IDENTITY =
                           " UPDATE [dbo].[tblEmployee]" +
                           " SET" +
                           " [intCompanyID] = @intCompanyID " +
                           ",[dtCreatedOn]  = @dtCreatedOn " +
                           ",[dtDeletedOn]  = @dtDeletedOn " +
                           ",[vcEmail]      = @vcEmail " +
                           ",[vcFax]        = @vcFax " +
                           ",[vcName]       = @vcName " +
                           ",[dtLastLogin]  = @dtLastLogin " +
                           ",[vcPassword]   = @vcPassword " +
                           ",[intPortalID]  = @intPortalID " +
                           ",[intRoleID]    = @intRoleID " +
                           ",[intStatusID]  = @intStatusID " +
                           ",[vcTelephone]  = @vcTelephone " +
                           ",[vcUpdatedOn]  = @vcUpdatedOn " +
                           ",[vcUsername]   = @vcUsername " +
                             WHERE_IDENTITY;
    }

}
