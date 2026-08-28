using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;//third person controllerのスクリプトを使用するため

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
        if (other.CompareTag("Player"))//Tagを使用。nameはよくない?
        {
            ClearCanvas.SetActive(true);
            playerArmature.GetComponent<CharacterController>().enabled = false;
            playerArmature.GetComponent<ThirdPersonController>().enabled = false;
            isClear = true;
            if (gameBGM != null) gameBGM.Stop();    // ゲーム中の曲を止める
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
        // スペース
        if (isClear == true && Input.GetKeyDown(KeyCode.Space))
        {
        SceneManager.LoadScene(titleSceneName);    
        }
    }
}
