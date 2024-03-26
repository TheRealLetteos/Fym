using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public abstract class GameState : IState
    {

        protected AbstractStateMachine<GameState> _fsm;


        public bool CanEnter(IState currentState)
        {
            throw new System.NotImplementedException();
        }

        public bool CanExit()
        {
            throw new System.NotImplementedException();
        }

        public void OnEnter()
        {
            throw new System.NotImplementedException();
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
    }
}