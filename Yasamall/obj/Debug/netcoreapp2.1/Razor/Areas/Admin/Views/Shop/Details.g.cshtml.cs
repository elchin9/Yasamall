#pragma checksum "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\Shop\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fc1394fe214dc2143d4e48ab93e9ec9bd4dec6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shop_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/Shop/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Shop/Details.cshtml", typeof(AspNetCore.Areas_Admin_Views_Shop_Details))]
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
#line 2 "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\_ViewImports.cshtml"
using Yasamall.Models;

#line default
#line hidden
#line 3 "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\_ViewImports.cshtml"
using Yasamall.ViewModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fc1394fe214dc2143d4e48ab93e9ec9bd4dec6a", @"/Areas/Admin/Views/Shop/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4032012f45eb513df75691a0ecfc0ed3978695ef", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shop_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Brands>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("product-admin-panel"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger mt-5"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\Shop\Details.cshtml"
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(64, 419, true);
            WriteLiteral(@"
<div class=""page-container"">
    <div class=""main-content"">
        <div class=""section__content section__content--p30"">
            <div class=""container-fluid"">
                <section class=""wrapper"" style=""padding-bottom:50px;"">
                    <div class=""row"">
                        <div class=""col-12 col-md-6"">
                            <div class=""nd-image"">
                                ");
            EndContext();
            BeginContext(483, 35, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5c8b713da9f44db885372f66003c8c9c", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 493, "~/img/", 493, 6, true);
#line 15 "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\Shop\Details.cshtml"
AddHtmlAttributeValue("", 499, Model.PhotoURL, 499, 15, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(518, 157, true);
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-12 col-md-6\">\r\n                            <h3>");
            EndContext();
            BeginContext(676, 10, false);
#line 19 "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\Shop\Details.cshtml"
                           Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(686, 51, true);
            WriteLiteral("</h3>\r\n                            <p class=\"mt-3\">");
            EndContext();
            BeginContext(738, 11, false);
#line 20 "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\Shop\Details.cshtml"
                                       Write(Model.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(749, 37, true);
            WriteLiteral("</p>\r\n                            <p>");
            EndContext();
            BeginContext(787, 16, false);
#line 21 "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\Shop\Details.cshtml"
                          Write(Model.Floor.Name);

#line default
#line hidden
            EndContext();
            BeginContext(803, 57, true);
            WriteLiteral(" mərtəbə</p>\r\n                            <a class=\"mt-3\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 860, "\"", 887, 1);
#line 22 "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\Shop\Details.cshtml"
WriteAttributeValue("", 867, Model.InstagramLink, 867, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(888, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(890, 19, false);
#line 22 "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\Shop\Details.cshtml"
                                                                   Write(Model.InstagramLink);

#line default
#line hidden
            EndContext();
            BeginContext(909, 36, true);
            WriteLiteral("</a>\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 945, "\"", 971, 1);
#line 23 "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\Shop\Details.cshtml"
WriteAttributeValue("", 952, Model.FacebookLink, 952, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(972, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(974, 18, false);
#line 23 "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\Shop\Details.cshtml"
                                                     Write(Model.FacebookLink);

#line default
#line hidden
            EndContext();
            BeginContext(992, 36, true);
            WriteLiteral("</a>\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1028, "\"", 1049, 1);
#line 24 "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\Shop\Details.cshtml"
WriteAttributeValue("", 1035, Model.Website, 1035, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1050, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1052, 13, false);
#line 24 "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\Shop\Details.cshtml"
                                                Write(Model.Website);

#line default
#line hidden
            EndContext();
            BeginContext(1065, 73, true);
            WriteLiteral("</a>\r\n                            <div>\r\n                                ");
            EndContext();
            BeginContext(1138, 118, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7855fd09094f48f880654b29a9970d63", async() => {
                BeginContext(1238, 14, true);
                WriteLiteral("Məhsullara bax");
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
#line 26 "C:\Users\user\source\repos\Yasamall\Yasamall\Areas\Admin\Views\Shop\Details.cshtml"
                                                                                 WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1256, 255, true);
            WriteLiteral("\r\n                            </div>\r\n                            \r\n                        </div>\r\n                    </div>\r\n\r\n                    <div class=\"row\">\r\n                        <div class=\"col-12 text-center\">\r\n                            ");
            EndContext();
            BeginContext(1511, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6cc1dbdb0aa848cfa1aa545a8eb55fb2", async() => {
                BeginContext(1561, 20, true);
                WriteLiteral("Əsas səhifəyə qayıt.");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1585, 148, true);
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </section>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Brands> Html { get; private set; }
    }
}
#pragma warning restore 1591
