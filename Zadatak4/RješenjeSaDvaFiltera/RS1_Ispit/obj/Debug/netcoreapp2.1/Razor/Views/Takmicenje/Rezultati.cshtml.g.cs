#pragma checksum "C:\Users\Emir\Desktop\Zadatak4\1.9.2020. dva filtera\RS1_Ispit\Views\Takmicenje\Rezultati.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ee2273a34ee979a185fb4c53451348b5f0de07b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Takmicenje_Rezultati), @"mvc.1.0.view", @"/Views/Takmicenje/Rezultati.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Takmicenje/Rezultati.cshtml", typeof(AspNetCore.Views_Takmicenje_Rezultati))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ee2273a34ee979a185fb4c53451348b5f0de07b", @"/Views/Takmicenje/Rezultati.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0f6eb31d1c8637546d58ee5a6164dbc58c0c748", @"/Views/_ViewImports.cshtml")]
    public class Views_Takmicenje_Rezultati : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RS1_Ispit_asp.net_core.ViewModels.TakmicenjeRezultatVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Zakljucaj", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Takmicenje", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dodaj", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(63, 24, true);
            WriteLiteral("\r\n<label>Škola domaćin: ");
            EndContext();
            BeginContext(88, 18, false);
#line 3 "C:\Users\Emir\Desktop\Zadatak4\1.9.2020. dva filtera\RS1_Ispit\Views\Takmicenje\Rezultati.cshtml"
                 Write(Model.SkolaDomacin);

#line default
#line hidden
            EndContext();
            BeginContext(106, 36, true);
            WriteLiteral("</label>\r\n<br />\r\n\r\n<label>Predmet: ");
            EndContext();
            BeginContext(143, 13, false);
#line 6 "C:\Users\Emir\Desktop\Zadatak4\1.9.2020. dva filtera\RS1_Ispit\Views\Takmicenje\Rezultati.cshtml"
           Write(Model.Predmet);

#line default
#line hidden
            EndContext();
            BeginContext(156, 35, true);
            WriteLiteral("</label>\r\n<br />\r\n\r\n<label>Razred: ");
            EndContext();
            BeginContext(192, 12, false);
#line 9 "C:\Users\Emir\Desktop\Zadatak4\1.9.2020. dva filtera\RS1_Ispit\Views\Takmicenje\Rezultati.cshtml"
          Write(Model.Razred);

#line default
#line hidden
            EndContext();
            BeginContext(204, 34, true);
            WriteLiteral("</label>\r\n<br />\r\n\r\n<label>Datum: ");
            EndContext();
            BeginContext(239, 34, false);
#line 12 "C:\Users\Emir\Desktop\Zadatak4\1.9.2020. dva filtera\RS1_Ispit\Views\Takmicenje\Rezultati.cshtml"
         Write(Model.Datum.ToString("dd/MM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(273, 21, true);
            WriteLiteral("</label>\r\n<br />\r\n\r\n ");
            EndContext();
            BeginContext(294, 98, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6186fc530208418b84cc95296f26eaa5", async() => {
                BeginContext(379, 9, true);
                WriteLiteral("Zakljucaj");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 15 "C:\Users\Emir\Desktop\Zadatak4\1.9.2020. dva filtera\RS1_Ispit\Views\Takmicenje\Rezultati.cshtml"
                                                     WriteLiteral(Model.TakmicenjeID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(392, 52, true);
            WriteLiteral("\r\n<br />\r\n<br />\r\n\r\n<div id=\"ajaxDiv\">\r\n\r\n\r\n</div>\r\n");
            EndContext();
            BeginContext(444, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bd92ebd28e9432187233623292b0348", async() => {
                BeginContext(519, 15, true);
                WriteLiteral("Novo takmicenje");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(538, 40, true);
            WriteLiteral("\r\n\r\n<script>\r\n\r\n    $.get(\"/Ajax/Index?=");
            EndContext();
            BeginContext(579, 18, false);
#line 27 "C:\Users\Emir\Desktop\Zadatak4\1.9.2020. dva filtera\RS1_Ispit\Views\Takmicenje\Rezultati.cshtml"
                   Write(Model.TakmicenjeID);

#line default
#line hidden
            EndContext();
            BeginContext(597, 90, true);
            WriteLiteral("\", function (rezultat) {\r\n        $(\"#ajaxDiv\").html(rezultat);\r\n    })\r\n</script>\r\n\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RS1_Ispit_asp.net_core.ViewModels.TakmicenjeRezultatVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
