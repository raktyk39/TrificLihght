


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _vlnput;
    [SerializeField] private float _hlnput;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        _vlnput = Input.GetAxis("Vertical");
        _hlnput = Input.GetAxis("Horizontal");

        // Создаем глобальный вектор движения по оси Z (вперед) и оси X (горизонталь)
        Vector3 globalMove = new Vector3( 0f, 0f, _vlnput);

        // Применяем перемещение к позиции Rigidbody в глобальных координатах
        _rb.MovePosition(_rb.position + globalMove.normalized * _speed * Time.fixedDeltaTime);
    }


}
