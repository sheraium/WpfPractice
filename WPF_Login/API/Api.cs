using System.IO;

namespace WPF_Login.API
{
    public class Api
    {
        private readonly string _region;
        private readonly string _key;

        public Api(string region)
        {
            _region = region;
            _key = GetKey("Api.txt");
        }

        protected string GetURI(string path)
        {
            return "URI";
        }
        public string GetKey(string path)
        {
            using (var sr = new StreamReader(path))
            {
                return sr.ReadToEnd();
            }
        }
    }
}