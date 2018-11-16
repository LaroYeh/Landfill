/// Reference:
/// https://www.youtube.com/watch?v=EA5jF_7FteM   Encrypt/Decrypt with RSA in C#
/// https://stackoverflow.com/questions/34403823/verifying-jwt-signed-with-the-rs256-algorithm-using-public-key-in-c-sharp
/// https://stackoverflow.com/questions/1228701/code-for-decoding-encoding-a-modified-base64-url
/// https://tools.ietf.org/html/rfc7515 解釋JWS

/// 如何使用Google的ID Token
/// Google的ID Token可透過JWT來解析
/// 而JWT分三段，透過「.」分隔，皆是Base64URL做Encode，
///   BASE64URL(UTF8(JWS Protected Header)) || '.' || BASE64URL(JWS Payload) || '.' || BASE64URL(JWS Signature) with the HMAC SHA-256 algorithm
/// 然後各別的意思是
///    o  JOSE Header 
///    o  JWS Payload 
///    o  JWS Signature

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace CSharpTest
{

    class DecodeJWT
    {
        private string[] TokenParts { get; set; }

        public DecodeJWT() {
            //Sample
            string tokenStr = "eyJhbGciOiJSUzI1NiIsImtpZCI6ImQxZTg2OWU3YmY0MGRkYzNkM2RlMDgwNDI1OThiYTgzNTA5NzBmMGEiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJhY2NvdW50cy5nb29nbGUuY29tIiwiYXpwIjoiNDY1ODEyNjE2OTc2LWV2MzlrcTU3a3JsZGQ3MWdlYWJtbmVza3Q0aWg3NTBrLmFwcHMuZ29vZ2xldXNlcmNvbnRlbnQuY29tIiwiYXVkIjoiNDY1ODEyNjE2OTc2LWV2MzlrcTU3a3JsZGQ3MWdlYWJtbmVza3Q0aWg3NTBrLmFwcHMuZ29vZ2xldXNlcmNvbnRlbnQuY29tIiwic3ViIjoiMTE0ODQ3ODcyNDgyOTI5NTc0Nzc1IiwiZW1haWwiOiJsaHp5YW1pbmFiZUBnbWFpbC5jb20iLCJlbWFpbF92ZXJpZmllZCI6dHJ1ZSwiYXRfaGFzaCI6ImE4UkNDMlphZFFTb1ZnSmR1dERsQUEiLCJuYW1lIjoi44Gq44G544KE44G_IiwicGljdHVyZSI6Imh0dHBzOi8vbGgzLmdvb2dsZXVzZXJjb250ZW50LmNvbS8tZzRiNjk4eTBjbjAvQUFBQUFBQUFBQUkvQUFBQUFBQUFBSTgvNUhvZG9jV28xU2svczk2LWMvcGhvdG8uanBnIiwiZ2l2ZW5fbmFtZSI6IuOChOOBvyIsImZhbWlseV9uYW1lIjoi44Gq44G5IiwibG9jYWxlIjoiemgtVFciLCJpYXQiOjE1NDIwODExNjEsImV4cCI6MTU0MjA4NDc2MSwianRpIjoiNzAwOGY3OWI5NmRlMzllODM5MzdiN2NiMjIwMDYyNmMxNTk2NDkxMSJ9.JlzXA8MHLwqaFN7vtBPz-heGErtM7qmjJFJi1wdNQy1c2VTAKSzaZl6H2vvwnNqsi47DewKTvGSmTpaXVQxIhxrSIYVSNEgMU4uuc6Cw2tj7G5Qy3y4wn_qaxYa3VMaTP8JYZjcSs9e1cpXCJ7jtfj1yw478tUG-Bk18glCA3BJsRa7GYnc2Qg_PNZ-4F_Krok-ZZg7E6CCMhK2Gtg6raZCTP8gr1FoDeXwFEDI23aBvKCuzM44O8g5F3AGAxGvKJMtvfI7q2HT2Kzcn3vXKa8rYXcoP-8zGAH2AT14JGuChVVhvP9WwUrYxyEFyp1j17PeH5aF9g9KPx5_4nFLvgA";
            TokenParts = tokenStr.Split('.');
        }
        public DecodeJWT(string tokenStr)
        {
            TokenParts = tokenStr.Split('.');
        }

        public string GetHeader() { return Base64UrlToString(TokenParts[0]); }
        public string GetPayload() { return Base64UrlToString(TokenParts[1]); }
        public string GetSignature() {
            //未完成，Signature的驗證要跟RSA配合，但Public Key不知道怎麼判斷
            //https://www.googleapis.com/oauth2/v3/certs
            return Base64UrlToString(TokenParts[2]);
        }

        public bool IsSignatureValid() { return false; }
        public bool IsTokenValid() {
            //除了要通過IsSignatureValid外
            //還須驗證aud ( == YOUR_APPS_CLIENT_ID) 及 iss( == "https://accounts.google.com")
            //才表示資料是可信的
            return false;
        }

        private string Base64UrlToString(string base64Url)
        {
            byte[] encodeBytes = FromBase64Url(base64Url);
            return Encoding.UTF8.GetString(encodeBytes);
        }
        private byte[] FromBase64Url(string base64Url)
        {
            string padded = base64Url.Length % 4 == 0
                ? base64Url : base64Url + "====".Substring(base64Url.Length % 4);
            string base64 = padded.Replace("_", "/")
                                  .Replace("-", "+");
            return Convert.FromBase64String(base64);
        }
    }
}
