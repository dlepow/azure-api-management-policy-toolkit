﻿using System.Text;
using System.Text.Encodings.Web;

using Azure.ApiManagement.PolicyToolkit.Authoring.Implementations;

namespace Azure.ApiManagement.PolicyToolkit.Emulator.Expressions;

public class UrlContentEncoder : IUrlContentEncoder
{
    public string? Encode(IDictionary<string, IList<string>>? dictionary)
    {
        if (dictionary == null || dictionary.Count == 0)
        {
            return null;
        }

        return dictionary.SelectMany(kvp => kvp.Value.Select(v => (kvp.Key, Value: v)))
            .Aggregate(
                new StringBuilder(),
                (sb, kvp) =>
                {
                    if (sb.Length > 0)
                    {
                        sb.Append('&');
                    }

                    sb.Append(UrlEncoder.Default.Encode(kvp.Key));
                    sb.Append('=');
                    sb.Append(UrlEncoder.Default.Encode(kvp.Value));
                    return sb;
                },
                sb => sb.ToString());
    }
}