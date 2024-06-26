using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerInputSettings inputActions;

    [SerializeField] float jumpBufferInputTime = 0.5f;
    WaitForSeconds waiJumpBufferInputTime;
    public Vector2 Axes => inputActions.GamePlay.Axes.ReadValue<Vector2>();
    public float AxisX => Axes.x;
    public float AxisY => Axes.y;
    public bool Move => AxisX != 0f;

    public bool HasJumpBuffer {  get; set; }

    public bool Jump => inputActions.GamePlay.Jump.WasPressedThisFrame();
    public bool StopJump => inputActions.GamePlay.Jump.WasReleasedThisFrame();
    private void Awake()
    {
        inputActions = new PlayerInputSettings();
        waiJumpBufferInputTime = new WaitForSeconds(jumpBufferInputTime);
    }

    private void OnEnable()
    {
        inputActions.GamePlay.Jump.canceled += delegate
        {
            HasJumpBuffer = false;
        };
    }

    public void EnableGamePlayInputs()
    {
        inputActions.GamePlay.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnGUI()
    {
        Rect rect = new Rect(200,200,200,200);
        string msg = "Has Jump Buffer:" + HasJumpBuffer;
        GUIStyle gUIStyle = new GUIStyle();

        gUIStyle.fontSize = 20;
        gUIStyle.fontStyle = FontStyle.Bold;
        GUI.Label(rect,msg,gUIStyle);
    }

    public void SetJumpBufferInputTimer()
    {
        StopCoroutine(nameof(JumpBufferInputCoroutine));
        StartCoroutine(nameof(JumpBufferInputCoroutine));
    }

    IEnumerator JumpBufferInputCoroutine()
    {
        HasJumpBuffer = true;
        yield return waiJumpBufferInputTime;
        HasJumpBuffer = false;
    }


}
