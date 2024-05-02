using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{
    public abstract class GameState : IState, IObserver
    {

        protected GameManager m_gameManager;

        protected bool canEnter = false;

        public GameState(GameManager stateMachine)
        {
            m_gameManager = stateMachine;
        }

        public virtual bool CanEnter(IState currentState)
        {
            return canEnter;
        }

        public virtual bool CanExit()
        {
            return true;
        }

        public virtual void OnEnter()
        {
            Debug.Log("Entering " + this.GetType().Name);
        }

        public virtual void OnExit()
        {
            Debug.Log("Exiting " + this.GetType().Name);
            canEnter = false;
        }

        public virtual void OnFixedUpdate()
        {
        }

        public virtual void OnStart()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnNotify(GameEvent e)
        {
        }

    }
}