using System;
using UnityEngine;

namespace PrehistoricPlatformer.StatePattern
{
    public class StateFactory : MonoBehaviour
    {
        [SerializeField] private State idle, move, fall, climbing, attack, jump;

        public State GetState(StateType stateType)
        {
            switch (stateType)
            {
                case StateType.Idle:
                    return idle;
                    break;
                case StateType.Move:
                    return move;
                    break;
                case StateType.Fall:
                    return fall;
                    break;
                case StateType.Climbing:
                    return climbing;
                    break;
                case StateType.Attack:
                    return attack;
                    break;
                case StateType.Jump:
                    return jump;
                    break;
                default:
                    throw new System.Exception("State Not Found:" + stateType.ToString());
            }
        }

        public void InitializeStates(Agent.Agent agent)
        {
            State[] states = GetComponents<State>();
            foreach (State state in states)
            {
                state.InitializeState(agent);
            }
        }
    }//class
}// namespace
