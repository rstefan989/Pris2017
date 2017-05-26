﻿using IRS.Web.Code.Attributes.Validation;
using IRS.Web.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace IRS.Web.Areas.Admin.Models.ViewModels.Common
{
    public class UserViewModel : ViewModelBase
    {
        public int Id { get; set; }
    }
}