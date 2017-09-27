namespace Utils
{
    class HexString
    {
        public static string Bytes2hex(byte[] data)
        {
            string res = "";
            if (null == data)
                return res;

            foreach (byte b in data)
            {
                res += b.ToString("X2");
            }
            return res;
        }

        public static byte[] Hex2bytes(string hexStr)
        {
            int len = ((hexStr.Length + 1) >> 1);
            byte[] res = new byte[len];
            for (int i = 0; i < hexStr.Length; i++)
            {
                char c = hexStr[i];
                if ((i & 0x01) == 0)
                {
                    res[i >> 1] |= (byte)(hexChar2byte(c) << 4);
                }
                else
                {
                    res[i >> 1] |= hexChar2byte(c);
                }
            }
            return res;
        }

        private static byte hexChar2byte(char c)
        {
            byte res = 0x00;
            if (c >= '0' && c <= '9')
            {
                res = (byte)(c - '0');
            }
            else if (c >= 'A' && c <= 'F')
            {
                res = (byte)(10 + c - 'A');
            }
            else if (c >= 'a' && c <= 'f')
            {
                res = (byte)(10 + c - 'a');
            }
            return res;
        }
    }
}
