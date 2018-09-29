using GTKSSO.UILayer.Security;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace GTKSSO
{
    public class Global : System.Web.HttpApplication
    {
        bool IsSessionAvailable = false;
        string UserName = string.Empty;
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.AddHeader("x-frame-options", "DENY");
            //var application = sender as HttpApplication;
            //if (application != null && application.Context != null)
            //{
            //    application.Context.Response.Headers.Remove("Server");
            //}
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        public void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            gtkalidatePageRequest();
            URLReferrerValidation();
        }
        private void URLReferrerValidation()
        {
            string InjectionSec = ConfigurationManager.AppSettings["InjectValidation"] ?? "N";
            string ReferrerURLs = ConfigurationManager.AppSettings["ReferrerURLs"] ?? "";
            if (System.Web.HttpContext.Current.Request.UrlReferrer != null && InjectionSec == "Y")
            {
                if (!string.IsNullOrEmpty(Convert.ToString(HttpContext.Current.Request.UrlReferrer)) && ReferrerURLs != "")
                {
                    if (HttpContext.Current.Request.UrlReferrer.Host != ReferrerURLs.Split(',')[0]
                        && HttpContext.Current.Request.UrlReferrer.Host != ReferrerURLs.Split(',')[1])
                    {
                        throw new HttpException("Validation of Anti-XSRF token failed.");
                    }
                }
            }
        }
        public void gtkalidatePageRequest()
        {
            string[] LDAParr = { "\")(", "=*", "%3d%2a", ")(", "*!", "*|",  "@*", "*|", "*/", "/*", "%3D%2A", "/*", "%2F%2F", "%21", "%28", "%28", "%29", "%2A",  "~!", "~@", "~#","CURSOR","KILL","DBCC","@variable","sp_helptext","sp_exec",
                                  "~$", "~%", "~^", "~&", "~*", "~(", "~)", "~<", "~>", "~?", "~`", "~'", "~=", "~:", "~;", "~/", "~-", "~+",
                                  "~|", "~{", "~}", "~[", "~]", "!~", "!@", "!#", "!$", "!%", "!^", "!&", "!*", "!(", "!)", "!<", "!>", "!?",
                                  "!`", "!'", "!=", "!:", "!;", "!/", "!-", "!+", "!|", "!{", "!}", "![", "!]", "@~", "@!", "@#", "@$", "@%",
                                  "@^", "@&", "@*", "@(", "@)", "@<", "@>", "@?", "@`", "@'", "@=", "@:", "@;", "@/", "@-", "@+",  "@{",
                                  "@}", "@[", "@]", "#~", "#!",  "#$", "#%", "#&", "#*", "#(", "#)", "#<", "#>", "#?", "#`", "#'",
                                  "#=", "#:", "#;", "#/", "#-", "#+",  "#{", "#}", "#[", "#]", "$~", "$!", "$@", "$#", "$%", "$^", "$&",
                                  "$*", "$(", "$)", "$<", "$>", "$?", "$`", "$'", "$=", "$:", "$;", "$/", "$-", "$+", "$|", "${", "$}", "$[",
                                  "$]", "%~", "%!", "%@", "%#", "%$", "%^", "%&", "%*", "%(", "%)", "%<", "%>", "%?", "%`", "%'", "%=", "%:",
                                  "%;", "%/", "%-", "%+", "%|", "%{", "%}", "%[", "%]", "^~", "^!", "^@", "^#", "^$", "^%", "^&", "^*", "^(",
                                  "^)", "^<", "^>", "^?", "^`", "^'", "^=", "^:", "^;", "^/", "^-", "^+", "^|", "^{", "^}", "^[", "^]", "&~",
                                  "&!", "&@", "&#", "&$", "&%", "&^", "&*", "&(", "&)", "&<", "&>", "&?", "&`", "&'", "&=", "&:", "&;", "&/",
                                  "&-", "&+", "&|", "&{", "&}", "&[", "&]", "*~", "*!", "*@", "*#", "*$", "*%", "*^", "*&", "*(", "*)", "*<",
                                  "*>", "*?", "*`", "*'", "*=", "*:", "*;", "*/", "*-", "*+", "*|", "*{", "*}", "*[", "*]", "(~", "(!", "(@",
                                  "(#", "($", "(%", "(^", "(&", "(*", "()", "(<", "(>", "(?", "(`", "('", "(=", "(:", "(;", "(/", "(-", "(+",
                                  "(|", "({", "(}", "([", "(]", ")~", ")!", ")@", ")#", ")$", ")%", ")^", ")&", ")*", ")(", ")<", ")>", ")?",
                                  ")`", ")'", ")=", "):", ");", ")/", ")-", ")+", ")|", "){", ")}", ")[", ")]", "<~", "<!", "<@", "<#", "<$",
                                  "<%", "<^", "<&", "<*", "<(", "<)",  "<?", "<`", "<'", "<=", "<:", "<;", "</", "<-", "<+", "<|", "<{",
                                  "<}", "<[", "<]", ">~", ">!", ">@", ">#", ">$", ">%", ">^", ">&", ">*", ">(", ">)", "><", ">?", ">`", ">'",
                                  ">=", ">:", ">;", ">/", ">-", ">+", ">|", ">{", ">}", ">[", ">]", "?~", "?!", "?@", "?#", "?$", "?%", "?^",
                                  "?&", "?*", "?(", "?)", "?<", "?>", "?`", "?'", "?=", "?:", "?;", "?/", "?-", "?+", "?|", "?{", "?}", "?[",
                                  "?]", "`~", "`!", "`@", "`#", "`$", "`%", "`^", "`&", "`*", "`(", "`)", "`<", "`>", "`?", "`'", "`=", "`:",
                                  "`;", "`/", "`-", "`+", "`|", "`{", "`}", "`[", "`]", "'~", "'!", "'@", "'#", "'$", "'%", "'^", "'&", "'*",
                                  "'(", "')", "'<", "'>", "'?", "'`", "'=", "':", "';", "'/", "'-", "'+", "'|", "'{", "'}", "'[", "']", "=~",
                                  "=!", "=@", "=#", "=$",  "=^", "=*", "=(", "=)", "=<", "=>", "=?", "=`", "='", "=:", "=;",
                                  "=-", "=+", "=|", "={", "=}", "=[", "=]", ":~", ":!", ":@", ":#", ":$", ":%", ":^", ":&", ":*", ":(", ":)",
                                  ":<", ":>", ":?", ":`", ":'", ":=", ":;", ":-", ":+", ":|", ":{", ":}", ":[", ":]", ";~", ";!", ";@",
                                  ";#", ";$", ";%", ";^", ";&", ";*", ";(", ";)", ";<", ";>", ";?", ";`", ";'", ";=", ";:", ";/", ";-", ";+",
                                  ";|", ";{", ";}", ";[", ";]", "/~", "/!", "/@", "/#", "/$", "/^", "/&", "/*", "/(", "/)", "/<", "/>", "/?", "/`", "/'", "/=", "/:", "/;", "/-", "/+", "/|", "/{", "/}", "/[", "/]", "-~", "-!",  "-$", "-%", "-^", "-&", "-*", "-(", "-)", "-<", "->", "-?", "-`", "-'", "-=", "-:", "-;", "-/", "-+", "-{", "-}", "-[", "-]", "+~", "+!", "+@", "+#", "+$", "+%", "+^", "+&", "+*", "+(", "+)", "+<", "+>", "+?", "+`", "+'", "+=", "+:", "+;", "+/", "+-", "+|", "+{", "+}", "+[", "+]", "|~", "|!", "|$", "|%",  "|*", "|(", "|)", "|<", "|>", "|?", "|`", "|'", "|=", "|:", "|;", "|/", "|-", "|+", "|{", "|}", "|[", "|]", "{~", "{!", "{@", "{#", "{$", "{%", "{^", "{&", "{*", "{(", "{)", "{<", "{>", "{?", "{`", "{'", "{=", "{:", "{;", "{/", "{-", "{+", "{|", "{}", "{[", "{]", "}~", "}!", "}@", "}#", "}$", "}%", "}^", "}&", "}*", "}(", "})", "}<", "}>", "}?", "}`", "}'", "}=", "}:", "};", "}/", "}-", "}+", "}|", "}{", "}[", "}]", "[~", "[!", "[@", "[#", "[$", "[%", "[^", "[&", "[*", "[(", "[)", "[<", "[>", "[?", "[`", "['", "[=", "[:", "[;", "[/", "[-", "[+", "[|", "[{", "[}", "[]", "]~", "]!", "]@", "]#", "]$", "]%", "]^", "]&", "]*", "](", "])", "]<", "]>", "]?", "]`", "]'", "]=", "]:", "];", "]/", "]-", "]+", "]|", "]{", "]}", "][" };

            string[] SQLArr = { "'OR'", "'AND'", "'='", "\"", "%22", "TRUNCATE", "--", "SHUTDOWN", "TRUNCATE", "UPDATE", "exec", "declare@",
                "select@", "'", "--","CURSOR","KILL","DBCC","@variable","sp_helptext","sp_exec",
                                  "union", "drop", "exec", ">", "<", ",", "insert", "procedure", "orderby", "asc", "desc", "delete", "update",
                                  "distinct", "truncate", "replace", "handler", "\\2A", "\\28", "\\29", "\\5C", "\00", "~!", "~@", "~#",
                                  "~$", "~%", "~^", "~&", "~*", "~(", "~)", "~<", "~>", "~?", "~`", "~'", "~=", "~:", "~;", "~/", "~-", "~+",
                                  "~|", "~{", "~}", "~[", "~]", "!~", "!@", "!#", "!$", "!%", "!^", "!&", "!*", "!(", "!)", "!<", "!>", "!?",
                                  "!`", "!'", "!=", "!:", "!;", "!/", "!-", "!+", "!|", "!{", "!}", "![", "!]", "@~", "@!", "@#", "@$", "@%",
                                  "@^", "@&", "@*", "@(", "@)", "@<", "@>", "@?", "@`", "@'", "@=", "@:", "@;", "@/", "@-", "@+",  "@{",
                                  "@}", "@[", "@]", "#~", "#!", "#$", "#%",  "#&", "#*", "#(", "#)", "#<", "#>", "#?", "#`", "#'",
                                  "#=", "#:", "#;", "#/", "#-", "#+",  "#{", "#}", "#[", "#]", "$~", "$!", "$@", "$#", "$%", "$^", "$&",
                                  "$*", "$(", "$)", "$<", "$>", "$?", "$`", "$'", "$=", "$:", "$;", "$/", "$-", "$+", "$|", "${", "$}", "$[",
                                  "$]", "%~", "%!", "%@", "%#", "%$", "%^", "%&", "%*", "%(", "%)", "%<", "%>", "%?", "%`", "%'", "%=", "%:",
                                  "%;", "%/", "%-", "%+", "%|", "%{", "%}", "%[", "%]", "^~", "^!", "^@", "^#", "^$", "^%", "^&", "^*", "^(",
                                  "^)", "^<", "^>", "^?", "^`", "^'", "^=", "^:", "^;", "^/", "^-", "^+", "^|", "^{", "^}", "^[", "^]", "&~",
                                  "&!", "&@", "&#", "&$", "&%", "&^", "&*", "&(", "&)", "&<", "&>", "&?", "&`", "&'", "&=", "&:", "&;", "&/",
                                  "&-", "&+", "&|", "&{", "&}", "&[", "&]", "*~", "*!", "*@", "*#", "*$", "*%", "*^", "*&", "*(", "*)", "*<",
                                  "*>", "*?", "*`", "*'", "*=", "*:", "*;", "*/", "*-", "*+", "*|", "*{", "*}", "*[", "*]", "(~", "(!", "(@",
                                  "(#", "($", "(%", "(^", "(&", "(*", "()", "(<", "(>", "(?", "(`", "('", "(=", "(:", "(;", "(/", "(-", "(+",
                                  "(|", "({", "(}", "([", "(]", ")~", ")!", ")@", ")#", ")$", ")%", ")^", ")&", ")*", ")(", ")<", ")>", ")?",
                                  ")`", ")'", ")=", "):", ");", ")/", ")-", ")+", ")|", "){", ")}", ")[", ")]", "<~", "<!", "<@", "<#", "<$",
                                  "<%", "<^", "<&", "<*", "<(", "<)",  "<?", "<`", "<'", "<=", "<:", "<;", "</", "<-", "<+", "<|", "<{",
                                  "<}", "<[", "<]", ">~", ">!", ">@", ">#", ">$", ">%", ">^", ">&", ">*", ">(", ">)", "><", ">?", ">`", ">'",
                                  ">=", ">:", ">;", ">/", ">-", ">+", ">|", ">{", ">}", ">[", ">]", "?~", "?!", "?@", "?#", "?$", "?%", "?^",
                                  "?&", "?*", "?(", "?)", "?<", "?>", "?`", "?'", "?=", "?:", "?;", "?/", "?-", "?+", "?|", "?{", "?}", "?[",
                                  "?]", "`~", "`!", "`@", "`#", "`$", "`%", "`^", "`&", "`*", "`(", "`)", "`<", "`>", "`?", "`'", "`=", "`:",
                                  "`;", "`/", "`-", "`+", "`|", "`{", "`}", "`[", "`]", "'~", "'!", "'@", "'#", "'$", "'%", "'^", "'&", "'*",
                                  "'(", "')", "'<", "'>", "'?", "'`", "'=", "':", "';", "'/", "'-", "'+", "'|", "'{", "'}", "'[", "']", "=~",
                                  "=!", "=@", "=#", "=$",  "=^", "=*", "=(", "=)", "=<", "=>", "=?", "=`", "='", "=:", "=;",
                                  "=-", "=+", "=|", "={", "=}", "=[", "=]", ":~", ":!", ":@", ":#", ":$", ":%", ":^", ":&", ":*", ":(", ":)",
                                  ":<", ":>", ":?", ":`", ":'", ":=", ":;",  ":-", ":+", ":|", ":{", ":}", ":[", ":]", ";~", ";!", ";@",
                                  ";#", ";$", ";%", ";^", ";&", ";*", ";(", ";)", ";<", ";>", ";?", ";`", ";'", ";=", ";:", ";/", ";-", ";+",
                                  ";|", ";{", ";}", ";[", ";]", "/~", "/!", "/@", "/#", "/$",  "/^", "/&", "/*", "/(", "/)", "/<", "/>", "/?", "/`", "/'", "/=", "/:", "/;", "/-", "/+", "/|", "/{", "/}", "/[", "/]", "-~", "-!",  "-$", "-%", "-^", "-&", "-*", "-(", "-)", "-<", "->", "-?", "-`", "-'", "-=", "-:", "-;", "-/", "-+", "-{", "-}", "-[", "-]", "+~", "+!", "+@", "+#", "+$", "+%", "+^", "+&", "+*", "+(", "+)", "+<", "+>", "+?", "+`", "+'", "+=", "+:", "+;", "+/", "+-", "+|", "+{", "+}", "+[", "+]", "|~", "|!",  "|$", "|%", "|&", "|*", "|(", "|)", "|<", "|>", "|?", "|`", "|'", "|=", "|:", "|;", "|/", "|-", "|+", "|{", "|}", "|[", "|]", "{~", "{!", "{@", "{#", "{$", "{%", "{^", "{&", "{*", "{(", "{)", "{<", "{>", "{?", "{`", "{'", "{=", "{:", "{;", "{/", "{-", "{+", "{|", "{}", "{[", "{]", "}~", "}!", "}@", "}#", "}$", "}%", "}^", "}&", "}*", "}(", "})", "}<", "}>", "}?", "}`", "}'", "}=", "}:", "};", "}/", "}-", "}+", "}|", "}{", "}[", "}]", "[~", "[!", "[@", "[#", "[$", "[%", "[^", "[&", "[*", "[(", "[)", "[<", "[>", "[?", "[`", "['", "[=", "[:", "[;", "[/", "[-", "[+", "[|", "[{", "[}", "[]", "]~", "]!", "]@", "]#", "]$", "]%", "]^", "]&", "]*", "](", "])", "]<", "]>", "]?", "]`", "]'", "]=", "]:", "];", "]/", "]-", "]+", "]|", "]{", "]}", "][" };
            string[] HTMLorURLEncode = { "CENZIC123", "CENZIC456", "CENZIC", "./:;", ":;", "-./", ">?@", "{|}", "}~", "}~\\" };
            //"=",( ) ; " , "//"
            if (Request.HttpMethod == "GET")
            {
                // Below code blocks incoming HTTP GET requests which contains in query string parameters intended to be used in POST
                var hasPostParams = (Request.QueryString["__EVENTTARGET"] ??
                                       Request.QueryString["__VIEWSTATE"] ??
                                       Request.QueryString["__EVENTARGUMENT"] ??
                                       Request.QueryString["__EVENTVALIDATION"]) != null;

                if (hasPostParams)
                {
                    //Throwing an exception when the request is tampering
                    //
                    throw new HttpException(405, "No GET allowed for a POST");
                    //
                    //
                }
            }

            if (!String.IsNullOrEmpty("1"))
            {
                if (1 == 1)
                {
                    if (Request.HttpMethod == "POST")
                    {
                        foreach (string key in Request.Form.Keys)
                        {
                            string FormKey = Convert.ToString(Request.Form[key]).ToUpper() ?? "";

                            //if (Convert.ToString(Request.Form[key]).Contains("\")(") || Convert.ToString(Request.Form[key]).Contains("=*") || Convert.ToString(Request.Form[key]).Contains(")("))
                            foreach (string val in LDAParr)
                            {
                                if (FormKey.Contains(val.ToUpper()) && key != "__EVENTTARGET" && key != "__VSKEY" && key != "__EVENTVALIDATION" && key != "__VIEWSTATE" && key != "CSRFToken")
                                    throw new HttpException(400, "LDAP Injection Identified");
                            }

                            //foreach (string val in SQLArr)
                            //{
                            //    if (FormKey.Contains(val.ToUpper()) && key != "__EVENTTARGET" && key != "__VSKEY" && key != "__EVENTVALIDATION" && key != "__VIEWSTATE")
                            //        throw new HttpException(400, "Blind SQL Injection Identified");
                            //}

                            if (FormKey == "*" || FormKey == "&" || FormKey == "|" || FormKey == "%26" || FormKey == "/" || FormKey == "%7C")
                                throw new HttpException(400, "LDAP Injection Identified");
                        }
                        foreach (string key in Request.Form.Keys)
                        {
                            string FormKey = key == null ? "" : Convert.ToString(Request.Form[key]).Replace("%20", "").Replace(" ", "").ToUpper();
                            foreach (string val in LDAParr)
                            {
                                if ((FormKey.Contains(val)) && (key != "__EVENTTARGET" && key != "__VSKEY" && key != "__EVENTVALIDATION" && key != "__VIEWSTATE" && key != "CSRFToken"))
                                    throw new HttpException(400, "Blind SQL Injection Identified");

                                //Match _MMC = Regex.Match(FormKey.ToLower(), @"(\d+)(\sor\s)(\d+)=(\d+)");
                                //Match _MMC1 = Regex.Match(FormKey.ToLower(), @"(\d+)(\sand\s)(\d+)=(\d+)");
                                //Match _MMC2 = Regex.Match(FormKey.ToLower(), @"(\d+)(\=\s)(\d+)(\sand\s)(\d+)");
                                //Match _MMC3 = Regex.Match(FormKey.ToLower(), @"(\d+)(\=\s)(\d+)(\sor\s)(\d+)");
                                //if (_MMC.Success || _MMC1.Success || _MMC2.Success || _MMC3.Success)
                            }
                            if (
                                (
                                    (FormKey.Contains("AND") && FormKey.Contains("?") && FormKey.Contains("&") && FormKey.Contains("="))
                                    || (FormKey.Contains("OR ") && FormKey.Contains("="))
                                    || (FormKey.Contains("OR ") && FormKey.Contains("<>"))
                                    || (FormKey.Contains("OR ") && FormKey.Contains("<"))
                                    || (FormKey.Contains("OR ") && FormKey.Contains(">"))
                                    || (FormKey.Contains("OR ") && FormKey.Contains("LIKE"))
                                    || (FormKey.Contains("OR ") && FormKey.Contains("NULL"))
                                    || (FormKey.Contains(" OR") && FormKey.Contains("="))
                                    || (FormKey.Contains(" OR") && FormKey.Contains("<>"))
                                    || (FormKey.Contains(" OR") && FormKey.Contains("<"))
                                    || (FormKey.Contains(" OR") && FormKey.Contains(">"))
                                    || (FormKey.Contains(" OR") && FormKey.Contains("LIKE"))
                                    || (FormKey.Contains(" OR") && FormKey.Contains("NULL"))

                                   || (FormKey.Contains("AND ") && FormKey.Contains("<>"))
                                   || (FormKey.Contains("AND ") && FormKey.Contains("<"))
                                   || (FormKey.Contains("AND ") && FormKey.Contains(">"))
                                   || (FormKey.Contains("AND ") && FormKey.Contains("LIKE"))
                                   || (FormKey.Contains("AND ") && FormKey.Contains("NULL"))
                                   || (FormKey.Contains(" AND") && FormKey.Contains("<>"))
                                   || (FormKey.Contains(" AND") && FormKey.Contains("<"))
                                   || (FormKey.Contains(" AND") && FormKey.Contains(">"))
                                   || (FormKey.Contains(" AND") && FormKey.Contains("LIKE"))
                                   || (FormKey.Contains(" AND") && FormKey.Contains("NULL"))
                                   || (FormKey.Contains(" UNION") && FormKey.Contains("SELECT"))
                                   || (FormKey.Contains("UNION ") && FormKey.Contains("SELECT"))
                                )
                                &&
                                (
                                    key != "__EVENTTARGET"
                                 && key != "__VSKEY"
                                 && key != "__EVENTVALIDATION"
                                 && key != "__VIEWSTATE"
                                 && key != "CSRFToken")
                                )
                                throw new HttpException(400, "Blind SQL Injection Identified");
                        }
                        foreach (string key in Request.Form.Keys)
                        {
                            string FormKey = key == null ? "" : Request.Form[key].ToUpper();
                            foreach (string val in HTMLorURLEncode)
                            {
                                if (FormKey.Contains(val))
                                    throw new HttpException("HTMLorURLEncode Identified");
                            }
                        }
                    }
                    if (Request.HttpMethod == "POST" || Request.HttpMethod == "GET")
                    {
                        if (!string.IsNullOrEmpty(Request.Url.Query))
                        {
                            string URLQuery = Request.Url.Query ?? "";
                            if (Request.Url.AbsolutePath.Contains("ScriptResource.axd"))
                                return;
                            URLQuery = URLQuery.Replace("%20", "").Replace(" ", "").ToUpper();

                            //if (URLQuery.Contains("'or'") || URLQuery.Contains("'and'") || URLQuery.Contains("'='") || URLQuery.Contains("'") || URLQuery.Contains("\"") || URLQuery.Contains("%22"))
                            foreach (string val in SQLArr)
                            {
                                if (URLQuery.Contains(val.ToUpper()))
                                    throw new HttpException(400, "Blind SQL Injection Identified");
                            }

                            foreach (string val in LDAParr)
                            {
                                //if (URLQuery.Contains("\")(") || URLQuery.Contains("=*") || URLQuery.Contains("=*")
                                //    || URLQuery.Contains("%3d%2a") || URLQuery.Contains(")(") || URLQuery.Contains(")")
                                //    || URLQuery.Contains("(") || URLQuery.Contains("*!") || URLQuery.Contains("*|")
                                //    || URLQuery.Contains("/") || URLQuery.Contains("'") || URLQuery.Contains("!") ||
                                //    URLQuery.Contains("@*") || URLQuery.Contains("*|") || URLQuery.Contains("*/")
                                //    || URLQuery.Contains("/*") || URLQuery.Contains("%3D%2A") || URLQuery.Contains("/*"))
                                if (URLQuery.Contains(val.ToUpper()))
                                    throw new HttpException(400, "LDAP Injection Identified");
                            }

                            NameValueCollection Items = HttpUtility.ParseQueryString(URLQuery);
                            foreach (string QS in Items.AllKeys)
                            {
                                string QueryString = QS == null ? "" : QS.ToUpper();
                                string QSValue = QS == null ? "" : Items[QS].ToUpper();
                                if (QueryString == "*" || QSValue == "*" || QueryString == "&" || QSValue == "&" || QueryString == "%7C" || QSValue == "%7C" || QueryString == "%26" || QSValue == "%26" || QueryString == "|" || QSValue == "|")
                                    throw new HttpException(400, "LDAP Injection Identified");
                                if (QueryString == "*" || QSValue == "*" || QueryString == "?" || QSValue == "?" || QueryString == "&" || QSValue == "&" || QueryString == "&")
                                    throw new HttpException(400, "LDAP Injection Identified");
                                if (
                                     (
                                        (QSValue.Contains("AND") && QSValue.Contains("?") && QSValue.Contains("&") && QSValue.Contains("="))

                                    || (QSValue.Contains("OR ") && QSValue.Contains("="))
                                    || (QSValue.Contains("OR ") && QSValue.Contains("<>"))
                                    || (QSValue.Contains("OR ") && QSValue.Contains("<"))
                                    || (QSValue.Contains("OR ") && QSValue.Contains(">"))
                                    || (QSValue.Contains("OR ") && QSValue.Contains("LIKE"))
                                    || (QSValue.Contains("OR ") && QSValue.Contains("NULL"))
                                    || (QSValue.Contains(" OR") && QSValue.Contains("="))
                                    || (QSValue.Contains(" OR") && QSValue.Contains("<>"))
                                    || (QSValue.Contains(" OR") && QSValue.Contains("<"))
                                    || (QSValue.Contains(" OR") && QSValue.Contains(">"))
                                    || (QSValue.Contains(" OR") && QSValue.Contains("LIKE"))
                                    || (QSValue.Contains(" OR") && QSValue.Contains("NULL"))

                                   || (QSValue.Contains("AND ") && QSValue.Contains("<>"))
                                   || (QSValue.Contains("AND ") && QSValue.Contains("<"))
                                   || (QSValue.Contains("AND ") && QSValue.Contains(">"))
                                   || (QSValue.Contains("AND ") && QSValue.Contains("LIKE"))
                                   || (QSValue.Contains("AND ") && QSValue.Contains("NULL"))
                                   || (QSValue.Contains(" AND") && QSValue.Contains("<>"))
                                   || (QSValue.Contains(" AND") && QSValue.Contains("<"))
                                   || (QSValue.Contains(" AND") && QSValue.Contains(">"))
                                   || (QSValue.Contains(" AND") && QSValue.Contains("LIKE"))
                                   || (QSValue.Contains(" AND") && QSValue.Contains("NULL"))
                                   || (QSValue.Contains("UNION") && QSValue.Contains("SELECT"))
                                   || (QSValue.Contains("UNION ") && QSValue.Contains("SELECT"))


                                    )
                                  )
                                    throw new HttpException(400, "Blind SQL Injection Identified");
                                if ((QueryString.Contains("AND") && QueryString.Contains("=")) || (QueryString.Contains("OR") && QueryString.Contains("=")) || (QueryString.Contains("AND") && QueryString.Contains("LIKE")) || (QueryString.Contains("UNION") && QueryString.Contains("SELECT")) || (QueryString.Contains("OR") && QueryString.Contains("LIKE")))
                                    throw new HttpException(400, "Blind SQL Injection Identified");
                            }
                            foreach (string val in HTMLorURLEncode)
                            {
                                if (URLQuery.Contains(val.ToUpper()))
                                    throw new HttpException("HTMLorURLEncode Identified");
                            }
                        }
                    }
                }
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            SecPage LError = new SecPage();
            string ErrorURL = string.Empty;
            try
            {
                Exception ex = Server.GetLastError();
                ErrorURL = HttpContext.Current.Request.Path;
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["UserInfo"] != null)
                    IsSessionAvailable = true;
                UserName = IsSessionAvailable == true ? Convert.ToString(Session["UserInfo"]) : "";
                LError.LogError("Global - " + ErrorURL, "Application_Error", ex.Message.ToString().Replace("\r\n", ""), UserName, false);
            }
            catch (Exception exc)
            {
                //LError.LogError("Global" , "Application_Error_Ex", exc.Message.ToString().Replace("\r\n", ""), Session["UserInfo"].ToString(), false);
            }
            finally
            {
                Exception ex = Server.GetLastError();
                string InnerMsg = string.Empty;
                if (ex != null && ex.InnerException != null)
                    InnerMsg = ex.InnerException.Message;
                if (string.IsNullOrEmpty(InnerMsg))
                    InnerMsg = string.Empty;

                if (ex != null && ex.Message == "No GET allowed for a POST")
                {
                    HttpContext.Current.Server.ClearError();
                    HttpContext.Current.Response.StatusCode = (int)System.Net.HttpStatusCode.MethodNotAllowed;
                    HttpContext.Current.Response.AddHeader("Location", "~/UI/ErrorPage.aspx?ErrorURL=" + ErrorURL + "");
                    HttpContext.Current.Response.End();
                }
                else if (ex != null && (ex.Message == "Validation of Anti-XSRF token failed." || Convert.ToString(InnerMsg) == "Validation of Anti-XSRF token failed." || Convert.ToString(InnerMsg).Contains("Invalid postback or callback argument.")))
                {
                    HttpContext.Current.Server.ClearError();
                    HttpContext.Current.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    HttpContext.Current.Response.AddHeader("Location", "~/UI/ErrorPage.aspx?ErrorURL=" + ErrorURL + "");
                    HttpContext.Current.Response.End();
                }
                else if (ex != null && (Convert.ToString(InnerMsg) == "Restricted file upload" || ex.Message == "Restricted file upload"))
                {
                    HttpContext.Current.Server.ClearError();
                    HttpContext.Current.Response.StatusCode = (int)System.Net.HttpStatusCode.NotAcceptable;
                    HttpContext.Current.Response.AddHeader("Location", "~/UI/ErrorPage.aspx?ErrorURL=" + ErrorURL + "");
                    HttpContext.Current.Response.End();
                }
                else if (ex != null && (Convert.ToString(InnerMsg) == "LDAP Injection Identified" || ex.Message == "LDAP Injection Identified" || Convert.ToString(InnerMsg) == "Blind SQL Injection Identified" || ex.Message == "Blind SQL Injection Identified"))
                {
                    HttpContext.Current.Server.ClearError();
                    HttpContext.Current.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    HttpContext.Current.Response.AddHeader("Location", "~/UI/ErrorPage.aspx?ErrorURL=" + ErrorURL + "");
                    HttpContext.Current.Response.End();
                }
                else
                {
                    HttpContext.Current.Server.ClearError();
                    HttpContext.Current.Response.Redirect("~/UI/ErrorPage.aspx?ErrorURL=" + ErrorURL + "", false); //Redirecting to error page with URL
                }
            }
            //Exception exception = Server.GetLastError();
            //Server.Transfer("~/UI/ErrorPage.aspx", false);
            //if (exception is HttpUnhandledException)
            //{
            //    if (exception.InnerException == null)
            //    {
            //        Server.Transfer("~/UI/ErrorPage.aspx", false);
            //        return;
            //    }
            //    exception = exception.InnerException;
            //}

            //if (exception is HttpException)
            //{
            //    if (((HttpException)exception).GetHttpCode() == 404)
            //    {

            //        // Log if wished.
            //        Server.ClearError();
            //        Server.Transfer("~/UI/ErrorPage.aspx", false);
            //        return;
            //    }
            //}

            //if (Context != null && Context.IsCustomErrorEnabled)
            //    Server.Transfer("~/UI/ErrorPage.aspx", false);

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}