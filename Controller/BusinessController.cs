using System.Web.UI;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;
using DotNetNuke.UI.Modules;
using System.Collections.Generic;

namespace AngularNGMD.Controller
{
    /// ----------------------------------------------------------------------------- 
    /// <summary> 
    /// The Businesscontroller class for Angularmodule
    /// </summary> 
    /// ----------------------------------------------------------------------------- 
    //[DNNtc.BusinessControllerClass()]
    public class BusinessController : ICustomTokenProvider
    {
        private static BusinessController _instance;

        public static BusinessController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BusinessController();
                }
                return _instance;
            }
        }


        public IDictionary<string, IPropertyAccess> GetTokens(Page page, ModuleInstanceContext moduleContext)
        {
            var tokens = new Dictionary<string, IPropertyAccess>();
            tokens["moduleproperties"] = new ModulePropertiesPropertyAccess(moduleContext);
            return tokens;
        }
    }
}
