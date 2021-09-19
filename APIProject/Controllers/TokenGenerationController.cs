using Azure.Storage;
using Azure.Storage.Sas;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AzureSsnApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenGenerationController : ControllerBase
    {

        [HttpGet("GetSas")]
        public string GetSasToken()
        {
            var key = "DUYrm5lZOVfpl89CwH+YMClA8+kePDHbZXcRObWuHey3jzEcxq6PVOW+enf705qxuSUCmM5bzcSxi1TTV0niSg==";
            var sharedKeyCredentials = new StorageSharedKeyCredential("kpteststorage", key);
            var sasBuilder = new AccountSasBuilder()
            {
                StartsOn = DateTimeOffset.UtcNow,
                ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5),
                Services = AccountSasServices.Blobs,
                ResourceTypes = AccountSasResourceTypes.All,
                Protocol = SasProtocol.Https
            };
            sasBuilder.SetPermissions(AccountSasPermissions.All);

            var sasToken = sasBuilder.ToSasQueryParameters(sharedKeyCredentials).ToString();
            return sasToken;



        }

    }


}
