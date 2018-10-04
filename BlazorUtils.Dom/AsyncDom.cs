using BlazorUtils.Dom.Storages;
using BlazorUtils.Interfaces;
using BlazorUtils.Interfaces.EventArgs;
using System;
using System.Threading.Tasks;
using static BlazorUtils.Interfaces.Invokers.JsInvoke;

namespace BlazorUtils.Dom
{
    /// <summary>
    /// Represents a collection of DOM elements.
    /// </summary>
    public class AsyncDom : IAsyncDom
    {
        private readonly string _selector;

        /// <summary>
        /// Initialize async DOM with a selector string.
        /// </summary>
        /// <param name="selector">DOM Selector string.</param>
        internal AsyncDom(string selector)
        {
            _selector = selector;
        }

        /// <summary>
        /// Create a new jQuery object with elements added to the set of matched elements.
        /// </summary>
        /// <param name="selector">A string representing a selector expression to find additional elements to add to the set of matched elements.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Add(string selector)
        {
            await InvokeAsync<object>("LMTAdd", _selector, selector);
            return this;
        }

        /// <summary>
        /// Adds the specified class(es) to each element in the set of matched elements.
        /// </summary>
        /// <param name="className">One or more space-separated classes to be added to the class attribute of each matched element.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> AddClass(string className)
        {
            await InvokeAsync<object>("LMTAddClass", _selector, className);
            return this;
        }

        /// <summary>
        /// Perform a custom animation of a set of CSS properties.
        /// </summary>
        /// <param name="properties">An object of CSS properties and values that the animation will move toward.</param>
        /// <param name="duration">A string or number determining how long the animation will run.</param>
        /// <param name="easing">A string indicating which easing function to use for the transition.</param>
        /// <param name="complete">A function to call once the animation is complete, called once per matched element.</param>
        /// <returns>DOM object.</returns>
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

        /// <summary>
        /// Perform a custom animation of a set of CSS properties.
        /// </summary>
        /// <param name="properties">An object of CSS properties and values that the animation will move toward.</param>
        /// <param name="options">A map of additional options to pass to the method.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Animate(object properties, object options)
        {
            await InvokeAsync<object>("LMTAnimateOptions", _selector, properties, options);
            return this;
        }

        /// <summary>
        /// Set one or more attributes for the set of matched elements.
        /// </summary>
        /// <param name="attribute">The name of the attribute to set.</param>
        /// <param name="value">A value to set for the attribute. If null, the specified attribute will be removed (as in .removeAttr()).</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Attr(string attribute, string value)
        {
            await InvokeAsync<bool>("LMTDomAttr", _selector, attribute, value);
            return this;
        }

        /// <summary>
        /// Set one or more attributes for the set of matched elements.
        /// </summary>
        /// <param name="attribute">An object of attribute-value pairs to set.</param>
        /// <returns></returns>
        public async Task<string> Attr(object attribute)
        {
            return await InvokeAsync<string>("LMTDomAttr2", _selector, attribute);
        }

        /// <summary>
        /// Get the computed style properties for the first element in the set of matched elements.
        /// </summary>
        /// <param name="propertyName">A CSS property.</param>
        /// <returns>Computed style properties.</returns>
        public async Task<string> Css(string propertyName)
        {
            return await InvokeAsync<string>("LMTDomCss2", _selector, propertyName);
        }

        /// <summary>
        /// Set one or more CSS properties for the set of matched elements.
        /// </summary>
        /// <param name="propertyName">A CSS property name.</param>
        /// <param name="value">A value to set for the property.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Css(string propertyName, string value)
        {
            await InvokeAsync<object>("LMTDomCss", _selector, propertyName, value);
            return this;
        }

        /// <summary>
        /// Determine whether any of the matched elements are assigned the given class.
        /// </summary>
        /// <param name="className">The class name to search for.</param>
        /// <returns>Whether any of the matched elements are assigned the given class.</returns>
        public async Task<bool> HasClass(string className)
        {
            return await InvokeAsync<bool>("LMTHasClass", _selector, className);
        }

        /// <summary>
        /// Get the current computed height for the first element in the set of matched elements.
        /// </summary>
        /// <returns>The current computed height for the first element in the set of matched elements.</returns>
        public async Task<double> Height()
        {
            return await InvokeAsync<double>("LMTHeight2", _selector);
        }

        /// <summary>
        /// Set the CSS height of every matched element.
        /// </summary>
        /// <param name="value">An integer representing the number of pixels, or an integer with an optional unit of measure appended (as a string).</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Height(double value)
        {
            await InvokeAsync<object>("LMTHeight", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS height of every matched element.
        /// </summary>
        /// <param name="function">A function returning the height to set. Receives the index position of the element in the set and the old height as arguments.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Height(Func<int, int, string> function)
        {
            var id = IntIntStringStorage.Add(function);
            await InvokeAsync<object>("LMTHeightFunc2", _selector, id);
            return this;
        }

        /// <summary>
        /// Set the CSS height of every matched element.
        /// </summary>
        /// <param name="function">A function returning the height to set. Receives the index position of the element in the set and the old height as arguments.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Height(Func<int, int, double> function)
        {
            var id = IntIntDoubleStorage.Add(function);
            await InvokeAsync<object>("LMTHeightFunc1", _selector, id);
            return this;
        }

        /// <summary>
        /// Get the HTML contents of the first element in the set of matched elements.
        /// </summary>
        /// <returns>The HTML contents of the first element in the set of matched elements.</returns>
        public async Task<string> Html()
        {
            return await InvokeAsync<string>("LMTHtml", _selector);
        }

        /// <summary>
        /// Get the current computed height for the first element in the set of matched elements, including padding but not border.
        /// </summary>
        /// <returns>The current computed height for the first element in the set of matched elements, including padding but not border.</returns>
        public async Task<double> InnerHeight()
        {
            return await InvokeAsync<double>("LMTInnerHeight2", _selector);
        }

        /// <summary>
        /// Set the CSS inner height of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A number representing the number of pixels.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> InnerHeight(double value)
        {
            await InvokeAsync<object>("LMTInnerHeight", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS inner height of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A number along with an optional unit of measure appended (as a string).</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> InnerHeight(string value)
        {
            await InvokeAsync<object>("LMTInnerHeight", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS inner height of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the inner height (including padding but not border) to set. Receives the index position of the element in the set and the old inner height as arguments.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> InnerHeight(Func<int, double, string> function)
        {
            var id = IntDoubleStringStorage.Add(function);
            await InvokeAsync<object>("LMTInnerHeightFunc1", _selector, id);
            return this;
        }

        /// <summary>
        /// Set the CSS inner height of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the inner height (including padding but not border) to set. Receives the index position of the element in the set and the old inner height as arguments.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> InnerHeight(Func<int, double, double> function)
        {
            var id = IntDoubleDoubleStorage.Add(function);
            await InvokeAsync<object>("LMTInnerHeightFunc2", _selector, id);
            return this;
        }

        /// <summary>
        /// Get the current computed inner width for the first element in the set of matched elements, including padding but not border.
        /// </summary>
        /// <returns>The current computed inner width for the first element in the set of matched elements, including padding but not border.</returns>
        public async Task<double> InnerWidth()
        {
            return await InvokeAsync<double>("LMTInnerWidth2", _selector);
        }

        /// <summary>
        /// Set the CSS inner width of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A number representing the number of pixels.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> InnerWidth(double value)
        {
            await InvokeAsync<object>("LMTInnerWidth", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS inner width of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A number along with an optional unit of measure appended (as a string).</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> InnerWidth(string value)
        {
            await InvokeAsync<object>("LMTInnerWidth", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS inner width of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the inner width (including padding but not border) to set. Receives the index position of the element in the set and the old inner width as arguments.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> InnerWidth(Func<int, double, string> function)
        {
            var id = IntDoubleStringStorage.Add(function);
            await InvokeAsync<object>("LMTInnerWidthFunc1", _selector, id);
            return this;
        }

        /// <summary>
        /// Set the CSS inner width of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the inner width (including padding but not border) to set. Receives the index position of the element in the set and the old inner width as arguments.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> InnerWidth(Func<int, double, double> function)
        {
            var id = IntDoubleDoubleStorage.Add(function);
            await InvokeAsync<object>("LMTInnerWidthFunc2", _selector, id);
            return this;
        }

        /// <summary>
        /// Get the current coordinates of the first element in the set of matched elements, relative to the document.
        /// </summary>
        /// <returns>The current coordinates of the first element in the set of matched elements, relative to the document.</returns>
        public async Task<Coordinate> Offset()
        {
            return await InvokeAsync<Coordinate>("LMTOffset2", _selector);
        }

        /// <summary>
        /// Set the current coordinates of every element in the set of matched elements, relative to the document.
        /// </summary>
        /// <param name="coordinates">An object containing the properties top and left, which are numbers indicating the new top and left coordinates for the elements.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Offset(Coordinate coordinates)
        {
            await InvokeAsync<object>("LMTOffset", _selector, coordinates);
            return this;
        }

        /// <summary>
        /// Set the current coordinates of every element in the set of matched elements, relative to the document.
        /// </summary>
        /// <param name="function">A function to return the coordinates to set. Receives the index of the element in the collection as the first argument and the current coordinates as the second argument. The function should return an object with the new top and left properties.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Offset(Func<int, Coordinate, Coordinate> function)
        {
            var id = IntCoordsCoordsStorage.Add(function);
            await InvokeAsync<object>("LMTOffsetFunc", _selector, id);
            return this;
        }

        /// <summary>
        /// Attach an event handler function for one or more events to the selected elements.
        /// </summary>
        /// <param name="events">One or more space-separated event types and optional namespaces, such as "click" or "keydown.myPlugin".</param>
        /// <param name="handler">A function to execute when the event is triggered.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> On(string events, Action<LMTEventArgs> handler)
        {
            var id = UICallBacksStorage.Add(events, _selector, handler);
            await InvokeAsync<object>("LMTOn", _selector, events, id);
            return this;
        }

        /// <summary>
        /// Get the value of a property for the first element in the set of matched elements.
        /// </summary>
        /// <typeparam name="T">The type of returned object.</typeparam>
        /// <param name="propertyName">The name of the property to get.</param>
        /// <returns>The value of a property for the first element in the set of matched elements.</returns>
        public async Task<T> Prop<T>(string propertyName)
        {
            return await InvokeAsync<T>("LMTProp", _selector, propertyName);
        }

        /// <summary>
        /// Remove an attribute from each element in the set of matched elements.
        /// </summary>
        /// <param name="attributeName">An attribute to remove, it can be a space-separated list of attributes.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> RemoveAttr(string attributeName)
        {
            await InvokeAsync<object>("LMTRemoveAttr", _selector, attributeName);
            return this;
        }

        /// <summary>
        /// Remove a single class or multiple classes from each element in the set of matched elements.
        /// </summary>
        /// <param name="className">One or more space-separated classes to be removed from the class attribute of each matched element.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> RemoveClass(string className)
        {
            await InvokeAsync<object>("LMTRemoveClass", _selector, className);
            return this;
        }

        /// <summary>
        /// Remove a single class or multiple classes from each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning one or more space-separated class names to be removed. Receives the index position of the element in the set and the old class value as arguments.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> RemoveClass(Func<int, string, string> function)
        {
            var id = IntStringStringStorage.Add(function);
            await InvokeAsync<object>("LMTRemoveClassFunc", _selector, id);
            return this;
        }

        /// <summary>
        /// Remove a property for the set of matched elements.
        /// </summary>
        /// <param name="propertyName">The name of the property to remove.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> RemoveProp(string propertyName)
        {
            await InvokeAsync<object>("LMTRemoveProp", _selector, propertyName);
            return this;
        }

        /// <summary>
        /// Get the combined text contents of each element in the set of matched elements, including their descendants.
        /// </summary>
        /// <returns>Text contents of each element.</returns>
        public async Task<string> Text()
        {
            return await InvokeAsync<string>("LMTDomText2", _selector);
        }

        /// <summary>
        /// Set the text contents of the matched elements.
        /// </summary>
        /// <param name="text">The text to set as the content of each matched element. When Number or Boolean is supplied, it will be converted to a String representation.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Text(string text)
        {
            await InvokeAsync<object>("LMTDomText", _selector, text);
            return this;
        }

        /// <summary>
        /// Display or hide the matched elements.
        /// </summary>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Toggle()
        {
            await InvokeAsync<object>("LMTDomToggle", _selector);
            return this;
        }

        /// <summary>
        /// Add or remove one or more classes from each element in the set of matched elements, depending on either the class's presence or the value of the state argument.
        /// </summary>
        /// <param name="className">One or more class names (separated by spaces) to be toggled for each element in the matched set.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> ToggleClass(string className)
        {
            await InvokeAsync<object>("LMTToggleClass1", _selector, className);
            return this;
        }

        /// <summary>
        /// Add or remove one or more classes from each element in the set of matched elements, depending on either the class's presence or the value of the state argument.
        /// </summary>
        /// <param name="className">One or more class names (separated by spaces) to be toggled for each element in the matched set.</param>
        /// <param name="state">A Boolean (not just truthy/falsy) value to determine whether the class should be added or removed.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> ToggleClass(string className, bool state)
        {
            await InvokeAsync<object>("LMTToggleClass2", _selector, className, state);
            return this;
        }

        /// <summary>
        /// Add or remove one or more classes from each element in the set of matched elements, depending on either the class's presence or the value of the state argument.
        /// </summary>
        /// <param name="function">A function that returns class names to be toggled in the class attribute of each element in the matched set. Receives the index position of the element in the set, the old class value, and the state as arguments.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> ToggleClass(Func<int, string, string> function)
        {
            var id = IntStringStringStorage.Add(function);
            await InvokeAsync<object>("LMTToggleClass3", _selector, id);
            return this;
        }

        /// <summary>
        /// Add or remove one or more classes from each element in the set of matched elements, depending on either the class's presence or the value of the state argument.
        /// </summary>
        /// <param name="function">A function that returns class names to be toggled in the class attribute of each element in the matched set. Receives the index position of the element in the set, the old class value, and the state as arguments.</param>
        /// <param name="state">A boolean value to determine whether the class should be added or removed.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> ToggleClass(Func<int, string, string> function, bool state)
        {
            var id = IntStringStringStorage.Add(function);
            await InvokeAsync<object>("LMTToggleClass4", _selector, id, state);
            return this;
        }

        /// <summary>
        /// Convert async Dom to sync Dom.
        /// </summary>
        /// <returns>Sync Dom</returns>
        public IDom ToSync()
        {
            return new Dom(_selector);
        }

        /// <summary>
        /// Get the current value of the first element in the set of matched elements.
        /// </summary>
        /// <returns>The current value of the first element in the set of matched elements.</returns>
        public async Task<string> Val()
        {
            return await InvokeAsync<string>("LMTDomVal2", _selector);
        }

        /// <summary>
        /// Set the value of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A string of text corresponding to the value of each matched element to set as selected/checked.</param>
        /// <returns></returns>
        public async Task<IAsyncDom> Val(string value)
        {
            await InvokeAsync<object>("LMTDomVal", _selector, value);
            return this;
        }

        /// <summary>
        /// Get the current computed width for the first element in the set of matched elements.
        /// </summary>
        /// <returns>The current computed width for the first element in the set of matched elements.</returns>
        public async Task<double> Width()
        {
            return await InvokeAsync<double>("LMTWidth2", _selector);
        }

        /// <summary>
        /// Set the CSS width of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">An integer representing the number of pixels.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Width(double value)
        {
            await InvokeAsync<object>("LMTWidth", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS inner width of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A number along with an optional unit of measure appended (as a string).</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Width(string value)
        {
            await InvokeAsync<object>("LMTWidth", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS width of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the width to set. Receives the index position of the element in the set and the old width as arguments.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Width(Func<int, int, string> function)
        {
            var id = IntIntStringStorage.Add(function);
            await InvokeAsync<object>("LMTWidthFunc1", _selector, id);
            return this;
        }

        /// <summary>
        /// Set the CSS width of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the width to set. Receives the index position of the element in the set and the old width as arguments.</param>
        /// <returns>DOM object.</returns>
        public async Task<IAsyncDom> Width(Func<int, int, double> function)
        {
            var id = IntIntDoubleStorage.Add(function);
            await InvokeAsync<object>("LMTWidthFunc2", _selector, id);
            return this;
        }
    }
}