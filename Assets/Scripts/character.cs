//結局このコードを使わず、アセッツのキャラ操作使用
using UnityEngine;

public class character : MonoBehaviour
{
    [SerializeField] private float walkspeed =5f;
    [SerializeField] private float runspeed = 10f;
    [SerializeField] private Transform cam;
    [SerializeField] private float MouseSensitivity = 2f;

    private CharacterController controller;
    private float pitch = 0f;
    private float yaw = 0f;


    void Start()
    {
        //キャラクターコントローラーとカーソル削除
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        //wasd移動
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        Vector3 move = new Vector3(h,0f,v);

        controller.Move(move * walkspeed * Time.deltaTime);
        if(isRunning == true){
            controller.Move(move * runspeed * Time.deltaTime);
        }

        //カメラ操作
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

        pitch -= mouseY;
        yaw += mouseX;

        pitch = Mathf.Clamp(pitch, -90f, 90f);
        
        cam.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
