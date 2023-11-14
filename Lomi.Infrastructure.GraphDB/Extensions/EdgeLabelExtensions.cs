using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Extensions
{
    public static class EdgeLabelExtensions
    {
        public static int LocationOrder(this EdgeLabel edgeLabel)
        {
            if (edgeLabel == EdgeLabel.LivesIn)
                return 4;
            if (edgeLabel == EdgeLabel.WorksIn)
                return 3;
            if (edgeLabel == EdgeLabel.WorksAt)
                return 2;
            if (edgeLabel == EdgeLabel.In)
                return 1;
            return 0;
        }
    }
}