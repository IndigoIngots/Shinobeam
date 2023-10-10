using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMove : MonoBehaviour
{
    int life = 3;

    //���[���̈ړ��̐��l�����ꂼ��̕ϐ��Ő錾���܂��B
    [SerializeField] int MinLane = -2;
    [SerializeField] int MaxLane = 2;
    [SerializeField] float LaneWidth = 1.0f;

    //CharacterController�^��ϐ�controller�Ő錾���܂��B
    CharacterController controller;

    //Animator�^��ϐ�animator�Ő錾���܂��B
    [SerializeField] Animator animator;

    //���ꂼ��̍��W���O�Ő錾���܂��B
    Vector3 moveDirection = Vector3.zero;
    //int�^��ϐ�targetLane�Ő錾���܂��B
    int targetLane;

    //���ꂼ��̃p�����[�^�[�̐ݒ��Inspector�ŕς���l�ɂ��܂��B
    [SerializeField] float gravity;
    [SerializeField] float speedZ;
    [SerializeField] float speedX;
    [SerializeField] float speedJump;
    [SerializeField] float accelerationZ;

    [SerializeField] GameObject Shuriken;
    int ShotTimer;

    bool isAirJump = false;

    bool isPlay = false;

    [SerializeField] GameManager gameManager;
    [SerializeField] SEManager seManager;

    //�L�����N�^�[�R���g���[���[�̏Փˏ���
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            Destroy(hit.gameObject);
            moveDirection.z = 0;
            Debug.Log("�����@�G�@�Փ�");

            life --;
            LifeCheck();

            seManager.Damaged();
        }

    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Bullet")
        {
            Destroy(hit.gameObject);
            moveDirection.z = 0;

            life--;
            LifeCheck();

            seManager.Damaged();
        }

        if (hit.gameObject.tag == "Koban")
        {
            Destroy(hit.gameObject);

            gameManager.GetScore(100);
            seManager.Koban();
        }

        if (hit.gameObject.tag == "Dango")
        {
            Destroy(hit.gameObject);
            if (life != 3) life++;
            LifeCheck();
            seManager.Dango();
        }
    }

    void LifeCheck()
    {
        if (life == 3)
        {
            gameManager.Life3();
        }
        else if (life == 2)
        {
            gameManager.Life2();
        }
        else if (life == 1)
        {
            gameManager.Life1();
        }
        else if (life == 0)
        {
            OVER();
            gameManager.Life0();
        }
    }

    void OVER()
    {
        isPlay = false;
        Destroy(this.gameObject);
    }

    void Start()
    {
        animator.SetTrigger("idle");
        //GetComponent��CharacterControllerwp�擾���ĕϐ�controllse�ŎQ�Ƃ��܂��B
        controller = GetComponent<CharacterController>();

        Invoke("StartPlay", 4.0f);
    }

    public void StartPlay()
    {
        isPlay = true;
        moveDirection.z = speedZ;
        animator.SetTrigger("run");
    }


    void Update()
    {
        if (isPlay == true)
        { 
            if (controller.isGrounded) isAirJump = false;

            //���ꂼ��̖�󂪉����ꂽ�炻�ꂼ��̊֐������s���܂��B
            if (Input.GetKeyDown("left")) MoveToLeft();
            if (Input.GetKeyDown("right")) MoveToRight();
            if (Input.GetKeyDown("space") || Input.GetKeyDown("up")) Jump();
            //if (Input.GetKeyDown("down")) gameManager.Life0();

            //ShotTimer += 1;
            //if (ShotTimer % 20 == 0)
            //{ 
            //    Shot();
            //}
            if (Input.GetKeyDown("z")) Shot();

            float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
            moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);

            float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
            moveDirection.x = ratioX * speedX;

        }
            moveDirection.y -= gravity * Time.deltaTime;

            Vector3 globalDirection = transform.TransformDirection(moveDirection);
            controller.Move(globalDirection * Time.deltaTime);

            if (controller.isGrounded) moveDirection.y = 0;
    }


    //�V����������֐��̂��ꂼ��̏����B
    public void Shot()
    {
        Transform myTransform = this.transform;
        Vector3 shotPos = myTransform.position;
        shotPos.z += 1.5f;

        Instantiate(Shuriken, shotPos, Quaternion.identity);

        seManager.Throwing();
    }

    public void MoveToLeft()
    {
        if (targetLane > MinLane)
        {
            targetLane--;
            seManager.Move();
        }
    }

    public void MoveToRight()
    {
        if (targetLane < MaxLane)
        {
            targetLane++;
            seManager.Move();
        }
    }

    public void Jump()
    {
        if (controller.isGrounded)
        {
            moveDirection.y = speedJump;

            animator.SetTrigger("jump");

            seManager.Move();
        }
        else if (isAirJump == false)
        {
            moveDirection.y = speedJump;

            animator.SetTrigger("Wjump");

            isAirJump = true;

            seManager.Move();
        }
    }

    public void Slide()
    {
        if (controller.isGrounded)
        {
            animator.SetTrigger("slide");
        }
    }
}