using System;
using System.IO;
using System.Text;
using zIinz_3_K35_Inf.Classes;
using zIinz_3_K35_Inf.Classes.Business;

namespace zIinz_3_K35_Inf
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.CurrentLevel = Log.LevelEnum.DEV;

            using var log = Log.DEB("Program", "Main");

            log.PR_DEB("początek działania naszego cudownego programu XD");
            log.PR_DEV("a to jest tryb developerski - chwilowo zapewne nie będzie widoczny :P");
            
            string sXmlString = @"<User xmlns=""http://schemas.datacontract.org/2004/07/zIinz_3_K35_Inf.Classes.Business"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><Login>Jacek</Login><Password>12jacek34</Password><Permission>1</Permission><Response><ResponseCode>777</ResponseCode><ResponseString>Chyba działa :-)</ResponseString></Response></User>";

            User user = new User();

            user.FromXml(new MemoryStream(Encoding.UTF8.GetBytes(sXmlString)));

            log.PR_DEB(user.ToString());
            

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
