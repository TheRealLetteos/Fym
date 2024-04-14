using fym;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public class AbstractObservedObject : MonoBehaviour, IObservedObject
    {

        protected List<IObserver> observers = new List<IObserver>();

        public void Notify(GameEvent e)
        {
            foreach (IObserver observer in observers)
            {
                observer.OnNotify(e);
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            if(!observers.Contains(observer))
                observers.Add(observer);
        }

    }
}