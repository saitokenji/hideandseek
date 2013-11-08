using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public string pastKey = "";
	public GameObject target;
	public GameObject star;
	public string pastMove; 
 	public int DicovoredTargetPosition;
 	public int PastTargetPosition;
 	private Player playerScript;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player1");
		playerScript = target.GetComponent<Player>();

		DicovoredTargetPosition = 0;
		star = GameObject.Find("Star");
	}
	
	// Update is called once per frame
	void Update () {
		this.search();
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
	//追いかける時の動作。
	//１）ターゲット未発見（=0）の場合は、上下左右ランダムに動く。
	//２）ターゲットが周囲1〜9のどこに居るかでそれぞれに動く。
	//		0 0 0 0 0
	//		0 1 2 3 0
	//		0 4 鬼 6 0
	//		0 7 8 9 0
	//		0 0 0 0 0

	var n = (int)(Random.Range(0,2));//２）で使う変数n

	//ターゲット未発見の場合
	if(DicovoredTargetPosition == 0){
		if(transform.position.x == 0){
			if(transform.position.z == 0){
				switch((int)(Random.Range(0,2))){
				case 0:
					moveTo("RIGHT");
					break;
				case 1:
					moveTo("UP");
					break;}		
			}else if(transform.position.z == 7){
				switch((int)(Random.Range(0,2))){
				case 0:
					moveTo("RIGHT");
					break;
				case 1:
					moveTo("DOWN");
					break;}
			}else{
				switch((int)(Random.Range(0,3))){
				case 0:
					moveTo("RIGHT");
					break;
				case 1:
					moveTo("UP");
					break;
				case 2:
					moveTo("DOWN");
					break;}
			}
		}else if(transform.position.x == 7){
			if(transform.position.z == 0){
				switch((int)(Random.Range(0,2))){
				case 0:
					moveTo("LEFT");
					break;
				case 1:
					moveTo("UP");
					break;}
			}else if(transform.position.z == 7){
				switch((int)(Random.Range(0,2))){
				case 0:
					moveTo("LEFT");
					break;
				case 1:
					moveTo("DOWN");
					break;}
			}else{
				switch((int)(Random.Range(0,3))){
				case 0:
					moveTo("LEFT");
					break;
				case 1:
					moveTo("UP");
					break;
				case 2:
					moveTo("DOWN");
					break;}
			}
		}else{
			if(transform.position.z == 0){
				switch((int)(Random.Range(0,3))){
				case 0:
					moveTo("LEFT");
					break;
				case 1:
					moveTo("RIGHT");
					break;
				case 2:
					moveTo("UP");
					break;}
			}else if(transform.position.z == 7){
				switch((int)(Random.Range(0,3))){
				case 0:
					moveTo("LEFT");
					break;
				case 1:
					moveTo("RIGHT");
					break;
				case 2:
					moveTo("DOWN");
					break;}
			}else{
				switch((int)(Random.Range(0,4))){
				case 0:
					moveTo("LEFT");
					break;
				case 1:
					moveTo("RIGHT");
					break;
				case 2:
					moveTo("UP");
					break;
				case 3:
					moveTo("DOWN");
					break;}
			}
		}
	//ターゲットが左上
	}else if(DicovoredTargetPosition == 1){

		switch(n){
		case 0:
			moveTo("LEFT");//左
			break;
		case 1:
			moveTo("UP");//上
			break;}
	//ターゲットが上
	}else if(DicovoredTargetPosition == 2){

		moveTo("UP");//上

	//ターゲットが右上
	}else if(DicovoredTargetPosition == 3){

		switch(n){
			case 0:
				moveTo("RIGHT");//右
				break;
			case 1:
				moveTo("UP");//上
				break;
		}

	//ターゲットが左
	}else if(DicovoredTargetPosition == 4){

		moveTo("LEFT");;//左

	//
	}else if(DicovoredTargetPosition == 5){


	//ターゲットが右
	}else if(DicovoredTargetPosition == 6){

		moveTo("RIGHT");//右

	//ターゲットが左下
	}else if(DicovoredTargetPosition == 7){

		switch(n){
			case 0:
				moveTo("LEFT");//左
				break;
			case 1:
				moveTo("DOWN");//下
				break;
		}

	//ターゲットが下
	}else if(DicovoredTargetPosition == 8){

		moveTo("DOWN");//下
	
	//ターゲットが右下
	}else if(DicovoredTargetPosition == 9){

		switch(n){
			case 0:
				moveTo("RIGHT");//右
				break;
			case 1:
				moveTo("DOWN");//下
				break;
		}

	}

}

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
