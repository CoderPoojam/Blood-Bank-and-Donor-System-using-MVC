using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodProject.Security
{
    public class Encryption
    {
        public static string encode(string password)
        {
            byte[] b;
            string encodedString;
            try
            {
                b = System.Text.ASCIIEncoding.ASCII.GetBytes(password);
                encodedString = Convert.ToBase64String(b);

            }
            catch (Exception ex)
            {

                throw new Exception("Error in encodePassword: " + ex.Message);
            }
            return encodedString;
        }
    }
}
