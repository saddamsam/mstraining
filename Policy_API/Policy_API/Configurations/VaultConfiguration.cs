using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;

namespace Policy_API.Configurations
{
    public class VaultConfiguration(IConfiguration configuration)
    {
       private IConfiguration _configuration = configuration;

        public async Task<IDictionary<string,object>> GetSecrets(string RootKey, string Url)
        {
            //var Url = _configuration["Url"];
            //var RootKey = _configuration["Root_Key"];
            TokenAuthMethodInfo tokenAuthMethodInfo = new TokenAuthMethodInfo(RootKey);

            VaultClientSettings vaultClientSettings = new VaultClientSettings(Url, tokenAuthMethodInfo);

            IVaultClient vaultClient = new VaultClient(vaultClientSettings);


            var result = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(path :"S1930",mountPoint: "secret");

            return result.Data.Data;
        }

    }
}
