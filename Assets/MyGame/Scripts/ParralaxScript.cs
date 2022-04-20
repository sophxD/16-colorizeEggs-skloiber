using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxScript : MonoBehaviour
{
    public float scrollSpeed;
    public bool scroll = true;

    private Material backgroundMaterial;

    private void Awake()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    private void FixedUpdate()
    {
        if (scroll)
        {
            Vector2 offset = new Vector2(scrollSpeed * Time.time, 0f);

            backgroundMaterial.mainTextureOffset = offset;
        }

    }
}
