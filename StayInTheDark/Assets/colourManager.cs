using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class colourManager : MonoBehaviour 
{
    public List <Material> m_materials = new List<Material>();
    public List <List<Color>> m_colour = new List<List<Color>>();

    public static colourManager m_colourManager;

    void init ()
    {
        m_colourManager = new colourManager();

        m_colour.Add(new List<Color>());
        m_colour[0][0] = new Color(234, 144, 49); //light 
        m_colour[0][1] = new Color(203, 144, 49); //object
        m_colour[0][2] = new Color(186, 125, 42); //back

        m_colour.Add(new List<Color>());
        m_colour[1][0] = new Color(105, 132, 210);
        m_colour[1][1] = new Color(79, 109, 182);
        m_colour[1][2] = new Color(57, 85, 165);

        m_colour.Add(new List<Color>());
        m_colour[2][0] = new Color(201, 125, 202);
        m_colour[2][1] = new Color(185, 69, 197);
        m_colour[2][2] = new Color(206, 90, 208);
    }
		
	void generateColour()
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
