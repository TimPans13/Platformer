using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f; //сила прыжка                         
    [Range(0, 1)][SerializeField] private float m_CrouchSpeed = .36f; //скорость движения в присяде(36%)          
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;//Сглаживание движения
    [SerializeField] private bool m_AirControl = false; //Можем ли передвигаться в воздухе                      
    [SerializeField] private LayerMask m_WhatIsGround; //что такое земля                         
    [SerializeField] private Transform m_GroundCheck;                          
    [SerializeField] private Transform m_CeilingCheck;                         
    [SerializeField] private Collider2D m_CrouchDisableCollider;     //коллайдер отключаемый в присяде           
    const float k_GroundedRadius = .2f; // Радиус окружности, используемой для определения, находится ли персонаж на земле.
    private bool m_Grounded;//на земле ли?            
    const float k_CeilingRadius = .2f; // Радиус окружности, используемой для определения, может ли персонаж встать.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  //определям направление
    private Vector3 m_Velocity = Vector3.zero;// Вектор скорости персонажа, используемый для сглаживания движения.

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;// Событие, вызываемое при приземлении персонажа.

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { } 

    public BoolEvent OnCrouchEvent;// Событие, вызываемое при приседании персонажа.
    private bool m_wasCrouching = false;

    private void Awake()//создаём Event
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;  // Проверяем, находится ли персонаж на земле путем выполения overlap circle в позиции GroundCheck.
        m_Grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround); // Находим все объекты, на которых стоит персонаж
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;// Если найденный объект не является самим персонажем, то считаем, что персонаж находится на земле.
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }


    public void Move(float move, bool crouch, bool jump)
    {
        if (!crouch)
        {
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;// Если над персонажем есть препятствие, то персонаж приседает.
            }
        }

        if (m_Grounded || m_AirControl)
        {

            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);// Вызываем событие при приседании персонажа.
                }

                move *= m_CrouchSpeed;// Уменьшаем скорость перемещения персонажа в приседе.
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;// Отключаем коллайдер, который должен быть отключен в приседе.
            }
            else
            {
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;// Включаем коллайдер обратно, когда персонаж не в приседе.

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);// Вызываем событие, когда персонаж перестал быть в приседе.
                }
            }

            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);// Задаем целевую скорость перемещения персонажа.
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);// Плавное изменение скорости движения персонажа.

            if (move > 0 && !m_FacingRight)// Поворачиваем персонажа
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)// Поворачиваем персонажа
            {
                Flip();
            }
        }
        if (m_Grounded && jump)
        {
            m_Grounded = true;// Применяем силу прыжка, если персонаж находится на земле и нажата кнопка прыжка.
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }


    private void Flip()//поворачиваем персонажа
    {
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
