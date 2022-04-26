using System;
using System.Threading.Tasks;

namespace PollyTestConsole
{
    public class PollyTestManger
    {
        private ApiCaller apiCaller;

        public PollyTestManger()
        {
            apiCaller = new ApiCaller();

            RunInput();
        }

        private void RunInput()
        {
            bool again = true;
            string response = "";

            while (again)
            {
                Console.WriteLine("\n\nEnter command: ");

                string command = Console.ReadLine();

                int commandNum;

                if (!int.TryParse(command, out commandNum))
                    continue;

                switch (commandNum)
                {
                    case 0:
                        again = false;
                        break;

                    case 1:
                        response = ThreeToSuccess();
                        break;

                    default:
                        again = false;
                        break;
                }

                if (!again)
                    break;

                Console.WriteLine("Response: " + response);
            }
        }

        private string ThreeToSuccess()
        {
            Task<ExempleDataModel> task = apiCaller.LoadComic();

            Task.WaitAny(task);

            return task.Result.Num + "";
        }
    }
}
