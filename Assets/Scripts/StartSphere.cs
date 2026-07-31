using UnityEngine;

public class StartSphere : MonoBehaviour
{

//左右に動かす関数
    [SerializeField] private float moveWidth = 3f;  
    [SerializeField] private float moveSpeed = 1f;  
//上下させる関数 
    [SerializeField] private float bobbingSpeed = 2f; 
    [SerializeField] private float bobbingHeight = 0.3f; 

    private Vector3 startPositon;
    void Start()
    {
        startPositon = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Sin(Time.time * moveSpeed) * moveWidth;
        float y = Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;

        // 最初の位置を基準に動かす
        transform.position = startPositon + new Vector3(x, y, 0);
    }

}
