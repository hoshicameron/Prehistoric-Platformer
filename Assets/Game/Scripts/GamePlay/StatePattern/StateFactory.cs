using System;
using UnityEngine;

namespace PrehistoricPlatformer.StatePattern
{
    public class StateFactory : MonoBehaviour
    {
        [SerializeField] private State idle, move, fall, climbing, attack, jump;

        public State GetState(StateType stateType)
        {
            return stateType switch
            {
                StateType.Idle => idle,
                StateType.Move => move,
                StateType.Fall => fall,
                StateType.Climbing => climbing,
                StateType.Attack => attack,
                StateType.Jump => jump,
                _ => throw new System.Exception("State Not Found:" + stateType.ToString())
            };
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
