﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FOSCBot.Core.Resources {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class CoreResources {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CoreResources() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("FOSCBot.Core.Domain.Resources.CoreResources", typeof(CoreResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static string AboutText {
            get {
                return ResourceManager.GetString("AboutText", resourceCulture);
            }
        }
        
        internal static string HeyBroImage {
            get {
                return ResourceManager.GetString("HeyBroImage", resourceCulture);
            }
        }
        
        internal static string IpadAudio {
            get {
                return ResourceManager.GetString("IpadAudio", resourceCulture);
            }
        }
        
        internal static string LigmaSoftAudio {
            get {
                return ResourceManager.GetString("LigmaSoftAudio", resourceCulture);
            }
        }
        
        internal static string LigmaHardAudio {
            get {
                return ResourceManager.GetString("LigmaHardAudio", resourceCulture);
            }
        }
        
        internal static string NginxImage {
            get {
                return ResourceManager.GetString("NginxImage", resourceCulture);
            }
        }
        
        internal static string StartText {
            get {
                return ResourceManager.GetString("StartText", resourceCulture);
            }
        }
    }
}
