using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;//third person controllerのスクリプトを使用するため

public class GameoverFog : MonoBehaviour
{
    [SerializeField] private GameObject gameoverCanvas;
    [SerializeField] private GameObject playerArmature;
    private bool isGameover = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//Tagを使用。nameはよくない?
        {
            isGameover = true;
            gameoverCanvas.SetActive(true);
            playerArmature.GetComponent<CharacterController>().enabled = false;
            playerArmature.GetComponent<ThirdPersonController>().enabled = false;
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
        if (isGameover == true && Input.GetKeyDown(KeyCode.Space))
        {
            // リスタート
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
