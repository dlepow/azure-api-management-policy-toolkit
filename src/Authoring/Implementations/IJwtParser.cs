﻿using Azure.ApiManagement.PolicyToolkit.Authoring.Expressions;

namespace Azure.ApiManagement.PolicyToolkit.Authoring.Implementations;

public interface IJwtParser
{
    Jwt? Parse(string? value);
}