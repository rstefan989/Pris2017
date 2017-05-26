﻿using System.Collections.Generic;
using IRS.Domain.Entities;

namespace IRS.Domain.Interfaces.Services
{
    public interface ICommentService : IServiceBase
    {
        IEnumerable<Comment> GetAll();

        Comment GetById(int id);
    }
}
