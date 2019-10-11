using Newtonsoft.Json;
using RedArbor.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedArbor.Models
{

    public class GET_Employee : ModelBase
    {
        [DataField("intID")]
        [JsonProperty("Id")]
        public int Id { get; set; }
        [DataField("intCompanyID")]
        [JsonProperty("CompanyId")]
        public int CompanyId { get; set; }
        [DataField("dtCreatedOn")]
        [JsonProperty("CreatedOn")]
        public DateTime CreatedOn { get; set; }
        [DataField("dtDeletedOn")]
        [JsonProperty("DeletedOn")]
        public DateTime DeletedOn { get; set; }
        [DataField("vcEmail")]
        [JsonProperty("Email")]
        public string Email { get; set; }
        [DataField("vcFax")]
        [JsonProperty("Fax")]
        public string Fax { get; set; }
        [DataField("vcName")]
        [JsonProperty("Name")]
        public string Name { get; set; }
        [DataField("dtLastLogin")]
        [JsonProperty("Lastlogin")]
        public DateTime Lastlogin { get; set; }
        [DataField("vcPassword")]
        [JsonProperty("Password")]
        public string Password { get; set; }
        [DataField("intPortalID")]
        [JsonProperty("PortalId")]
        public int PortalId { get; set; }
        [DataField("intRoleID")]
        [JsonProperty("RoleId")]
        public int RoleId { get; set; }
        [DataField("intStatusID")]
        [JsonProperty("StatusId")]
        public int StatusId { get; set; }
        [DataField("vcTelephone")]
        [JsonProperty("Telephone")]
        public string Telephone { get; set; }
        [DataField("vcUpdatedOn")]
        [JsonProperty("UpdatedOn")]
        public DateTime UpdatedOn { get; set; }
        [DataField("vcUsername")]
        [JsonProperty("Username")]     
        public string Username { get; set; }

        public const string QUERY_SELECT =
                            "select intID" +
                            ", intCompanyID" +
                            ", dtCreatedOn" +
                            ", dtDeletedOn" +
                            ", vcEmail" +
                            ", vcFax" +
                            ", vcName" +
                            ", dtLastLogin" +
                            ", vcPassword" +
                            ", intPortalID" +
                            ", intRoleID" +
                            ", intStatusID" +
                            ", vcTelephone" +
                            ", vcUpdatedOn" +
                            ", vcUsername " +
                            "FROM tblEmployee WITH (nolock)";
    }
}
