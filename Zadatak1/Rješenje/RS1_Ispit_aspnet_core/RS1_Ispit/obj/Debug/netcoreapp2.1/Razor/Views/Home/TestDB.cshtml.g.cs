#pragma checksum "C:\Users\Emir\Desktop\Zadatak1\Rješenje\RS1_Ispit_aspnet_core\RS1_Ispit\Views\Home\TestDB.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39a95d0bf0ddb12a63bdbf2a4514200ea49a45ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TestDB), @"mvc.1.0.view", @"/Views/Home/TestDB.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/TestDB.cshtml", typeof(AspNetCore.Views_Home_TestDB))]
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
#line 1 "C:\Users\Emir\Desktop\Zadatak1\Rješenje\RS1_Ispit_aspnet_core\RS1_Ispit\Views\Home\TestDB.cshtml"
using RS1_Ispit_asp.net_core.EF;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39a95d0bf0ddb12a63bdbf2a4514200ea49a45ae", @"/Views/Home/TestDB.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0909514ccbe15c9b46987fb6fc827edf50cf04a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_TestDB : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RS1_Ispit_asp.net_core.EF.MojContext>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(79, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\Emir\Desktop\Zadatak1\Rješenje\RS1_Ispit_aspnet_core\RS1_Ispit\Views\Home\TestDB.cshtml"
  
    ViewBag.Title = "title";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(165, 52, true);
            WriteLiteral("\r\n<h2>Test DB - row count</h2>\r\n\r\nDodjeljenPredmet: ");
            EndContext();
            BeginContext(218, 30, false);
#line 11 "C:\Users\Emir\Desktop\Zadatak1\Rješenje\RS1_Ispit_aspnet_core\RS1_Ispit\Views\Home\TestDB.cshtml"
             Write(Model.DodjeljenPredmet.Count());

#line default
#line hidden
            EndContext();
            BeginContext(248, 20, true);
            WriteLiteral(" <br />\r\nNastavnik: ");
            EndContext();
            BeginContext(269, 23, false);
#line 12 "C:\Users\Emir\Desktop\Zadatak1\Rješenje\RS1_Ispit_aspnet_core\RS1_Ispit\Views\Home\TestDB.cshtml"
      Write(Model.Nastavnik.Count());

#line default
#line hidden
            EndContext();
            BeginContext(292, 21, true);
            WriteLiteral(" <br />\r\nOdjeljenje: ");
            EndContext();
            BeginContext(314, 24, false);
#line 13 "C:\Users\Emir\Desktop\Zadatak1\Rješenje\RS1_Ispit_aspnet_core\RS1_Ispit\Views\Home\TestDB.cshtml"
       Write(Model.Odjeljenje.Count());

#line default
#line hidden
            EndContext();
            BeginContext(338, 27, true);
            WriteLiteral(" <br />\r\nOdjeljenjeStavka: ");
            EndContext();
            BeginContext(366, 30, false);
#line 14 "C:\Users\Emir\Desktop\Zadatak1\Rješenje\RS1_Ispit_aspnet_core\RS1_Ispit\Views\Home\TestDB.cshtml"
             Write(Model.OdjeljenjeStavka.Count());

#line default
#line hidden
            EndContext();
            BeginContext(396, 25, true);
            WriteLiteral(" <br />\r\nPredajePredmet: ");
            EndContext();
            BeginContext(422, 28, false);
#line 15 "C:\Users\Emir\Desktop\Zadatak1\Rješenje\RS1_Ispit_aspnet_core\RS1_Ispit\Views\Home\TestDB.cshtml"
           Write(Model.PredajePredmet.Count());

#line default
#line hidden
            EndContext();
            BeginContext(450, 18, true);
            WriteLiteral(" <br />\r\nPredmet: ");
            EndContext();
            BeginContext(469, 21, false);
#line 16 "C:\Users\Emir\Desktop\Zadatak1\Rješenje\RS1_Ispit_aspnet_core\RS1_Ispit\Views\Home\TestDB.cshtml"
    Write(Model.Predmet.Count());

#line default
#line hidden
            EndContext();
            BeginContext(490, 16, true);
            WriteLiteral(" <br />\r\nSkola: ");
            EndContext();
            BeginContext(507, 19, false);
#line 17 "C:\Users\Emir\Desktop\Zadatak1\Rješenje\RS1_Ispit_aspnet_core\RS1_Ispit\Views\Home\TestDB.cshtml"
  Write(Model.Skola.Count());

#line default
#line hidden
            EndContext();
            BeginContext(526, 24, true);
            WriteLiteral(" <br />\r\nSkolskaGodina: ");
            EndContext();
            BeginContext(551, 27, false);
#line 18 "C:\Users\Emir\Desktop\Zadatak1\Rješenje\RS1_Ispit_aspnet_core\RS1_Ispit\Views\Home\TestDB.cshtml"
          Write(Model.SkolskaGodina.Count());

#line default
#line hidden
            EndContext();
            BeginContext(578, 17, true);
            WriteLiteral(" <br />\r\nUcenik: ");
            EndContext();
            BeginContext(596, 20, false);
#line 19 "C:\Users\Emir\Desktop\Zadatak1\Rješenje\RS1_Ispit_aspnet_core\RS1_Ispit\Views\Home\TestDB.cshtml"
   Write(Model.Ucenik.Count());

#line default
#line hidden
            EndContext();
            BeginContext(616, 13, true);
            WriteLiteral(" <br />\r\n\r\n\r\n");
            EndContext();
            BeginContext(630, 32, false);
#line 22 "C:\Users\Emir\Desktop\Zadatak1\Rješenje\RS1_Ispit_aspnet_core\RS1_Ispit\Views\Home\TestDB.cshtml"
Write(Html.ActionLink("Back", "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(662, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RS1_Ispit_asp.net_core.EF.MojContext> Html { get; private set; }
    }
}
#pragma warning restore 1591
