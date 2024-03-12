using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    private Renderer _renderer;
    public Color selectedColor = Color.red;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name != "Board")
                {
                    if (_renderer != null)
                    {
                    // Возвращаем исходный цвет, если другой объект был выбран
                        _renderer.material.color = Color.black;
                    }

                    _renderer = hit.transform.GetComponent<Renderer>();

                    if (_renderer != null)
                    {
                        // Изменяем цвет выбранного объекта
                        _renderer.material.color = selectedColor;
                    }
                }
            }
        }
    }
}
