using System;
using System.IO;
using System.Text;
using zIinz_3_K35_Inf.Classes;
using zIinz_3_K35_Inf.Classes.Business;
using zIinz_3_K35_Inf.Classes.Exceptions;
using zIinz_3_K35_Inf.Classes.Network;

namespace zIinz_3_K35_Inf
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.CurrentLevel = Log.LevelEnum.DEV;

            using var log = Log.DEB("Program", "Main");

            int iNetworkDataSize = 48;

            log.PR_DEB("początek działania naszego cudownego programu XD");
            log.PR_DEV("a to jest tryb developerski - chwilowo zapewne nie będzie widoczny :P");

            do
            {

                try
                {
                    string sXmlString = @"<User xmlns=""http://schemas.datacontract.org/2004/07/zIinz_3_K35_Inf.Classes.Business"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><Login>Jacek</Login><Password>12jacek34</Password><Permission>1</Permission><Response><ResponseCode>777</ResponseCode><ResponseString>Chyba działa :-)</ResponseString></Response></User>";

                    NetworkData obj = new NetworkData(iNetworkDataSize);

                    obj.Buffer = Encoding.UTF8.GetBytes(sXmlString);

                    User user = new User();

                    user.FromXml(new MemoryStream(Encoding.UTF8.GetBytes(sXmlString)));

                    log.PR_DEB(user.ToString());

                    break;
                }
                catch (NetworkDataBufferIsEmpty e)
                {
                    log.PR_DEB($"Wychwycono wyjątek <{e.GetType().Name}>: {e.Message}");
                    break;
                }
                catch (NetworkDataBufferToLarge e)
                {
                    log.PR_DEB($"Wychwycono wyjątek <{e.GetType().Name}>: {e.Message}");

                    iNetworkDataSize = e.Length + 1;
                }
                catch (Exception e)
                {
                    log.PR_DEB($"Wychwycono wyjątek ogólny: {e.Message}");
                    break;
                }
            }
            while (true);


            /*
            User user = new User
            {
                Login = "Jacek",
                Password = "12jacek34",
                Permission = 1,
                Response = new ResponseObject
                {
                    ResponseString = "Chyba działa :-)",
                    ResponseCode = 777
                }
            };

            Console.WriteLine(Encoding.UTF8.GetString(user.ToXml().ToArray()));
            */
        }
    }
}
