using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {
	public GameObject player;
	public GameObject enemy;
	public GameObject star;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player1");
		enemy = GameObject.Find("Enemy2");
		star = GameObject.Find("Star"); 

		player.GetComponent<Player>().enabled = true;
		//enemy.GetComponent<Enemy>().enabled = false;
		enemy.GetComponent<Enemy2>().enabled = false;

		gameStart();

	}
	
	// Update is called once per frame
	void Update () {
		//プレイヤとスターが同じ位置になったら、プレーヤとオニの立場逆転。（オニが逃げ出しはじめる）
		//かつ、スターをランダムで別のマスに生成。
		//(オニとプレイヤーのいるとこには生成しないようにする)
		if(player.transform.position == star.transform.position){
			star.transform.position = new Vector3(Random.Range(0,8), 1, Random.Range(0,8));
		}

		//プレイヤーとオニが同じ位置になったらゲーム終了
		if(player.transform.position == enemy.transform.position){

			this.gameOver();

		}
			
	}

	void gameStart(){

		//gameStartFlag = true;
	
	}

	void gameOver(){

		//gameOverFlag = true;

	}

	//GodはGUI表示もする
	void OnGUI(){



	}


}