using System;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    private Vector3 screenPoint; // Экранные координаты точки касания мыши
    private Vector3 offset; // Смещение между позицией объекта и позицией курсора в момент нажатия
    [SerializeField] float _slopes = 45f;
    [SerializeField] GameObject _gameObject;
    [SerializeField] GameObject _centr;
    [SerializeField] bool invisible;
    private void FixedUpdate()
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y, _gameObject.transform.position.z);
        Slopes();
    }

    void Slopes()
    {
        // Сначала обработаем крайние случаи, чтобы избежать лишних проверок
        if (transform.position.y > 20 && transform.position.x > -3)
        {
            transform.rotation = Quaternion.Euler(0, 0, _slopes);
        }
        else if (transform.position.y > 3)
        {
            if (transform.position.x < -2)
            {
                transform.rotation = Quaternion.Euler(0, 0, -_slopes);
            }
            else if (transform.position.x > 2)
            {
                transform.rotation = Quaternion.Euler(0, 0, _slopes);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if (transform.position.y < -3)
        {
            if (transform.position.x > 2)
            {
                transform.rotation = Quaternion.Euler(0, 0, _slopes);
            }
            else if (transform.position.x < 2)
            {
                transform.rotation = Quaternion.Euler(0, 0, -_slopes);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void OnMouseDown()
    {
        // Вычисляем смещение между текущей позицией объекта и положением курсора в момент нажатия
        offset = transform.position - GetMouseWorldPos();
    }
    void OnMouseDrag()
    {
        // Получаем новую позицию курсора в мировых координатах, добавляем смещение
        transform.position = GetMouseWorldPos() + offset;
        
    }
    private void OnMouseUp()
    {
        Invisible();
    }

    Vector3 GetMouseWorldPos()
    {
        // Запоминаем экранные координаты точки касания мыши относительно объекта
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        // Преобразуем экранные координаты курсора в мировые координаты
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
    bool IsObjectInViewport()
    {
        Vector3 vp = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        return vp.x >= 0f && vp.x <= 1f &&
               vp.y >= 0f && vp.y <= 1f &&
               vp.z > 0f; // объект должен быть перед камерой
    } 
    void ReturnToCenter()
    {
        Vector3 centerVP = new Vector3(0.5f, 0.5f, Camera.main.WorldToViewportPoint(gameObject.transform.position).z);
        Vector3 centerWorld = Camera.main.ViewportToWorldPoint(centerVP);
        gameObject.transform.position = centerWorld;
        //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, centerWorld, Time.deltaTime * 3f);
    }
    void Invisible()
    {
        if (IsObjectInViewport())
        {
            invisible = false; 
        }
        else if (!IsObjectInViewport())
        {
            Debug.Log($"{gameObject.name} вне зоны видимости камеры");
            invisible = true;
            ReturnToCenter();
        }
    }
}
