using ExitGames.Client.Photon;
using System;

namespace KDQHNPHTool.Model
{
    public class PlayerPeer : IPhotonPeerListener
    {
        public enum State
        {
            Connected,
            World,
            Disconnect
        };
        public int id;

        public delegate void OperationResponseDelegate(OperationResponse operationResponse);
        public event OperationResponseDelegate OperationResponse;

        public delegate void StatusChangedDelegate(State st);
        public event StatusChangedDelegate StatusChanged;

        public delegate void EventResponseDelegate(EventData eventData);
        public event EventResponseDelegate EventResponse;

        protected void RaiseStatusChanged(State st)
        {
            if (StatusChanged != null)
            {
                StatusChanged(st);
            }
        }

        public PlayerPeer()
        {
        }

        protected void RaiseOperationResponse(OperationResponse operationResponse)
        {
            if (OperationResponse != null)
            {
                OperationResponse(operationResponse);
            }
        }

        protected void RaiseEventResponse(EventData eventData)
        {
            if (EventResponse != null)
            {
                EventResponse(eventData);
            }
        }

        public State state = State.Disconnect;

        public void DebugReturn(DebugLevel level, string message)
        {
            Console.WriteLine("{0}: {1}", level, message);
        }

        public void OnEvent(EventData eventData)
        {
            RaiseEventResponse(eventData);
        }

        public void OnOperationResponse(OperationResponse operationResponse)
        {
            RaiseOperationResponse(operationResponse);
        }

        public void OnStatusChanged(StatusCode statusCode)
        {
            if (statusCode == StatusCode.Connect)
            {
                state = State.Connected;
            }
            else if (statusCode == StatusCode.Disconnect)
            {
                state = State.Disconnect;
            }
            RaiseStatusChanged(state);
        }
    }
}
