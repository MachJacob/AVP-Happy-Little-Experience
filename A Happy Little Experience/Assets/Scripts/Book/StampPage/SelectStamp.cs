using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStamp : MonoBehaviour
{
    StampManager stampManager;
    StampManager.Stamp stamp;

    private void Start()
    {
        stampManager = GetComponentInParent<StampManager>();
    }

    public void SetStamp(StampManager.Stamp newStamp)
    {
        stamp = newStamp;

        GetComponent<BoxCollider>().enabled = true;
        if (transform.childCount == 0)
        {
            GameObject stampSprite = Instantiate(new GameObject(), transform);
            stampSprite.AddComponent<SpriteRenderer>().sprite = Sprite.Create(stamp.tex, new Rect(0, 0, stamp.tex.width, stamp.tex.height), new Vector2(0.5f, 0.5f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        stampManager.UpdateStampViewer(stamp);
    }

}
