using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public abstract class GameState : IState, IObserver
    {

        protected GameManager _fsm;

        protected bool canEnter = false;

        public GameState(GameManager stateMachine)
        {
            _fsm = stateMachine;
        }

        public bool CanEnter(IState currentState)
        {
            return canEnter;
        }

        public bool CanExit()
        {
            return true;
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }

        public void OnFixedUpdate()
        {
        }

        public void OnStart()
        {
        }

        public void OnUpdate()
        {
        }

        public abstract void OnNotify(GameEvent e);

    }
}