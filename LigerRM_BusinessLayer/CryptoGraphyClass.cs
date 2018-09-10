using System;
using System.Collections.Generic;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace SignetInternet_BusinessLayer
{
    public class CryptoGraphyClass
    {
        private SymmetricAlgorithm mobjCryptoService;
        private HashAlgorithm HashCryptoService;
        private string Key;
        public CryptoGraphyClass()
        {
            mobjCryptoService = new RijndaelManaged();
            Key = "Guz(%&hj7x89H$yuBI0456FtmaT5&fvHUFCy76*h%(HilJ$lhj!y6&(*jkP87jH7";
            HashCryptoService = new SHA512Managed();
        }
        RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
        public string PrivateKey
        {
            get { return Convert.ToBase64String(RSAalg.ExportCspBlob(true)); }
        }

        public string PublicKey
        {
            get { return Convert.ToBase64String(RSAalg.ExportCspBlob(false)); }
        }

        //RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
        //string str_Private_Key = Convert.ToBase64String( RSAalg.ExportCspBlob(true) );
        //string str_Public_Key = Convert.ToBase64String( RSAalg.ExportCspBlob(false) );

        public string HashAndSign(string str_DataToSign, string str_Private_Key)
        {
            ASCIIEncoding ByteConverter = new ASCIIEncoding();
            byte[] DataToSign = ByteConverter.GetBytes(str_DataToSign);
            try
            {
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
                RSAalg.ImportCspBlob(Convert.FromBase64String(str_Private_Key));
                byte[] signedData = RSAalg.SignData(DataToSign, new SHA1CryptoServiceProvider());
                string str_SignedData = Convert.ToBase64String(signedData);
                return str_SignedData;
            }
            catch (CryptographicException e)
            {
                return null;
            }
        }
        //验证签名
        public bool VerifySignedHash(string str_DataToVerify, string str_SignedData, string str_Public_Key)
        {
            byte[] SignedData = Convert.FromBase64String(str_SignedData);
            ASCIIEncoding ByteConverter = new ASCIIEncoding();
            byte[] DataToVerify = ByteConverter.GetBytes(str_DataToVerify);
            try
            {
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
                RSAalg.ImportCspBlob(Convert.FromBase64String(str_Public_Key));
                return RSAalg.VerifyData(DataToVerify, new SHA1CryptoServiceProvider(), SignedData);
            }
            catch (CryptographicException e)
            {
                return false;
            }
        }

        public string GetMD5ID(string source)
        {
            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            byte[] message;
            message = Encoding.Default.GetBytes(source);
            md5Provider.ComputeHash(message);
            return Convert.ToBase64String(md5Provider.Hash);
        }


        private byte[] GetLegalKey()
        {
            string sTemp = Key;
            mobjCryptoService.GenerateKey();
            byte[] bytTemp = mobjCryptoService.Key;
            int KeyLength = bytTemp.Length;
            if (sTemp.Length > KeyLength)
                sTemp = sTemp.Substring(0, KeyLength);
            else if (sTemp.Length < KeyLength)
                sTemp = sTemp.PadRight(KeyLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }

        private byte[] GetLegalIV()
        {
            string sTemp = "E4ghj*Ghg7!rNIfb&95GUY86GfghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";
            mobjCryptoService.GenerateIV();
            byte[] bytTemp = mobjCryptoService.IV;
            int IVLength = bytTemp.Length;
            if (sTemp.Length > IVLength)
                sTemp = sTemp.Substring(0, IVLength);
            else if (sTemp.Length < IVLength)
                sTemp = sTemp.PadRight(IVLength, ' ');
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }

        public string Encrypt(string Source)
        {
            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
            MemoryStream ms = new MemoryStream();
            mobjCryptoService.Key = GetLegalKey();
            mobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            ms.Close();
            byte[] bytOut = ms.ToArray();
            return Convert.ToBase64String(bytOut);
        }

        public string Decrypt(string Source)
        {
            byte[] bytIn = Convert.FromBase64String(Source);
            MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
            mobjCryptoService.Key = GetLegalKey();
            mobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

        public string HasEncrypt(string Source)
        {
            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
            byte[] bytOut = HashCryptoService.ComputeHash(bytIn);
            return Convert.ToBase64String(bytOut);
        }
    }
}
