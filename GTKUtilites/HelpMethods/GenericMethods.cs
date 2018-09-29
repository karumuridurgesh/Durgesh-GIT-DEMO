using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTKUtilites.HelpMethods
{
    public class GenericMethods
    {
        static System.Security.Cryptography.RNGCryptoServiceProvider m_rng = new System.Security.Cryptography.RNGCryptoServiceProvider();

        static int CSRF_TOKEN_LENGTH = 32;
        //private static HttpSessionState session { get { return HttpContext.Current.Session; } }
        public static void CheckXSRF(Page page, HiddenField antiforgery)
        {
            string antiforgeryToken = string.Empty;
            antiforgeryToken = GenerateCustomizedCSRFToken();
            System.Collections.Generic.SortedDictionary<string, string> l_CSRFTokenCollection = new System.Collections.Generic.SortedDictionary<string, string>();

            if (!page.IsPostBack)
            {
                if (l_CSRFTokenCollection.ContainsKey(page.AppRelativeVirtualPath.ToUpper()))
                {
                    l_CSRFTokenCollection.Remove(page.AppRelativeVirtualPath.ToUpper());
                }
                l_CSRFTokenCollection.Add(page.AppRelativeVirtualPath.ToUpper(), antiforgeryToken);

                page.Session.Add("CSRFTokens", l_CSRFTokenCollection);

                antiforgery.Value = antiforgeryToken;

                antiforgeryToken = string.Empty;
            }
            else
            {

                if (page.Session["CSRFTokens"] == null)
                {
                    throw new HttpException("Validation of Anti-XSRF token failed.");
                }

                l_CSRFTokenCollection = (System.Collections.Generic.SortedDictionary<string, string>)page.Session["CSRFTokens"];
                if (!l_CSRFTokenCollection.ContainsKey(page.AppRelativeVirtualPath.ToUpper()))
                {
                    throw new HttpException("Validation of Anti-XSRF token failed.");
                }
                if ((antiforgery.Value != l_CSRFTokenCollection[page.AppRelativeVirtualPath.ToUpper()]))
                {
                    throw new HttpException("Validation of Anti-XSRF token failed.");
                }

                //l_CSRFTokenCollection.Remove(page.AppRelativeVirtualPath);

                //l_CSRFTokenCollection.Add(page.AppRelativeVirtualPath, antiforgeryToken);

                //page.Session.Add("CSRFTokens", l_CSRFTokenCollection);

                //antiforgery.Value = antiforgeryToken;

            }
            
        }


        public static string GenerateCSRFToken()
        {
            string l_CSRFToken = "";
            try
            {
                byte[] CSRFTokenBytes = new byte[CSRF_TOKEN_LENGTH];
                m_rng.GetBytes(CSRFTokenBytes);
                l_CSRFToken = Convert.ToBase64String(CSRFTokenBytes);
            }
            catch (System.Security.Cryptography.CryptographicUnexpectedOperationException ex)
            {
                throw ex;
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return l_CSRFToken;
        }

        private static string GenerateCustomizedCSRFToken()
        {
            StringBuilder result = new StringBuilder(CSRF_TOKEN_LENGTH);
            try
            {
                char[] chars = new char[62];
                string a;
                a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_";
                chars = a.ToCharArray();
                byte[] data = new byte[CSRF_TOKEN_LENGTH];
                RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
                crypto.GetNonZeroBytes(data);
                foreach (byte b in data)
                {
                    result.Append(chars[b % (chars.Length - 1)]);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return result.ToString();
        }

    }
}
