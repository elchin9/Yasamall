#pragma checksum "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da7990831f9f57d79cf59722d45a4ba86c6653f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_ShopDetails), @"mvc.1.0.view", @"/Views/Shop/ShopDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shop/ShopDetails.cshtml", typeof(AspNetCore.Views_Shop_ShopDetails))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da7990831f9f57d79cf59722d45a4ba86c6653f8", @"/Views/Shop/ShopDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"309021642bd299ddbc47725980987baeac659b11", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_ShopDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProTags>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ProductsPartialView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
    ViewData["Title"] = "";

#line default
#line hidden
            BeginContext(58, 74, true);
            WriteLiteral("\r\n<!-- Start Cover Section -->\r\n\r\n<input type=\"hidden\" id=\"productDetails\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 132, "\"", 159, 1);
#line 9 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
WriteAttributeValue("", 140, ViewBag.TotalCount, 140, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(160, 327, true);
            WriteLiteral(@" />

<section id=""cover-image"" style=""background-attachment: fixed;"">
    <div class=""overlay-main-image""></div>
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12 col-md-6"">
                <div class=""store-property"">
                    <input type=""hidden"" name=""name"" id=""brandId""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 487, "\"", 510, 1);
#line 17 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
WriteAttributeValue("", 495, Model.Brand.Id, 495, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(511, 69, true);
            WriteLiteral(" />\r\n                    <input type=\"hidden\" name=\"name\" id=\"userId\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 580, "\"", 602, 1);
#line 18 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
WriteAttributeValue("", 588, Model.User.Id, 588, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(603, 29, true);
            WriteLiteral(" />\r\n                    <h4>");
            EndContext();
            BeginContext(633, 16, false);
#line 19 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
                   Write(Model.Brand.Name);

#line default
#line hidden
            EndContext();
            BeginContext(649, 30, true);
            WriteLiteral("</h4>\r\n                    <p>");
            EndContext();
            BeginContext(680, 22, false);
#line 20 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
                  Write(Model.Brand.Floor.Name);

#line default
#line hidden
            EndContext();
            BeginContext(702, 37, true);
            WriteLiteral(" mərtəbə</p>\r\n                    <p>");
            EndContext();
            BeginContext(740, 17, false);
#line 21 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
                  Write(Model.Brand.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(757, 75, true);
            WriteLiteral("</p>\r\n                    <div class=\"website\">\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 832, "\"", 859, 1);
#line 23 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
WriteAttributeValue("", 839, Model.Brand.Website, 839, 20, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(860, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(862, 19, false);
#line 23 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
                                                  Write(Model.Brand.Website);

#line default
#line hidden
            EndContext();
            BeginContext(881, 148, true);
            WriteLiteral("</a>\r\n                    </div>\r\n                    <ul class=\"objectSocial d-flex\">\r\n                        <li>\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1029, "\"", 1061, 1);
#line 27 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
WriteAttributeValue("", 1036, Model.Brand.FacebookLink, 1036, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1062, 195, true);
            WriteLiteral(">\r\n                                <i class=\"fab fa-facebook-f\"></i>\r\n                            </a>\r\n                        </li>\r\n                        <li>\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1257, "\"", 1290, 1);
#line 32 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
WriteAttributeValue("", 1264, Model.Brand.InstagramLink, 1264, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1291, 205, true);
            WriteLiteral(">\r\n                                <i class=\"fab fa-instagram\"></i>\r\n                            </a>\r\n                        </li>\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 39 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
             if(User.Identity.Name == Model.User.UserName)
            {

#line default
#line hidden
            BeginContext(1571, 181, true);
            WriteLiteral("            <div class=\"col-12 col-md-6\">\r\n                <div class=\"edit-pages mt-5 mt-md-0 d-flex justify-content-center justify-content-md-end flex-wrap\">\r\n                    ");
            EndContext();
            BeginContext(1752, 93, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31a0dbe974fd4b4b9566c8ecceaa3331", async() => {
                BeginContext(1804, 37, true);
                WriteLiteral("<i class=\"fal fa-edit\"></i>Düzəliş et");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 43 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
                                           WriteLiteral(Model.Brand.Id);

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
            BeginContext(1845, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(1867, 113, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b126a2e1b05041ec8505486fd00b048a", async() => {
                BeginContext(1928, 48, true);
                WriteLiteral("<i class=\"fal fa-shopping-bag\"></i> Məhsul artır");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 44 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
                                                    WriteLiteral(Model.Brand.Id);

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
            BeginContext(1980, 46, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 47 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
            }

#line default
#line hidden
            BeginContext(2041, 69, true);
            WriteLiteral("        </div>\r\n    </div>\r\n    <div class=\"profile-photo\">\r\n        ");
            EndContext();
            BeginContext(2110, 46, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d52994ee0b78432faae88bc64c85b71e", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2120, "~/img/", 2120, 6, true);
#line 51 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
AddHtmlAttributeValue("", 2126, Model.Brand.PhotoURL, 2126, 21, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2156, 269, true);
            WriteLiteral(@"
    </div>
</section>

<!-- End Cover Section -->
<!-- Start Product Section -->

<section id=""products-shop"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""store-tags d-flex flex-wrap"">
");
            EndContext();
#line 63 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
                     foreach (var t in Model.BrandTags)
                    {

#line default
#line hidden
            BeginContext(2505, 82, true);
            WriteLiteral("                        <div class=\"tag-content\">\r\n                            <p>");
            EndContext();
            BeginContext(2588, 10, false);
#line 66 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
                          Write(t.Tag.Name);

#line default
#line hidden
            EndContext();
            BeginContext(2598, 38, true);
            WriteLiteral("</p>\r\n                        </div>\r\n");
            EndContext();
#line 68 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
                    }

#line default
#line hidden
            BeginContext(2659, 60, true);
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 72 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
         if (Model.Brand.Products.Count() > 0)
        {

#line default
#line hidden
            BeginContext(2778, 63, true);
            WriteLiteral("            <div class=\"row productRow mt-5\">\r\n                ");
            EndContext();
            BeginContext(2841, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "51b3bc3cc7d1431abb1c7e765d5add67", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#line 75 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2893, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 77 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
             if (ViewBag.TotalCount > 8)
            {

#line default
#line hidden
            BeginContext(2972, 297, true);
            WriteLiteral(@"                <div class=""row mt-5"">
                    <div class=""col-12 text-center"">
                        <div class=""btn-more btn-shop-details"">
                            <a href=""#"">Daha Çox</a>
                        </div>
                    </div>
                </div>
");
            EndContext();
#line 86 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
            }

#line default
#line hidden
#line 86 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
             
        }
        else
        {

#line default
#line hidden
            BeginContext(3320, 119, true);
            WriteLiteral("            <div class=\"col-12\">\r\n                <p class=\"notFound\">Brandin məhsulu yoxdur.</p>\r\n            </div>\r\n");
            EndContext();
#line 93 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\ShopDetails.cshtml"
        }

#line default
#line hidden
            BeginContext(3450, 56, true);
            WriteLiteral("    </div>\r\n</section>\r\n\r\n<!-- End Product Section -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProTags> Html { get; private set; }
    }
}
#pragma warning restore 1591
