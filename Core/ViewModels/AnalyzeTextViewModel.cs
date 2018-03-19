using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using maximst.CognitiveDemo.Core.Consts;
using maximst.CognitiveDemo.Core.Models;
using maximst.CognitiveDemo.Core.ViewModels.Base;
using MugenMvvmToolkit.Models;
using Newtonsoft.Json;

namespace maximst.CognitiveDemo.Core.ViewModels
{
    public class AnalyzeTextViewModel: BaseViewModel
    {
        public string InputText { get; set; }

        public ICommand LanguageCommand
        {
            get { return new RelayCommand(async () =>
            {
                Dialogs.ShowLoading();
                var model = await GetTextResult(Api.UriBaseTextLanguageApi);
                Dialogs.HideLoading();
                Dialogs.Alert(JsonPrettyPrint(model));
            }); }
        }

        public ICommand KeyPhrasesCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    Dialogs.ShowLoading();
                    var model = await GetTextResult(Api.UriBaseTextKeyPhrasesApi);
                    Dialogs.HideLoading();
                    Dialogs.Alert(JsonPrettyPrint(model));
                });
            }
        }

        public ICommand SentimentCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    Dialogs.ShowLoading();
                    var model = await GetTextResult(Api.UriBaseTextSentimentApi);
                    Dialogs.HideLoading();
                    Dialogs.Alert(JsonPrettyPrint(model));
                });
            }
        }

        private async Task<string> GetTextResult(string baseUrl)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var queryString = HttpUtility.ParseQueryString(string.Empty);

                    // Request headers
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Api.KeyTextApi);

                    // Request parameters

                    var uri = baseUrl + queryString;

                    HttpResponseMessage response;

                    var body = new Document
                    {
                        Id = Guid.NewGuid().ToString(),
                        Text = InputText
                    };
                    var list = new Documents();
                   list.DocumentsList.Add(body);
                    // Request body
                    byte[] byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(list));

                    using (var content = new ByteArrayContent(byteData))
                    {
                        content.Headers.ContentType =
                            new MediaTypeHeaderValue("application/json");
                        response = await client.PostAsync(uri, content);
                        return  await response.Content.ReadAsStringAsync();
                    }

                }
            }
        
            catch (Exception e)
            {
                Dialogs.Toast(e.Message);
                return null;
            }

        }


        string JsonPrettyPrint(string json)
        {
            if (string.IsNullOrEmpty(json))
                return string.Empty;

            json = json.Replace(Environment.NewLine, "").Replace("\t", "");

            StringBuilder sb = new StringBuilder();
            bool quote = false;
            bool ignore = false;
            int offset = 0;
            int indentLength = 3;

            foreach (char ch in json)
            {
                switch (ch)
                {
                    case '"':
                        if (!ignore) quote = !quote;
                        break;
                    case '\'':
                        if (quote) ignore = !ignore;
                        break;
                }

                if (quote)
                    sb.Append(ch);
                else
                {
                    switch (ch)
                    {
                        case '{':
                        case '[':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', ++offset * indentLength));
                            break;
                        case '}':
                        case ']':
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', --offset * indentLength));
                            sb.Append(ch);
                            break;
                        case ',':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', offset * indentLength));
                            break;
                        case ':':
                            sb.Append(ch);
                            sb.Append(' ');
                            break;
                        default:
                            if (ch != ' ') sb.Append(ch);
                            break;
                    }
                }
            }

            return sb.ToString().Trim();
        }

    }
}