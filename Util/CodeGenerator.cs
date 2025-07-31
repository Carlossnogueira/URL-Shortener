using System.Text;

namespace URL_Shortener.Util
{
    public static class CodeGenerator
    {
        private const string _alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly int _base =  _alphabet.Length;

        public static string Encode(int num)
        {
            var sb = new StringBuilder();
            while (num > 0)
            {
                sb.Insert(0, _alphabet[num % _base]);
                num /= _base;
            }

            return sb.ToString();
        }

        public static int Decode(string code)
        {
            int num = 0;
            foreach (char c in code)
            {
                num = num * _base + _alphabet.IndexOf(c);
            }

            return num;
        }

    }
}
