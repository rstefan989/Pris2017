using System;
using System.Runtime.Serialization;

namespace IRS.Domain
{
    [Serializable]
    public class AccountNotExistsException : Exception
    {
        public AccountNotExistsException()
        {
        }
    }
}