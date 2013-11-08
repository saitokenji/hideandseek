using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public string pastKey = "";
	public GameObject enemy;
	public GameObject star;
	public bool playerTurn;
	//private Enemy enemyScript;
	private Enemy2 enemyScript;

	// Use this for initialization
	void Start () {
		enemy = GameObject.Find("Enemy2");
		star = GameObject.Find("Star");

		//enemyScript = enemy.GetComponent<Enemy>();
		enemyScript = enemy.GetComponent<Enemy2>();
	}
	
	// Update is called once per frame
	void Update () {

		this.move();
		this.evaluate();

	}

	void move(){	
		//キー入力に応じてPlayerを動かす
		//ただし、直前にいたマスには進めない
		//かつ、鬼のいるマスには進めない
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			if(pastKey == "DOWN") return;
			if(enemy.transform.position  == this.transform.position + new Vector3(0,0,1)) return;
			if(this.transform.position.z == 7) return;

			transform.position += new Vector3(0,0,1);
			pastKey = "UP";
			switchTurn();
			
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			if(pastKey == "UP") return;
			if(enemy.transform.position  == this.transform.position - new Vector3(0,0,1)) return;
			if(this.transform.position.z == 0) return;

			transform.position  -= new Vector3(0,0,1);
			pastKey = "DOWN";
			switchTurn();
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			if(pastKey == "LEFT") return;
			if(enemy.transform.position  == this.transform.position + new Vector3(1,0,0)) return;
			if(this.transform.position.x == 7) return;

			transform.position += new Vector3(1,0,0);
			pastKey = "RIGHT";
			switchTurn();
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			if(pastKey == "RIGHT") return;
			if(enemy.transform.position  == this.transform.position - new Vector3(1,0,0)) return;
			if(this.transform.position.x == 0) return;

			transform.position  -= new Vector3(1,0,0);
			pastKey = "LEFT";
			switchTurn();
		}
	}


	void evaluate(){

		
	}

	void switchTurn(){
		enabled = false;
		enemyScript.enabled = true;
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
