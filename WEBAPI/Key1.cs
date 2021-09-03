using System;
using System.Collections.Generic;

#nullable disable

namespace WEBAPI
{
    public partial class Key1
    {
        public int? Idgem { get; set; }
        public int? Idsyle { get; set; }

        public virtual Game IdgemNavigation { get; set; }
        public virtual StyleFoGame IdsyleNavigation { get; set; }
    }
}
