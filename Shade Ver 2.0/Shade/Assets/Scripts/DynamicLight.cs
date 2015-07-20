using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using pseudoSinCos;


public class verts
{
	public float angle {get;set;}
	public int location {get;set;}
	public Vector3 pos {get;set;}
	public bool endpoint { get; set;}

}


public class DynamicLight : MonoBehaviour {
	
	public Material lightMaterial;
	public PolygonCollider2D[] allMeshes;

	public List<verts> allVertices = new List<verts>();
	public float lightRadius = 20f;
	public int lightSegments = 8;

	Mesh lightMesh;
	
	void Start () {
		PseudoSinCos.initPseudoSinCos();
		

		MeshFilter meshFilter = (MeshFilter)gameObject.AddComponent(typeof(MeshFilter));	
		MeshRenderer renderer = gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;	
		gameObject.name = "2DLight";
		//renderer.material.shader = Shader.Find ("Transparent/Diffuse");				
		//renderer.sharedMaterial = lightMaterial;			
		lightMesh = new Mesh();		
		meshFilter.mesh = lightMesh;
		lightMesh.name = "Light Mesh";
		lightMesh.MarkDynamic ();
	}
	
	void Update(){
		getAllMeshes();
		setLight ();
		renderLightMesh ();
		resetBounds();
        checkPlayerInLight();
	}

    void checkPlayerInLight()
    {
        GameObject p = GameObject.FindGameObjectsWithTag("Player")[0];
        RaycastHit2D ray = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(p.transform.position.x,p.transform.position.y) -  new Vector2(gameObject.transform.position.x,gameObject.transform.position.y));
        Debug.DrawRay(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(p.transform.position.x, p.transform.position.y) - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y));

        if (ray != null)
        {
            if (ray.collider != null && ray.collider.tag == "Player")
            {
                GameManager.Instance.EndGame();
            }
        }
    }

	void getAllMeshes(){
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("ShadowCaster");
        allMeshes = new PolygonCollider2D[allObjects.Length];
        for (int i = 0; i < allObjects.Length; i++)
        {
            allMeshes[i] = allObjects[i].GetComponent<PolygonCollider2D>();
        }
	}

	void resetBounds(){
		Bounds b = lightMesh.bounds;
		b.center = Vector3.zero;
		lightMesh.bounds = b;
	}

	void setLight () {
		bool sortAngles = false;
		allVertices.Clear();

		bool lows = false;
		bool his = false;
		float magRange = 0.15f;

		List <verts> tempVerts = new List<verts>();

		for (int m = 0; m < allMeshes.Length; m++) {
			tempVerts.Clear();
			PolygonCollider2D mf = allMeshes[m];

			lows = false; // Less than -0.5
			his = false; // Greater than 2.0



			for (int i = 0; i < mf.GetTotalPointCount(); i++) {
				
				verts v = new verts();
				Vector3 worldPoint = mf.transform.TransformPoint(mf.points[i]);

				RaycastHit2D ray = Physics2D.Raycast(transform.position, worldPoint - transform.position, (worldPoint - transform.position).magnitude);

				if(ray){
					v.pos = ray.point;
					if( worldPoint.sqrMagnitude >= (ray.point.sqrMagnitude - magRange) && worldPoint.sqrMagnitude <= (ray.point.sqrMagnitude + magRange) )
						v.endpoint = true;
						
				}else{
					v.pos =  worldPoint;
					v.endpoint = true;
				}

				v.pos = transform.InverseTransformPoint(v.pos); 
				v.angle = getVectorAngle(true,v.pos.x, v.pos.y);

				if(v.angle < 0f )
					lows = true;
				
				if(v.angle > 2f)
					his = true;
				
				if((v.pos).sqrMagnitude <= lightRadius*lightRadius){
					tempVerts.Add(v);

				}
					
				if(sortAngles == false)
					sortAngles = true;
			
			}


			if(tempVerts.Count > 0){

				sortList(tempVerts);

				int posLowAngle = 0; 
				int posHighAngle = 0;

				if(his == true && lows == true){
					float lowestAngle = -1f;
					float highestAngle = tempVerts[0].angle;


					for(int d=0; d<tempVerts.Count; d++){



						if(tempVerts[d].angle < 1f && tempVerts[d].angle > lowestAngle){
							lowestAngle = tempVerts[d].angle;
							posLowAngle = d;
						}

						if(tempVerts[d].angle > 2f && tempVerts[d].angle < highestAngle){
							highestAngle = tempVerts[d].angle;
							posHighAngle = d;
						}
					}


				}else{
					posLowAngle = 0; 
					posHighAngle = tempVerts.Count-1;

				}


				tempVerts[posLowAngle].location = 1;
				tempVerts[posHighAngle].location = -1;



				allVertices.AddRange(tempVerts); 
				//allVertices.Add(tempVerts[0]);
				//allVertices.Add(tempVerts[tempVerts.Count - 1]);



				for(int r = 0; r<2; r++){
					Vector3 fromCast = new Vector3();
					bool isEndpoint = false;

					if(r==0){
						fromCast = transform.TransformPoint(tempVerts[posLowAngle].pos);
						isEndpoint = tempVerts[posLowAngle].endpoint;

					}else if(r==1){
						fromCast = transform.TransformPoint(tempVerts[posHighAngle].pos);
						isEndpoint = tempVerts[posHighAngle].endpoint;
					}





					if(isEndpoint == true){
						Vector3 dir = (fromCast - transform.position);
						fromCast += (dir * .01f);
						
						
						
						float mag = (lightRadius);
						RaycastHit2D rayCont = Physics2D.Raycast(fromCast, dir, mag);

						
						Vector3 hitp;
						if(rayCont){
							hitp = rayCont.point;
						}else{
							hitp = transform.TransformPoint( dir.normalized * mag);
						}

						Debug.DrawLine(fromCast, hitp, Color.green);	

						verts vL = new verts();
						vL.pos = transform.InverseTransformPoint(hitp);

						vL.angle = getVectorAngle(true,vL.pos.x, vL.pos.y);
						allVertices.Add(vL);
					}


				}


			}

			
		}


		int theta = 0;
		int amount = 360 / lightSegments;



		for (int i = 0; i < lightSegments; i++)  {

			theta =amount * (i);
			if(theta == 360) theta = 0;

			verts v = new verts();
			//v.pos = new Vector3((Mathf.Sin(theta)), (Mathf.Cos(theta)), 0); // in radians low performance
			v.pos = new Vector3((PseudoSinCos.SinArray[theta]), (PseudoSinCos.CosArray[theta]), 0); // in dregrees (previous calculate)

			v.angle = getVectorAngle(true,v.pos.x, v.pos.y);
			v.pos *= lightRadius;
			v.pos += transform.position;



			RaycastHit2D ray = Physics2D.Raycast(transform.position,v.pos - transform.position,lightRadius);

			if (!ray){
				v.pos = transform.InverseTransformPoint(v.pos);
				allVertices.Add(v);

			}
		 
		}

		if (sortAngles == true) {
			sortList(allVertices);
		}
		float rangeAngleComparision = 0.00001f;
		for(int i = 0; i< allVertices.Count-1; i+=1){
			
			verts uno = allVertices[i];
			verts dos = allVertices[i +1];

			if(uno.angle >= dos.angle-rangeAngleComparision && uno.angle <= dos.angle + rangeAngleComparision){
				
				if(dos.location == -1){
					
					if(uno.pos.sqrMagnitude > dos.pos.sqrMagnitude){
						allVertices[i] = dos;
						allVertices[i+1] = uno;
					}
				}
				
				if(uno.location == 1){
					if(uno.pos.sqrMagnitude < dos.pos.sqrMagnitude){
						
						allVertices[i] = dos;
						allVertices[i+1] = uno;
					}
				}
				
			}


		}



	}

	void renderLightMesh(){

		//interface_touch.vertexCount = allVertices.Count; // notify to UI
		
		Vector3 []initVerticesMeshLight = new Vector3[allVertices.Count+1];
		
		initVerticesMeshLight [0] = Vector3.zero;
		
		
		for (int i = 0; i < allVertices.Count; i++) { 
			initVerticesMeshLight [i+1] = allVertices[i].pos;
			
			
		}
		
		lightMesh.Clear ();
		lightMesh.vertices = initVerticesMeshLight;
		
		Vector2 [] uvs = new Vector2[initVerticesMeshLight.Length];
		for (int i = 0; i < initVerticesMeshLight.Length; i++) {
			uvs[i] = new Vector2(initVerticesMeshLight[i].x, initVerticesMeshLight[i].y);		
		}
		lightMesh.uv = uvs;
		
		int idx = 0;
		int [] triangles = new int[(allVertices.Count * 3)];
		for (int i = 0; i < (allVertices.Count*3); i+= 3) {
			
			triangles[i] = 0;
			triangles[i+1] = idx+1;
			
			
			if(i == (allVertices.Count*3)-3){
				triangles[i+2] = 1;	
			}else{
				triangles[i+2] = idx+2;
			}
			
			idx++;
		}
		
		
		lightMesh.triangles = triangles;												
		//lightMesh.RecalculateNormals();
		GetComponent<Renderer>().sharedMaterial = lightMaterial;
	}

	void sortList(List<verts> lista){
			lista.Sort((item1, item2) => (item2.angle.CompareTo(item1.angle)));
	}

	void drawLinePerVertex(){
		for (int i = 0; i < allVertices.Count; i++)
		{
			if (i < (allVertices.Count -1))
			{
				Debug.DrawLine(allVertices [i].pos , allVertices [i+1].pos, new Color(i*0.02f, i*0.02f, i*0.02f));
			}
			else
			{
				Debug.DrawLine(allVertices [i].pos , allVertices [0].pos, new Color(i*0.02f, i*0.02f, i*0.02f));
			}
		}
	}

	float getVectorAngle(bool pseudo, float x, float y){
		float ang = 0;
		if(pseudo == true){
			ang = pseudoAngle(x, y);
		}else{
			ang = Mathf.Atan2(y, x);
		}
		return ang;
	}
	
	float pseudoAngle(float dx, float dy){
		
		float ax = Mathf.Abs (dx);
		float ay = Mathf.Abs (dy);
		float p = dy / (ax + ay);
		if (dx < 0){
			p = 2 - p;

		}
		return p;
	}

}