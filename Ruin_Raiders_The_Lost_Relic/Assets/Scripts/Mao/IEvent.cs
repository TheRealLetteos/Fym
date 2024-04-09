using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public interface IEvent
    {

        public string GetName();

        public object GetSender();

        public double GetTime();

    }
}
