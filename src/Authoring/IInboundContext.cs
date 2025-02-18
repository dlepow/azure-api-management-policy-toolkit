using System.Diagnostics.CodeAnalysis;

using Azure.ApiManagement.PolicyToolkit.Authoring.Expressions;

namespace Azure.ApiManagement.PolicyToolkit.Authoring;

public interface IInboundContext : IHaveExpressionContext
{
    /// <summary>
    /// The base policy used to specify when parent scope policy should be executed
    /// </summary>
    void Base();

    /// <summary>
    /// Adds header of specified name with values or overrides values if header already exists.<br />
    /// Compiled to <a href="https://learn.microsoft.com/en-us/azure/api-management/set-header-policy">set-header</a> policy.
    /// </summary>
    /// <param name="name">
    /// Specifies name of the header to be added. Policy expressions are allowed.
    /// </param>
    /// <param name="values">
    /// Specifies the values of the header to be set. Policy expressions are allowed.
    /// </param>
    void SetHeader(string name, params string[] values);

    /// <summary>
    /// Sets header of specified name and values if header not already exist.<br />
    /// Compiled to <a href="https://learn.microsoft.com/en-us/azure/api-management/set-header-policy">set-header</a> policy.
    /// </summary>
    /// <param name="name">
    /// Specifies name of the header to be added. Policy expressions are allowed.
    /// </param>
    /// <param name="values">
    /// Specifies the values of the header to be set. Policy expressions are allowed.
    /// </param>
    void SetHeaderIfNotExist(string name, params string[] values);

    /// <summary>
    /// Adds header of specified name with values or appends values if header already exists.<br />
    /// Compiled to <a href="https://learn.microsoft.com/en-us/azure/api-management/set-header-policy">set-header</a> policy.
    /// </summary>
    /// <param name="name">
    /// Specifies name of the header to be added. Policy expressions are allowed.
    /// </param>
    /// <param name="values">
    /// Specifies the values of the header to be set or appended. Policy expressions are allowed.
    /// </param>
    void AppendHeader(string name, params string[] values);

    /// <summary>
    /// Deletes header of specified name.<br />
    /// Compiled to <a href="https://learn.microsoft.com/en-us/azure/api-management/set-header-policy">set-header</a> policy.
    /// </summary>
    /// <param name="name">
    /// Specifies name of the header to be deleted. Policy expressions are allowed.
    /// </param>
    void RemoveHeader(string name);

    /// <summary>
    /// The cors policy adds cross-origin resource sharing (CORS) support to an operation or an API to allow cross-domain calls from browser-based clients.
    /// </summary>
    /// <param name="config"></param>
    void Cors(CorsConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="body"></param>
    /// <param name="config"></param>
    void SetBody(string body, SetBodyConfig? config = null);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    void SetVariable(string name, dynamic value);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void RateLimit(RateLimitConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="template"></param>
    /// <param name="copyUnmatchedParams"></param>
    void RewriteUri(string template, bool copyUnmatchedParams = true);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void Quota(QuotaConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="method"></param>
    void SetMethod(string method);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void IpFilter(IpFilterConfig config);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="values"></param>
    void SetQueryParameter(string name, params string[] values);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="values"></param>
    void SetQueryParameterIfNotExist(string name, params string[] values);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="values"></param>
    void AppendQueryParameter(string name, params string[] values);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    void RemoveQueryParameter(string name);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void RateLimitByKey(RateLimitByKeyConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void CheckHeader(CheckHeaderConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void MockResponse(MockResponseConfig? config = null);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void SendRequest(SendRequestConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void ReturnResponse(ReturnResponseConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void ValidateJwt(ValidateJwtConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void SetBackendService(SetBackendServiceConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    void AuthenticationBasic(string username, string password);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void CacheLookup(CacheLookupConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void EmitMetric(EmitMetricConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void LlmEmitTokenMetric(EmitTokenMetricConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void AzureOpenAiEmitTokenMetric(EmitTokenMetricConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void LlmSemanticCacheLookup(SemanticCacheLookupConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void AzureOpenAiSemanticCacheLookup(SemanticCacheLookupConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void AuthenticationManagedIdentity(ManagedIdentityAuthenticationConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void AuthenticationCertificate(CertificateAuthenticationConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void JsonToXml(JsonToXmlConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void CacheLookupValue(CacheLookupValueConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void CacheStoreValue(CacheStoreValueConfig config);

    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="config"></param>
    void CacheRemoveValue(CacheRemoveValueConfig config);

    /// <summary>
    /// Inlines the specified policy as is to policy document.
    /// </summary>
    /// <param name="policy">
    /// Policy in xml format.
    /// </param>
    void InlinePolicy(string policy);
}