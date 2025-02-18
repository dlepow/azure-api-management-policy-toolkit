﻿using Azure.ApiManagement.PolicyToolkit.Authoring.Expressions;

namespace Azure.ApiManagement.PolicyToolkit.Emulator.Expressions;

public record MockBasicAuthCredentials(string Username, string Password) : BasicAuthCredentials
{
}