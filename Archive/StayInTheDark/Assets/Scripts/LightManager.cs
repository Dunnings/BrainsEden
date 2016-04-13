using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightManager : MonoBehaviour
{

    public Player player;
    public List<GameObject> allLights;

    public int lightDmg = 20;

    // Use this for initialization
    void Start()
    {
        //Object[] allL = GameObject.FindObjectsOfType(typeof(DynamicLight));

        //for(int i =0; i<allL.Length;i++){
        //    if (((GameObject)allL[i]).activeInHierarchy)
        //    {
        //        allLights.Add((GameObject)allL[i]);
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (isInAnyLight(player.gameObject, allLights))
        {
            player.Damage(lightDmg);
            //Debug.Log("HIT");
            return;
        }

        //Debug.Log("NO HIT");
    }

    public bool isInAnyLight(GameObject player, List<GameObject> allLights)
    {
        bool isInAny = false;
        for (int i = 0; i < allLights.Count; i++)
        {
            if (isInLight(player, allLights[i]))
            {
                isInAny = true;
            }
        }
        return isInAny;
    }

    private bool isInLight(GameObject player, GameObject light)
    {
        //RaycastHit2D hit = Physics2D.Raycast(new Vector2(player.transform.position.x, player.transform.position.x), light.transform.position - player.transform.position);
        RaycastHit2D newHit = Physics2D.Raycast(new Vector2(light.transform.position.x, light.transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y) - new Vector2(light.transform.position.x, light.transform.position.y));
        Debug.DrawRay(new Vector2(light.transform.position.x, light.transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y) - new Vector2(light.transform.position.x, light.transform.position.y));

        if (newHit != null)
        {
            if (newHit.collider != null)
            {
                Debug.DrawLine(new Vector3(light.transform.position.x, light.transform.position.y, 0f), new Vector3(newHit.collider.transform.position.x, newHit.collider.transform.position.y, 0f), new Color(1.0f, 1.0f, 0f));
                if (newHit.collider.tag == "Player")
                {
                    return true;
                }
                //newHit.collider.gameObject.SetActive(false);
            }
        }
        return false;


        //bool hitPlayer = false;
        //int lines = 50;
        //Vector2 d = Vector2.up;
        //for (int i = 0; i < lines; i++)
        //{
        //    d = Rotate(d, (360 / lines) * i);
        //    RaycastHit2D newHit = Physics2D.Raycast(new Vector2(light.transform.position.x, light.transform.position.y), d, 1000f);
        //    Debug.DrawRay(new Vector2(light.transform.position.x, light.transform.position.y), d);
        //    if (newHit != null && newHit.collider != null)
        //    {
        //        if (newHit.collider.gameObject.tag == "Player")
        //        {
        //            Debug.Log("HIT");
        //            hitPlayer = true;
        //            break;
        //        }
        //    }
        //}
        //return hitPlayer;
    }
}