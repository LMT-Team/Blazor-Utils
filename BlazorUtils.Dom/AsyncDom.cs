#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using BlazorUtils.Dom.Storages;
using BlazorUtils.Interfaces;
using BlazorUtils.Interfaces.EventArgs;
using System;
using System.Threading.Tasks;
using static BlazorUtils.Interfaces.Invokers.JsInvoke;

namespace BlazorUtils.Dom
{
    ///<inheritdoc cref = "IDom" />
    public class AsyncDom : IAsyncDom
    {
        private readonly string _selector;
        private IDom _dom;

        /// <summary>
        /// Initialize async DOM with a selector string.
        /// </summary>
        /// <param name="selector">DOM Selector string.</param>
        internal AsyncDom(string selector)
        {
            _selector = selector;
        }

        /// <summary>
        /// Initialize async DOM with a selector string.
        /// </summary>
        /// <param name="dom">Dom object for singleton converting method.</param>
        /// <param name="selector">DOM Selector string.</param>
        internal AsyncDom(Dom dom, string selector)
        {
            _dom = dom;
            _selector = selector;
        }

        public async Task<IAsyncDom> Add(string selector)
        {
            await InvokeAsync<object>("LMTAdd", _selector, selector);
            return this;
        }

        public async Task<IAsyncDom> AddClass(string className)
        {
            await InvokeAsync<object>("LMTAddClass", _selector, className);
            return this;
        }

        public async Task<IAsyncDom> Animate(object properties, int duration = 400, string easing = "swing", Action complete = null)
        {
            await InvokeAsync<object>("LMTAnimate", _selector, properties, duration, easing);
            // ReSharper disable once InvertIf
            if (complete != null)
            {
                await Task.Delay(duration);
                complete.Invoke();
            }

            return this;
        }

        public async Task<IAsyncDom> Animate(object properties, object options)
        {
            await InvokeAsync<object>("LMTAnimateOptions", _selector, properties, options);
            return this;
        }

        public IDom AsSync()
        {
            if (_dom == null)
            {
                _dom = new Dom(_selector);
            }
            return _dom;
        }

        public async Task<IAsyncDom> Attr(string attribute, string value)
        {
            await InvokeAsync<object>("LMTDomAttr", _selector, attribute, value);
            return this;
        }

        public Task<string> Attr(object attribute)
        {
            return InvokeAsync<string>("LMTDomAttr2", _selector, attribute);
        }

        public Task<string> Css(string propertyName)
        {
            return InvokeAsync<string>("LMTDomCss2", _selector, propertyName);
        }

        public async Task<IAsyncDom> Css(string propertyName, string value)
        {
            await InvokeAsync<object>("LMTDomCss", _selector, propertyName, value);
            return this;
        }

        public Task<bool> HasClass(string className)
        {
            return InvokeAsync<bool>("LMTHasClass", _selector, className);
        }

        public Task<double> Height()
        {
            return InvokeAsync<double>("LMTHeight2", _selector);
        }

        public async Task<IAsyncDom> Height(double value)
        {
            await InvokeAsync<object>("LMTHeight", _selector, value);
            return this;
        }

        public async Task<IAsyncDom> Height(Func<int, int, string> function)
        {
            var id = IntIntStringStorage.Add(function);
            await InvokeAsync<object>("LMTHeightFunc2", _selector, id);
            return this;
        }

        public async Task<IAsyncDom> Height(Func<int, int, double> function)
        {
            var id = IntIntDoubleStorage.Add(function);
            await InvokeAsync<object>("LMTHeightFunc1", _selector, id);
            return this;
        }

        public Task<string> Html()
        {
            return InvokeAsync<string>("LMTHtml", _selector);
        }

        public Task<double> InnerHeight()
        {
            return InvokeAsync<double>("LMTInnerHeight2", _selector);
        }

        public async Task<IAsyncDom> InnerHeight(double value)
        {
            await InvokeAsync<object>("LMTInnerHeight", _selector, value);
            return this;
        }

        public async Task<IAsyncDom> InnerHeight(string value)
        {
            await InvokeAsync<object>("LMTInnerHeight", _selector, value);
            return this;
        }

        public async Task<IAsyncDom> InnerHeight(Func<int, double, string> function)
        {
            var id = IntDoubleStringStorage.Add(function);
            await InvokeAsync<object>("LMTInnerHeightFunc1", _selector, id);
            return this;
        }

        public async Task<IAsyncDom> InnerHeight(Func<int, double, double> function)
        {
            var id = IntDoubleDoubleStorage.Add(function);
            await InvokeAsync<object>("LMTInnerHeightFunc2", _selector, id);
            return this;
        }

        public Task<double> InnerWidth()
        {
            return InvokeAsync<double>("LMTInnerWidth2", _selector);
        }

        public async Task<IAsyncDom> InnerWidth(double value)
        {
            await InvokeAsync<object>("LMTInnerWidth", _selector, value);
            return this;
        }

        public async Task<IAsyncDom> InnerWidth(string value)
        {
            await InvokeAsync<object>("LMTInnerWidth", _selector, value);
            return this;
        }

        public async Task<IAsyncDom> InnerWidth(Func<int, double, string> function)
        {
            var id = IntDoubleStringStorage.Add(function);
            await InvokeAsync<object>("LMTInnerWidthFunc1", _selector, id);
            return this;
        }

        public async Task<IAsyncDom> InnerWidth(Func<int, double, double> function)
        {
            var id = IntDoubleDoubleStorage.Add(function);
            await InvokeAsync<object>("LMTInnerWidthFunc2", _selector, id);
            return this;
        }

        public async Task<IAsyncDom> Off()
        {
            await InvokeAsync<object>("LMTOff", _selector);
            return this;
        }

        public async Task<IAsyncDom> Off(string @event)
        {
            await InvokeAsync<object>("LMTOffEvent", _selector, @event);
            return this;
        }

        public Task<Coordinate> Offset()
        {
            return InvokeAsync<Coordinate>("LMTOffset2", _selector);
        }

        public async Task<IAsyncDom> Offset(Coordinate coordinates)
        {
            await InvokeAsync<object>("LMTOffset", _selector, coordinates);
            return this;
        }

        public async Task<IAsyncDom> Offset(Func<int, Coordinate, Coordinate> function)
        {
            var id = IntCoordsCoordsStorage.Add(function);
            await InvokeAsync<object>("LMTOffsetFunc", _selector, id);
            return this;
        }

        public async Task<IAsyncDom> On(string events, Action<LMTEventArgs> handler)
        {
            var id = UICallBacksStorage.Add(events, _selector, handler);
            await InvokeAsync<object>("LMTOn", _selector, events, id);
            return this;
        }

        public Task<double> OuterHeight(bool includeMargin = false)
        {
            return InvokeAsync<double>("LMTOuterHeightMargin", _selector, includeMargin);
        }

        public async Task<IAsyncDom> OuterHeight(double value)
        {
            await InvokeAsync<object>("LMTOuterHeight", _selector, value);
            return this;
        }

        public async Task<IAsyncDom> OuterHeight(string value)
        {
            await InvokeAsync<object>("LMTOuterHeight", _selector, value);
            return this;
        }

        public async Task<IAsyncDom> OuterHeight(Func<int, double, string> function)
        {
            var id = IntDoubleStringStorage.Add(function);
            await InvokeAsync<object>("LMTOuterHeightFunc1", _selector, id);
            return this;
        }

        public async Task<IAsyncDom> OuterHeight(Func<int, double, double> function)
        {
            var id = IntDoubleDoubleStorage.Add(function);
            await InvokeAsync<object>("LMTOuterHeightFunc2", _selector, id);
            return this;
        }

        public Task<double> OuterWidth(bool includeMargin = false)
        {
            return InvokeAsync<double>("LMTOuterWidthMargin", _selector, includeMargin);
        }

        public async Task<IAsyncDom> OuterWidth(double value)
        {
            await InvokeAsync<object>("LMTOuterWidth", _selector, value);
            return this;
        }

        public async Task<IAsyncDom> OuterWidth(string value)
        {
            await InvokeAsync<object>("LMTOuterWidth", _selector, value);
            return this;
        }

        public async Task<IAsyncDom> OuterWidth(Func<int, double, string> function)
        {
            var id = IntDoubleStringStorage.Add(function);
            await InvokeAsync<object>("LMTOuterWidthFunc1", _selector, id);
            return this;
        }

        public async Task<IAsyncDom> OuterWidth(Func<int, double, double> function)
        {
            var id = IntDoubleDoubleStorage.Add(function);
            await InvokeAsync<object>("LMTOuterWidthFunc2", _selector, id);
            return this;
        }

        public Task<Coordinate> Position()
        {
            return InvokeAsync<Coordinate>("LMTPosition", _selector);
        }

        public Task<T> Prop<T>(string propertyName)
        {
            return InvokeAsync<T>("LMTProp", _selector, propertyName);
        }

        public async Task<IAsyncDom> RemoveAttr(string attributeName)
        {
            await InvokeAsync<object>("LMTRemoveAttr", _selector, attributeName);
            return this;
        }

        public async Task<IAsyncDom> RemoveClass(string className)
        {
            await InvokeAsync<object>("LMTRemoveClass", _selector, className);
            return this;
        }

        public async Task<IAsyncDom> RemoveClass(Func<int, string, string> function)
        {
            var id = IntStringStringStorage.Add(function);
            await InvokeAsync<object>("LMTRemoveClassFunc", _selector, id);
            return this;
        }

        public async Task<IAsyncDom> RemoveProp(string propertyName)
        {
            await InvokeAsync<object>("LMTRemoveProp", _selector, propertyName);
            return this;
        }

        public Task<int> ScrollLeft()
        {
            return InvokeAsync<int>("LMTScrollLeft2", _selector);
        }

        public async Task<IAsyncDom> ScrollLeft(double value)
        {
            await InvokeAsync<object>("LMTScrollLeft", _selector, value);
            return this;
        }

        public Task<double> ScrollTop()
        {
            return InvokeAsync<double>("LMTScrollTop2", _selector);
        }

        public async Task<IAsyncDom> ScrollTop(double value)
        {
            await InvokeAsync<object>("LMTScrollTop", _selector);
            return this;
        }

        public Task<string> Text()
        {
            return InvokeAsync<string>("LMTDomText2", _selector);
        }

        public async Task<IAsyncDom> Text(string text)
        {
            await InvokeAsync<object>("LMTDomText", _selector, text);
            return this;
        }

        public async Task<IAsyncDom> Toggle()
        {
            await InvokeAsync<object>("LMTDomToggle", _selector);
            return this;
        }

        public async Task<IAsyncDom> ToggleClass(string className)
        {
            await InvokeAsync<object>("LMTToggleClass1", _selector, className);
            return this;
        }

        public async Task<IAsyncDom> ToggleClass(string className, bool state)
        {
            await InvokeAsync<object>("LMTToggleClass2", _selector, className, state);
            return this;
        }

        public async Task<IAsyncDom> ToggleClass(Func<int, string, string> function)
        {
            var id = IntStringStringStorage.Add(function);
            await InvokeAsync<object>("LMTToggleClass3", _selector, id);
            return this;
        }

        public async Task<IAsyncDom> ToggleClass(Func<int, string, string> function, bool state)
        {
            var id = IntStringStringStorage.Add(function);
            await InvokeAsync<object>("LMTToggleClass4", _selector, id, state);
            return this;
        }

        public IDom ToSync()
        {
            return new Dom(_selector);
        }

        public Task<string> Val()
        {
            return InvokeAsync<string>("LMTDomVal2", _selector);
        }

        public async Task<IAsyncDom> Val(string value)
        {
            await InvokeAsync<object>("LMTDomVal", _selector, value);
            return this;
        }

        public Task<double> Width()
        {
            return InvokeAsync<double>("LMTWidth2", _selector);
        }

        public async Task<IAsyncDom> Width(double value)
        {
            await InvokeAsync<object>("LMTWidth", _selector, value);
            return this;
        }

        public async Task<IAsyncDom> Width(string value)
        {
            await InvokeAsync<object>("LMTWidth", _selector, value);
            return this;
        }

        public async Task<IAsyncDom> Width(Func<int, int, string> function)
        {
            var id = IntIntStringStorage.Add(function);
            await InvokeAsync<object>("LMTWidthFunc1", _selector, id);
            return this;
        }

        public async Task<IAsyncDom> Width(Func<int, int, double> function)
        {
            var id = IntIntDoubleStorage.Add(function);
            await InvokeAsync<object>("LMTWidthFunc2", _selector, id);
            return this;
        }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member