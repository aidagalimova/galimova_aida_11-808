#pragma checksum "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "461a6a1e530a4ca58fbf4b11c3985f9d4dcde4c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Posts_Index), @"mvc.1.0.view", @"/Views/Posts/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Posts/Index.cshtml", typeof(AspNetCore.Views_Posts_Index))]
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
#line 1 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\_ViewImports.cshtml"
using MVCProject2;

#line default
#line hidden
#line 2 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\_ViewImports.cshtml"
using MVCProject2.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"461a6a1e530a4ca58fbf4b11c3985f9d4dcde4c3", @"/Views/Posts/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c88ac8146ee60dd602760e9c86a40430821a7ef", @"/Views/_ViewImports.cshtml")]
    public class Views_Posts_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MVCProject2.Models.Post>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(86, 18, true);
            WriteLiteral("<h2>Posts</h2>\r\n\r\n");
            EndContext();
#line 7 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
            BeginContext(137, 23, true);
            WriteLiteral("    <div>\r\n        <h2>");
            EndContext();
            BeginContext(161, 43, false);
#line 10 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.PostName));

#line default
#line hidden
            EndContext();
            BeginContext(204, 21, true);
            WriteLiteral("</h2>\r\n        <br>\r\n");
            EndContext();
#line 12 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
         if(item.Text != "")
        {
        

#line default
#line hidden
            BeginContext(275, 39, false);
#line 14 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
   Write(Html.DisplayFor(modelItem => item.Text));

#line default
#line hidden
            EndContext();
            BeginContext(316, 14, true);
            WriteLiteral("        <br>\r\n");
            EndContext();
#line 16 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(341, 8, true);
            WriteLiteral("        ");
            EndContext();
#line 17 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
         if(item.FileName != "")
        {

#line default
#line hidden
            BeginContext(386, 12, true);
            WriteLiteral("        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 398, "\"", 443, 1);
#line 19 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
WriteAttributeValue("", 404, Url.Content("/Files/" + item.FileName), 404, 39, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(444, 32, true);
            WriteLiteral(" alt=\"IMAGES\" />\r\n        <br>\r\n");
            EndContext();
#line 21 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(487, 33, true);
            WriteLiteral("        <h5>Author</h5>\r\n        ");
            EndContext();
            BeginContext(521, 48, false);
#line 23 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
   Write(Html.DisplayFor(modelItem => item.User.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(569, 47, true);
            WriteLiteral("\r\n        <br>\r\n        <h5>Date</h5>\r\n        ");
            EndContext();
            BeginContext(617, 46, false);
#line 26 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
   Write(Html.DisplayFor(modelItem => item.CurrentTime));

#line default
#line hidden
            EndContext();
            BeginContext(663, 16, true);
            WriteLiteral("\r\n        <br>\r\n");
            EndContext();
#line 28 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
         if(item.EditingTime != DateTime.MinValue)
        {

#line default
#line hidden
            BeginContext(742, 28, true);
            WriteLiteral("        <h6>Edit Date</h6>\r\n");
            EndContext();
            BeginContext(779, 46, false);
#line 31 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
   Write(Html.DisplayFor(modelItem => item.EditingTime));

#line default
#line hidden
            EndContext();
            BeginContext(827, 16, true);
            WriteLiteral("        <br />\r\n");
            EndContext();
#line 33 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(854, 10, true);
            WriteLiteral("        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 864, "\"", 925, 2);
            WriteAttributeValue("", 871, "/Posts/Edit/", 871, 12, true);
#line 34 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
WriteAttributeValue("", 883, Html.DisplayFor(modelItem => item.PostId), 883, 42, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(926, 42, true);
            WriteLiteral(">Edit Post</a>\r\n        <br />\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 968, "\"", 1031, 2);
            WriteAttributeValue("", 975, "/Posts/Delete/", 975, 14, true);
#line 36 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
WriteAttributeValue("", 989, Html.DisplayFor(modelItem => item.PostId), 989, 42, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1032, 67, true);
            WriteLiteral(">Delete Post</a>\r\n        <hr>\r\n    </div>\r\n    <h4>Comments</h4>\r\n");
            EndContext();
#line 40 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
     if (item.Comment != null)
    {
        

#line default
#line hidden
#line 42 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
         foreach (var comment in item.Comment)
        {
            

#line default
#line hidden
            BeginContext(1210, 49, false);
#line 44 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
       Write(Html.DisplayFor(modelItem => comment.CommentText));

#line default
#line hidden
            EndContext();
#line 44 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
                                                              ;

#line default
#line hidden
            BeginContext(1262, 47, true);
            WriteLiteral("            <br>\r\n            <h5>Author</h5>\r\n");
            EndContext();
            BeginContext(1322, 51, false);
#line 47 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
       Write(Html.DisplayFor(modelItem => comment.User.UserName));

#line default
#line hidden
            EndContext();
#line 47 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
                                                                ;

#line default
#line hidden
            BeginContext(1376, 45, true);
            WriteLiteral("            <br>\r\n            <h5>Date</h5>\r\n");
            EndContext();
            BeginContext(1434, 49, false);
#line 50 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
       Write(Html.DisplayFor(modelItem => comment.CurrentTime));

#line default
#line hidden
            EndContext();
#line 50 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
                                                              ;

#line default
#line hidden
            BeginContext(1486, 18, true);
            WriteLiteral("            <br>\r\n");
            EndContext();
#line 52 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
             if ((DateTime.Now - comment.CurrentTime).TotalMinutes < 15)
            {

#line default
#line hidden
            BeginContext(1593, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1611, "\"", 1681, 2);
            WriteAttributeValue("", 1618, "/Comments/Edit/", 1618, 15, true);
#line 54 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
WriteAttributeValue("", 1633, Html.DisplayFor(modelItem => comment.CommentId), 1633, 48, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1682, 19, true);
            WriteLiteral(">Edit comment</a>\r\n");
            EndContext();
#line 55 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1716, 32, true);
            WriteLiteral("            <br>\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1748, "\"", 1820, 2);
            WriteAttributeValue("", 1755, "/Comments/Delete/", 1755, 17, true);
#line 57 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
WriteAttributeValue("", 1772, Html.DisplayFor(modelItem => comment.CommentId), 1772, 48, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1821, 39, true);
            WriteLiteral(">Delete comment</a>\r\n            <hr>\r\n");
            EndContext();
#line 59 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
        }

#line default
#line hidden
#line 59 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
         
    }

#line default
#line hidden
            BeginContext(1878, 6, true);
            WriteLiteral("    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1884, "\"", 1957, 2);
            WriteAttributeValue("", 1891, "/Comments/Create?PostId=", 1891, 24, true);
#line 61 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
WriteAttributeValue("", 1915, Html.DisplayFor(modelItem => item.PostId), 1915, 42, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1958, 18, true);
            WriteLiteral(">Add comment</a>\r\n");
            EndContext();
#line 62 "C:\Users\Аида\source\repos\MVCProject2\MVCProject2\Views\Posts\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1979, 47, true);
            WriteLiteral("<br>\r\n<a href=\"/Posts/Create\">Add Posts</a>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MVCProject2.Models.Post>> Html { get; private set; }
    }
}
#pragma warning restore 1591
