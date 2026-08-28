using UnityEngine;
using TMPro;
public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
 
    [SerializeField] private Camera maincamera;
   
    [SerializeField] private int maxAmmmo = 7;
    [SerializeField] private float ReloadTime = 3f;
    
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip reloadSound;

    private int currentAmmo;
    private bool isReloading = false;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentAmmo = maxAmmmo;
        UpdateAmmoText();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }


        if (Input.GetMouseButtonDown(0))//左クリックで発射
        {

            if(currentAmmo > 0)
            {
                shoot();
                currentAmmo--;
                UpdateAmmoText();

                if(currentAmmo <= 0)
                {
                    StartCoroutine(Reload());
                }
            }

            
        }
       
    }
    
    void UpdateAmmoText()
    {
        if(ammoText != null)
        {
            ammoText.text = currentAmmo + " / " + maxAmmmo; 
        }
    }

        void shoot()
    {
        //直線で飛ばしたいためRayを使用
        Ray ray = maincamera.ScreenPointToRay(new Vector3(Screen.width / 2,  Screen.height / 2, 0));//真ん中を指定
        Vector3 targetPoint = ray.GetPoint(1000f);//適当な遠さ
        Vector3 spawnPos = maincamera.transform.position + maincamera.transform.forward * 1.5f;
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);//投げるものの指定
        bullet.transform.forward = (targetPoint - spawnPos).normalized;
        audioSource.PlayOneShot(shootSound, 0.5f);
    }
//3秒待ってから実行するため、voidではなくIEnumeratorを使う
    System.Collections.IEnumerator Reload(){
        isReloading = true;
        if(ammoText != null)
        {
            ammoText.text = "Reloading...";

        }
        audioSource.PlayOneShot(reloadSound, 0.5f);
        yield return new WaitForSeconds(ReloadTime);//3秒待つ
        currentAmmo = maxAmmmo;
        UpdateAmmoText();
        isReloading = false;
    }
}
