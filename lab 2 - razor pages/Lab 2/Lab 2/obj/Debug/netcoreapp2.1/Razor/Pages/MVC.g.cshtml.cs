#pragma checksum "C:\sandbox\Web-Database-Spring-2020\lab 2 - razor pages\Lab 2\Lab 2\Pages\MVC.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9e2a2021c3fb8058cf31a68db03854435726cb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RazorPageDemo.Pages.Pages_MVC), @"mvc.1.0.razor-page", @"/Pages/MVC.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/MVC.cshtml", typeof(RazorPageDemo.Pages.Pages_MVC), null)]
namespace RazorPageDemo.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\sandbox\Web-Database-Spring-2020\lab 2 - razor pages\Lab 2\Lab 2\Pages\_ViewImports.cshtml"
using RazorPageDemo;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9e2a2021c3fb8058cf31a68db03854435726cb8", @"/Pages/MVC.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d995c6663349f4b5695f5ad1087c2b572ddb9ce", @"/Pages/_ViewImports.cshtml")]
    public class Pages_MVC : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\sandbox\Web-Database-Spring-2020\lab 2 - razor pages\Lab 2\Lab 2\Pages\MVC.cshtml"
  
    ViewData["Title"] = "MVC";
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(130, 36, true);
            WriteLiteral("        <h2 class=\"col-lg-offset-2\">");
            EndContext();
            BeginContext(167, 13, false);
#line 7 "C:\sandbox\Web-Database-Spring-2020\lab 2 - razor pages\Lab 2\Lab 2\Pages\MVC.cshtml"
                               Write(Model.Message);

#line default
#line hidden
            EndContext();
            BeginContext(180, 36, true);
            WriteLiteral("</h2>\r\n        <h3 class=\"col-lg-2\">");
            EndContext();
            BeginContext(217, 17, false);
#line 8 "C:\sandbox\Web-Database-Spring-2020\lab 2 - razor pages\Lab 2\Lab 2\Pages\MVC.cshtml"
                        Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(234, 857, true);
            WriteLiteral(@"</h3>
        <div class=""col-lg-8"">
            <p>
                This programming model splits the project into three different layers.
                <br>The <b>Model</b>      - Business Layer
                <br>The <b>View</b>       - Display Layer
                <br>The <b>Controller</b> - Input Control<br>
                This allows multiple teams to work on the same project without too much interference because the code is separated.  Designers can work on the front end and developers can work on the back-end.  This model also gives much more control over the behavior of the project by giving the user direct control over much of the front end development that the Web Form model automates.  This model works well with larger and complex projects and supports unit testing among other features.
            </p>
        </div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RazorPageDemo.Pages.MVCModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorPageDemo.Pages.MVCModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorPageDemo.Pages.MVCModel>)PageContext?.ViewData;
        public RazorPageDemo.Pages.MVCModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
