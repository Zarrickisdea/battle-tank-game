using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private BaseState currentState;

    public BaseState CurrentState { get => currentState; set => currentState = value; }

    public void ChangeState(BaseState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateLogic();
        }
    }

    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdatePhysics();
        }
    }

    private void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }
}
