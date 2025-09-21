namespace serverManagement2.StateStore
{
    public class Observer
    {
        protected Action? _listeners;

        public void AddStateChangeListeners(Action? listener)
        {
            if(listener != null) 
                _listeners += listener;
        }

        public void RemoveStateChangeListeners(Action? listener) 
        {
            if(_listeners != null)
                _listeners -= listener;
        }

        public void BroadcastStateChange()
        {
            _listeners?.Invoke();
        }
    }
}
