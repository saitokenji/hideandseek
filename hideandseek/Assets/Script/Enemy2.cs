using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {
	public string pastKey = "";
	public GameObject target;
	public GameObject star;
	public string pastMove; 
 	public int DicovoredTargetPosition;
 	public int PastTargetPosition;
 	private Player playerScript;
 	private Vector3 enemyPos;
 	private Vector3 targetPos;

	string[] DIRECTION = { "LEFT", "RIGHT", "UP", "DOWN"};

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player1");
		playerScript = target.GetComponent<Player>();
	
		DicovoredTargetPosition = 0;
		star = GameObject.Find("Star");

	//	targetPos = target.transform.position;
	//	enemyPos = this.transform.position;  
		
		var d = Random.Range(0, 3);
		pastMove = DIRECTION[d];

	}
	
	// Update is called once per frame
	void Update () {
		//this.search();
		this.seekMove();
		//this.research();
		this.evaluate();

	}

	void search(){

		if(transform.position + new Vector3(-1, 0, 1) == target.transform.position){
			DicovoredTargetPosition = 1;

		}else if(transform.position + new Vector3(0, 0, 1) == target.transform.position){
			DicovoredTargetPosition = 2;

		}else if(transform.position + new Vector3(1, 0, 1) == target.transform.position){
			DicovoredTargetPosition = 3;

		}else if(transform.position + new Vector3(-1, 0, 0) == target.transform.position){
			DicovoredTargetPosition = 4;
		
		}else if(transform.position + new Vector3(1, 0, 0) == target.transform.position){
			DicovoredTargetPosition = 6;

		}else if(transform.position + new Vector3(-1, 0, -1) == target.transform.position){
			DicovoredTargetPosition = 7;

		}else if(transform.position + new Vector3(0, 0, -1) == target.transform.position){
			DicovoredTargetPosition = 8;

		}else if(transform.position + new Vector3(1, 0, -1) == target.transform.position){
			DicovoredTargetPosition = 9;

		}else{
			DicovoredTargetPosition = PastTargetPosition;
		}


	}



void seekMove(){
	


	if(transform.position.x >= target.transform.position.x){ 

		if(transform.position.z >= target.transform.position.z){//①

			if(transform.position.x == 0){
				if(pastMove == "UP"){print("ERROR");}
				moveTo("DOWN");
			}else if(transform.position.z == 0){
				if(pastMove == "RIGHT"){print("ERROR");}
				moveTo("LEFT");
			}


			if(pastMove == "RIGHT"){
				moveTo("DOWN");
			}else if(pastMove == "UP"){
				moveTo("LEFT");
			}else{
				if(Random.Range(0,2) == 1){
				moveTo("DOWN");
				}else{
				moveTo("LEFT");
				}
			}

		
		}else if(transform.position.z < target.transform.position.z){//②

			if(transform.position.x == 0){
				if(pastMove == "DOWN"){print("ERROR");}
				moveTo("UP");
			}
		
			if(pastMove == "RIGHT"){
					moveTo("UP");
			}else if(pastMove == "DOWN"){
					moveTo("LEFT");
			}else{
				if(Random.Range(0,2) == 1){
				moveTo("UP");
				}else{
				moveTo("LEFT");}
			}
		}

	}else if(transform.position.x < target.transform.position.x){
		
		if(transform.position.z >= target.transform.position.z){//③

			if(transform.position.z == 0){
				if(pastMove == "LEFT"){print("ERROR");}
				moveTo("RIGHT");
			}

			if(pastMove == "LEFT"){
				moveTo("DOWN");
			}else if(pastMove == "UP"){
				moveTo("RIGHT");
			}else{
				if(Random.Range(0,2) == 1){
				moveTo("DOWN");
				}else{
				moveTo("RIGHT");}
			}
		
		}else if(transform.position.z < target.transform.position.z){//④
		
			if(pastMove == "LEFT"){
					moveTo("UP");
			}else if(pastMove == "DOWN"){
					moveTo("RIGHT");
			}else{
				if(Random.Range(0,2) == 1){
				moveTo("UP");
				}else{
				moveTo("RIGHT");}
			}
		}

	}else{print("ERROR!");}

	//print("targetPos" + target.transform.position + " :enemyPos" + transform.position);

}


/*	void seekMove(){
		var n = Random.Range(0, 3);
		if(pastMove == "LEFT"){
			if(n == 0){
				moveTo("UP");
			}else if(n == 1){
				moveTo("DOWN");
			}else if(n == 2){
				moveTo("LEFT");
			}
		}else if(pastMove == "RIGHT"){
			if(n == 0){
				moveTo("UP");
			}else if(n == 1){
				moveTo("DOWN");
			}else if(n == 2){
				moveTo("RIGHT");
			}
		}else if(pastMove == "UP"){
			if(n == 0){
				moveTo("UP");
			}else if(n == 1){
				moveTo("LEFT");
			}else if(n == 2){
				moveTo("RIGHT");
			}
		}else if(pastMove == "DOWN"){
			if(n == 0){
				moveTo("DOWN");
			}else if(n == 1){
				moveTo("LEFT");
			}else if(n == 2){
				moveTo("RIGHT");
			}
		} 
	}
*/	



	void moveTo(string dir){
		switch(dir){
			case "LEFT":
				pastMove = "LEFT";
				transform.position += new Vector3(-1,0,0);//左
				enabled = false;
				playerScript.enabled = true;
				break;
			case "RIGHT":
				pastMove = "RIGHT";
				transform.position += new Vector3(1,0,0);//右
				enabled = false;
				playerScript.enabled = true;
				break;
			case "UP":
				pastMove = "UP";
				transform.position += new Vector3(0,0,1);//上
				enabled = false;
				playerScript.enabled = true;
				break;
			case "DOWN":
				pastMove = "DOWN";
				transform.position += new Vector3(0,0,-1);//下
				enabled = false;
				playerScript.enabled = true;
				break;
		}
	}





	void hide(){



	}




	void evaluate(){

		
	}

	void research(){

		if(transform.position + new Vector3(-1, 0, 1) == target.transform.position){
			PastTargetPosition = 1;

		}else if(transform.position + new Vector3(0, 0, 1) == target.transform.position){
			PastTargetPosition = 2;

		}else if(transform.position + new Vector3(1, 0, 1) == target.transform.position){
			PastTargetPosition = 3;

		}else if(transform.position + new Vector3(-1, 0, 0) == target.transform.position){
			PastTargetPosition = 4;
		
		}else if(transform.position + new Vector3(1, 0, 0) == target.transform.position){
			PastTargetPosition = 6;

		}else if(transform.position + new Vector3(-1, 0, -1) == target.transform.position){
			PastTargetPosition = 7;

		}else if(transform.position + new Vector3(0, 0, -1) == target.transform.position){
			PastTargetPosition = 8;

		}else if(transform.position + new Vector3(1, 0, -1) == target.transform.position){
			PastTargetPosition = 9;

		}else{
			PastTargetPosition = 0;
		}


	}




/*
	void OnTriggerEnter(Collider other){
		
		if(other.gameObject.name == "Star") {

			//プレイヤが星と接触したらロール交代（鬼の振る舞いが「追う」から「追われる」に変わる）

		}

		//SendMessage(string methodName, object , SendMessageOptions options = SendMessageOptions.RequireReceiver)
		
	}
*/

	



}
