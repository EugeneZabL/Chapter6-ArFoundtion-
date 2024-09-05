using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    public void RotatePlaneToCamera()
    {
        // Получаем вектор направления от объекта к камере
        Vector3 direction = Camera.main.transform.position - transform.position;

        // Обнуляем компоненты по осям X и Z, чтобы оставить только вращение по оси Y
        direction.y = 0;

        // Проверяем, чтобы direction не был нулевым, чтобы избежать ошибок
        if (direction != Vector3.zero)
        {
            // Вычисляем поворот, необходимый для того, чтобы объект смотрел на камеру
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Применяем поворот к объекту
            transform.rotation = rotation;
        }
    }
}
