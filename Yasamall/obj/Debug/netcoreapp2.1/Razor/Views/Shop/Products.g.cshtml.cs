#pragma checksum "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c40012e20c8db4776228122a6fbfc306ecf3b891"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Products), @"mvc.1.0.view", @"/Views/Shop/Products.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shop/Products.cshtml", typeof(AspNetCore.Views_Shop_Products))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c40012e20c8db4776228122a6fbfc306ecf3b891", @"/Views/Shop/Products.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"309021642bd299ddbc47725980987baeac659b11", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_Products : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShopDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
    ViewData["Title"] = "Products";

#line default
#line hidden
            BeginContext(76, 275, true);
            WriteLiteral(@"


<!-- Start One Product Section -->

<section id=""oneProduct"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12 col-lg-1"">
                <div class=""product-slider-images"">
                    <ul class=""d-flex d-lg-block"">
");
            EndContext();
#line 17 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                         foreach (var p in Model.Product.Photos)
                        {
                            if (p.IsMain)
                            {

#line default
#line hidden
            BeginContext(518, 64, true);
            WriteLiteral("                                <li class=\"hover-slider-active\">");
            EndContext();
            BeginContext(582, 36, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2de041a3a027446aaa9b3ca6dc2eed5b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 592, "~/img/", 592, 6, true);
#line 21 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
AddHtmlAttributeValue("", 598, p.PhotoURL, 598, 11, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(618, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 22 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"

                            }
                            else
                            {

#line default
#line hidden
            BeginContext(723, 36, true);
            WriteLiteral("                                <li>");
            EndContext();
            BeginContext(759, 36, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1a096b93b9114199a0f5d300bac60a31", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 769, "~/img/", 769, 6, true);
#line 26 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
AddHtmlAttributeValue("", 775, p.PhotoURL, 775, 11, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(795, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 27 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                            }
                        }

#line default
#line hidden
            BeginContext(860, 175, true);
            WriteLiteral("                    </ul>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-12 col-lg-6\">\r\n                <div class=\"one-image\">\r\n                    ");
            EndContext();
            BeginContext(1035, 93, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "edd6932add3c42d0b8dd1d3197c3b329", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1045, "~/img/", 1045, 6, true);
#line 34 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
AddHtmlAttributeValue("", 1051, Model.Product.Photos.FirstOrDefault(p => p.IsMain == true).PhotoURL, 1051, 68, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1128, 162, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"col-12 col-lg-5\">\r\n                <div class=\"main-product-info\">\r\n                    <h4>");
            EndContext();
            BeginContext(1291, 25, false);
#line 39 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                   Write(Model.Product.Brands.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1316, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(1320, 18, false);
#line 39 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                                                Write(Model.Product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1338, 56, true);
            WriteLiteral("</h4>\r\n                    <p>\r\n                        ");
            EndContext();
            BeginContext(1395, 18, false);
#line 41 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                   Write(Model.Product.Info);

#line default
#line hidden
            EndContext();
            BeginContext(1413, 189, true);
            WriteLiteral("\r\n                    </p>\r\n                </div>\r\n                <div class=\"main-product-color\">\r\n                    <p>Rənglər :</p>\r\n                    <div class=\"colors d-flex\">\r\n");
            EndContext();
#line 47 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                         foreach (var c in Model.ProColors)
                        {

#line default
#line hidden
            BeginContext(1690, 32, true);
            WriteLiteral("                            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1722, "\"", 1758, 2);
#line 49 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
WriteAttributeValue("", 1730, c.Color.ColorCode, 1730, 18, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1748, "color-all", 1749, 10, true);
            EndWriteAttribute();
            BeginContext(1759, 9, true);
            WriteLiteral("></div>\r\n");
            EndContext();
#line 50 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                        }

#line default
#line hidden
            BeginContext(1795, 184, true);
            WriteLiteral("                    </div>\r\n                </div>\r\n                <div class=\"main-product-size\">\r\n                    <p>Ölçü :</p>\r\n                    <div class=\"sizes d-flex\">\r\n");
            EndContext();
#line 56 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                         foreach (var s in Model.ProSizes)
                        {

#line default
#line hidden
            BeginContext(2066, 50, true);
            WriteLiteral("                            <div class=\"size-all\">");
            EndContext();
            BeginContext(2117, 11, false);
#line 58 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                                             Write(s.Size.Size);

#line default
#line hidden
            EndContext();
            BeginContext(2128, 8, true);
            WriteLiteral("</div>\r\n");
            EndContext();
#line 59 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                        }

#line default
#line hidden
            BeginContext(2163, 128, true);
            WriteLiteral("                    </div>\r\n                </div>\r\n                <div class=\"main-product-price\">\r\n                    <span>");
            EndContext();
            BeginContext(2292, 19, false);
#line 63 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                     Write(Model.Product.Price);

#line default
#line hidden
            EndContext();
            BeginContext(2311, 514, true);
            WriteLiteral(@"</span>
                </div>
            </div>
        </div>
    </div>
</section>

<!-- End One Product Section -->
<!-- Start Products Section -->

<section id=""products-details"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""store-tags d-flex align-items-center justify-content-between flex-wrap"">
                    <h4>Brendin digər məhsulları :</h4>
                    <div class=""btn-more"">
                        ");
            EndContext();
            BeginContext(2825, 102, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb8a5cce469e4c14b776075107e00490", async() => {
                BeginContext(2915, 8, true);
                WriteLiteral("Daha Çox");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 80 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                                                                            WriteLiteral(Model.Product.Brands.Id);

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
            BeginContext(2927, 122, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"row mt-5\">\r\n");
            EndContext();
#line 86 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
             foreach (var p in Model.AllProduct)
            {

#line default
#line hidden
            BeginContext(3114, 77, true);
            WriteLiteral("            <div class=\"col-12 col-sm-6 col-md-4 col-lg-3\">\r\n                ");
            EndContext();
            BeginContext(3191, 559, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5996f0ab32e34f9b8f99de283fbf26ea", async() => {
                BeginContext(3259, 144, true);
                WriteLiteral("\r\n                    <div class=\"product-shop-content\">\r\n                        <div class=\"product-shop-image\">\r\n                            ");
                EndContext();
                BeginContext(3403, 83, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "7891fa10d70749d78f329e5c32115717", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 3413, "~/img/", 3413, 6, true);
#line 92 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
AddHtmlAttributeValue("", 3419, p.Photos.FirstOrDefault(pr => pr.IsMain == true).PhotoURL, 3419, 58, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3486, 123, true);
                WriteLiteral("\r\n                        </div>\r\n                        <div class=\"product-shop-info\">\r\n                            <h5>");
                EndContext();
                BeginContext(3610, 6, false);
#line 95 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                           Write(p.Name);

#line default
#line hidden
                EndContext();
                BeginContext(3616, 39, true);
                WriteLiteral("</h5>\r\n                            <p>$");
                EndContext();
                BeginContext(3656, 7, false);
#line 96 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                           Write(p.Price);

#line default
#line hidden
                EndContext();
                BeginContext(3663, 83, true);
                WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n                 ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 89 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
                                                                 WriteLiteral(p.Id);

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
            BeginContext(3750, 22, true);
            WriteLiteral("\r\n            </div>\r\n");
            EndContext();
#line 101 "C:\Users\user\source\repos\Yasamall\Yasamall\Views\Shop\Products.cshtml"
            }

#line default
#line hidden
            BeginContext(3787, 72, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</section>\r\n\r\n<!-- End Product Section -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
