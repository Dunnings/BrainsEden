using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FluxScript : MonoBehaviour {

    private float startXScale;
    private float endXScale;
    private bool expand = true;

    public RectTransform r;

	// Use this for initialization
    void Start()
    {
        startXScale = r.rect.xMax;
        endXScale = r.rect.xMax + 20f;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.localScale = new Vector3(Time.deltaTime * 50.0f, transform.localScale.y, transform.localScale.z);
        if (expand)
        {
            r.sizeDelta.Scale(new Vector2(r.rect.xMax + 0.1f * Time.deltaTime, 1f));
            if (r.rect.xMax >= endXScale)
            {
                expand = false;
            }
        }
        else
        {
            r.sizeDelta.Scale(new Vector2(r.rect.xMax - 0.1f * Time.deltaTime, 1f));
            if (r.rect.xMax <= startXScale)
            {
                expand = true;
            }
        }
	}
}