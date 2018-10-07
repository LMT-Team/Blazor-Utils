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
    public class Dom : IDom
    {
        private readonly string _selector;

        /// <summary>
        /// Initialize DOM with a selector string.
        /// </summary>
        /// <param name="selector">DOM Selector string.</param>
        public Dom(string selector)
        {
            _selector = selector;
        }

        /// <summary>
        /// Display or hide the matched elements.
        /// </summary>
        /// <returns>DOM object.</returns>
        public IDom Toggle()
        {
            Invoke<object>("LMTDomToggle", _selector);
            return this;
        }

        /// <summary>
        /// Get the combined text contents of each element in the set of matched elements, including their descendants.
        /// </summary>
        /// <returns>Text contents of each element.</returns>
        public string Text()
        {
            return Invoke<string>("LMTDomText2", _selector);
        }

        /// <summary>
        /// Set the text contents of the matched elements.
        /// </summary>
        /// <param name="text">The text to set as the content of each matched element. When Number or Boolean is supplied, it will be converted to a String representation.</param>
        /// <returns>DOM object.</returns>
        public IDom Text(string text)
        {
            Invoke<object>("LMTDomText", _selector, text);
            return this;
        }

        /// <summary>
        /// Get the computed style properties for the first element in the set of matched elements.
        /// </summary>
        /// <param name="propertyName">A CSS property.</param>
        /// <returns>Computed style properties.</returns>
        public string Css(string propertyName)
        {
            return Invoke<string>("LMTDomCss2", _selector, propertyName);
        }

        /// <summary>
        /// Set one or more CSS properties for the set of matched elements.
        /// </summary>
        /// <param name="propertyName">A CSS property name.</param>
        /// <param name="value">A value to set for the property.</param>
        /// <returns>DOM object.</returns>
        public IDom Css(string propertyName, string value)
        {
            Invoke<object>("LMTDomCss", _selector, propertyName, value);
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

        /// <summary>
        /// Perform a custom animation of a set of CSS properties.
        /// </summary>
        /// <param name="properties">An object of CSS properties and values that the animation will move toward.</param>
        /// <param name="options">A map of additional options to pass to the method.</param>
        /// <returns>DOM object.</returns>
        public IDom Animate(object properties, object options)
        {
            Invoke<object>("LMTAnimateOptions", _selector, properties, options);
            return this;
        }

        /// <summary>
        /// Attach an event handler function for one or more events to the selected elements.
        /// </summary>
        /// <param name="events">One or more space-separated event types and optional namespaces, such as "click" or "keydown.myPlugin".</param>
        /// <param name="handler">A function to execute when the event is triggered.</param>
        /// <returns>DOM object.</returns>
        public IDom On(string events, Action<LMTEventArgs> handler)
        {
            var id = UICallBacksStorage.Add(events, _selector, handler);
            Invoke<object>("LMTOn", _selector, events, id);
            return this;
        }

        /// <summary>
        /// Create a new jQuery object with elements added to the set of matched elements.
        /// </summary>
        /// <param name="selector">A string representing a selector expression to find additional elements to add to the set of matched elements.</param>
        /// <returns>DOM object.</returns>
        public IDom Add(string selector)
        {
            Invoke<object>("LMTAdd", _selector, selector);
            return this;
        }

        #region CSS
        /// <summary>
        /// Get the current computed height for the first element in the set of matched elements.
        /// </summary>
        /// <returns>The current computed height for the first element in the set of matched elements.</returns>
        public double Height()
        {
            return Invoke<double>("LMTHeight2", _selector);
        }

        /// <summary>
        /// Set the CSS height of every matched element.
        /// </summary>
        /// <param name="value">An integer representing the number of pixels, or an integer with an optional unit of measure appended (as a string).</param>
        /// <returns>DOM object.</returns>
        public IDom Height(double value)
        {
            Invoke<object>("LMTHeight", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS height of every matched element.
        /// </summary>
        /// <param name="function">A function returning the height to set. Receives the index position of the element in the set and the old height as arguments.</param>
        /// <returns>DOM object.</returns>
        public IDom Height(Func<int, int, string> function)
        {
            var id = IntIntStringStorage.Add(function);
            Invoke<object>("LMTHeightFunc2", _selector, id);
            return this;
        }

        /// <summary>
        /// Set the CSS height of every matched element.
        /// </summary>
        /// <param name="function">A function returning the height to set. Receives the index position of the element in the set and the old height as arguments.</param>
        /// <returns>DOM object.</returns>
        public IDom Height(Func<int, int, double> function)
        {
            var id = IntIntDoubleStorage.Add(function);
            Invoke<object>("LMTHeightFunc1", _selector, id);
            return this;
        }

        /// <summary>
        /// Get the current computed height for the first element in the set of matched elements, including padding but not border.
        /// </summary>
        /// <returns>The current computed height for the first element in the set of matched elements, including padding but not border.</returns>
        public double InnerHeight()
        {
            return Invoke<double>("LMTInnerHeight2", _selector);
        }

        /// <summary>
        /// Set the CSS inner height of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A number representing the number of pixels.</param>
        /// <returns>DOM object.</returns>
        public IDom InnerHeight(double value)
        {
            Invoke<object>("LMTInnerHeight", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS inner height of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A number along with an optional unit of measure appended (as a string).</param>
        /// <returns>DOM object.</returns>
        public IDom InnerHeight(string value)
        {
            Invoke<object>("LMTInnerHeight", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS inner height of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the inner height (including padding but not border) to set. Receives the index position of the element in the set and the old inner height as arguments.</param>
        /// <returns>DOM object.</returns>
        public IDom InnerHeight(Func<int, double, string> function)
        {
            var id = IntDoubleStringStorage.Add(function);
            Invoke<object>("LMTInnerHeightFunc1", _selector, id);
            return this;
        }

        /// <summary>
        /// Set the CSS inner height of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the inner height (including padding but not border) to set. Receives the index position of the element in the set and the old inner height as arguments.</param>
        /// <returns>DOM object.</returns>
        public IDom InnerHeight(Func<int, double, double> function)
        {
            var id = IntDoubleDoubleStorage.Add(function);
            Invoke<object>("LMTInnerHeightFunc2", _selector, id);
            return this;
        }

        /// <summary>
        /// Get the current computed width for the first element in the set of matched elements.
        /// </summary>
        /// <returns>The current computed width for the first element in the set of matched elements.</returns>
        public double Width()
        {
            return Invoke<double>("LMTWidth2", _selector);
        }

        /// <summary>
        /// Set the CSS width of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">An integer representing the number of pixels.</param>
        /// <returns>DOM object.</returns>
        public IDom Width(double value)
        {
            Invoke<object>("LMTWidth", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS width of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">An integer along with an optional unit of measure appended (as a string).</param>
        /// <returns>DOM object.</returns>
        public IDom Width(string value)
        {
            Invoke<object>("LMTWidth", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS width of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the width to set. Receives the index position of the element in the set and the old width as arguments.</param>
        /// <returns>DOM object.</returns>
        public IDom Width(Func<int, int, string> function)
        {
            var id = IntIntStringStorage.Add(function);
            Invoke<object>("LMTWidthFunc1", _selector, id);
            return this;
        }

        /// <summary>
        /// Set the CSS width of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the width to set. Receives the index position of the element in the set and the old width as arguments.</param>
        /// <returns>DOM object.</returns>
        public IDom Width(Func<int, int, double> function)
        {
            var id = IntIntDoubleStorage.Add(function);
            Invoke<object>("LMTWidthFunc2", _selector, id);
            return this;
        }

        /// <summary>
        /// Get the current computed inner width for the first element in the set of matched elements, including padding but not border.
        /// </summary>
        /// <returns>The current computed inner width for the first element in the set of matched elements, including padding but not border.</returns>
        public double InnerWidth()
        {
            return Invoke<double>("LMTInnerWidth2", _selector);
        }

        /// <summary>
        /// Set the CSS inner width of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A number representing the number of pixels.</param>
        /// <returns>DOM object.</returns>
        public IDom InnerWidth(double value)
        {
            Invoke<object>("LMTInnerWidth", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS inner width of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A number along with an optional unit of measure appended (as a string).</param>
        /// <returns>DOM object.</returns>
        public IDom InnerWidth(string value)
        {
            Invoke<object>("LMTInnerWidth", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS inner width of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the inner width (including padding but not border) to set. Receives the index position of the element in the set and the old inner width as arguments.</param>
        /// <returns>DOM object.</returns>
        public IDom InnerWidth(Func<int, double, string> function)
        {
            var id = IntDoubleStringStorage.Add(function);
            Invoke<object>("LMTInnerWidthFunc1", _selector, id);
            return this;
        }

        /// <summary>
        /// Set the CSS inner width of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the inner width (including padding but not border) to set. Receives the index position of the element in the set and the old inner width as arguments.</param>
        /// <returns>DOM object.</returns>
        public IDom InnerWidth(Func<int, double, double> function)
        {
            var id = IntDoubleDoubleStorage.Add(function);
            Invoke<object>("LMTInnerWidthFunc2", _selector, id);
            return this;
        }

        /// <summary>
        /// Get the current coordinates of the first element in the set of matched elements, relative to the document.
        /// </summary>
        /// <returns>The current coordinates of the first element in the set of matched elements, relative to the document.</returns>
        public Coordinate Offset()
        {
            return Invoke<Coordinate>("LMTOffset2", _selector);
        }

        /// <summary>
        /// Set the current coordinates of every element in the set of matched elements, relative to the document.
        /// </summary>
        /// <param name="coordinates">An object containing the properties top and left, which are numbers indicating the new top and left coordinates for the elements.</param>
        /// <returns>DOM object.</returns>
        public IDom Offset(Coordinate coordinates)
        {
            Invoke<object>("LMTOffset", _selector, coordinates);
            return this;
        }

        /// <summary>
        /// Set the current coordinates of every element in the set of matched elements, relative to the document.
        /// </summary>
        /// <param name="function">A function to return the coordinates to set. Receives the index of the element in the collection as the first argument and the current coordinates as the second argument. The function should return an object with the new top and left properties.</param>
        /// <returns>DOM object.</returns>
        public IDom Offset(Func<int, Coordinate, Coordinate> function)
        {
            var id = IntCoordsCoordsStorage.Add(function);
            Invoke<object>("LMTOffsetFunc", _selector, id);
            return this;
        }

        #endregion

        #region Attributes
        /// <summary>
        /// Adds the specified class(es) to each element in the set of matched elements.
        /// </summary>
        /// <param name="className">One or more space-separated classes to be added to the class attribute of each matched element.</param>
        /// <returns>DOM object.</returns>
        public IDom AddClass(string className)
        {
            Invoke<object>("LMTAddClass", _selector, className);
            return this;
        }

        /// <summary>
        /// Determine whether any of the matched elements are assigned the given class.
        /// </summary>
        /// <param name="className">The class name to search for.</param>
        /// <returns>Whether any of the matched elements are assigned the given class.</returns>
        public bool HasClass(string className)
        {
            return Invoke<bool>("LMTHasClass", _selector, className);
        }

        /// <summary>
        /// Get the HTML contents of the first element in the set of matched elements.
        /// </summary>
        /// <returns>The HTML contents of the first element in the set of matched elements.</returns>
        public string Html()
        {
            return Invoke<string>("LMTHtml", _selector);
        }

        /// <summary>
        /// Get the value of a property for the first element in the set of matched elements.
        /// </summary>
        /// <typeparam name="T">The type of returned object.</typeparam>
        /// <param name="propertyName">The name of the property to get.</param>
        /// <returns>The value of a property for the first element in the set of matched elements.</returns>
        public T Prop<T>(string propertyName)
        {
            return Invoke<T>("LMTProp", _selector, propertyName);
        }

        /// <summary>
        /// Remove an attribute from each element in the set of matched elements.
        /// </summary>
        /// <param name="attributeName">An attribute to remove, it can be a space-separated list of attributes.</param>
        /// <returns>DOM object.</returns>
        public IDom RemoveAttr(string attributeName)
        {
            Invoke<object>("LMTRemoveAttr", _selector, attributeName);
            return this;
        }

        /// <summary>
        /// Remove a single class or multiple classes from each element in the set of matched elements.
        /// </summary>
        /// <param name="className">One or more space-separated classes to be removed from the class attribute of each matched element.</param>
        /// <returns>DOM object.</returns>
        public IDom RemoveClass(string className)
        {
            Invoke<object>("LMTRemoveClass", _selector, className);
            return this;
        }

        /// <summary>
        /// Remove a single class or multiple classes from each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning one or more space-separated class names to be removed. Receives the index position of the element in the set and the old class value as arguments.</param>
        /// <returns>DOM object.</returns>
        public IDom RemoveClass(Func<int, string, string> function)
        {
            var id = IntStringStringStorage.Add(function);
            Invoke<object>("LMTRemoveClassFunc", _selector, id);
            return this;
        }

        /// <summary>
        /// Remove a property for the set of matched elements.
        /// </summary>
        /// <param name="propertyName">The name of the property to remove.</param>
        /// <returns>DOM object.</returns>
        public IDom RemoveProp(string propertyName)
        {
            Invoke<object>("LMTRemoveProp", _selector, propertyName);
            return this;
        }

        /// <summary>
        /// Add or remove one or more classes from each element in the set of matched elements, depending on either the class's presence or the value of the state argument.
        /// </summary>
        /// <param name="className">One or more class names (separated by spaces) to be toggled for each element in the matched set.</param>
        /// <returns>DOM object.</returns>
        public IDom ToggleClass(string className)
        {
            Invoke<object>("LMTToggleClass1", _selector, className);
            return this;
        }

        /// <summary>
        /// Add or remove one or more classes from each element in the set of matched elements, depending on either the class's presence or the value of the state argument.
        /// </summary>
        /// <param name="className">One or more class names (separated by spaces) to be toggled for each element in the matched set.</param>
        /// <param name="state">A Boolean (not just truthy/falsy) value to determine whether the class should be added or removed.</param>
        /// <returns>DOM object.</returns>
        public IDom ToggleClass(string className, bool state)
        {
            Invoke<object>("LMTToggleClass2", _selector, className, state);
            return this;
        }

        /// <summary>
        /// Add or remove one or more classes from each element in the set of matched elements, depending on either the class's presence or the value of the state argument.
        /// </summary>
        /// <param name="function">A function that returns class names to be toggled in the class attribute of each element in the matched set. Receives the index position of the element in the set, the old class value, and the state as arguments.</param>
        /// <returns>DOM object.</returns>
        public IDom ToggleClass(Func<int, string, string> function)
        {
            var id = IntStringStringStorage.Add(function);
            Invoke<object>("LMTToggleClass3", _selector, id);
            return this;
        }

        /// <summary>
        /// Add or remove one or more classes from each element in the set of matched elements, depending on either the class's presence or the value of the state argument.
        /// </summary>
        /// <param name="function">A function that returns class names to be toggled in the class attribute of each element in the matched set. Receives the index position of the element in the set, the old class value, and the state as arguments.</param>
        /// <param name="state">A boolean value to determine whether the class should be added or removed.</param>
        /// <returns>DOM object.</returns>
        public IDom ToggleClass(Func<int, string, string> function, bool state)
        {
            var id = IntStringStringStorage.Add(function);
            Invoke<object>("LMTToggleClass4", _selector, id, state);
            return this;
        }

        /// <summary>
        /// Set one or more attributes for the set of matched elements.
        /// </summary>
        /// <param name="attribute">The name of the attribute to set.</param>
        /// <param name="value">A value to set for the attribute. If null, the specified attribute will be removed (as in .removeAttr()).</param>
        /// <returns>DOM object.</returns>
        public IDom Attr(string attribute, string value)
        {
            Invoke<object>("LMTDomAttr", _selector, attribute, value);
            return this;
        }

        /// <summary>
        /// Set one or more attributes for the set of matched elements.
        /// </summary>
        /// <param name="attribute">An object of attribute-value pairs to set.</param>
        /// <returns></returns>
        public string Attr(object attribute)
        {
            return Invoke<string>("LMTDomAttr2", _selector, attribute);
        }

        /// <summary>
        /// Get the current value of the first element in the set of matched elements.
        /// </summary>
        /// <returns>The current value of the first element in the set of matched elements.</returns>
        public string Val()
        {
            return Invoke<string>("LMTDomVal2", _selector);
        }

        /// <summary>
        /// Set the value of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A string of text corresponding to the value of each matched element to set as selected/checked.</param>
        /// <returns></returns>
        public IDom Val(string value)
        {
            Invoke<object>("LMTDomVal", _selector, value);
            return this;
        }

        /// <summary>
        /// Convert Dom to Async Dom, useful to server-side Blazor project.
        /// </summary>
        /// <returns>Async Dom</returns>
        public IAsyncDom ToAsync() => new AsyncDom(_selector);

        /// <summary>
        /// Remove an event handler.
        /// </summary>
        /// <returns></returns>
        public IDom Off()
        {
            Invoke<object>("LMTOff", _selector);
            return this;
        }

        /// <summary>
        /// Remove an event handler.
        /// </summary>
        /// <param name="event">One or more space-separated event types and optional namespaces, or just namespaces, such as "click", "keydown.myPlugin", or ".myPlugin".</param>
        /// <returns></returns>
        public IDom Off(string @event)
        {
            Invoke<object>("LMTOffEvent", _selector, @event);
            return this;
        }

        /// <summary>
        /// Get the current computed outer height (including padding, border, and optionally margin) for the first element in the set of matched elements.
        /// </summary>
        /// <param name="includeMargin">A Boolean indicating whether to include the element's margin in the calculation.</param>
        /// <returns></returns>
        public double OuterHeight(bool includeMargin = false)
        {
            return Invoke<double>("LMTOuterHeightMargin", _selector, includeMargin);
        }

        /// <summary>
        /// Set the CSS outer height of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A number representing the number of pixels, or a number along with an optional unit of measure appended (as a string).</param>
        /// <returns></returns>
        public IDom OuterHeight(double value)
        {
            Invoke<object>("LMTOuterHeight", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS outer height of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A number representing the number of pixels, or a number along with an optional unit of measure appended (as a string).</param>
        /// <returns></returns>
        public IDom OuterHeight(string value)
        {
            Invoke<object>("LMTOuterHeight", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS outer height of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the outer height to set. Receives the index position of the element in the set and the old outer height as arguments. Within the function, this refers to the current element in the set.</param>
        /// <returns></returns>
        public IDom OuterHeight(Func<int, double, string> function)
        {
            var id = IntDoubleStringStorage.Add(function);
            Invoke<object>("LMTOuterHeightFunc1", _selector, id);
            return this;
        }

        /// <summary>
        /// Set the CSS outer height of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the outer height to set. Receives the index position of the element in the set and the old outer height as arguments. Within the function, this refers to the current element in the set.</param>
        /// <returns></returns>
        public IDom OuterHeight(Func<int, double, double> function)
        {
            var id = IntDoubleDoubleStorage.Add(function);
            Invoke<object>("LMTOuterHeightFunc2", _selector, id);
            return this;
        }

        /// <summary>
        /// Get the current computed outer width (including padding, border, and optionally margin) for the first element in the set of matched elements.
        /// </summary>
        /// <param name="includeMargin">A Boolean indicating whether to include the element's margin in the calculation.</param>
        /// <returns></returns>
        public double OuterWidth(bool includeMargin = false)
        {
            return Invoke<double>("LMTOuterWidthMargin", _selector, includeMargin);
        }

        /// <summary>
        /// Set the CSS outer width of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A number representing the number of pixels, or a number along with an optional unit of measure appended (as a string).</param>
        /// <returns></returns>
        public IDom OuterWidth(double value)
        {
            Invoke<object>("LMTOuterWidth", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS outer width of each element in the set of matched elements.
        /// </summary>
        /// <param name="value">A number representing the number of pixels, or a number along with an optional unit of measure appended (as a string).</param>
        /// <returns></returns>
        public IDom OuterWidth(string value)
        {
            Invoke<object>("LMTOuterWidth", _selector, value);
            return this;
        }

        /// <summary>
        /// Set the CSS outer width of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the outer width to set. Receives the index position of the element in the set and the old outer width as arguments. Within the function, this refers to the current element in the set.</param>
        /// <returns></returns>
        public IDom OuterWidth(Func<int, double, string> function)
        {
            var id = IntDoubleStringStorage.Add(function);
            Invoke<object>("LMTOuterWidthFunc1", _selector, id);
            return this;
        }

        /// <summary>
        /// Set the CSS outer width of each element in the set of matched elements.
        /// </summary>
        /// <param name="function">A function returning the outer width to set. Receives the index position of the element in the set and the old outer width as arguments. Within the function, this refers to the current element in the set.</param>
        /// <returns></returns>
        public IDom OuterWidth(Func<int, double, double> function)
        {
            var id = IntDoubleDoubleStorage.Add(function);
            Invoke<object>("LMTOuterWidthFunc2", _selector, id);
            return this;
        }

        /// <summary>
        /// Get the current coordinates of the first element in the set of matched elements, relative to the offset parent.
        /// </summary>
        /// <returns></returns>
        public Coordinate Position()
        {
            return Invoke<Coordinate>("LMTPosition", _selector);
        }

        /// <summary>
        /// Get the current horizontal position of the scroll bar for the first element in the set of matched elements.
        /// </summary>
        /// <returns></returns>
        public int ScrollLeft()
        {
            return Invoke<int>("LMTScrollLeft2", _selector);
        }

        /// <summary>
        /// Set the current horizontal position of the scroll bar for each of the set of matched elements.
        /// </summary>
        /// <param name="value">An integer indicating the new position to set the scroll bar to.</param>
        /// <returns></returns>
        public IDom ScrollLeft(double value)
        {
            Invoke<object>("LMTScrollLeft", _selector, value);
            return this;
        }

        /// <summary>
        /// Get the current vertical position of the scroll bar for the first element in the set of matched elements or set the vertical position of the scroll bar for every matched element.
        /// </summary>
        /// <returns></returns>
        public double ScrollTop()
        {
            return Invoke<double>("LMTScrollTop2", _selector);
        }

        /// <summary>
        /// Set the current vertical position of the scroll bar for each of the set of matched elements.
        /// </summary>
        /// <param name="value">A number indicating the new position to set the scroll bar to.</param>
        /// <returns></returns>
        public double ScrollTop(double value)
        {
            return Invoke<double>("LMTScrollTop", _selector);
        }
        #endregion
    }
}