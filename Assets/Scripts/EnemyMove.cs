using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float StopDistance = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         if(player == null)return;

        float distance = Vector3.Distance(transform.position, player.position);//２点間の距離取得

        //近づいたらゆっくり動き出す。
        if(distance > StopDistance)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,//今の位置か
                player.position,//プレイヤーの位置
                moveSpeed * Time.deltaTime//速度
            );
        }
    }
}
