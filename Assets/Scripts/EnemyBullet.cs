using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 3f;
    [SerializeField]private int damage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);//蓄積させないよう、球を消滅させる。
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);//玉の速度
    }

//当たった時に確認
    private void OnTriggerEnter(Collider other)
    {
        PlayerHP player = other.GetComponent<PlayerHP>();//ぶつかった相手のPlayerHPをplayerと名付けHPを取得する。
        if(player != null)
        {
            player.TakeDamage(damage);
        }
        Destroy(gameObject);//ものに当たったら消滅するように、プレイヤーでなくても消滅させる。
    }
}
