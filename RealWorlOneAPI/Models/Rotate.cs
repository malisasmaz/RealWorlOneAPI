using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealWorlOneAPI.Models {
    /// <summary>
    /// Rotation types
    /// </summary>
    public enum Rotate : ushort {
        None = 0,
        Rotate90 = 90,
        Rotate180 = 180,
        Rotate270 = 270
    }
}
