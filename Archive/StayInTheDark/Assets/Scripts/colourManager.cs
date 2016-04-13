using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class colourManager : MonoBehaviour 
{
    public List <Material> m_materials = new List<Material>();
    public List<List<Color>> m_colour = new List<List<Color>>();

    public static colourManager m_colourManager;

    void Awake ()
    {
        m_colourManager = this;
        genColours();
        //m_colour.Add(new List<Color32>());
        //m_colour[0].Add(new Color32(234, 144, 49,255)); //1light 
        //m_colour[0].Add(new Color32(203, 144, 49, 255)); //object
        //m_colour[0].Add(new Color(186, 125, 42, 255)); //back

        //m_colour.Add(new List<Color32>());
        //m_colour[1].Add(new Color32(105, 132, 210, 255));
        //m_colour[1].Add(new Color32(79, 109, 182, 255));
        //m_colour[1].Add(new Color32(57, 85, 165, 255));

        //m_colour.Add(new List<Color32>());
        //m_colour[2].Add(new Color32(201, 125, 202, 255));
        //m_colour[2].Add(new Color32(185, 69, 197, 255));
        //m_colour[2].Add(new Color32(206, 90, 208, 255));

        //Debug.Log("Added colours");
    }

    public void genColours()
    {
        int lMod = 255;
        int oMod = 150;
        int bMod = 75;
        m_colour.Clear();

        for (int i = 0; i < 10; i++)
        {
            m_colour.Add(new List<Color>());
            float rand1 = Random.Range(0.6f, 0.8f);
            float rand2 = Random.Range(0.6f, 0.8f);
            float rand3 = Random.Range(0.6f, 0.8f);

            byte Lrand1 = (byte)(rand1 * lMod);
            byte Lrand2 = (byte)(rand2 * lMod);
            byte Lrand3 = (byte)(rand3 * lMod);

            byte Orand1 = (byte)(rand1 * oMod);
            byte Orand2 = (byte)(rand2 * oMod);
            byte Orand3 = (byte)(rand3 * oMod);

            byte Brand1 = (byte)(rand1 * bMod);
            byte Brand2 = (byte)(rand2 * bMod);
            byte Brand3 = (byte)(rand3 * bMod);

            m_colour[i].Add(new Color32(Lrand1, Lrand2, Lrand3, 255)); //1light 
            m_colour[i].Add(new Color32(Orand1, Orand2, Orand3, 255)); //1light 
            m_colour[i].Add(new Color32(Brand1, Brand2, Brand3, 255)); //1light 
        }
        generateColour();
    }
		
	public void generateColour()
    {
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
