using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private RawImage rawImage;
    [SerializeField] private float x, y;

    // Update is called once per frame
    void Update()
    {
        ScrollBackgroundImage();
    }

    private void ScrollBackgroundImage()
    {
        rawImage.uvRect = new Rect(rawImage.uvRect.position + new Vector2(x, y) * Time.fixedDeltaTime, rawImage.uvRect.size);
    }
}
