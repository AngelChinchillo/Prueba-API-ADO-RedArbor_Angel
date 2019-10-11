using Newtonsoft.Json;
using RedArbor.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedArbor.Models
{
    public class POST_Employee : ModelBase
    {
        [JsonProperty("CompanyId", Required = Required.Always)] 
        public int CompanyId { get; set; }
        [JsonProperty("CreatedOn", Required = Required.Always)] 
        public DateTime CreatedOn { get; set; }
        [JsonProperty("DeletedOn", Required = Required.Always)] 
        public DateTime DeletedOn { get; set; }
        [JsonProperty("Email", Required = Required.Always)] 
        public string Email { get; set; }
        [JsonProperty("Fax", Required = Required.Always)] 
        public string Fax { get; set; }
        [JsonProperty("Name", Required = Required.Always)] 
        public string Name { get; set; }  
        [JsonProperty("Lastlogin", Required = Required.Always)] 
        public DateTime Lastlogin { get; set; }
        [JsonProperty("Password", Required = Required.Always)] 
        public string Password { get; set; }
        [JsonProperty("PortalId", Required = Required.Always)] 
        public int PortalId { get; set; }
        [JsonProperty("RoleId", Required = Required.Always)] 
        public int RoleId { get; set; }
        [JsonProperty("StatusId", Required = Required.Always)] 
        public int StatusId { get; set; }
        [JsonProperty("Telephone", Required = Required.Always)]
        public string Telephone { get; set; }       
        [JsonProperty("UpdatedOn",Required = Required.Always)]
        public DateTime UpdatedOn { get; set; }
        [JsonProperty("Username", Required = Required.Always)]     
        public string Username { get; set; }  
        
        public const string QUERY_INSERT_ALL_RETURN_IDENTITY = 
                            "INSERT INTO [dbo].[tblEmployee]([intCompanyID],[dtCreatedOn],[dtDeletedOn],[vcEmail],[vcFax],[vcName],[dtLastLogin],[vcPassword],[intPortalID],[intRoleID],[intStatusID],[vcTelephone],[vcUpdatedOn],[vcUsername])" +
                            "OUTPUT INSERTED.intID    VALUES(@intCompanyID, @dtCreatedOn, @dtDeletedOn, @vcEmail, @vcFax, @vcName, @dtLastLogin, @vcPassword, @intPortalID ,@intRoleID, @intStatusID, @vcTelephone, @vcUpdatedOn, @vcUsername )";

    }

}
