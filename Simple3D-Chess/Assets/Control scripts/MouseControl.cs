using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    private Renderer _renderer;
    private string _tag;
    public Color selectedColor = Color.red;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.transform.tag != "env")
            {
                if (_renderer != null)
                {
                    _renderer.material.color = _tag == "white" ? Color.white : Color.black;
                }

                _renderer = hit.transform.GetComponent<Renderer>();
                _tag = _renderer.gameObject.tag;

                if (_renderer != null)
                {
                    _renderer.material.color = selectedColor;
                    _renderer.transform.Translate(0, _tag == "white" ? 1 : -1, 0);
                }
            }
        }
    }
}
