#pragma checksum "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shared\_RestaurantPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3cb865478a219806152d1d8704c49d996a8a19d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__RestaurantPartialView), @"mvc.1.0.view", @"/Views/Shared/_RestaurantPartialView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_RestaurantPartialView.cshtml", typeof(AspNetCore.Views_Shared__RestaurantPartialView))]
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
#line 1 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\_ViewImports.cshtml"
using Yasamall;

#line default
#line hidden
#line 2 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\_ViewImports.cshtml"
using Yasamall.Models;

#line default
#line hidden
#line 4 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\_ViewImports.cshtml"
using Yasamall.ViewModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3cb865478a219806152d1d8704c49d996a8a19d6", @"/Views/Shared/_RestaurantPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"309021642bd299ddbc47725980987baeac659b11", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__RestaurantPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Brands>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Restaurant", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RestaurantDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shared\_RestaurantPartialView.cshtml"
    Layout = null;

#line default
#line hidden
            BeginContext(61, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shared\_RestaurantPartialView.cshtml"
 foreach (var b in Model)
{

#line default
#line hidden
            BeginContext(93, 80, true);
            WriteLiteral("    <div class=\"col-12 col-sm-6 col-md-4 col-lg-3\" data-aos=\"zoom-in\">\r\n        ");
            EndContext();
            BeginContext(173, 482, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c36220252d3d492ea0ee9969c9311fd1", async() => {
                BeginContext(256, 117, true);
                WriteLiteral("\r\n            <div class=\"restaurant-content\">\r\n                <div class=\"content-image\">\r\n                    <img");
                EndContext();
                BeginWriteAttribute("src", " src=\"", 373, "\"", 394, 2);
                WriteAttributeValue("", 379, "img/", 379, 4, true);
#line 13 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shared\_RestaurantPartialView.cshtml"
WriteAttributeValue("", 383, b.PhotoURL, 383, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(395, 102, true);
                WriteLiteral(" alt=\"\">\r\n                </div>\r\n                <div class=\"content-info\">\r\n                    <h4>");
                EndContext();
                BeginContext(498, 6, false);
#line 16 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shared\_RestaurantPartialView.cshtml"
                   Write(b.Name);

#line default
#line hidden
                EndContext();
                BeginContext(504, 30, true);
                WriteLiteral("</h4>\r\n                    <p>");
                EndContext();
                BeginContext(535, 12, false);
#line 17 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shared\_RestaurantPartialView.cshtml"
                  Write(b.Floor.Name);

#line default
#line hidden
                EndContext();
                BeginContext(547, 38, true);
                WriteLiteral("  mərtəbə</p>\r\n                    <p>");
                EndContext();
                BeginContext(586, 7, false);
#line 18 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shared\_RestaurantPartialView.cshtml"
                  Write(b.Phone);

#line default
#line hidden
                EndContext();
                BeginContext(593, 58, true);
                WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 10 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shared\_RestaurantPartialView.cshtml"
                                                                        WriteLiteral(b.Id);

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
            BeginContext(655, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
#line 23 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shared\_RestaurantPartialView.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Brands>> Html { get; private set; }
    }
}
#pragma warning restore 1591