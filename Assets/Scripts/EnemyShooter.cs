using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform firepoint;
    [SerializeField] private Transform player;
    [SerializeField] private float Interval = 2f;

    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null) return;
        transform.LookAt(player);
        timer += Time.deltaTime;

        if(timer >= Interval)
        {
            Shoot();
            timer = 0f;
        }
    }
    void Shoot()
    {
        //上を狙う。
        Vector3 targetPos = player.position + Vector3.up * 1f;
        //playerの方向を求める
        Vector3 direction = (player.position - firepoint.position).normalized;//ベクトルの長さを一つに決める

        GameObject bullet = Instantiate(BulletPrefab, firepoint.position, Quaternion.identity);
        bullet.transform.forward = direction;
    }
}
