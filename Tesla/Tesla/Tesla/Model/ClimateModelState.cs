﻿using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Model
{
    public class ClimateModelState: ModelState
    {
		public double Temperature { get { return Get<double>(); } set { Set(value); } }
	}
}
