using IRS.Web.Code.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IRS.Web.Areas.Admin.Models.ViewModels.Common
{
    public class UserRoleViewModel
    {
        public int Id { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "Name")]
        [RequiredLocalized]
        public string Name { get; set; }
        [Display(ResourceType = typeof(Labels), Name = "Description")]
        public string Description { get; set; }
    }
}