
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using YuSpin.Fw.Extensions;

namespace YuSpin.Fw.Cryptography.Tokens
{
    public class TokenProvider : DataProtector
    {

        // Public constructor
        // The Demand for DataProtectionPermission is in the constructor because we Assert this permission 
        // in the ProviderProtect/ProviderUnprotect methods. 
        [DataProtectionPermission(SecurityAction.Demand, Unrestricted = true)]
        [SecuritySafeCritical]
        public TokenProvider(string appName, string primaryPurpose)
            : base(appName, primaryPurpose, null)
        {
        }

        public DataProtectionScope Scope { get; set; }
        // This implementation gets the HashedPurpose from the base class and passes it as OptionalEntropy to ProtectedData.
        // The default for DataProtector is to prepend the hash to the plain text, but because we are using the hash 
        // as OptionalEntropy there is no need to prepend it.
        protected override bool PrependHashedPurposeToPlaintext
        {
            get
            {
                return false;
            }
        }


        public virtual string GenerateToken(int userId, string email, string passSalt)
        {
            var ms = new MemoryStream();
            using (var writer = ms.CreateWriter())
            {
                writer.Write(DateTimeOffset.UtcNow);
                writer.Write(userId);
                writer.Write(email);
                writer.Write(passSalt);
            }
            return Convert.ToBase64String(Protect(ms.ToArray()));
        }

        public virtual bool ValidateToken(int userId, string email, string passSalt, string token, TimeSpan tokemLifeTime)
        {
            try
            {
                var unprotectedData = Unprotect(Convert.FromBase64String(token));
                var ms = new MemoryStream(unprotectedData);
                using (var reader = ms.CreateReader())
                {
                    var t_creationTime = reader.ReadDateTimeOffset();
                    var t_expirationTime = t_creationTime + tokemLifeTime;
                    if (t_expirationTime < DateTimeOffset.UtcNow)
                        return false;

                    var t_userId = reader.ReadInt32();
                    if (t_userId != userId) return false;

                    var t_email = reader.ReadString();
                    if (t_email != email) return false;

                    var t_passSalt = reader.ReadString();
                    if (t_passSalt != passSalt) return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }


        public void Dispose()
        {

        }

        [SecuritySafeCritical]
        [DataProtectionPermission(SecurityAction.Assert, ProtectData = true)]
        protected override byte[] ProviderProtect(byte[] userData)
        {
            // Delegate to ProtectedData
            return ProtectedData.Protect(userData, GetHashedPurpose(), Scope);
        }
        [SecuritySafeCritical]
        [DataProtectionPermission(SecurityAction.Assert, UnprotectData = true)]
        protected override byte[] ProviderUnprotect(byte[] encryptedData)
        {
            // Delegate to ProtectedData
            return ProtectedData.Unprotect(encryptedData, GetHashedPurpose(), Scope);
        }
        public override bool IsReprotectRequired(byte[] encryptedData)
        {
            // For now, this cannot be determined, so always return true;
            return true;
        }


    }
}
