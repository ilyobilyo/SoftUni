using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    public class InputCarModel
    {
        public InputCarModel()
        {
            PartIds = new List<int>();
        }
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public List<int> PartIds { get; set; }
    }
}
