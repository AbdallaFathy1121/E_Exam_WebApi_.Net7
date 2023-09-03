﻿using Application.DTOs.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IJWTManagerRepository
    {
        GenerateToken Authenticate(User user);
    }
}