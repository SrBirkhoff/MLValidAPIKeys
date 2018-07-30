using System;
using System.Net;
using System.IO;


namespace MLValidateAPIKeys
{
    class Validacao
    {
        static void Main(string[] args)
        {
            // comment here
            String idMercadoLivre;
            String secretKeyMercadoLivre;

            var UserKeys = InputUserData(); // Get user Keys to validate
            idMercadoLivre = UserKeys.Item1;
            secretKeyMercadoLivre = UserKeys.Item2;

            // comment to here
            ValidateAPIKeys(idMercadoLivre, secretKeyMercadoLivre);

        }

        private static bool ValidateAPIKeys(string idMercadoLivre, string secretKeyMercadoLivre)
        {
            int RequestCode = MercadoLivreGetSessionStatus(idMercadoLivre, secretKeyMercadoLivre); // tries to get a Mercado Livre Access token

            int retorno = requestsStatusChecker(RequestCode);

            if (retorno == 1 || retorno == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //comment here
        private static Tuple<string, string> InputUserData()
        {
            String idMercadoLivre;
            String secretKeyMercadoLivre;

            Console.WriteLine("Olá Lojista, bem vindo a 2BHub!");
            Console.WriteLine("Para começarmos, informe suas chaves de acesso no Mercado Livre.");

            Console.WriteLine();
            Console.Write("Id Mercado Livre: ");
            idMercadoLivre = Console.ReadLine();


            Console.Write("Secret Key Mercado Livre: ");
            secretKeyMercadoLivre = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("*----------------------------------*");

            Console.WriteLine("id: " + idMercadoLivre);
            Console.WriteLine("Secret: " + secretKeyMercadoLivre);

            Console.WriteLine("*----------------------------------*");
            Console.WriteLine("");


            return new Tuple<String, String>(idMercadoLivre, secretKeyMercadoLivre);
        }// comment to here


        private static int requestsStatusChecker(int RequestCode)
        {
            if (RequestCode == 200) // verify the HTTP code
            {
                return 1;
            }
            else if (RequestCode == 400)
            {
                return 0;
            }
            else
            {
                return 5;
            }

        }

        private static int MercadoLivreGetSessionStatus(string idMercadoLivre, string secretKeyMercadoLivre)
        {

            var webRequest = WebRequest.CreateHttp("https://api.mercadolibre.com/oauth/token?grant_type=client_credentials&client_id=" + idMercadoLivre + "&client_secret=" + secretKeyMercadoLivre);
            webRequest.Method = "POST";

            try
            {
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var WebStatusCode = webResponse.StatusCode;

                Console.WriteLine("OK> " + (int)WebStatusCode);

                return (int)WebStatusCode;
            }
            catch (WebException we)
            {
                var WebStatusCode = ((HttpWebResponse)we.Response).StatusCode;
                Console.WriteLine("Error> " + (int)WebStatusCode);

                return (int)WebStatusCode;
            }

        }


    }

}