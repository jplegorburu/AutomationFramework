using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using System;
namespace EAAutoFramework.Base
{
    public abstract class BaseStep : Base
    {
        public virtual void NavigateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelpers.Write(string.Format("Navigated to site {0}!!", Settings.AUT));

        }
    }
}
