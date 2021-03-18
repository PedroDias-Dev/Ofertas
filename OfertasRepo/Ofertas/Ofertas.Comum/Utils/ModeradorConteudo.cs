using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Comum.Utils
{
    public class ModeradorConteudo
    {
        private static readonly string ChaveSubinscricao = "48e94274902b484db672722bbf5bff63";
        private static readonly string EndPoint = "https://content-moderator-codetur.cognitiveservices.azure.com/";

        public IList<DetectedTerms> Moderar(string texto)
        {
            ContentModeratorClient client = new ContentModeratorClient(new ApiKeyServiceClientCredentials(ChaveSubinscricao));
            client.Endpoint = EndPoint;

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(texto));

            var resultado = client.TextModeration.ScreenText("text/plain", stream);

            return resultado.Terms;
        }
    }
}
