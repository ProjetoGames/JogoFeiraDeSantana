using UnityEngine;
using System.Collections;

public class MovimentoDaPessoa : MonoBehaviour {


	int rand=0;//, QTD=0;
	private int LEFT = 1;
	private int RIGHT = 2;
	private int UP= 3;
	private int DOWN = 4;
	private MovimentoDaBanana lixo;
	//public GameObject onde;

	// Use this for initialization
	void Start () {


		rand = Random.Range (1,4);
		//Debug.Log (contadorTempo);


	}
	// Update is called once per frame
	void Update () {

				
		if (rand == LEFT) {
			transform.position += new Vector3 (-1.5f , 0, 0) * Time.deltaTime;

		} else if (rand == RIGHT) {
			transform.position += new Vector3 (1.5f, 0, 0) * Time.deltaTime;

		} else if (rand == UP) {
			transform.position += new Vector3 (0, 1.5f, 0) * Time.deltaTime;

		}else if (rand == DOWN) {
			transform.position += new Vector3 (0, -1.5f, 0) * Time.deltaTime;

		}  

	}

	void OnTriggerEnter2D (Collider2D col){

		if(col.name.Equals("Lixo") && lixo!=null){
			lixo.SetNoChao(true);
		}else if(col.name.Equals("cascaDeBanana")){
			JogarCascaNoLixo(col);
			return;
		}

		//Debug.Log("massafera");
		if(rand==LEFT){
			rand = Random.Range (2,4);

		}else if(rand==RIGHT){
			do{
				rand = Random.Range (1,4);
			}while(rand==2);

		}else if(rand==UP){

			do{
				rand = Random.Range (1,4);
			}while(rand==3);

		}else if(rand==DOWN){
			rand = Random.Range (1,3);
	    }

		//.SendMessage ("tipapowxa");//  SendMessageUpwards("blablaba");


	}

	public void JogarCascaNoLixo(Collider2D col){

		col.GetComponent<MovimentoDaBanana> ().AcessoAoMovimento (this);
		lixo = col.GetComponent<MovimentoDaBanana> ();

	}





}

