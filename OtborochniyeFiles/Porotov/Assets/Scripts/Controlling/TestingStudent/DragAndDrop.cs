using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private Transform magnetPoint; // Ссылка на пустой объект, к которому будет примагничиваться фигура
    [SerializeField] private float magnetDistance = 0.1f; // Дистанция, на которую фигура должна примагнититься к точке

    private Vector3 offset; // Смещение между центром фигуры и позицией нажатия мыши
    private bool isDragging; // Флаг, указывающий на перетаскивание фигуры
    private bool isMagnetized; // Флаг, указывающий на примагничивание фигуры к точке

    private void OnMouseDown()
    {
        Debug.Log("Touching");
        // Сохраняем смещение между центром фигуры и позицией нажатия мыши
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            // Получаем позицию курсора в мировых координатах
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Перемещаем фигуру вместе с курсором, учитывая смещение
            transform.position = cursorPosition + offset;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        // Если фигура не примагничена к точке и её центр находится достаточно близко к точке, примагничиваем её
        if (!isMagnetized && Vector3.Distance(transform.position, magnetPoint.position) <= magnetDistance)
        {
            transform.position = magnetPoint.position;
            isMagnetized = true;

            // Проверяем, должна ли фигура быть в этом месте
            bool isCorrectPosition = CheckPosition();

            // Если фигура не должна быть в этом месте, возвращаем её на исходную позицию
            if (!isCorrectPosition)
            {
                transform.position = offset + Camera.main.ScreenToWorldPoint(Input.mousePosition);
                isMagnetized = false;
            }
        }
        else
        {
            isMagnetized = false;
        }
    }

    private bool CheckPosition()
    {
        // Здесь можно реализовать логику проверки, должна ли фигура быть в этом месте
        return true;
    }
}