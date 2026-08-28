using UnityEngine;

public class lightsphere : MonoBehaviour
{
    //プレイヤーの距離その他パラメーター
    [SerializeField] private Transform Player;
    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] private float runAwayDistance = 10f; 
    [SerializeField] private float acceleration = 8f;

    // 上下するための変数
    [SerializeField] private float bobbingSpeed = 2f;
    [SerializeField] private float bobbingHeight = 0.3f;
    [SerializeField] private float hoverHeight = 1.5f;

    //後半直進以外に動く変数
    [SerializeField] private Transform[]Waypoints;
    [SerializeField] private float WaypointSpeeed = 3f;
    [SerializeField] private float WaypointDistance = 0.3f;

    //捕まった後の処理
    [SerializeField]private Transform finalGoal;
    [SerializeField]private float finalSpeed;

    [SerializeField]private GameObject FinalBattleObjects;

    private float currentSpeed = 0f;//速さ
    private float startY; //記録

    private bool WayPointStart = false;
    private int currentIndex = 0;

    private bool finalMove = false;

    private bool finalbattle = false;


    void Start()
    {
        startY = transform.position.y;
        FinalBattleObjects.SetActive(false);
    }

    void Update()
    {
        //waypointを追加するための分岐
        if (Player == null) return;

        if(WayPointStart == false)
        {
            ChaseMove();
        }else
        {
            WaypointMove();
        } 
    }
    //プレイヤーとの距離の処理
        void ChaseMove(){
            //離れたら止まる
        float distToPlayer = Vector3.Distance(transform.position, Player.position);
        if (distToPlayer < runAwayDistance)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, acceleration * Time.deltaTime);
        }

        
        //上下の動きと段差を登らすためのやつ
        Vector3 pos = transform.position + transform.forward * currentSpeed * Time.deltaTime;

        if (Physics.Raycast(pos , Vector3.down, out RaycastHit hit, 20f))
        {
            float groundY = hit.point.y;
            pos.y = groundY + hoverHeight + Mathf.Sin(Time.time * bobbingSpeed) * bobbingHeight;
        } 
        
        transform.position = pos;
        }

        //チェックポイントの処理
        void WaypointMove()
        {
            //すべてのチェックポイントを回ったら停止
            if(currentIndex >= Waypoints.Length)
        {
            //敵やUIの有効化
            if(finalbattle == false)
            {
                finalbattle = true;
                if(FinalBattleObjects != null)
                {
                    FinalBattleObjects.SetActive(true);
                }
            }

            //最後の動き
            if(finalMove && finalGoal != null)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    finalGoal.position,
                    finalSpeed * Time.deltaTime
                );
            }
            return;
        }

            float distancePlayer = Vector3.Distance(transform.position, Player.position);

            if (distancePlayer < runAwayDistance)
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, WaypointSpeeed, acceleration * Time.deltaTime);
            }
            else
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, acceleration * Time.deltaTime);
            }
            
            Transform target = Waypoints[currentIndex];
            transform.position = Vector3.MoveTowards(
                transform.position,//今の場所
                target.position,//目的地
                currentSpeed * Time.deltaTime//一回で進む速さ
            );
            //チェックポイントを数える
            if(Vector3.Distance(transform.position, target.position) < WaypointDistance)
            {
                currentIndex++;
            }
        }


        private void OnTriggerEnter(Collider other)
    {
        //チェックポイントの移動の確認
        if (other.CompareTag("ClimbStart"))
        {
            WayPointStart = true;
        }
    }

    public void Release()
    {
        FinalBattleObjects.SetActive(false);
        finalMove = true;
    }
}
