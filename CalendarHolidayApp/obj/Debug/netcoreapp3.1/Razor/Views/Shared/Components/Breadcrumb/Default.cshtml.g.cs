#pragma checksum "C:\Users\USER\Source\Repos\CalendarHolidayApp\CalendarHolidayApp\Views\Shared\Components\Breadcrumb\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3b904c7ea41f23d952398b9d615806eb365ff9c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Breadcrumb_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Breadcrumb/Default.cshtml")]
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
#nullable restore
#line 1 "C:\Users\USER\Source\Repos\CalendarHolidayApp\CalendarHolidayApp\Views\_ViewImports.cshtml"
using CalendarHolidayApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\USER\Source\Repos\CalendarHolidayApp\CalendarHolidayApp\Views\_ViewImports.cshtml"
using CalendarHolidayApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3b904c7ea41f23d952398b9d615806eb365ff9c", @"/Views/Shared/Components/Breadcrumb/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a112ce67706a76917b42e0f0b2a2922cd0afa197", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Breadcrumb_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\USER\Source\Repos\CalendarHolidayApp\CalendarHolidayApp\Views\Shared\Components\Breadcrumb\Default.cshtml"
 foreach (var item in ViewBag.BreadcrumbDetail)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li><a");
            BeginWriteAttribute("href", " href=\"", 60, "\"", 76, 1);
#nullable restore
#line 3 "C:\Users\USER\Source\Repos\CalendarHolidayApp\CalendarHolidayApp\Views\Shared\Components\Breadcrumb\Default.cshtml"
WriteAttributeValue("", 67, item.Uri, 67, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"font-size:13px;\"> ");
#nullable restore
#line 3 "C:\Users\USER\Source\Repos\CalendarHolidayApp\CalendarHolidayApp\Views\Shared\Components\Breadcrumb\Default.cshtml"
                                                Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\n");
#nullable restore
#line 4 "C:\Users\USER\Source\Repos\CalendarHolidayApp\CalendarHolidayApp\Views\Shared\Components\Breadcrumb\Default.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
