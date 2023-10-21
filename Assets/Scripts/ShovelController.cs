using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelController : MonoBehaviour
{
    private bool isDragged = false;
    private bool isCollidingWithAnotherPlant = false;

    private GameObject plantToRemove;

    private Vector3 mouseDragStartPos;

    private Vector3 spriteDragStartPos;

    [SerializeField] private AudioSource shovelSound;

    private bool soundPlayed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plants"))
        {
            isCollidingWithAnotherPlant = true;
            plantToRemove = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plants"))
        {
            isCollidingWithAnotherPlant = false;
            plantToRemove = null;
        }
    }

    private void OnMouseDown()
    {
        isDragged = true;
        mouseDragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPos = transform.localPosition;
        soundPlayed = false;
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition = spriteDragStartPos + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPos);
        }
    }

    private void OnMouseUp()
    {
        if (isCollidingWithAnotherPlant == true && plantToRemove != null)
        {
            if (!soundPlayed)
            {
                shovelSound.Play();
                soundPlayed = true;
            }
            Destroy(plantToRemove);
        }
        transform.localPosition = spriteDragStartPos;
        isDragged = false;
    }
}
