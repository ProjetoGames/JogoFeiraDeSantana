using UnityEngine;
using System.Collections;


public class MovimentoDaBanana : MonoBehaviour {

	private bool noChao;
	private MovimentoDaPessoa pessoa;
	public GameObject cascaBanana;
	private Animator animator;

	// Use this for initialization
	void Start () {
		noChao = true;
		animator = cascaBanana.GetComponent<Animator> ();
		print (animator.name);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!noChao) {
			transform.position = pessoa.transform.position;
			transform.position += new Vector3 (0 , 0, -10.5f) * Time.deltaTime;
		}
			
		if (Input.GetKey ("left") ) {
			transform.position += new Vector3 (-1.5f , 0, 0) * Time.deltaTime;

		} else if (Input.GetKey ("right") ) {
			transform.position += new Vector3 (1.5f , 0, 0) * Time.deltaTime;
			
		} else if (Input.GetKey ("up") ) {
			transform.position += new Vector3 (0, 1.5f, 0) * Time.deltaTime;
			
		} else if (Input.GetKey ("down") ) {
			transform.position += new Vector3 (0, -1.5f, 0) * Time.deltaTime;
		}
	
	}

	public void AcessoAoMovimento(MovimentoDaPessoa pessoa){

		this.pessoa = pessoa;
		noChao = false;
	}

	void OnTriggerEnter2D (Collider2D col){		

		
		if(col.name.Equals("Lixo")){
		

			transform.position = col.transform.position;
			yield return new WaitForSeconds(0.5f);
			//
			animator.SetBool("taIndoLixo", true);
			cascaBanana.SetActive(false);
			yield break;

			//yield return new WaitForSeconds(5);
			// Prints 0
			//StartCoroutine(esperarOtempo());


		}

	}

	IEnumerator esperarOtempo(Collider2D col){
		//Debug.Log ("about to yield return WaitForSeconds(1)");

	}

	public void SetNoChao(bool b){
		noChao = b;
	}
}
