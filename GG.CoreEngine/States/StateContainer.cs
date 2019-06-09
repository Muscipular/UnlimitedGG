using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.States
{
    public class StateContainer
    {
        private readonly Dictionary<string, IState> States = new Dictionary<string, IState>();


        public StateContainer(params IState[] states)
        {
            foreach (var state in states)
            {
                States.Add(state.Name, state);
            }
        }

        public T Get<T>(string name = null) where T : IState
        {
            if (States.TryGetValue(name ?? typeof(T).Name, out var state))
            {
                return (T)state;
            }
            return default(T);
        }
    }
}