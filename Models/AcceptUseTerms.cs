﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AcceptUseTerms
    {
        public int Id { get; set; }
        public UseTerms? UseTerms { get; set; }
        public DateTime AcceptanceDate { get; set; }
        public Client? Client { get; set; }
    }
}
