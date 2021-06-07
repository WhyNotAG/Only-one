using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private float currentSpread;
    [SerializeField] private float speedSpread;

    [SerializeField] private Part[] _parts;
    [SerializeField] private Movement _movement;

    private float t;
    private float curSpread;

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(_movement.vertical) > 0)
        {
            currentSpread = 20 * (5 + _movement.vertical);
        }
        else
        {
            currentSpread = 20;
        }

        CrosshairUpdate();
    }

    public void CrosshairUpdate()
    {
        t = 0.005f * speedSpread;
        curSpread = Mathf.Lerp(curSpread, currentSpread, t);

        foreach (Part part in _parts)
        {
            part.trans.anchoredPosition = part.pos * curSpread;
        }
    }

    [System.Serializable]
    public class Part
    {
        public RectTransform trans;
        public Vector2 pos;
    }
}
