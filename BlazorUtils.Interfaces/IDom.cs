using BlazorUtils.Interfaces.EventArgs;
using System;
using System.Threading.Tasks;

namespace BlazorUtils.Interfaces
{
    public interface IDom
    {
        IDom Attr(string attribute, string value);
        IDom Toggle();
        string Attr(object attribute);
        string Val();
        IDom Val(string value);
        string Text();
        IDom Text(string text);
        string Css(string propertyName);
        IDom Css(string propertyName, string value);
        Task<IDom> Animate(object properties, int duration, string easing, Action complete);
        IDom Animate(object properties, object options);
        IDom On(string events, Action<LMTEventArgs> handler);
        IDom Add(string selector);
        IDom AddClass(string className);
        bool HasClass(string className);
        string Html();
        T Prop<T>(string propertyName);
        IDom RemoveAttr(string attributeName);
        IDom RemoveClass(string className);
        IDom RemoveClass(Func<int, string, string> function);
        IDom RemoveProp(string propertyName);
        IDom ToggleClass(string className);
        IDom ToggleClass(string className, bool state);
        IDom ToggleClass(Func<int, string, string> function);
        IDom ToggleClass(Func<int, string, string> function, bool state);
        double Height();
        IDom Height(double value);
        IDom Height(Func<int, int, string> function);
        IDom Height(Func<int, int, double> function);
        double InnerHeight();
        IDom InnerHeight(double value);
        IDom InnerHeight(string value);
        IDom InnerHeight(Func<int, double, string> function);
        IDom InnerHeight(Func<int, double, double> function);
        double Width();
        IDom Width(double value);
        IDom Width(string value);
        IDom Width(Func<int, int, string> function);
        IDom Width(Func<int, int, double> function);
        double InnerWidth();
        IDom InnerWidth(double value);
        IDom InnerWidth(string value);
        IDom InnerWidth(Func<int, double, string> function);
        IDom InnerWidth(Func<int, double, double> function);
        Coordinate Offset();
        IDom Offset(Coordinate coordinates);
        IDom Offset(Func<int, Coordinate, Coordinate> function);
        IAsyncDom ToAsync();
    }
}
