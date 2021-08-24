using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Data
{
    public class Conexion
    {
        public static List<Usuarios> ConsultarUsuario(string url)
        {
            List<Usuarios> Usu = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                Usu = JsonConvert.DeserializeObject<List<Usuarios>>(json);
            }

            return Usu;

        }
    }
}
