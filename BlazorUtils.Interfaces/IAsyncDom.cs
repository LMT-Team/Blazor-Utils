#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using BlazorUtils.Interfaces.EventArgs;
using System;
using System.Threading.Tasks;

namespace BlazorUtils.Interfaces
{
    public interface IAsyncDom
    {
        Task<IAsyncDom> Attr(string attribute, string value);
        Task<IAsyncDom> Toggle();
        Task<string> Attr(object attribute);
        Task<string> Val();
        Task<IAsyncDom> Val(string value);
        Task<string> Text();
        Task<IAsyncDom> Text(string text);
        Task<string> Css(string propertyName);
        Task<IAsyncDom> Css(string propertyName, string value);
        Task<IAsyncDom> Animate(object properties, int duration, string easing, Action complete);
        Task<IAsyncDom> Animate(object properties, object options);
        Task<IAsyncDom> On(string events, Action<LMTEventArgs> handler);
        Task<IAsyncDom> Add(string selector);
        Task<IAsyncDom> AddClass(string className);
        Task<bool> HasClass(string className);
        Task<string> Html();
        Task<T> Prop<T>(string propertyName);
        Task<IAsyncDom> RemoveAttr(string attributeName);
        Task<IAsyncDom> RemoveClass(string className);
        Task<IAsyncDom> RemoveClass(Func<int, string, string> function);
        Task<IAsyncDom> RemoveProp(string propertyName);
        Task<IAsyncDom> ToggleClass(string className);
        Task<IAsyncDom> ToggleClass(string className, bool state);
        Task<IAsyncDom> ToggleClass(Func<int, string, string> function);
        Task<IAsyncDom> ToggleClass(Func<int, string, string> function, bool state);
        Task<double> Height();
        Task<IAsyncDom> Height(double value);
        Task<IAsyncDom> Height(Func<int, int, string> function);
        Task<IAsyncDom> Height(Func<int, int, double> function);
        Task<double> InnerHeight();
        Task<IAsyncDom> InnerHeight(double value);
        Task<IAsyncDom> InnerHeight(string value);
        Task<IAsyncDom> InnerHeight(Func<int, double, string> function);
        Task<IAsyncDom> InnerHeight(Func<int, double, double> function);
        Task<double> Width();
        Task<IAsyncDom> Width(double value);
        Task<IAsyncDom> Width(string value);
        Task<IAsyncDom> Width(Func<int, int, string> function);
        Task<IAsyncDom> Width(Func<int, int, double> function);
        Task<double> InnerWidth();
        Task<IAsyncDom> InnerWidth(double value);
        Task<IAsyncDom> InnerWidth(string value);
        Task<IAsyncDom> InnerWidth(Func<int, double, string> function);
        Task<IAsyncDom> InnerWidth(Func<int, double, double> function);
        Task<Coordinate> Offset();
        Task<IAsyncDom> Offset(Coordinate coordinates);
        Task<IAsyncDom> Offset(Func<int, Coordinate, Coordinate> function);
        IDom ToSync();
        Task<IAsyncDom> Off();
        Task<IAsyncDom> Off(string @event);
        Task<double> OuterHeight(bool includeMargin = false);
        Task<IAsyncDom> OuterHeight(double value);
        Task<IAsyncDom> OuterHeight(string value);
        Task<IAsyncDom> OuterHeight(Func<int, double, string> function);
        Task<IAsyncDom> OuterHeight(Func<int, double, double> function);
        Task<double> OuterWidth(bool includeMargin = false);
        Task<IAsyncDom> OuterWidth(double value);
        Task<IAsyncDom> OuterWidth(string value);
        Task<IAsyncDom> OuterWidth(Func<int, double, string> function);
        Task<IAsyncDom> OuterWidth(Func<int, double, double> function);
        Task<Coordinate> Position();
        Task<int> ScrollLeft();
        Task<IAsyncDom> ScrollLeft(double value);
        Task<double> ScrollTop();
        Task<IAsyncDom> ScrollTop(double value);
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member