using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public interface IObservedObject
    {

        public void Notify(IEvent e);
        public void RegisterObserver(IObserver observer);

    }
}