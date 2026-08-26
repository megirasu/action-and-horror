using UnityEngine;

public class SampleFootsteps : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;//音のなる場所。PlayerAmatureにアタッチ
    [SerializeField] private AudioClip[] footstepSounds;//音そのもの
    [SerializeField] private AudioClip[] planeSounds;//着地の音
    [SerializeField] private float interval = 0.5f;

    private CharacterController controller;
    private float timer = 0f;
    private bool plane = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.velocity.magnitude > 0.1f && controller.isGrounded)//地面の設置を確認し、その時のみ実行。
        {
            timer += Time.deltaTime;
            if(timer >= interval)
            {
                PlayFootstep();
                timer = 0f;
            }
        }
         if (plane == false && controller.isGrounded == true)
        {
            PlayPlane();
        }
        plane = controller.isGrounded; 
    }

            void PlayFootstep()
        {
            if(footstepSounds.Length == 0)return;
            int index = Random.Range(0,footstepSounds.Length);
            audioSource.PlayOneShot(footstepSounds[index]);//一度だけ鳴らす
        }
        void PlayPlane()
    {
        if (plane != null)
        {
            if(planeSounds.Length == 0)return;
            int index = Random.Range(0,planeSounds.Length);
            audioSource.PlayOneShot(planeSounds[index]);//一度だけ鳴らす
        }
    }
}
