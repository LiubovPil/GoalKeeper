using System.Collections.Generic;
using UnityEngine.Events;
using GoalKeeper.Interactables;
using GoalKeeper.UI;


namespace GoalKeeper.Controllers
{
    public static class EventManager 
    {
        private static List<ProgressInteractable> _invokersChangeProgressEvent = new List<ProgressInteractable>();
        private static UnityAction<int> _listenerChangeProgressEvent;

        private static List<CoinInteractable> _invokersChangeScoreEvent = new List<CoinInteractable>();
        private static UnityAction<int> _listenerChangeScoreEvent;

        private static UITimer _invokerFinishGameEvent;
        private static UnityAction _listenerFinishGameEvent;

        public static void AddInvokerChangeProgressEvent(ProgressInteractable invoker)
        {
            _invokersChangeProgressEvent.Add(invoker);

            if (_listenerChangeProgressEvent != null)
            {
                invoker.AddChangeProgressEvent(_listenerChangeProgressEvent);
            }
        }
        public static void AddListenerChangeProgressEvent(UnityAction<int> listener)
        {
            _listenerChangeProgressEvent = listener;

            foreach (ProgressInteractable invoker in _invokersChangeProgressEvent)
                invoker.AddChangeProgressEvent(_listenerChangeProgressEvent);
        }
        public static void AddInvokerChangeScoreEvent(CoinInteractable invoker)
        {
            _invokersChangeScoreEvent.Add(invoker);

            if (_listenerChangeScoreEvent != null)
            {
                invoker.AddListenerChangeScoreEvent(_listenerChangeScoreEvent);
            }
        }
        public static void AddListenerChangeScoreEvent(UnityAction<int> listener)
        {
            _listenerChangeScoreEvent = listener;

            foreach (CoinInteractable invoker in _invokersChangeScoreEvent)
                invoker.AddListenerChangeScoreEvent(_listenerChangeProgressEvent);
        }
        public static void AddInvokerFinishGameEvent(UITimer invoker)
        {
            _invokerFinishGameEvent = invoker;

            if (_listenerFinishGameEvent != null)
            {
                _invokerFinishGameEvent.AddListenerFinishGameEvent(_listenerFinishGameEvent);
            }
        }
        public static void AddListenerFinishGameEvent(UnityAction listener)
        {
            _listenerFinishGameEvent = listener;

            if (_invokerFinishGameEvent != null)
            {
                _invokerFinishGameEvent.AddListenerFinishGameEvent(_listenerFinishGameEvent);
            }
        }
    }
}
