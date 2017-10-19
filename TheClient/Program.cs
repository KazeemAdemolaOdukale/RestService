using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TheClient
{
    class Program
    {
        static int choice;
        static string txtString;
        static void Main(string[] args)
        {
            do
            {
                DisplayOptions();
                switch (choice)
                {
                    case 1:
                        ConvertToStringClient();
                        break;
                    case 2:
                        ConvertToUpperClient();
                        break;
                    case 3:
                        LengthOfStringClient();
                        break;
                    case 4:
                        WordsAndLengthClient();
                        break;
                    default:
                        break;
                }
            } while (choice != 0);
            Environment.Exit(0);
        }

        private static void WordsAndLengthClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:56987");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/api/arrayString/" + txtString).Result;
            if (response.IsSuccessStatusCode)
            {
                List<string> theString = response.Content.ReadAsAsync<List<string>>().Result;
                foreach (var item in theString)
                {
                    Console.WriteLine("{0,-12} {1,-2}", item, item.Length);
                }
            }
        }

        private static void LengthOfStringClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:56987");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/api/stringLength/" + txtString).Result;
            if (response.IsSuccessStatusCode)
            {
                int stringLength = response.Content.ReadAsAsync<int>().Result;
                Console.WriteLine($"Length of string: {stringLength}");
            }
        }

        private static void ConvertToUpperClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:56987");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string response = client.GetStringAsync("/api/upperCase/" + txtString).Result;
            Console.WriteLine($"{response}");
        }

        private static void DisplayOptions()
        {
            Console.WriteLine("********** Make your Selection *********");
            Console.WriteLine("*                                      *");
            Console.WriteLine("* 1: Array of string                   *");
            Console.WriteLine("* 2: Convert to upper case             *");
            Console.WriteLine("* 3: Length of strings                 *");
            Console.WriteLine("* 4: Words and their length            *");
            Console.WriteLine("* 0: Exit                              *");
            Console.WriteLine("*                                      *");
            Console.WriteLine("****************************************\n");
            Console.Write("Select from the above: ");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the text: ");
            txtString = Console.ReadLine();
        }

        private static void ConvertToStringClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:56987");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("/api/arrayString/" + txtString).Result;
            if (response.IsSuccessStatusCode)
            {
                string[] theString = response.Content.ReadAsAsync<string[]>().Result;
                foreach (var item in theString)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
