﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceships.Application.Dtos;

public record UserProfileDto(string Email, string FirstName, string LastName, bool IsAdmin);

