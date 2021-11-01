using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace AppSale.Domain.Entities.Security
{
    public class SigningConfiguration
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfiguration(TokenConfiguration tokenConfiguration)
        {
            Key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(tokenConfiguration.SecretKey));

            SigningCredentials = new(
                Key, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
