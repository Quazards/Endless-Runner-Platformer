using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxBackground : MonoBehaviour
{
    public float additionalScrollSpeed;

    public GameObject[] backgrounds;

    public float[] scrollSpeed;

    private void FixedUpdate()
    {
        for(int i = 0; i < backgrounds.Length; i++)
        {
            Renderer _renderer = backgrounds[i].GetComponent<Renderer>();

            float offset = Time.time * (scrollSpeed[i] + additionalScrollSpeed);

            _renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));

        }
    }

}
