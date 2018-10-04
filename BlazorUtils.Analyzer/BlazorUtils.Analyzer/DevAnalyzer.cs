using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace BlazorUtils.Analyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class DevAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "BlazorUtilsAnalyzer";

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = "An object will be mapped by BlazorUtils.Dev";
        private static readonly LocalizableString MessageFormat = "{0} will be mapped by BlazorUtils.Dev";
        private static readonly LocalizableString Description = "Mapping costs performance. Please remove these mapping line or use \"if\" to skip mapping for production.";
        private const string Category = "BlazorUtils.Dev";

        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
            context.RegisterSyntaxTreeAction(AnalyzeDevMapping);

        }

        //private static void AnalyzeSymbol(SymbolAnalysisContext context)
        //{
        //    // TODO: Replace the following code with your own analysis, generating Diagnostic objects for any issues you find
        //    var namedTypeSymbol = (INamedTypeSymbol)context.Symbol;

        //    // Find just those named type symbols with names containing lowercase letters.
        //    if (namedTypeSymbol.Name.ToCharArray().Any(char.IsLower))
        //    {
        //        // For all such symbols, produce a diagnostic.
        //        var diagnostic = Diagnostic.Create(Rule, namedTypeSymbol.Locations[0], namedTypeSymbol.Name);

        //        context.ReportDiagnostic(diagnostic);
        //    }
        //}

        private static void AnalyzeDevMapping(SyntaxTreeAnalysisContext context)
        {
            var root = context.Tree.GetRoot();

            //var nodes = from node in root.DescendantNodes()
            //                         .OfType<InvocationExpressionSyntax>()
            //            let id = node.Expression as IdentifierNameSyntax
            //            where id != null
            //            where id.Identifier.ValueText == nameof(Dev.Dev.Map)
            //            select node;

            var nodes = root.DescendantNodes()
                                     .OfType<InvocationExpressionSyntax>()
                                     .Where(x => x.Expression as IdentifierNameSyntax != null && ((IdentifierNameSyntax)x.Expression).Identifier.ValueText == nameof(Dev.Dev.Map))
                                     .Select(x => x.GetText());

            var diagnostic = Diagnostic.Create(Rule, root.GetLocation());

            context.ReportDiagnostic(diagnostic);
        }
    }
}
