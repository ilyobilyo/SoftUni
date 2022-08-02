using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Responses
{
    public class ViewResponse : ContentResponse
    {
        private const char PathSeparator = '/';

        public ViewResponse(string viewName, string controllerName, object model = null)
            : base(string.Empty, ContentType.Html)
        {
            if (!viewName.Contains(PathSeparator))
            {
                viewName = controllerName + PathSeparator + viewName;

                var viewPath = Path.GetFullPath($"./Views/" + viewName.TrimStart(PathSeparator) + ".cshtml");

                var viewContent = File.ReadAllText(viewPath);

                if (model != null)
                {
                    viewContent = this.PopulateModel(viewContent, model);
                }

                this.Body = viewContent;
            }

        }

        private string PopulateModel(string viewContent, object model)
        {
            var data = model.GetType()
                .GetProperties()
                .Select(x => new
                {
                    x.Name,
                    Value = x.GetValue(model)
                });

            foreach (var item in data)
            {
                const string oppeningBrackets = "{{";
                const string closingBrackets = "}}";

                viewContent = viewContent.Replace($"{oppeningBrackets}{item.Name}{closingBrackets}", item.Value.ToString());
            }

            return viewContent;
        }
    }
}
