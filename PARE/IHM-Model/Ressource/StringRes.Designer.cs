﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IHM_Model.Ressource {
    using System;
    
    
    /// <summary>
    ///   Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    /// </summary>
    // Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    // à l'aide d'un outil, tel que ResGen ou Visual Studio.
    // Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    // avec l'option /str ou régénérez votre projet VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class StringRes {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringRes() {
        }
        
        /// <summary>
        ///   Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("IHM_Model.Ressource.StringRes", typeof(StringRes).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Remplace la propriété CurrentUICulture du thread actuel pour toutes
        ///   les recherches de ressources à l'aide de cette classe de ressource fortement typée.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Error when adding the teacher.
        /// </summary>
        internal static string ErrorAddTeacher {
            get {
                return ResourceManager.GetString("ErrorAddTeacher", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Error during update the module.
        /// </summary>
        internal static string ErrorMAJModule {
            get {
                return ResourceManager.GetString("ErrorMAJModule", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Error during update the teacher.
        /// </summary>
        internal static string ErrorMAJTeacher {
            get {
                return ResourceManager.GetString("ErrorMAJTeacher", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à Error during the add of the teacher.
        /// </summary>
        internal static string ErrorTeacher {
            get {
                return ResourceManager.GetString("ErrorTeacher", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The teacher’s assigned hours are negative and cannot be validated..
        /// </summary>
        internal static string HourNegative {
            get {
                return ResourceManager.GetString("HourNegative", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The hours assigned to the teacher must be less than or equal to the program hours..
        /// </summary>
        internal static string HourProgram {
            get {
                return ResourceManager.GetString("HourProgram", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The start week cannot be equal than the end week.
        /// </summary>
        internal static string SameWeekBeginEnd {
            get {
                return ResourceManager.GetString("SameWeekBeginEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à the begin week should be between 2 ans 14.
        /// </summary>
        internal static string SemesterEven {
            get {
                return ResourceManager.GetString("SemesterEven", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The begin week should be between 35 and 53.
        /// </summary>
        internal static string WeekBegin {
            get {
                return ResourceManager.GetString("WeekBegin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The begin week cannot be longer than the end week.
        /// </summary>
        internal static string WeekBeginAfterWeekEnd {
            get {
                return ResourceManager.GetString("WeekBeginAfterWeekEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Recherche une chaîne localisée semblable à The end week should be between 35 and 53.
        /// </summary>
        internal static string WeekEnd {
            get {
                return ResourceManager.GetString("WeekEnd", resourceCulture);
            }
        }
    }
}
