using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRS.Domain.Entities;

namespace IRS.Domain.Interfaces.Configuration
{
    public interface IConfigProvider
    {
        IAuthUser AuthUser { get; set; }
        IWebConfig WebConfig { get; set; }

        void SetLanguage(string selectedLanguage);
        string SelectedLanguage { get; }
    }
}
