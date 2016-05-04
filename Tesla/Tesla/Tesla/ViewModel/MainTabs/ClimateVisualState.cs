﻿using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel.MainTabs
{
	public class ClimateVisualState : VisualState
	{
		public ClimateVisualState(IBaseModel model) : base(model) { }

		public override void Init()
		{
			Task.Run(async () =>
			{
				await ClimateModel.GetTemperature();
			});
		}

		//TODO: not liking this wire up, see if there is a better way
		protected override void OnModelStatePropertyChanged(string propertyName)
		{
			if (propertyName == nameof(IClimateModelState.Temperature))
			{ Temperature = ((Model as IClimateModel).ModelState as IClimateModelState).Temperature; }
		}

		private IClimateModel ClimateModel
		{
			get
			{
				return base.Model as IClimateModel;
			}
		}

		private double _temperature = 0;
		public double Temperature
		{
			get
			{
				return _temperature;
			}
			set
			{
				_temperature = value;
				OnPropertyChanged();
			}
		}
	}
}
