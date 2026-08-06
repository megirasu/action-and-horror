using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform CenterFirePoint;
    [SerializeField] private Transform firePoint;//球の出る位置。
    [SerializeField] private Camera maincamera;
   
    [SerializeField] private int maxAmmmo = 7;
    [SerializeField] private float ReloadTime = 3f;
    
    private int currentAmmo;
    private bool isReloading = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAmmo = maxAmmmo;
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

                if(currentAmmo <= 0)
                {
                    StartCoroutine(Reload());
                }
            }

            
        }
       
    }

        void shoot()
    {
        //カメラの向きに投げる
        Vector3 ShootDirection = maincamera.transform.forward;
        GameObject bullet;
        if(Input.GetMouseButton(1))//右クリックで狙い撃ち
        {
             bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity//
             );
        }
        else
        {
            bullet = Instantiate(bulletPrefab, CenterFirePoint.position, Quaternion.identity);
        }
        
        
        bullet.transform.forward  = ShootDirection;
    }
//3秒待ってから実行するため、voidではなくIEnumeratorを使う
    System.Collections.IEnumerator Reload(){
        isReloading = true;
        yield return new WaitForSeconds(ReloadTime);//3秒待つ
        currentAmmo = maxAmmmo;
        isReloading = false;
    }
}
