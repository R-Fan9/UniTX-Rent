#pragma checksum "C:\Users\R. Fan\Source\Repos\UniTX - Rent\UniTX - Rent\Views\Renter\Join.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c15ead91b256882836106197e3fbe97ade24fb34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Renter_Join), @"mvc.1.0.view", @"/Views/Renter/Join.cshtml")]
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
#line 1 "C:\Users\R. Fan\Source\Repos\UniTX - Rent\UniTX - Rent\Views\_ViewImports.cshtml"
using UniTX___Rent;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\R. Fan\Source\Repos\UniTX - Rent\UniTX - Rent\Views\_ViewImports.cshtml"
using UniTX___Rent.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c15ead91b256882836106197e3fbe97ade24fb34", @"/Views/Renter/Join.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90a0340202deafda563b4ff63ec1ffac445466be", @"/Views/_ViewImports.cshtml")]
    public class Views_Renter_Join : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UniTX___Rent.Models.JoinModel.JoinModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <div class=""container"">
        <div class=""header clearfix"">
            <h2 class=""text-muted"">Join</h2>
        </div>

        <div class=""jumbotron"">
            <div class=""row"">

                <div class=""col col-sm-12 col-lg-6 mt-5"">
");
#nullable restore
#line 12 "C:\Users\R. Fan\Source\Repos\UniTX - Rent\UniTX - Rent\Views\Renter\Join.cshtml"
                     using (Html.BeginForm("PlaceJoin", "Renter", FormMethod.Post))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"input-field\">\r\n                            ");
#nullable restore
#line 15 "C:\Users\R. Fan\Source\Repos\UniTX - Rent\UniTX - Rent\Views\Renter\Join.cshtml"
                       Write(Html.TextBoxFor(a => a.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <label class=\"active\" for=\"FirstName\">FirstName</label>\r\n                        </div>\r\n                        <div class=\"input-field\">\r\n                            ");
#nullable restore
#line 19 "C:\Users\R. Fan\Source\Repos\UniTX - Rent\UniTX - Rent\Views\Renter\Join.cshtml"
                       Write(Html.TextBoxFor(a => a.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <label class=\"active\" for=\"LastName\">LastName</label>\r\n                        </div>\r\n                        <div class=\"input-field\">\r\n                            ");
#nullable restore
#line 23 "C:\Users\R. Fan\Source\Repos\UniTX - Rent\UniTX - Rent\Views\Renter\Join.cshtml"
                       Write(Html.TextBoxFor(a => a.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <label class=\"active\" for=\"Email\">Email</label>\r\n                        </div>\r\n                        <div class=\"input-field\">\r\n                            ");
#nullable restore
#line 27 "C:\Users\R. Fan\Source\Repos\UniTX - Rent\UniTX - Rent\Views\Renter\Join.cshtml"
                       Write(Html.TextBoxFor(a => a.Telephone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <label class=\"active\" for=\"Telephone\">Telephone</label>\r\n                        </div>\r\n                        <div class=\"input-field\">\r\n                            ");
#nullable restore
#line 31 "C:\Users\R. Fan\Source\Repos\UniTX - Rent\UniTX - Rent\Views\Renter\Join.cshtml"
                       Write(Html.TextBoxFor(a => a.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <label class=\"active\" for=\"Address\">Address</label>\r\n                        </div>\r\n                        <div class=\"input-field\">\r\n                            ");
#nullable restore
#line 35 "C:\Users\R. Fan\Source\Repos\UniTX - Rent\UniTX - Rent\Views\Renter\Join.cshtml"
                       Write(Html.TextBoxFor(a => a.CardID));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            <label class=""active"" for=""CardID"">CardID</label>
                        </div>
                        <div>
                            <button type=""submit"" class=""waves-effect waves-light btn teal darken-3""><p class=""white-text"">Sign On</p></button>
                        </div>
");
#nullable restore
#line 41 "C:\Users\R. Fan\Source\Repos\UniTX - Rent\UniTX - Rent\Views\Renter\Join.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UniTX___Rent.Models.JoinModel.JoinModel> Html { get; private set; }
    }
}
#pragma warning restore 1591