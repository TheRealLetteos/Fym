using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public class PlayerState : IState
    {

        protected AbstractStateMachine<PlayerState> m_StateMachine;

        protected PlayerState(AbstractStateMachine<PlayerState> stateMachine) {
            m_StateMachine = stateMachine;
        }

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