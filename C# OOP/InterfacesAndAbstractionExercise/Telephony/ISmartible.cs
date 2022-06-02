using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ISmartible : IPhone
    {
        void BrowsingInWeb(string site);
    }
}
