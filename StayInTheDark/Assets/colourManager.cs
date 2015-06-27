using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class colourManager : MonoBehaviour 
{
    public List <Material> m_materials = new List<Material>();
    public List<List<Color32>> m_colour = new List<List<Color32>>();

    public static colourManager m_colourManager;

    void Awake ()
    {
        m_colourManager = this;
        m_colour.Add(new List<Color32>());
        m_colour[0].Add(new Color32(234, 144, 49,255)); //1light 
        m_colour[0].Add(new Color32(203, 144, 49, 255)); //object
        m_colour[0].Add(new Color(186, 125, 42, 255)); //back

        m_colour.Add(new List<Color32>());
        m_colour[1].Add(new Color32(105, 132, 210, 255));
        m_colour[1].Add(new Color32(79, 109, 182, 255));
        m_colour[1].Add(new Color32(57, 85, 165, 255));

        m_colour.Add(new List<Color32>());
        m_colour[2].Add(new Color32(201, 125, 202, 255));
        m_colour[2].Add(new Color32(185, 69, 197, 255));
        m_colour[2].Add(new Color32(206, 90, 208, 255));

        Debug.Log("Added colours");
    }
		
	public void generateColour()
    {
        Debug.Log(m_colour.Count);
        //get random index
        int index = Random.Range(0, m_colour.Count);
        int i = 0;

        foreach (Material _mat in m_materials)
        {
            _mat.color = m_colour[index][i];
            i++;
        }

        Camera.main.backgroundColor = m_colour[index][i];

    }
}
