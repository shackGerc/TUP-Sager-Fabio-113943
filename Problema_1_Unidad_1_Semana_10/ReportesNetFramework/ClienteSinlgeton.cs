using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReportesNetFramework
{
    internal class ClienteSingleton
    {
        private static ClienteSingleton instancia;
        private HttpClient cliente;

        private ClienteSingleton()
        {
            cliente = new HttpClient();
        }

        public static ClienteSingleton ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new ClienteSingleton();
            }
            return instancia;
        }

        public async Task<String> GetAsync(string url)
        {
            var result = await cliente.GetAsync(url);
            var content = "";

            if (result.IsSuccessStatusCode)
            {
                content = await result.Content.ReadAsStringAsync();
            }
            return content;
        }

    }
}
