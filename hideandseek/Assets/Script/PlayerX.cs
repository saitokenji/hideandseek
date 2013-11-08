using UnityEngine;
using System.Collections;

public class PlayerX : MonoBehaviour {
	public Vector3 playerNewPosition;
	//public Vector3 playerCurrentPosition;
	public Vector3 playerPastPosition;
	public int plan;
	
	// Use this for initialization
	void Start () {
		//playerCurrentPosition = transform.position;
		playerPastPosition = new Vector3(0,0,0);
		plan = 4;
	}

	
	// Update is called once per frame
	void Update () {

		//NewPositionに現在の位置を代入
		playerNewPosition = transform.position;

		//0~3までのプラン決め
		plan = Random.Range(0,4);	Debug.Log(plan);

		switch(plan){
			case 0:
				playerNewPosition.x += 1.0f;
				break;
			case 1:
				playerNewPosition.x -= 1.0f;
				break;
			case 2:
				playerNewPosition.z += 1.0f;
				break;
			case 3:
				playerNewPosition.z -= 1.0f;
				break;
			default:
				break;

		}
		
		//前の位置と同じだった場合、NewPositionを初期化して、再度プラン決め
		if(playerNewPosition == playerPastPosition){

			switch(plan){
				case 0:
					playerNewPosition.x -= 1.0f;
					break;
				case 1:
					playerNewPosition.x += 1.0f;
					break;
				case 2:
					playerNewPosition.z -= 1.0f;
					break;
				case 3:
					playerNewPosition.z += 1.0f;
					break;
				default:
					break;
			}

			return;
		}


		if(playerNewPosition.x > 7.0f) playerNewPosition.x = 0.0f;

		if(playerNewPosition.x < 0.0f) playerNewPosition.x = 7.0f;

		if(playerNewPosition.z > 7.0f) playerNewPosition.z = 0.0f;

		if(playerNewPosition.z < 0.0f) playerNewPosition.z = 7.0f;
		

		//次回のプラン決めの時用にpastPositionに現在位置を保存
		playerPastPosition = transform.position; 
		 //playerにNewPositionの適用
		transform.position = playerNewPosition;
		
	}
}