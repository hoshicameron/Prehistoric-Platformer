using PrehistoricPlatformer.StatePattern;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.Agent
{
    public class Agent:MonoBehaviour
    {
        [field: Header("Data")]
        [field:SerializeField]
        public AgentDataSO AgentData { get; private set; }
        public Rigidbody2D Rb2D { get; private set; }
        public AgentInput AgentInput { get; private set; }
        public AgentAnimation AgentAnimation { get; private set; }
        public AgentRenderer AgentRenderer { get; private set; }
        public GroundDetector GroundDetector { get; private set; }
        public ClimbingDetector ClimbingDetector { get; private set; }

        private State currentState = null, previousState = null;

        [Header("Starting State")][SerializeField]
        private State idleState;

        [Header("State Debugging")] [SerializeField]
        private string stateName = string.Empty;

        [field:SerializeField]
        private UnityEvent OnRespawnRequired { get; set; }
        private void Awake()
        {
            Rb2D = GetComponent<Rigidbody2D>();
            AgentInput = GetComponentInParent<AgentInput>();
            AgentAnimation = GetComponentInChildren<AgentAnimation>();
            AgentRenderer = GetComponentInChildren<AgentRenderer>();
            GroundDetector = GetComponentInChildren<GroundDetector>();
            ClimbingDetector = GetComponentInChildren<ClimbingDetector>();

            State[] states = GetComponentsInChildren<State>();
            foreach (State state in states)
            {
                state.InitializeState(this);
            }

        }

        private void OnEnable()
        {
           AgentInput.OnMovement += AgentRenderer.faceDirection;
        }

        private void Start()
        {
            TransitionToState(idleState);
        }

        private void OnDisable()
        {
            AgentInput.OnMovement -= AgentRenderer.faceDirection;
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
            GroundDetector.CheckIsGrounded();
            currentState.StateFixedUpdate();
        }

        public void AgentDie()
        {
            OnRespawnRequired?.Invoke();
        }



    }// class
}// namespace