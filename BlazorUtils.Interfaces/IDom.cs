using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;

namespace BlazorUtils.Interfaces
{
    public interface IDom
    {
        IDom Attr(string attribute, string value);
        IDom Toggle();
        string Attr(string attribute);
        string Val();
        IDom Val(string value);
        string Text();
        IDom Text(string text);
        string Css(string propertyName);
        IDom Css(string propertyName, string value);
        Task<IDom> Animate(object properties, int duration, string easing, Action complete);
        IDom Animate(object properties, object options);
        IDom On(string events, Action<UIEventArgs> handler);
        IDom Add(string arg);
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
    }
}
