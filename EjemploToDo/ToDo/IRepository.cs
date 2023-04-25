﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    public interface IRepository
    {
        void Add(string description);
        int Count();
    }
}
