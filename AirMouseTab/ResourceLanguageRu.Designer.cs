﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirMouseTab {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ResourceLanguageRu {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceLanguageRu() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AirMouseTab.ResourceLanguageRu", typeof(ResourceLanguageRu).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
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
        ///   Ищет локализованную строку, похожую на По умолчанию.
        /// </summary>
        internal static string buttonDefault {
            get {
                return ResourceManager.GetString("buttonDefault", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Сгенерировать.
        /// </summary>
        internal static string buttonGenerate {
            get {
                return ResourceManager.GetString("buttonGenerate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Программа предназначена для управления компьютером через Wi-Fi с помощью мобильного устройства.
        ///Введите перечисленные ниже значения на смартфоне или планшете..
        /// </summary>
        internal static string labelHeader {
            get {
                return ResourceManager.GetString("labelHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на IP-адрес.
        /// </summary>
        internal static string labelIp {
            get {
                return ResourceManager.GetString("labelIp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Выберите первый из предложенных адресов. Если не удаётся подключиться выберите другой..
        /// </summary>
        internal static string labelIpInfo {
            get {
                return ResourceManager.GetString("labelIpInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на ПИН-код.
        /// </summary>
        internal static string labelPIN {
            get {
                return ResourceManager.GetString("labelPIN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Порт.
        /// </summary>
        internal static string labelPort {
            get {
                return ResourceManager.GetString("labelPort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Перезапустите программу, чтобы использовать выбранный язык..
        /// </summary>
        internal static string messageChangeLanguage {
            get {
                return ResourceManager.GetString("messageChangeLanguage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Недопустимое значение для PIN кода. Выберите из диапазона от 100000 до 999000000.
        /// </summary>
        internal static string messageErrorPin {
            get {
                return ResourceManager.GetString("messageErrorPin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Недопустимое значение порта. Выберите из диапазона от 1024 до 65535.
        /// </summary>
        internal static string messageErrorPort {
            get {
                return ResourceManager.GetString("messageErrorPort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Старт.
        /// </summary>
        internal static string stateConnect {
            get {
                return ResourceManager.GetString("stateConnect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Стоп.
        /// </summary>
        internal static string stateStop {
            get {
                return ResourceManager.GetString("stateStop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Ожидание.
        /// </summary>
        internal static string stateWait {
            get {
                return ResourceManager.GetString("stateWait", resourceCulture);
            }
        }
    }
}
