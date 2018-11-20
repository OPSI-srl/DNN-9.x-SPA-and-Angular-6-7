using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Web;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.Localization;
using DotNetNuke.Services.Tokens;
using DotNetNuke.UI.Modules;
using Newtonsoft.Json;

namespace AngularNGMD.Controller
{
    public class ModulePropertiesPropertyAccess : IPropertyAccess
    {
        private ModuleInstanceContext _moduleContext;

        public ModulePropertiesPropertyAccess(ModuleInstanceContext moduleContext)
        {
            _moduleContext = moduleContext;
        }

        public string GetProperty(string propertyName, string format, CultureInfo formatProvider, UserInfo accessingUser, Scope accessLevel, ref bool propertyNotFound)
        {
            string retVal = "";

            int moduleId = _moduleContext.ModuleId;
            int portalId = _moduleContext.PortalId;
            int tabId = _moduleContext.TabId;
            ModuleInfo module = new ModuleController().GetModule(moduleId, tabId);

            string moduleDirectory = "/" + _moduleContext.Configuration.ModuleControl.ControlSrc; // ControlSrc;
            moduleDirectory = moduleDirectory.Substring(0, moduleDirectory.LastIndexOf('/') + 1);

            switch (propertyName.ToLower())
            {
                case "all":
                    dynamic properties = new ExpandoObject();
                    properties.Resources = GetResources(module);
                    properties.Settings = _moduleContext.Settings;
                    properties.IsEditable = _moduleContext.IsEditable;
                    properties.EditMode = _moduleContext.EditMode;
                    properties.IsAdmin = accessingUser.IsInRole(PortalSettings.Current.AdministratorRoleName);
                    properties.ModuleId = _moduleContext.ModuleId;
                    properties.PortalId = _moduleContext.PortalId;
                    properties.UserId = accessingUser.UserID;
                    properties.HomeDirectory = PortalSettings.Current.HomeDirectory.Substring(1);
                    properties.ModuleDirectory = moduleDirectory;
                    properties.RawUrl = HttpContext.Current.Request.RawUrl;
                    properties.PortalLanguages = GetPortalLanguages();
                    properties.CurrentLanguage = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
                    properties.Users = UserController.GetUsers(_moduleContext.PortalId).Cast<UserInfo>().Select(u => new { text = u.Username, id = u.UserID }).ToList();
                    return JsonConvert.SerializeObject(properties);

                case "modulepath":
                    return moduleDirectory;
                case "approotangularbegin":
                    return "<app-root-" + moduleId + ">";
                case "approotangularend":
                    return "</app-root-" + moduleId + ">";
                case "ModuleId":
                    return _moduleContext.ModuleId.ToString();
                case "rawurl":
                    return HttpContext.Current.Request.RawUrl;
                case "test":
                    return "test";

            }
            return "";
        }

        public CacheLevel Cacheability
        {
            get { return CacheLevel.notCacheable; }
        }

        private Dictionary<string, string> GetResources(ModuleInfo module)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(HttpContext.Current.Server.MapPath("~/" + _moduleContext.Configuration.ModuleControl.ControlSrc + ".resx"));
            string physResourceFile = fi.DirectoryName + "/App_LocalResources/" + fi.Name;
            string relResourceFile = "/DesktopModules/" + module.DesktopModule.FolderName + "/App_LocalResources/" + fi.Name;
            if (File.Exists(physResourceFile))
            {
                using (var rsxr = new ResXResourceReader(physResourceFile))
                {
                    var res = rsxr.OfType<DictionaryEntry>()
                        .ToDictionary(
                            entry => entry.Key.ToString().Replace(".", "_"),
                            entry => Localization.GetString(entry.Key.ToString(), relResourceFile));

                    return res;
                }
            }
            return new Dictionary<string, string>();
        }

        private List<string> GetPortalLanguages()
        {
            List<string> languages = new List<string>();
            LocaleController lc = new LocaleController();
            Dictionary<string, Locale> loc = lc.GetLocales(_moduleContext.PortalId);
            foreach (KeyValuePair<string, Locale> item in loc)
            {
                string cultureCode = item.Value.Culture.Name;
                languages.Add(cultureCode);
            }
            return languages;
        }
    }
}