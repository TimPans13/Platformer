using System;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;//�������� ����

    float horizontalMove = 0f;
    bool jump = false;//����� ��� ������/������
    bool crouch = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;// �������� �������������� �������� �� ����� ������
        animator.SetFloat("Speed", Math.Abs(horizontalMove));//������������� �������� "Speed" � ��������� � ���������� �������� ��������������� ��������
        if (Input.GetButtonDown("Jump")) { jump = true; animator.SetBool("isJumping", true); }// ���� ������ ������ ������, ������������� ����� ������ � true
        if (Input.GetButtonDown("Crouch")) { crouch = true; animator.SetBool("isCrouching", true); }//���� ������ ������ ����������, ������������� ����� ���������� � true
        else if (Input.GetButtonUp("Crouch")) { crouch = false; animator.SetBool("isCrouching", false); }//���� ������ ���������� ��������, ���������� ����� ���������� � false
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);// ���������� ��� ����������� ���������, ������������� �������� "isJumping" � ��������� � false
    }

    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);// ���������� ��� ���������� ���������, ������������� �������� "isCrouching" � ��������� � �������� isCrouching
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);//�������� ����� Move() ��� ����������� ���������
        jump = false;
    }
}
