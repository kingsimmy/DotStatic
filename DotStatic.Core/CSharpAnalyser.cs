using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotStatic.Core
{
    public class CSharpAnalyser
    {
        public static ProjectsData AnalyseSolutions(params string[] solutionPaths)
        {
            return solutionPaths.Select(s => AnalyseSolution(s)).Aggregate(ProjectsData.Merge);
        }

        public static ProjectsData AnalyseSolution(string solutionPath)
        {
            ProjectsData result = new ProjectsData();
            MSBuildWorkspace msWorkspace = MSBuildWorkspace.Create();
            try
            {
                Solution solution = msWorkspace.OpenSolutionAsync(solutionPath).Result;
                foreach (Project project in solution.Projects)
                {
                    Compilation compilation = project.GetCompilationAsync().Result;
                    foreach (Document document in project.Documents)
                    {
                        SyntaxNode root = document.GetSyntaxRootAsync().Result;

                        var nodes = root.DescendantNodes(n => true);
                        var st = root.SyntaxTree;
                        var sm = compilation.GetSemanticModel(st);
                        SyntaxNode[] syntaxNodes = nodes as SyntaxNode[] ?? nodes.ToArray();

                        IEnumerable<ITypeSymbol> symbolsReferenced = GetReferencedSymbols(sm, syntaxNodes);
                        IEnumerable<ITypeSymbol> symbolsDeclared = GetClassDeclarations(sm, syntaxNodes);
                        result.AddReferencedTypes(project.Name, symbolsReferenced.Select(x => x.ToDisplayString()));
                        result.AddDeclaredTypes(project.Name, symbolsDeclared.Select(x => x.ToDisplayString()));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return result;
        }

        private static IEnumerable<INamedTypeSymbol> GetClassDeclarations(SemanticModel sm, SyntaxNode[] syntaxNodes)
        {
            return syntaxNodes
                .OfType<ClassDeclarationSyntax>()
                .Select(id => sm.GetDeclaredSymbol(id))
                .Where(si => si.DeclaredAccessibility == Accessibility.Public)
                .OfType<INamedTypeSymbol>()
                .ToArray();
        }
        
        private static IEnumerable<ITypeSymbol> GetReferencedSymbols(SemanticModel sm, SyntaxNode[] syntaxNodes)
        {
            HashSet<ITypeSymbol> symbols = new HashSet<ITypeSymbol>();
            // IdentifierNameSyntax: var keyword, identifiers of any kind (including type names)
            var namedTypes = syntaxNodes
                .OfType<IdentifierNameSyntax>()
                .Select(id => sm.GetSymbolInfo(id).Symbol)                
                .OfType<INamedTypeSymbol>()                
                .SelectMany(x => x.TypeArguments.Add(x.OriginalDefinition))
                .Where(x => !x.IsAnonymousType && x.SpecialType != SpecialType.System_Void && x.TypeKind != TypeKind.Error)
                .ToArray();

            symbols.UnionWith(namedTypes);

            // ExpressionSyntax: method calls, property uses, field uses, all kinds of composite expressions
            var expressionTypes = syntaxNodes
                .OfType<ExpressionSyntax>()
                .Select(ma => sm.GetTypeInfo(ma).Type)
                .OfType<INamedTypeSymbol>()                
                .SelectMany(x => x.TypeArguments.Add(x.OriginalDefinition))
                .Where(x => !x.IsAnonymousType && x.SpecialType != SpecialType.System_Void && x.TypeKind != TypeKind.Error)
                .ToArray();

            symbols.UnionWith(expressionTypes);
            return symbols;
        }
    }
}