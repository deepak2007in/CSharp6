using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IOCompletionPort
{
    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
    public struct Overlapped
    {
        // UInt32* ulpInternal;
        // UInt32* ulpInternalHigh;
        Int32 lOffset;
        Int32 lOffsetHigh;
        UInt32 hEvent;
    }

    
}
