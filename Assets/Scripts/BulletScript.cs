using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 3f;
    [SerializeField]private int damage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
//当たった時に確認
    private void OnTriggerEnter(Collider other)
    {
        //敵かどうか確認し、そうならダメージを受けさせる
        EnemyHP enemy = other.GetComponent<EnemyHP>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
