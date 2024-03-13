using System.Collections;
using System.Collections.Generic;
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
            if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform.tag != "env")
            {
                if (_renderer != null)
                    _renderer.material.color = _tag == "white" ? Color.white : Color.black;

                _renderer = hit.transform.GetComponent<Renderer>();
                _tag = _renderer.gameObject.tag;

                _renderer.material.color = selectedColor;
                _renderer.transform.Translate(0, _tag == "white" ? 1 : -1, 0);

                Collider[] colliders = Physics.OverlapSphere(_renderer.transform.position, 0.1f);
                foreach (var collider in colliders)
                {
                    if (collider != _renderer)
                        Destroy(collider.gameObject);
                }
            }
        }
    }
}
