using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GTKUtilites.SessionUtils
{
   public class SessionObjects 
    {
        private static SessionObjects _self = new SessionObjects();

        public static SessionObjects obj
        {
            get
            {
                return _self;
            }
        }


       public List<LOVInputData> LOVInputDataObject
        {
            get
            {
                if (HttpContext.Current.Session["LOVInputDataObject"] == null)
                {
                    List<LOVInputData> _self = new List<LOVInputData>();

                    for (int i = 0; i < SessionObjects.obj.GlobalPropertiesObject.LOVInputSize; i++)
                    {
                        _self.Add(new LOVInputData());
                    }
                    HttpContext.Current.Session.Add("LOVInputDataObject", _self);
                }
                return (List<LOVInputData>)HttpContext.Current.Session["LOVInputDataObject"];
            }
            set 
            {
                HttpContext.Current.Session.Add("LOVInputDataObject", value);
            }
        }

        public List<PagingParameters> PagingParametersObject
        {
            get
            {
                if (HttpContext.Current.Session["PagingParametersObject"] == null)
                {
                     List<PagingParameters> _self;

                     _self = new List<PagingParameters>();

                     for (int i = 0; i < SessionObjects.obj.GlobalPropertiesObject.PagingInputSize; i++)
                     {
                         _self.Add(new PagingParameters());
                     }

                     HttpContext.Current.Session.Add("PagingParametersObject", _self);
                }
                return (List<PagingParameters>)HttpContext.Current.Session["PagingParametersObject"];
            }
            set
            {
                HttpContext.Current.Session.Add("PagingParametersObject", value);
            }
        }       

        public GlobalProperties GlobalPropertiesObject
        {
            get
            {
                if (HttpContext.Current.Session["GlobalPropertiesObject"] == null)
                {
                    HttpContext.Current.Session.Add("GlobalPropertiesObject", new GlobalProperties());
                }
                return (GlobalProperties)HttpContext.Current.Session["GlobalPropertiesObject"];
            }
            set
            {
                HttpContext.Current.Session.Add("GlobalPropertiesObject", value);
            }
        }

        public RequestTypeMasterProperties RequestTypeMasterPropertiesObject
        {
            get
            {
                if (HttpContext.Current.Session["RequestTypeMasterPropertiesObject"] == null)
                {
                    HttpContext.Current.Session.Add("RequestTypeMasterPropertiesObject", new RequestTypeMasterProperties());
                }
                return (RequestTypeMasterProperties)HttpContext.Current.Session["RequestTypeMasterPropertiesObject"];
            }
            set
            {
                HttpContext.Current.Session.Add("RequestTypeMasterPropertiesObject", value);
            }
        }

        public SolicitationResponseProperties SolicitationResponsePropertiesObject
        {
            get
            {
                if (HttpContext.Current.Session["SolicitationResponsePropertiesObject"] == null)
                {
                    HttpContext.Current.Session.Add("SolicitationResponsePropertiesObject", new SolicitationResponseProperties());
                }
                return (SolicitationResponseProperties)HttpContext.Current.Session["SolicitationResponsePropertiesObject"];
            }
            set
            {
                HttpContext.Current.Session.Add("SolicitationResponsePropertiesObject", value);
            }
        }          
        public FilterProperties FilterPropertiesObject
        {
            get
            {
                if (HttpContext.Current.Session["FilterPropertiesObject"] == null)
                {
                    HttpContext.Current.Session.Add("FilterPropertiesObject", new FilterProperties());
                }
                return (FilterProperties)HttpContext.Current.Session["FilterPropertiesObject"];
            }
            set
            {
                HttpContext.Current.Session.Add("FilterPropertiesObject", value);
            }
        }
        public DeniedPartyClass DeniedPartyClassObject
        {
            get
            {
                if (HttpContext.Current.Session["DeniedPartyClassObject"] == null)
                {
                    HttpContext.Current.Session.Add("DeniedPartyClassObject", new DeniedPartyClass());
                }
                return (DeniedPartyClass)HttpContext.Current.Session["DeniedPartyClassObject"];
            }
            set
            {
                HttpContext.Current.Session.Add("DeniedPartyClassObject", value);
            }
        }

        public CCSummaryProperties CCSummaryPropertiesObject
        {
            get
            {
                if (HttpContext.Current.Session["CCSummaryPropertiesObject"] == null)
                {
                    HttpContext.Current.Session.Add("CCSummaryPropertiesObject", new CCSummaryProperties());
                }
                return (CCSummaryProperties)HttpContext.Current.Session["CCSummaryPropertiesObject"];
            }
            set
            {
                HttpContext.Current.Session.Add("CCSummaryPropertiesObject", value);
            }
        }
        public PropertiesObject PropertiesObject1
        {
            get
            {
                if (HttpContext.Current.Session["PropertiesObject1"] == null)
                {
                    HttpContext.Current.Session.Add("PropertiesObject1", new PropertiesObject());
                }
                return (PropertiesObject)HttpContext.Current.Session["PropertiesObject1"];
            }
            set
            {
                HttpContext.Current.Session.Add("PropertiesObject1", value);
            }
        }
        public ZnRcptSummaryProperties ZnRcptSummaryPropertiesObject
        {
            get
            {
                if (HttpContext.Current.Session["ZnRcptSummaryPropertiesObject"] == null)
                {
                    HttpContext.Current.Session.Add("ZnRcptSummaryPropertiesObject", new ZnRcptSummaryProperties());
                }
                return (ZnRcptSummaryProperties)HttpContext.Current.Session["ZnRcptSummaryPropertiesObject"];
            }
            set
            {
                HttpContext.Current.Session.Add("ZnRcptSummaryPropertiesObject", value);
            }
        }
        public ViewInventiryProperties ViewInventiryPropertiesObject
        {
            get
            {
                if (HttpContext.Current.Session["ViewInventiryPropertiesObject"] == null)
                {
                    HttpContext.Current.Session.Add("ViewInventiryPropertiesObject", new ViewInventiryProperties());
                }
                return (ViewInventiryProperties)HttpContext.Current.Session["ViewInventiryPropertiesObject"];
            }
            set
            {
                HttpContext.Current.Session.Add("ViewInventiryPropertiesObject", value);
            }
        }
        public Validate ValidateObject
        {
            get
            {
                if (HttpContext.Current.Session["ValidateObject"] == null)
                {
                    HttpContext.Current.Session.Add("ValidateObject", new Validate());
                }
                return (Validate)HttpContext.Current.Session["ValidateObject"];
            }
            set
            {
                HttpContext.Current.Session.Add("ValidateObject", value);
            }
        }

        public CTPATProperties CTPATPropertiesObject
        {
            get
            {
                if (HttpContext.Current.Session["CTPATPropertiesObject"] == null)
                {
                    HttpContext.Current.Session.Add("CTPATPropertiesObject", new CTPATProperties());
                }
                return (CTPATProperties)HttpContext.Current.Session["CTPATPropertiesObject"];
            }
            set
            {
                HttpContext.Current.Session.Add("CTPATPropertiesObject", value);
            }
        }

        public ViewScreens_Properties ViewScreens_PropertiesObject
        {
            get
            {
                if (HttpContext.Current.Session["ViewScreens_PropertiesObject"] == null)
                {
                    HttpContext.Current.Session.Add("ViewScreens_PropertiesObject", new ViewScreens_Properties());
                }
                return (ViewScreens_Properties)HttpContext.Current.Session["ViewScreens_PropertiesObject"];
            }
            set
            {
                HttpContext.Current.Session.Add("ViewScreens_PropertiesObject", value);
            }
        }


        public List<ADHRepProperties> ADHRepPropertiesObject
        {
            get
            {
                if (HttpContext.Current.Session["MasterADHRepPropertiesObject"] == null)
                {
                    List<ADHRepProperties> _self;

                    _self = new List<ADHRepProperties>();

                    for (int i = 0; i < SessionObjects.obj.GlobalPropertiesObject.ADHRepInputSize; i++)
                    {
                        _self.Add(new ADHRepProperties());
                    }

                    HttpContext.Current.Session.Add("MasterADHRepPropertiesObject", _self);
                }
                return (List<ADHRepProperties>)HttpContext.Current.Session["MasterADHRepPropertiesObject"];
            }
            set
            {
                HttpContext.Current.Session.Add("MasterADHRepPropertiesObject", value);
            }
        }

        public List<RPTProperties> RPTPropertiesObject
        {
            get
            {
                if (HttpContext.Current.Session["MasterRPTPropertiesObject"] == null)
                {
                    List<RPTProperties> _self = new List<RPTProperties>();

                    for (int i = 0; i < SessionObjects.obj.GlobalPropertiesObject.RPTInputSize; i++)
                    {
                        _self.Add(new RPTProperties());
                    }
                    HttpContext.Current.Session.Add("MasterRPTPropertiesObject", _self);
                }
                return (List<RPTProperties>)HttpContext.Current.Session["MasterRPTPropertiesObject"];
            }
            set
            {
                HttpContext.Current.Session.Add("MasterRPTPropertiesObject", value);
            }
        }

        public string GTKOrgID
        {
            get
            {
                if (HttpContext.Current.Session["GTKOrgID"] == null)
                    return null;
                else
                    return (string)HttpContext.Current.Session["GTKOrgID"];
            }
            set
            {
                HttpContext.Current.Session.Add("GTKOrgID", value);
            }
        }

    }
}
