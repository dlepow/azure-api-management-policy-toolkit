using System.Xml.Linq;

using Microsoft.CodeAnalysis;

namespace Azure.ApiManagement.PolicyToolkit.Compilation;

public class CompilationContext : ICompilationContext, ICompilationResult
{
    private readonly IList<string> _errors = new List<string>();
    private readonly XElement _rootElement;

    public CompilationContext(SyntaxNode syntaxRoot, XElement rootElement)
    {
        SyntaxRoot = syntaxRoot;
        _rootElement = rootElement;
    }

    public void AddPolicy(XNode element) => _rootElement.Add(element);

    public void ReportError(string message) => _errors.Add(message);

    public SyntaxNode SyntaxRoot { get; }

    public XElement Document => _rootElement;

    public IReadOnlyList<string> Errors => _errors.AsReadOnly();
}