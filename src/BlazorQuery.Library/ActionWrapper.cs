using Microsoft.JSInterop;
using System;

namespace BlazorQuery.Library
{
	public class ActionWrapper<T>
	{
		private readonly Action<T> _action;

		public ActionWrapper(Action<T> action)
		{
			_action = action;
		}

		// Callbacks
		[JSInvokable]
		public void ActionCallback(T obj)
		{
			_action(obj);
		}
	}
}
