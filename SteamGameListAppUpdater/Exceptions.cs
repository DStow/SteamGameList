using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamGameListAppUpdater
{
    public class ToManyAPIRequestsException : ApplicationException
    {
        public ToManyAPIRequestsException()
                    : base("To many requests have been made to the Steam API!")
        {

        }
    }
}
