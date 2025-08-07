using UnityEngine;
using System.Collections.Generic;

public class CarPoint : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] float _turnSpeed = 5f;
    [SerializeField] float _range = 0.5f;
    public bool _isGround;
    [SerializeField] bool _isWalk;
    Vector3 vec;
    [SerializeField] List<Vector3> vecList = new List<Vector3>();
    [SerializeField] bool useList = true; // Переключатель режима
    Vector3 lastMoveDirection; // Направление последнего движения

    private void Start()
    {
        _isGround = true;
        _isWalk = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SetTarget();
        }
        if (vecList.Count > 0)
        {
            Move();
        }
    }

    void SetTarget()
    {
        RaycastHit _hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit))
        {
            if (_hit.collider != null && _hit.collider.tag == "Ground")
            {
                vec = new Vector3(_hit.point.x, _hit.point.y, _hit.point.z);
                if (useList)
                {
                    // Проверка на уникальность последней добавленной позиции
                    if (vecList.Count == 0 || vecList[vecList.Count - 1] != vec)
                    {
                        vecList.Add(vec);
                    }
                }
                else
                {
                    // Запись только одной позиции
                    vecList.Clear();
                    vecList.Add(vec);
                }
            }
        }
    }

    void Move()
    {
        if (vecList.Count == 0)
        {
            return;
        }

        Vector3 targetPosition = vecList[0];

        // Проверка на достижение точки
        if (Vector3.Distance(transform.position, targetPosition) < _range)
        {
            // Поворот к цели
            Quaternion lookRotation = Quaternion.LookRotation(lastMoveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, _turnSpeed * Time.deltaTime);

            // Проверка на достижение точки
            if (Vector3.Distance(transform.position, targetPosition) < _range)
            {
                // Удаление достигнутой точки
                vecList.RemoveAt(0);

                // Если нет других точек, оставаться на месте, смотреть в последнее направление движения
                if (vecList.Count == 0)
                {
                    transform.rotation = lookRotation;
                }
            }
        }
        else
        {
            // Если объект еще не достиг точки, двигаемся к ней
            Vector3 direction = (targetPosition - transform.position).normalized;
            lastMoveDirection = direction;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, _turnSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        }
    }
}