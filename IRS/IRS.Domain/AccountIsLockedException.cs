using System;
using System.Runtime.Serialization;

namespace IRS.Domain
{
    [Serializable]
    public class AccountIsLockedException : Exception
    {
        public AccountIsLockedException()
        {
        }
    }
}