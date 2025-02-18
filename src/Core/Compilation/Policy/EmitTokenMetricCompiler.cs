﻿using System.Xml.Linq;

using Azure.ApiManagement.PolicyToolkit.Authoring;

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Azure.ApiManagement.PolicyToolkit.Compilation.Policy;

public class EmitTokenMetricCompiler : IMethodPolicyHandler
{
    public static IMethodPolicyHandler Llm =>
        new EmitTokenMetricCompiler("llm-emit-token-metric", nameof(IInboundContext.LlmEmitTokenMetric));

    public static IMethodPolicyHandler AzureOpenAi =>
        new EmitTokenMetricCompiler("azure-openai-emit-token-metric",
            nameof(IInboundContext.AzureOpenAiEmitTokenMetric));

    private readonly string _policyName;
    public string MethodName { get; }

    private EmitTokenMetricCompiler(string policyName, string methodName)
    {
        this._policyName = policyName;
        MethodName = methodName;
    }

    public void Handle(ICompilationContext context, InvocationExpressionSyntax node)
    {
        if (!node.TryExtractingConfigParameter<EmitTokenMetricConfig>(context, _policyName, out var values))
        {
            return;
        }

        var element = new XElement(_policyName);

        element.AddAttribute(values, nameof(EmitTokenMetricConfig.Namespace), "namespace");

        if (!values.TryGetValue(nameof(EmitTokenMetricConfig.Dimensions), out var dimensionsInitializer))
        {
            context.ReportError(
                $"{_policyName} {nameof(EmitTokenMetricConfig.Dimensions)} must have been defined. {node.GetLocation()}");
            return;
        }

        var dimensions = dimensionsInitializer.UnnamedValues ?? Array.Empty<InitializerValue>();
        if (dimensions.Count == 0)
        {
            context.ReportError(
                $"{_policyName} {nameof(EmitTokenMetricConfig.Dimensions)} must have at least one value. {node.GetLocation()}");
            return;
        }

        foreach (var dimension in dimensions)
        {
            if (!dimension.TryGetValues<MetricDimensionConfig>(out var result))
            {
                continue;
            }

            var dimensionElement = new XElement("dimension");
            if (!dimensionElement.AddAttribute(result, nameof(MetricDimensionConfig.Name), "name"))
            {
                context.ReportError(
                    $"{_policyName}.dimension {nameof(MetricDimensionConfig.Name)}. {node.GetLocation()}");
                continue;
            }

            dimensionElement.AddAttribute(result, nameof(MetricDimensionConfig.Value), "value");
            element.Add(dimensionElement);
        }
        
        context.AddPolicy(element);
    }
}