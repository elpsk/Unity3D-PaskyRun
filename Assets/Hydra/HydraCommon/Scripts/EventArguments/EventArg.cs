// <copyright file=EventArg company=Hydra>
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Christopher Cameron</author>

using System;

namespace Hydra.HydraCommon.EventArguments
{
	public class EventArg<T> : EventArgs
	{
		private readonly T m_EventData;

		/// <summary>
		/// 	Gets the data.
		/// </summary>
		/// <value>The data.</value>
		public T data { get { return m_EventData; } }

		/// <summary>
		/// 	Initializes a new instance of the <see cref="Hydra.HydraCommon.EventArguments.EventArg`1"/> class.
		/// </summary>
		/// <param name="data">Data.</param>
		public EventArg(T data)
		{
			m_EventData = data;
		}
	}
}
