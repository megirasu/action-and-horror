using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class GoalScript : MonoBehaviour
{
    [SerializeField] private GameObject ClearCanvas;
    [SerializeField] private GameObject playerArmature;
    [SerializeField] private AudioSource gameBGM;    
    [SerializeField] private AudioSource goalBGM;   
    [SerializeField] private string titleSceneName = "TitleScene";

    private bool isClear = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//Tagを使用。
        {
            //ゴール画面を表示し、操作をできなくさせる。加えてBGM再生
            ClearCanvas.SetActive(true);
            playerArmature.GetComponent<CharacterController>().enabled = false;
            playerArmature.GetComponent<ThirdPersonController>().enabled = false;
            isClear = true;
            if (gameBGM != null) gameBGM.Stop();    // ゲーム中の曲を止め、ゴールの音を再生
            if (goalBGM != null) goalBGM.Play();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // スペースを押すとタイトルに戻るように設定。
        if (isClear == true && Input.GetKeyDown(KeyCode.Space))
        {
        SceneManager.LoadScene(titleSceneName);    
        }
    }
}
