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
    }
}
