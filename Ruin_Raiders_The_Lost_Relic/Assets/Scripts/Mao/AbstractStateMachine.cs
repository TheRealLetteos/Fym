using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fym
{

    public abstract class AbstractStateMachine<T> : MonoBehaviour where T : IState
    {
        protected T m_currentState;
        protected List<T> m_possibleStates;

        protected virtual void Awake()
        {
            CreatePossibleStates();
        }

        protected virtual void Start()
        {
            foreach (IState state in m_possibleStates)
            {
                state.OnStart();
            }
            m_currentState = m_possibleStates[0];
            m_currentState.OnEnter();
        }

        protected virtual void Update()
        {
            //Debug.Log(GetType() + "Current state:" +  m_currentState.GetType());
            m_currentState.OnUpdate();
            TryStateTransition();
        }

        protected virtual void FixedUpdate()
        {
            //Debug.Log(GetType() + "Current state:" + m_currentState.GetType());
            m_currentState.OnFixedUpdate();
        }

        protected virtual void CreatePossibleStates()
        {

        }


        protected void TryStateTransition()
        {
            if (!m_currentState.CanExit())
            {
                return;
            }

            foreach (var state in m_possibleStates)
            //for(int i=0;i<m_possibleStates.Count;i++)
            {
                //var state = m_possibleStates[(i+1) % m_possibleStates.Count];
                if (m_currentState.Equals(state))
                {
                    continue;
                }

                if (state.CanEnter(m_currentState))
                {
                    //quit current state
                    m_currentState.OnExit();
                    m_currentState = state;
                    //enter new state
                    m_currentState.OnEnter();
                    return;
                }
            }
        }

        public List<T> GetAllStates()
        {
            return m_possibleStates;
        }
    }


}
