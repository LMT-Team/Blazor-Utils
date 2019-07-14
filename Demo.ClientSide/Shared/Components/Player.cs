using System;
using BlazorUtils.Interfaces.BlazorComponents;

namespace Demo.ClientSide.Shared.Components
{
    public class Player : LMTDynamicContext
    {
        public string QueryStringParam { get; set; }

        public Player(string queryStringParam)
        {
            QueryStringParam = queryStringParam;
        }

        public override Type ComponentSwitch()
        {
            if (QueryStringParam == null)
                return typeof(AdultPlayer);
            return typeof(KidPlayer);
        }

        public override (string PropertyName, object Value)[] ParametersSwitch()
        {
            return new (string, object)[] {
                  ("url", "https://tempuri.org/videos/id=123"),
                  ("starttime", 0),
                  ("repeat", false)};
        }
    }
}
