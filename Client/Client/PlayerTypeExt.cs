using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedModel;

namespace Client
{
    internal static class PlayerTypeExt
    {
        public static string GetSymbol(this PlayerType playerType, bool isUpperCase)
        {
            switch (playerType)
            {
                case PlayerType.Cross:
                    return isUpperCase ? "X" : "x";
                case PlayerType.Zero:
                    return isUpperCase ? "O" : "o";
                default:
                    throw new InvalidEnumArgumentException(nameof(playerType));
            }
        }
    }
}
