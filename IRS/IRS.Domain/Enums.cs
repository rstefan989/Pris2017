namespace IRS.Domain
{
    public enum AuthenticationResult
    {
        Successful,
        Failed,
        Locked
    }

    public enum NotificationType
    {
        Success = 1,
        Error = -1,
        Info = 2,
        Warning = 3
    }

    public enum UserRole
    {
        Admin = 1,
        User = 2
    }
}
