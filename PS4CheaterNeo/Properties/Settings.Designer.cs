﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PS4CheaterNeo.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.0.3.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("|1_General|1_Connect|Enter PS4 IP location")]
        public global::OptionTreeView.Option<string> PS4IP {
            get {
                return ((global::OptionTreeView.Option<string>)(this["PS4IP"]));
            }
            set {
                this["PS4IP"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("9021|1_General|1_Connect|Enter PS4 Port")]
        public global::OptionTreeView.Option<ushort> PS4Port {
            get {
                return ((global::OptionTreeView.Option<ushort>)(this["PS4Port"]));
            }
            set {
                this["PS4Port"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("|1_General|1_SendPayload|Enter PS4 FW Version (Confirm the fw version only when p" +
            "erform sendpayload)")]
        public global::OptionTreeView.Option<string> PS4FWVersion {
            get {
                return ((global::OptionTreeView.Option<string>)(this["PS4FWVersion"]));
            }
            set {
                this["PS4FWVersion"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True|2_Cheat|2_Cheat|Determine whether to enable verifying Section values when lo" +
            "cking cheat items. Default enabled")]
        public global::OptionTreeView.Option<bool> VerifySectionWhenLock {
            get {
                return ((global::OptionTreeView.Option<bool>)(this["VerifySectionWhenLock"]));
            }
            set {
                this["VerifySectionWhenLock"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True|2_Cheat|2_Cheat|Determine whether to enable verifying Section values when re" +
            "freshing the cheat list. Default enabled")]
        public global::OptionTreeView.Option<bool> VerifySectionWhenRefresh {
            get {
                return ((global::OptionTreeView.Option<bool>)(this["VerifySectionWhenRefresh"]));
            }
            set {
                this["VerifySectionWhenRefresh"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True|3_Query|1_Query|Determine whether to enable automatic perform get processes " +
            "when opening the Query window. Default enabled")]
        public global::OptionTreeView.Option<bool> AutoPerformGetProcesses {
            get {
                return ((global::OptionTreeView.Option<bool>)(this["AutoPerformGetProcesses"]));
            }
            set {
                this["AutoPerformGetProcesses"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("eboot.bin|3_Query|1_Query|Set the default selected program when perform get proce" +
            "sses. Default is eboot.bin")]
        public global::OptionTreeView.Option<string> DefaultProcess {
            get {
                return ((global::OptionTreeView.Option<string>)(this["DefaultProcess"]));
            }
            set {
                this["DefaultProcess"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3|3_Query|1_Query|Enter the number of threads to use when querying. Default is 3 " +
            "threads")]
        public global::OptionTreeView.Option<byte> MaxQueryThreads {
            get {
                return ((global::OptionTreeView.Option<byte>)(this["MaxQueryThreads"]));
            }
            set {
                this["MaxQueryThreads"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True|3_Query|2_Filter|Determine whether to enable filtering Sections when opening" +
            " the query window. Default enabled")]
        public global::OptionTreeView.Option<bool> EnableFilterQuery {
            get {
                return ((global::OptionTreeView.Option<bool>)(this["EnableFilterQuery"]));
            }
            set {
                this["EnableFilterQuery"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("libSce,libc.prx,SceShell,SceLib,SceNp,SceVoice,SceFios,libkernel,SceVdec|3_Query|" +
            "2_Filter|Enter the filter value, the filter will be set here when listing Sectio" +
            "ns")]
        public global::OptionTreeView.Option<string> SectionFilterKeys {
            get {
                return ((global::OptionTreeView.Option<string>)(this["SectionFilterKeys"]));
            }
            set {
                this["SectionFilterKeys"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0x2000|3_Query|3_Result|Enter the maximum number of displayed query results. will" +
            " only affect the number of results displayed in the ResultView. Default value is" +
            " 8192")]
        public global::OptionTreeView.Option<uint> MaxResultShow {
            get {
                return ((global::OptionTreeView.Option<uint>)(this["MaxResultShow"]));
            }
            set {
                this["MaxResultShow"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("204800|3_Query|2_Filter|Filter out when section size is less than this value(unit" +
            " is bytes)")]
        public global::OptionTreeView.Option<uint> SectionFilterSize {
            get {
                return ((global::OptionTreeView.Option<uint>)(this["SectionFilterSize"]));
            }
            set {
                this["SectionFilterSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False|3_Query|2_Filter|Determine whether to enable filtering Sections by size whe" +
            "n opening the query window. Default disabled")]
        public global::OptionTreeView.Option<bool> EnableFilterSizeQuery {
            get {
                return ((global::OptionTreeView.Option<bool>)(this["EnableFilterSizeQuery"]));
            }
            set {
                this["EnableFilterSizeQuery"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"50|3_Query|1_Query|Set the minimum buffer size (in MB) in querying and pointerFinder, enter 0 to not use buffer, setting this value to 0 is better when the total number of Sections in the game is low. If the game has more than a thousand Sections, Buffer must be set")]
        public global::OptionTreeView.Option<uint> QueryBufferSize {
            get {
                return ((global::OptionTreeView.Option<uint>)(this["QueryBufferSize"]));
            }
            set {
                this["QueryBufferSize"] = value;
            }
        }
    }
}
