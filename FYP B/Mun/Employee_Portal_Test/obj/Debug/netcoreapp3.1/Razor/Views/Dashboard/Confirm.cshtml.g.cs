#pragma checksum "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1663f754fbc95a078db57ca123f0a128f4cd566f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Confirm), @"mvc.1.0.view", @"/Views/Dashboard/Confirm.cshtml")]
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
#line 1 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\_ViewImports.cshtml"
using Employee_Portal_Test;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\_ViewImports.cshtml"
using Employee_Portal_Test.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1663f754fbc95a078db57ca123f0a128f4cd566f", @"/Views/Dashboard/Confirm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"448a618bb7a6144a85aecc150393387dcabe05d1", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Confirm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/scripts/confirm.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
  
    ViewBag.Title = "Confirm";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />
<br />
<div class=""alert alert-warning"" id=""previous"">
    <strong>Approve the edit</strong>
    <input type=""submit"" class=""btn btn-warning"" value=""Approve"" onclick=""Verified()"" />
</div>

<div class=""alert alert-success"" id=""after"" style=""display:none"">
    <strong><span class=""glyphicon glyphicon-ok""></span> HOD APPROVED</strong>
</div>
<div class=""alert alert-warning"" id=""previous1"">
    <strong>Reject the edit</strong>
    <input type=""submit"" class=""btn btn-warning"" value=""Reject"" onclick=""Verified1()"" />
</div>
<div class=""alert alert-success"" id=""after1"" style=""display:none"">
    <strong><span class=""glyphicon glyphicon-ok""></span> The Request is rejected </strong>
</div>


<div class=""card-body"">
    Emp No : ");
#nullable restore
#line 26 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
              foreach (var a in Model.Pmast)
    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
Write(a.Empno);

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
             ;
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    Name : ");
#nullable restore
#line 30 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
            foreach (var a in Model.Pmast)
    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
Write(a.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
            ;
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
<div class=""card-body"">
    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col""> </th>
                <th scope=""col"">Previous</th>
                <th scope=""col"">After</th>

            </tr>
        </thead>
        <tbody>
            <tr>
                <th scope=""row"">Address 1</th>
                <td>
");
#nullable restore
#line 48 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var a in Model.Pmast)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(a.Add1);

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                            ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 53 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var b in Model.PmastTemp)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(b.Add1);

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                            ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n            <tr>\r\n                <th scope=\"row\">Address 2</th>\r\n                <td>\r\n");
#nullable restore
#line 61 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var a in Model.Pmast)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(a.Add2);

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                            ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 66 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var b in Model.PmastTemp)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(b.Add2);

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                            ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n            <tr>\r\n                <th scope=\"row\">PostCode</th>\r\n                <td>\r\n");
#nullable restore
#line 74 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var a in Model.Pmast)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(a.Postcode);

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                                ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 79 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var b in Model.PmastTemp)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(b.Postcode);

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                                ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n            <tr>\r\n                <th scope=\"row\">Town</th>\r\n                <td>\r\n");
#nullable restore
#line 87 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var a in Model.Pmast)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(a.Town);

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                            ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 92 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var b in Model.PmastTemp)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(b.Town);

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                            ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n            <tr>\r\n                <th scope=\"row\">State</th>\r\n                <td>\r\n");
#nullable restore
#line 100 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var a in Model.Pmast)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 101 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(a.State);

#line default
#line hidden
#nullable disable
#nullable restore
#line 101 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                             ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 105 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var b in Model.PmastTemp)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 106 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(b.State);

#line default
#line hidden
#nullable disable
#nullable restore
#line 106 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                             ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n            <tr>\r\n                <th scope=\"row\">Phone No</th>\r\n                <td>\r\n");
#nullable restore
#line 113 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var a in Model.Pmast)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 114 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(a.Phone2);

#line default
#line hidden
#nullable disable
#nullable restore
#line 114 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                              ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 118 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var b in Model.PmastTemp)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 119 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(b.Phone2);

#line default
#line hidden
#nullable disable
#nullable restore
#line 119 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                              ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n            <tr>\r\n                <th scope=\"row\">Martial Status</th>\r\n                <td>\r\n");
#nullable restore
#line 126 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var a in Model.Pmast)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 127 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(a.Mstatus);

#line default
#line hidden
#nullable disable
#nullable restore
#line 127 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                               ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 131 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var b in Model.PmastTemp)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 132 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(b.Mstatus);

#line default
#line hidden
#nullable disable
#nullable restore
#line 132 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                               ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n            <tr>\r\n                <th scope=\"row\">Religion</th>\r\n                <td>\r\n");
#nullable restore
#line 139 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var a in Model.Pmast)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 140 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(a.Relcode);

#line default
#line hidden
#nullable disable
#nullable restore
#line 140 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                               ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 144 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var b in Model.PmastTemp)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 145 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(b.Relcode);

#line default
#line hidden
#nullable disable
#nullable restore
#line 145 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                               ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n            <tr>\r\n                <th scope=\"row\">Income Tax No</th>\r\n\r\n                <td>\r\n");
#nullable restore
#line 153 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var a in Model.Pmast)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 154 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(a.Itaxno);

#line default
#line hidden
#nullable disable
#nullable restore
#line 154 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                              ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n");
#nullable restore
#line 158 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                     foreach (var b in Model.PmastTemp)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 159 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                Write(b.Itaxno);

#line default
#line hidden
#nullable disable
#nullable restore
#line 159 "C:\Users\Mun yoo min\Documents\GitHub\FYP_A_Employee_Portal\FYP B\Mun\Employee_Portal_Test\Views\Dashboard\Confirm.cshtml"
                              ;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n\r\n        </tbody>\r\n    </table>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1663f754fbc95a078db57ca123f0a128f4cd566f22676", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"    <script>
        function Verified() {
            $.ajax({
                type: ""post"",
                url: ""/Dashboard/RegisterConfirm1"",
                data: { 'empno': '123456' },
                success: function (msg) {
                    $(""#previous"").hide();
                    $(""#after"").show();
                    alert(msg);
                }
            })
        }
    </script>
    <script>
        function Verified1() {
            $.ajax({
                type: ""post"",
                url: ""/Dashboard/RegisterConfirm_1"",
                data: { 'empno': '123456' },
                success: function (msg) {
                    $(""#previous1"").hide();
                    $(""#after1"").show();
                    alert(msg);
                }
            })
        }
    </script>
");
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
