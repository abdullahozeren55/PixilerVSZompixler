using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    private bool isDragged = false;
    private bool isCollidingWithAnotherPlant = false;

    public int sunCost;

    private Vector3 mouseDragStartPos;

    private Vector3 spriteDragStartPos;

    [SerializeField] private List<Transform> tileCenters;
    private float snapRange = 0.75f;

    [SerializeField] private GameObject plantPrefab;

    private Vector3 spawnPos;

    [SerializeField] private AudioSource plantSound;

    private bool soundPlayed;

    private float remainingTime;
    [SerializeField] private float cooldownTime = 3f;

    private SpriteRenderer SR;

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            SR.color = new Color(1f, 1f, 1f, 1f);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plants"))
        {
            isCollidingWithAnotherPlant = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plants"))
        {
            isCollidingWithAnotherPlant = false;
        }
    }
    private void OnMouseDown()
    {
        soundPlayed = false;
        if (ShopController.sunAmount >= sunCost && remainingTime <= 0)
        {
            isDragged = true;
            mouseDragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spriteDragStartPos = transform.localPosition;
        }
        else
        {
            isDragged = false;
        }

    }
    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition = spriteDragStartPos + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPos);
        }
        else
        {
            return;
        }
    }

    private void OnMouseUp()
    {
        if (isDragged)
        {
            float closestDistance = -1;
            Transform closestTileCenter = null;

            foreach (Transform tileCenter in tileCenters)
            {
                float currentDistance = Vector2.Distance(transform.localPosition, tileCenter.transform.localPosition);
                if (closestTileCenter == null || currentDistance < closestDistance)
                {
                    closestTileCenter = tileCenter;
                    closestDistance = currentDistance;
                }
            }
            if (closestTileCenter != null && closestDistance <= snapRange && !isCollidingWithAnotherPlant)
            {
                ShopController.UpdateSunAmount(-sunCost);
                spawnPos = closestTileCenter.transform.localPosition;
                if (!soundPlayed)
                {
                    plantSound.Play();
                    soundPlayed = true;
                }
                Instantiate(plantPrefab, spawnPos, Quaternion.identity);
                remainingTime = cooldownTime;
                SR.color = new Color(1f, 1f, 1f, 0.3f);


            }
            else
            {
            }
            transform.localPosition = spriteDragStartPos;
            isDragged = false;
        }
    }
}
