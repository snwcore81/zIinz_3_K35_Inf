﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using zIinz_3_K35_Inf.Classes.Network;
using zIinz_3_K35_Inf.Classes.Network.Services;
using zIinz_3_K35_Inf.Interfaces;

namespace zIinz_3_K35_Inf.Classes.Business.Messages
{
    [DataContract]
    public class LoginMessage : AutoInitXmlStorage<LoginMessage>, IMessage
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public Response Response { get; set; }

        public LoginMessage()
        {
            Login = string.Empty;
            Response = null;
        }

        public IMessage ProcessRequest(StateObject Object = null)
        {
            var _client = Object.GetObject<ClientService>();

            if (_client.HasRegisteredServer)
            {
                var _server = _client.GetRegisteredServer<ServerService<ClientService>>();

                if (_server.ConnectedClients.Find(x => x.Identifier == Login) == null)
                {
                    _client.Identifier = Login;
                    Response = new Response(1, "Zalogowano poprawne");

                    TextMessage _msg = new TextMessage
                    {
                        From = "Server",
                        To = "*",
                        Text = $"Na serwerze zalogował się użytkownik <{Login}>"
                    };

                    _server.AsyncSendBroadcast(_msg.AsNetworkData(),_client);
                }
                else
                {
                    Response = new Response(0, "Uzytkownik o takim loginie jest juz zalogowany!");
                }
            }
            else
                Response = new Response(0, new Exception("Wyjątek krytyczny"));

            return this;
        }

        public IMessage ProcessResponse(StateObject Object = null)
        {
            var _client = Object.GetObject<ClientService>();

            if (Response.Object is Exception)
                throw Response.Object as Exception;

            if (Response.Code == 0)
                throw new Exception($"Błąd podczas logowania! {Response}");

            if (Response.Code == 1)
            {
                _client.Identifier = Login;

                Console.WriteLine("Zalogowano do systemu!");
            }

            return this;
        }
        public NetworkData AsNetworkData(int a_iBufferSize = 100000)
        {
            return new NetworkData(a_iBufferSize)
            {
                Buffer = ToXml().ToArray()
            };
        }
        public override string ToString()
        {
            return $"[Login={Login}|Response={Response}]";
        }
    }
}
