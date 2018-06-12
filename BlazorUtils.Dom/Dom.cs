using BlazorUtils.Dom.Storages;
using BlazorUtils.Interfaces;
using Microsoft.AspNetCore.Blazor;
using System;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Blazor.Browser.Interop.RegisteredFunction;

namespace BlazorUtils.Dom
{
    public class Dom : IDom
    {
        private readonly string _selector;

        public Dom(string selector)
        {
            _selector = selector;
        }

        public IDom Toggle()
        {
            Invoke<object>("LMTDomToggle", _selector);
            return this;
        }

        public string Text()
        {
            return Invoke<string>("LMTDomText2", _selector);
        }

        public IDom Text(string text)
        {
            Invoke<object>("LMTDomText", _selector, text);
            return this;
        }

        public string Css(string propertyName)
        {
            return Invoke<string>("LMTDomCss2", _selector, propertyName);
        }

        public IDom Css(string propertyName, string value)
        {
            Invoke<object>("LMTDomCss", _selector, propertyName, value);
            return this;
        }

        public async Task<IDom> Animate(object properties, int duration = 400, string easing = "swing", Action complete = null)
        {
            Invoke<object>("LMTAnimate", _selector, properties, duration, easing);
            // ReSharper disable once InvertIf
            if (complete != null)
            {
                await Task.Delay(duration);
                complete.Invoke();
            }

            return this;
        }

        public IDom Animate(object properties, object options)
        {
            Invoke<object>("LMTAnimateOptions", _selector, properties, options);
            return this;
        }

        public IDom On(string events, Action<UIEventArgs> handler)
        {
            var id = UICallBacksStorage.Add(events, _selector, handler);
            Invoke<object>("LMTOn", _selector, events, id);
            return this;
        }

        public IDom Add(string arg)
        {
            Invoke<object>("LMTAdd", _selector, arg);
            return this;
        }

        #region CSS

        public double Height()
        {
            return Invoke<double>("LMTHeight2", _selector);
        }

        public IDom Height(double value)
        {
            Invoke<object>("LMTHeight", _selector, value);
            return this;
        }

        public IDom Height(Func<int, int, string> function)
        {
            var id = IntIntStringStorage.Add(function);
            Invoke<object>("LMTHeightFunc2", _selector, id);
            return this;
        }

        public IDom Height(Func<int, int, double> function)
        {
            var id = IntIntDoubleStorage.Add(function);
            Invoke<object>("LMTHeightFunc1", _selector, id);
            return this;
        }

        public double InnerHeight()
        {
            return Invoke<double>("LMTInnerHeight2", _selector);
        }

        public IDom InnerHeight(double value)
        {
            Invoke<object>("LMTInnerHeight", _selector, value);
            return this;
        }

        public IDom InnerHeight(string value)
        {
            Invoke<object>("LMTInnerHeight", _selector, value);
            return this;
        }

        public IDom InnerHeight(Func<int, double, string> function)
        {
            var id = IntDoubleStringStorage.Add(function);
            Invoke<object>("LMTInnerHeightFunc1", _selector, id);
            return this;
        }

        public IDom InnerHeight(Func<int, double, double> function)
        {
            var id = IntDoubleDoubleStorage.Add(function);
            Invoke<object>("LMTInnerHeightFunc2", _selector, id);
            return this;
        }

        public double Width()
        {
            return Invoke<double>("LMTWidth2", _selector);
        }

        public IDom Width(double value)
        {
            Invoke<object>("LMTWidth", _selector, value);
            return this;
        }

        public IDom Width(string value)
        {
            Invoke<object>("LMTWidth", _selector, value);
            return this;
        }

        public IDom Width(Func<int, int, string> function)
        {
            var id = IntIntStringStorage.Add(function);
            Invoke<object>("LMTWidthFunc1", _selector, id);
            return this;
        }

        public IDom Width(Func<int, int, double> function)
        {
            var id = IntIntDoubleStorage.Add(function);
            Invoke<object>("LMTWidthFunc2", _selector, id);
            return this;
        }

        public double InnerWidth()
        {
            return Invoke<double>("LMTInnerWidth2", _selector);
        }

        public IDom InnerWidth(double value)
        {
            Invoke<object>("LMTInnerWidth", _selector, value);
            return this;
        }

        public IDom InnerWidth(string value)
        {
            Invoke<object>("LMTInnerWidth", _selector, value);
            return this;
        }

        public IDom InnerWidth(Func<int, double, string> function)
        {
            var id = IntDoubleStringStorage.Add(function);
            Invoke<object>("LMTInnerWidthFunc1", _selector, id);
            return this;
        }

        public IDom InnerWidth(Func<int, double, double> function)
        {
            var id = IntDoubleDoubleStorage.Add(function);
            Invoke<object>("LMTInnerWidthFunc2", _selector, id);
            return this;
        }

        public Coordinate Offset()
        {
            return Invoke<Coordinate>("LMTOffset2", _selector);
        }

        public IDom Offset(Coordinate coordinates)
        {
            Invoke<object>("LMTOffset", _selector, coordinates);
            return this;
        }

        public IDom Offset(Func<int, Coordinate, Coordinate> function)
        {
            var id = IntCoordsCoordsStorage.Add(function);
            Invoke<object>("LMTOffsetFunc", _selector, id);
            return this;
        }

        #endregion

        #region Attributes
        public IDom AddClass(string className)
        {
            Invoke<object>("LMTAddClass", _selector, className);
            return this;
        }

        public bool HasClass(string className)
        {
            return Invoke<bool>("LMTHasClass", _selector, className);
        }

        public string Html()
        {
            return Invoke<string>("LMTHtml", _selector);
        }

        public T Prop<T>(string propertyName)
        {
            return Invoke<T>("LMTProp", _selector, propertyName);
        }

        public IDom RemoveAttr(string attributeName)
        {
            Invoke<object>("LMTRemoveAttr", _selector, attributeName);
            return this;
        }

        public IDom RemoveClass(string className)
        {
            Invoke<object>("LMTRemoveClass", _selector, className);
            return this;
        }

        public IDom RemoveClass(Func<int, string, string> function)
        {
            var id = IntStringStringStorage.Add(function);
            Invoke<object>("LMTRemoveClassFunc", _selector, id);
            return this;
        }

        public IDom RemoveProp(string propertyName)
        {
            Invoke<object>("LMTRemoveProp", _selector, propertyName);
            return this;
        }

        public IDom ToggleClass(string className)
        {
            Invoke<object>("LMTToggleClass1", _selector, className);
            return this;
        }

        public IDom ToggleClass(string className, bool state)
        {
            Invoke<object>("LMTToggleClass2", _selector, className, state);
            return this;
        }

        public IDom ToggleClass(Func<int, string, string> function)
        {
            var id = IntStringStringStorage.Add(function);
            Invoke<object>("LMTToggleClass3", _selector, id);
            return this;
        }

        public IDom ToggleClass(Func<int, string, string> function, bool state)
        {
            var id = IntStringStringStorage.Add(function);
            Invoke<object>("LMTToggleClass4", _selector, id, state);
            return this;
        }

        public IDom Attr(string attribute, string value)
        {
            Invoke<bool>("LMTDomAttr", _selector, attribute, value);
            return this;
        }

        public string Attr(string attribute)
        {
            return Invoke<string>("LMTDomAttr2", _selector, attribute);
        }

        public string Val()
        {
            return Invoke<string>("LMTDomVal2", _selector);
        }

        public IDom Val(string value)
        {
            Invoke<object>("LMTDomVal", _selector, value);
            return this;
        }
        #endregion
    }
}
