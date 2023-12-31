﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sail.Core.Client;
using Sail.Core.Server;
using UnityEngine;

namespace Sail.Util
{
    /// <summary>
    /// Small logger class to handle logging information.
    /// Build on the premise of minimal messaging where possible.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Logs a Sail Message to the console.
        /// </summary>
        /// <param name="message"></param>
        public static void Log(string message)
        {
            Debug.Log(AddLogStarter(message, ""));
        }

        /// <summary>
        /// Logs a Sail Warning Message to the console.
        /// </summary>
        /// <param name="message"></param>
        public static void LogWarning(string message)
        {
            Debug.LogWarning(AddLogStarter(message, "Warning: "));
        }

        /// <summary>
        /// Logs a Sail Error Message to the console.
        /// </summary>
        /// <param name="message"></param>
        public static void LogError(string message, INetworkCore core = null)
        {
            Debug.LogError(AddLogStarter(message, "Error: ", core));
        }

        /// <summary>
        /// Logs a Sail Exception Message to the console.
        /// </summary>
        /// <param name="message"></param>
        public static void LogException(Exception e)
        {
            Debug.LogException(e);
        }

        private static string AddLogStarter(string message, string additional, INetworkCore core = null)
        {
            if (core != null)
            {
                if (core.GetType() == typeof(ServerCore))
                {
                    return "[SAIL] " + " [SERVER] " + additional + message;
                }

                if (core.GetType() == typeof(ClientCore))
                {
                    return "[SAIL] " + " [CLIENT] " + additional + message;
                }
            }

            return "[SAIL] " + additional + message;
        }
    }
}