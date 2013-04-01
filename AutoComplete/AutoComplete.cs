 <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script> 
    <script type="text/javascript">
    $(function () {
        $(".td").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "AjaxMethods.asmx/GetLocations",
                    data: "{ 'prefix': '" + request.term + "' }",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return { value: item }
                        }))
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });
            },
            minLength: 2
        });
    });

</script>

using System.Web;
using System.Web.Services;
using pdiary.model;

namespace pdiary
{
    /// <summary>
    /// Summary description for AjaxMethods
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AjaxMethods : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetLocations(string prefix)
        {
            PostModel post = new PostModel();
            return post.getLocations(prefix);            
        }
    }
}
