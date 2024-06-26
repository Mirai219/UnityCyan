using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState currentState;
    protected Dictionary<System.Type, IState> stateTable;
    void Update()
    {
        currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        currentState.PhysicUpdate();
    }

    protected void SwitchOn(IState newState)
    {
        currentState = newState;
        currentState.Enter();
    }
    protected void SwitchOn(System.Type newState)
    {
        currentState = stateTable[newState];
        currentState.Enter();
    }
    public void SwitchState(IState newState)
    {
        currentState.Exit();
        SwitchOn(newState);
    }

    public void SwitchState(System.Type newState)
    {
        SwitchState(stateTable[newState]);
    }

    private void OnGUI()
    {
        Rect rect = new Rect(300, 300, 200, 200);
        string msg = "current state:" + currentState;
        GUIStyle gUIStyle = new GUIStyle();

        gUIStyle.fontSize = 20;
        gUIStyle.fontStyle = FontStyle.Bold;
        GUI.Label(rect, msg, gUIStyle);
    }
}
