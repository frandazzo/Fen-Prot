﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WIN.SCHEDULING_APPLICATION.DOMAIN
{
    public interface ILastProtocolNumberRetriever
    {
        int GetLastProtocolNumber(int year);
    }
}
