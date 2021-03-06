Imports System
Imports EnvDTE
Imports EnvDTE80
Imports EnvDTE90
Imports EnvDTE90a
Imports EnvDTE100
Imports System.Diagnostics

Public Module Common
    Sub ReReplace(ByVal a, ByVal b)
        DTE.Find.FindWhat = a
        DTE.Find.ReplaceWith = b
        DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocumentSelection
        DTE.Find.MatchCase = False
        DTE.Find.MatchWholeWord = False
        DTE.Find.MatchInHiddenText = False
        DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr
        DTE.Find.ResultsLocation = vsFindResultsLocation.vsFindResultsNone
        DTE.Find.Action = vsFindAction.vsFindActionReplaceAll
        If (DTE.Find.Execute() = vsFindResult.vsFindResultNotFound) Then
            Throw New System.Exception("vsFindResultNotFound")
        End If
    End Sub
    Sub Replace(ByVal a, ByVal b)
        DTE.Find.FindWhat = a
        DTE.Find.ReplaceWith = b
        DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocumentSelection
        DTE.Find.MatchCase = False
        DTE.Find.MatchWholeWord = False
        DTE.Find.MatchInHiddenText = False
        DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxLiteral
        DTE.Find.ResultsLocation = vsFindResultsLocation.vsFindResultsNone
        DTE.Find.Action = vsFindAction.vsFindActionReplaceAll
        If (DTE.Find.Execute() = vsFindResult.vsFindResultNotFound) Then
            Throw New System.Exception("vsFindResultNotFound")
        End If
    End Sub
    Sub FillGuid()
        DTE.Find.FindWhat = "Guid="""""
        DTE.Find.ReplaceWith = "Guid=""{" + Guid.NewGuid().ToString().ToUpper() + "}"""
        DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocumentSelection
        DTE.Find.MatchCase = False
        DTE.Find.MatchWholeWord = False
        DTE.Find.MatchInHiddenText = False
        DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr
        DTE.Find.ResultsLocation = vsFindResultsLocation.vsFindResultsNone
        DTE.Find.Action = vsFindAction.vsFindActionReplace

        If (DTE.Find.Execute() = vsFindResult.vsFindResultNotFound) Then
            Throw New System.Exception("vsFindResultNotFound")
        End If
    End Sub
    Sub _T2L()
        DTE.Find.FindWhat = "_T\({:q}\)"
        DTE.Find.ReplaceWith = "L\1"
        DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocumentSelection
        DTE.Find.MatchCase = False
        DTE.Find.MatchWholeWord = False
        DTE.Find.MatchInHiddenText = False
        DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr
        DTE.Find.ResultsLocation = vsFindResultsLocation.vsFindResultsNone
        DTE.Find.Action = vsFindAction.vsFindActionReplaceAll
        If (DTE.Find.Execute() = vsFindResult.vsFindResultNotFound) Then
            Throw New System.Exception("vsFindResultNotFound")
        End If
    End Sub

    Sub ParamNextLine()
        ReReplace(",", ",\n")
        DTE.ExecuteCommand("Edit.FormatSelection")
    End Sub

    Sub wstring_to_string()
        DTE.Find.FindWhat = "wstring"
        DTE.Find.ReplaceWith = "string"
        DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocumentSelection
        DTE.Find.MatchCase = False
        DTE.Find.MatchWholeWord = False
        DTE.Find.MatchInHiddenText = False
        DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr
        DTE.Find.ResultsLocation = vsFindResultsLocation.vsFindResultsNone
        DTE.Find.Action = vsFindAction.vsFindActionReplaceAll
        If (DTE.Find.Execute() = vsFindResult.vsFindResultNotFound) Then
            Throw New System.Exception("vsFindResultNotFound")
        End If
    End Sub
    Sub string_to_wstring()
        DTE.Find.FindWhat = "string"
        DTE.Find.ReplaceWith = "wstring"
        DTE.Find.Target = vsFindTarget.vsFindTargetCurrentDocumentSelection
        DTE.Find.MatchCase = False
        DTE.Find.MatchWholeWord = False
        DTE.Find.MatchInHiddenText = False
        DTE.Find.PatternSyntax = vsFindPatternSyntax.vsFindPatternSyntaxRegExpr
        DTE.Find.ResultsLocation = vsFindResultsLocation.vsFindResultsNone
        DTE.Find.Action = vsFindAction.vsFindActionReplaceAll
        If (DTE.Find.Execute() = vsFindResult.vsFindResultNotFound) Then
            Throw New System.Exception("vsFindResultNotFound")
        End If
    End Sub

    Sub WixWrapFileWithComponent()
        ReReplace("\<File Id=""{.@}"".*/\>", "\<Component Id=""CMP_\1"" Guid=""""\>\n\0\n\</Component\>")

        ReReplace("\<File Id=""{.@}""", "\<File Id=""FILE_\1""")


        DTE.ExecuteCommand("Edit.FormatSelection")
    End Sub

    Sub WixFileAddKeyPath()
        ReReplace("\<File {.*}/\>", "\<File \1 KeyPath=""yes""/\>")
        DTE.ExecuteCommand("Edit.FormatSelection")
    End Sub

    Sub WixFileAddCheckSum()
        ReReplace("\<File {.*}/\>", "\<File \1 Checksum=""yes""/\>")
        DTE.ExecuteCommand("Edit.FormatSelection")
    End Sub
    Sub QuoteToDoubleQuote()
        Replace("'", """")
        DTE.ExecuteCommand("Edit.FormatSelection")
    End Sub
    Sub StdMethod2StdMethodImp()
        ReReplace("STDMETHOD_\({:i},:b+{:i}\)", "STDMETHODIMP_(\1) WixMultilangBA::\2")
        DTE.ExecuteCommand("Edit.FormatSelection")
    End Sub
End Module
