using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homeworke_Hotel_Api.Models
{
    public class RoomStatus
    {
        public enum EStatus
        {
            Occupied,
            Dirty,
            Ready,
            OutOfOrder
        }
    }
}
