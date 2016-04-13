using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 lastPos;
    // Update is called once per frame
    void Update()
    {
        if (Level.level.gameState == Level.GameState.PLAYING)
        {
            move();
        }
    }

    void move()
    {


        Vector3 dir = (Player.Instance.transform.position - lastPos).normalized;
        lastPos = Player.Instance.transform.position;

        RaycastHit2D[] daveIloveYou = Physics2D.RaycastAll(new Vector2(Player.Instance.transform.position.x, Player.Instance.transform.position.y), new Vector2(dir.x, dir.y), 1f);
        Debug.DrawRay((new Vector3(Player.Instance.transform.position.x, Player.Instance.transform.position.y, 0.0f)), new Vector3(dir.x, dir.y, 0.0f));


        bool canMove = true;
        if (daveIloveYou != null)
        {
            for (int i = 0; i < daveIloveYou.Length; i++)
            {
                if (daveIloveYou[i].collider.gameObject.tag == "wall")
                {
                    canMove = false;
                    break;
                }
            }
        }
        if (canMove)
        {
            if (Input.acceleration.x > 0.08f || Input.acceleration.x < -0.08f
                || Input.acceleration.y > 0.08f || Input.acceleration.y < -0.08f)
            {
                float x = Input.acceleration.x;
                float y = Input.acceleration.y;
                float z = Input.acceleration.z;
                if (x > 0.5f) { x = 0.5f; }
                if (x < -0.5f) { x = -0.5f; }
                if (y > 0.5f) { y = 0.5f; }
                if (y < -0.5f) { y = -0.5f; }
                
                Vector3 translate = new Vector3(x,y,0f);
                transform.Translate(translate * speed * Time.deltaTime);
            }



            if (Input.GetButton("Horizontal"))
            {
                transform.Translate(new Vector3((Input.GetAxis("Horizontal") * speed * 0.5f * Time.deltaTime), 0.0f, 0.0f));
            }
            if (Input.GetButton("Vertical"))
            {
                transform.Translate(new Vector3(0.0f, (Input.GetAxis("Vertical") * speed * 0.5f * Time.deltaTime), 0.0f));
            }
        }



    }
}