using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int maxHP = 3;
    [SerializeField] private Slider hpBar;
    [SerializeField] private GameObject gameoverCanvas;
    [SerializeField] private GameObject playerArmature;
    private int currentHP;
    private bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
        if(hpBar != null)
        {
            hpBar.maxValue = maxHP;
            hpBar.value = currentHP;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ゲームオーバー時スペースを押すとリスタート
        if(isDead == true && Input.GetKeyDown(KeyCode.Space))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }

    public void TakeDamage(int damage)
    {
        if(isDead == true)return;
        currentHP -= damage;
        if(hpBar != null)
        {
            hpBar.value = currentHP;
        }

        if(currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //ゲームオーバー画面を表示し、入力を受けないようにする。
        isDead = true;
        if(gameoverCanvas != null)
        {
            gameoverCanvas.SetActive(true);
        }
        if(playerArmature != null)
        {
            playerArmature.GetComponent<CharacterController>().enabled = false;
            playerArmature.GetComponent<StarterAssets.ThirdPersonController>().enabled = false;
        }
    }
}
