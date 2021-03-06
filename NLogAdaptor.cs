﻿using System;
using NLog;

namespace InternetScanner
{
	public class NLogAdaptor : ILog
	{
		public Logger Logger { get; set; }

		public NLogAdaptor()
		{
			Logger = LogManager.GetCurrentClassLogger();
		}

		public void Info(string message)
		{
			Logger.Info(message);
		}

		public void Trace(string message)
		{
			Logger.Trace(message);
		}

		public void Debug(string message)
		{
			Logger.Debug(message);
		}

		public void Error(string message)
		{
			Logger.Error(message);
		}

		public void Warning(string message)
		{
			Logger.Warn(message);
		}

		public void ErrorException(string message, Exception ex)
		{
			Logger.Error(ex, message);
		}
	}
}
