﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BI.GST.Application.Interface
{
    public interface IBaseAppService
    {
        void BeginTransaction();

        void Commit();
    }
}
