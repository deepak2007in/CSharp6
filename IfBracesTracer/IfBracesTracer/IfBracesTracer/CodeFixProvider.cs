using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.Text;

namespace IfBracesTracer
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(IfBracesTracerCodeFixProvider)), Shared]
    public class IfBracesTracerCodeFixProvider : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds
        {
            get { return ImmutableArray.Create(IfBracesTracerAnalyzer.DiagnosticId); }
        }

        public sealed override FixAllProvider GetFixAllProvider()
        {
            return WellKnownFixAllProviders.BatchFixer;
        }

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            // TODO: Replace the following code with your own analysis, generating a CodeAction for each fix to suggest
            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;

            // Find the type declaration identified by the diagnostic.
            var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<IfStatementSyntax>().First();

            // Register a code action that will invoke the fix.
            context.RegisterCodeFix(
                CodeAction.Create("Add Deepak's Braces", c => AddBracesAsync(context.Document, declaration, c)),
                diagnostic);
        }

        private async Task<Document> AddBracesAsync(Document document, IfStatementSyntax ifStatement, CancellationToken cancellationToken)
        {
            var nonBlockedStatement = ifStatement.Statement as ExpressionStatementSyntax;
            var newBlockedStatement = SyntaxFactory.Block(statements: nonBlockedStatement);
            var newIfStatement = ifStatement.ReplaceNode(oldNode: nonBlockedStatement, newNode: newBlockedStatement);
            var root = await document.GetSyntaxRootAsync();
            var newRoot = root.ReplaceNode(oldNode: ifStatement, newNode: newIfStatement);
            var newDocument = document.WithSyntaxRoot(newRoot);
            return newDocument;
        }
    }
}