using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Json;

namespace SMS.API
{
    public class SMS
    {
        string uri = "https://sms.comtele.com.br/api/";
        string chave;
        System.Net.WebProxy proxy = new System.Net.WebProxy();

        public SMS(string Chave)
        {
            this.chave = Chave;
        }

        public void Proxy(string uri)
        {
            this.proxy.Address = new Uri(uri);
        }

        public string saldo()
        {
            return Exec(uri + chave + "/balance", "GET");
        }

        public string Exec(string url,string metodo)
        {
            string tetorno = "";
            // Create a 'WebRequest' object with the specified url. 
            WebRequest myWebRequest = WebRequest.Create(url);
            myWebRequest.Method = metodo;
           
            myWebRequest.Proxy = this.proxy;
            // Send the 'WebRequest' and wait for response.
            WebResponse myWebResponse = myWebRequest.GetResponse();

            // Obtain a 'Stream' object associated with the response object.
            Stream ReceiveStream = myWebResponse.GetResponseStream();

            // Pipe the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(ReceiveStream);

            Char[] read = new Char[256];

            // Read 256 charcters at a time.     
            int count = readStream.Read(read, 0, 256);

            while (count > 0)
            {
                // Dump the 256 characters on a string and display the string onto the console.
                String str = new String(read, 0, count);
                tetorno += str;
                count = readStream.Read(read, 0, 256);
            }

            // Release the resources of stream object.
            readStream.Close();

            // Release the resources of response object.
            myWebResponse.Close();
            return tetorno;
        }

        public bool EnviarMensagem(string remetente, string destinatario, string mensagem)
        {
            try
            {
                string url = String.Format(uri+"{0}/sendmessage?sender={1}&receivers={2}&content={3}", this.chave, remetente, destinatario, mensagem);
                AutoResetEvent ev = new AutoResetEvent(false);
                WebPost(new Uri(url), string.Empty, (data) =>
                {
                    //Retorno enviado pela API.
                    var d = data;
                    ev.Set();
                });

                ev.WaitOne();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void WebPost(Uri uri, string data, Action<object> callback)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);

            request.Proxy = this.proxy;
            request.Method = "POST";
            request.ContentType = "text/plain;charset=utf-8";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] bytes = encoding.GetBytes(data);

            request.ContentLength = bytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            request.BeginGetResponse((x) =>
            {
                using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(x))
                {
                    if (callback != null)
                    {
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(object));
                        callback(ser.ReadObject(response.GetResponseStream()) as object);
                    }
                }
            }, null);
        }
    }
}