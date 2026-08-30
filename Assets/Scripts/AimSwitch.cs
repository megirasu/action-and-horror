using UnityEngine;

public class AimSwitch : MonoBehaviour
{
    [SerializeField] private GameObject aimCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aimCamera.SetActive(false);//基本は3人称のためスタート時false
    }

    // Update is called once per frame
    void Update()
    {
        //押してる時のみ
        if(Input.GetMouseButton(1))
        {
            aimCamera.SetActive(true);
        }
        else 
        {
            aimCamera.SetActive(false);
        }
    }
}
