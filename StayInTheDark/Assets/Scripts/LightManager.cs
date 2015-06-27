using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightManager : MonoBehaviour
{

    public Player player;
    public List<GameObject> allLights;

    public int lightDmg = 3;

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
        }
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
        RaycastHit2D newHit = Physics2D.Raycast(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(light.transform.position.x, light.transform.position.y));
        Debug.DrawLine(new Vector3(player.transform.position.x, player.transform.position.y, 0f), new Vector3(light.transform.position.x, light.transform.position.y, 0f), new Color(1.0f,0f,0f));
        return (newHit.collider == null);
    }
}
