﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckInSystem.Objects
{
    public class BaseEntity
    {
        #region Attributes        
        private string id;
        #endregion

        #region Properties        
        public string Id { get { return id; } set { id = value; } }
        #endregion
    }
}
