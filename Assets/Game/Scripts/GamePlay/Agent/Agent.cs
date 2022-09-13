using PrehistoricPlatformer.StatePattern;
using UnityEngine;

namespace PrehistoricPlatformer.Agent
{
    public class Agent:MonoBehaviour
    {
        [Header("Data")]
        public AgentDataSO agentData;

        [Header("Component's Reference")]
        public Rigidbody2D rb2d;
        public AgentInput agentInput;
        public AgentAnimation agentAnimation;
        public AgentRenderer agentRenderer;
        public GroundDetector groundDetector;
        public ClimbingDetector climbingDetector;

        private State currentState = null, previousState = null;

        [Header("Starting State")]
        public State idleState;

        [Header("State Debugging")] public string stateName = string.Empty;
        private void Awake()
        {
            TryGetComponent<Rigidbody2D>(out rb2d);
            agentInput = GetComponentInParent<AgentInput>();
            agentAnimation = GetComponentInChildren<AgentAnimation>();
            agentRenderer = GetComponentInChildren<AgentRenderer>();
            groundDetector = GetComponentInChildren<GroundDetector>();
            climbingDetector = GetComponentInChildren<ClimbingDetector>();

            State[] states = GetComponentsInChildren<State>();
            foreach (State state in states)
            {
                state.InitializeState(this);
            }

        }

        private void OnEnable()
        {
           agentInput.OnMovement += agentRenderer.faceDirection;
        }

        private void Start()
        {
            TransitionToState(idleState);
        }

        private void OnDisable()
        {
            agentInput.OnMovement -= agentRenderer.faceDirection;
        }

        public void TransitionToState(State desireState)
        {
            if(desireState==null)    return;

            if(currentState!=null)    currentState.Exit();

            previousState = currentState;
            currentState = desireState;
            currentState.Enter();

            DisplayState();
        }

        private void DisplayState()
        {
            if (previousState == null || previousState.GetType() != currentState.GetType())
            {
                stateName = currentState.GetType().ToString();
            }
        }

        private void Update()
        {
            currentState.StateUpdate();
        }

        private void FixedUpdate()
        {
            groundDetector.CheckIsGrounded();
            currentState.StateFixedUpdate();
        }

        public void AgentDie()
        {
            //
        }



    }// class
}// namespace