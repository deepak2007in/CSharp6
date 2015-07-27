using System.Threading;
using System.Globalization;

namespace MyLibrary
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class MySiteCultureService : IMySiteCultureService
    {
        public void SetCulture()
        {
#if DNX451
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
#elif DNXCORE50
            CultureInfo.CurrentCulture = new CultureInfo("fr-FR");
#else
#error Not Supported
#endif
        }
    }
}
