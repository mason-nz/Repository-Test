﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Diagnostics;
using BitAuto.DSC.IM_DMS2014.Core;
namespace BitAuto.DSC.IM_DMS2014.Core
{
    /// <summary>
    /// This is our handler for the comet subscription mechanism
    /// </summary>
    public class DefaultChannelHandler : IHttpAsyncHandler
    {
        /// <summary>
        /// This is our state manager that manages the state of the client
        /// </summary>
        private static CometStateManager stateManager;

        static DefaultChannelHandler()
        {
            //
            //  Initialize 
            stateManager = new CometStateManager(
                new InProcCometStateProvider());


            stateManager.ClientInitialized += new CometClientEventHandler(stateManager_ClientInitialized);
            stateManager.ClientSubscribed += new CometClientEventHandler(stateManager_ClientSubscribed);
            stateManager.IdleClientKilled += new CometClientEventHandler(stateManager_IdleClientKilled);
        }

        static void stateManager_IdleClientKilled(object sender, CometClientEventArgs args)
        {
            //
            //  ok, write a message saying we have timed out
            Debug.WriteLine("Client Killed: " + args.CometClient.DisplayName);
            //  send a chat message
            ChatMessage cm = new ChatMessage();

            cm.From = "System";
            cm.Message = args.CometClient.DisplayName + " has left the chat room.";

            stateManager.SendMessage("ChatMessage", cm);
        }

        static void stateManager_ClientSubscribed(object sender, CometClientEventArgs args)
        {
            //
            //  ok, write a message saying we have timed out
            Debug.WriteLine("Client Subscribed: " + args.CometClient.DisplayName);
        }

        static void stateManager_ClientInitialized(object sender, CometClientEventArgs args)
        {
            //
            //  ok, write a message saying we have timed out
            Debug.WriteLine("Client Initialized: " + args.CometClient.DisplayName);
            //  send a chat message
            ChatMessage cm = new ChatMessage();

            cm.From = "System";
            cm.Message = args.CometClient.DisplayName + " has joined the chat room.";

            stateManager.SendMessage("ChatMessage", cm);
        }

        #region IHttpAsyncHandler Members

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            return stateManager.BeginSubscribe(context, cb, extraData);
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            stateManager.EndSubscribe(result);
        }

        #endregion

        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public static CometStateManager StateManager
        {
            get { return stateManager; }
        }

        #endregion
    }
}