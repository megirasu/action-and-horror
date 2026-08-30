using UnityEngine;

public class FogChaser : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float moveSpeed = 2f; 

    void Update()
    {
        if (Player == null) return;
        // プレイヤーの場所を取得し、playerがジャンプしても飛ばないよう固定。
        Vector3 targetPosition = Player.position;
        targetPosition.y = transform.position.y;

        // プレイヤーに向かって一定のスピードで進む
        transform.position = Vector3.MoveTowards(
            transform.position,//現在
            targetPosition,//目的地
            moveSpeed * Time.deltaTime
        );

    }
}
