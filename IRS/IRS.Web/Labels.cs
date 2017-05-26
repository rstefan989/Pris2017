using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Web.UI.WebControls;
using IRS.Web.Code.Mapping;

namespace IRS.Web
{
    public class Labels
    {
        #region Resource management code
        private static ResourceManager resourceMan;

        public Labels()
        {
        }

        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                    resourceMan = new ResourceManager("Resources.Resource", Assembly.Load("App_GlobalResources"));

                return resourceMan;
            }
        }

        static string GetString(string key)
        {
            var value = ResourceManager.GetString(key, CultureInfo.CurrentUICulture);
            value = value ?? ResourceManager.GetString(key, CultureInfo.CreateSpecificCulture("en-US"));




            return value;
        }
        #endregion

        /// <summary>
        /// list of properties/words enter bellow
        /// </summary>
        //public static string GetResourceByName(string resName) { return GetString(resName); }
        public static string Saved { get { return GetString("Saved"); } }
        public static string Name { get { return GetString("Name"); } }
        public static string Description { get { return GetString("Description"); } }
        public static string Email { get { return GetString("Email"); } }
        public static string Password { get { return GetString("Password"); } }
        public static string OldPassword { get { return GetString("OldPassword"); } }
        public static string NewPassword { get { return GetString("NewPassword"); } }
        public static string ConfirmPassword { get { return GetString("ConfirmPassword"); } }
        public static string PasswordDoesNotMatch { get { return GetString("PasswordDoesNotMatch"); } }
        public static string Save { get { return GetString("Save"); } }
        public static string Cancel { get { return GetString("Cancel"); } }
        public static string FullView { get { return GetString("FullView"); } }
        public static string Login { get { return GetString("Login"); } }
        public static string ErrorOccured { get { return GetString("ErrorOccured"); } }
        public static string ForbiddenPageTitle { get { return GetString("ForbiddenPageTitle"); } }
        public static string InsufficientPermissions { get { return GetString("InsufficientPermissions"); } }
        public static string AccessDenied { get { return GetString("AccessDenied"); } }
        public static string Admin { get { return GetString("Admin"); } }
        public static string LogOff { get { return GetString("LogOff"); } }
        public static string ChangePassword { get { return GetString("ChangePassword"); } }
        public static string EditAccount { get { return GetString("EditAccount"); } }
        public static string Error { get { return GetString("Error"); } }
        public static string UserProfile { get { return GetString("UserProfile"); } }
        public static string Signin { get { return GetString("Signin"); } }
        public static string RequiredField { get { return GetString("RequiredField"); } }
        
    }
}