using System;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;//скорость бега

    float horizontalMove = 0f;
    bool jump = false;//флаги под прыжок/присяд
    bool crouch = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;// Получаем горизонтальное движение от ввода игрока
        animator.SetFloat("Speed", Math.Abs(horizontalMove));//Устанавливаем параметр "Speed" в аниматоре в абсолютное значение горизонтального движения
        if (Input.GetButtonDown("Jump")) { jump = true; animator.SetBool("isJumping", true); }// Если нажата кнопка прыжка, устанавливаем флаги прыжка в true
        if (Input.GetButtonDown("Crouch")) { crouch = true; animator.SetBool("isCrouching", true); }//Если нажата кнопка приседания, устанавливаем флаги приседания в true
        else if (Input.GetButtonUp("Crouch")) { crouch = false; animator.SetBool("isCrouching", false); }//Если кнопка приседания отпущена, сбрасываем флаги приседания в false
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);// Вызывается при приземлении персонажа, устанавливает параметр "isJumping" в аниматоре в false
    }

    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);// Вызывается при приседании персонажа, устанавливает параметр "isCrouching" в аниматоре в значение isCrouching
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);//Вызывает метод Move() для перемещения персонажа
        jump = false;
    }
}
