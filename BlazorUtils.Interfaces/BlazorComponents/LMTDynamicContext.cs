using System;

namespace BlazorUtils.Interfaces.BlazorComponents
{
    public abstract class LMTDynamicContext
    {
        public abstract Type ComponentSwitch();

        public abstract (string PropertyName, object Value)[] ParametersSwitch();
    }
}
