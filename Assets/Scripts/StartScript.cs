using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{

public void ChangeScene(string SceneName)
        {
            SceneManager.LoadScene(SceneName);//ロード
            Cursor.lockState = CursorLockMode.Locked;//真ん中に固定
            Cursor.visible = false;//カーソルを非表示
            
        }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
