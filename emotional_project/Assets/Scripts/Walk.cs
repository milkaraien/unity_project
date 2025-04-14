using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float speed = 5f; // Скорость движения персонажа
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            float moveInput = Input.GetAxis("Horizontal"); // Получаем входные данные по оси X (A/D или стрелки)

            // Устанавливаем скорость движения персонажа
            _rb.velocity = new Vector2(moveInput * speed, _rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetTrigger("Walk");
        }
    }
}
