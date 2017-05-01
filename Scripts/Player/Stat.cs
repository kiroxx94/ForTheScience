using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;


public class Stat : MonoBehaviour {

	[Range(0,100)]
	public int life ; // vie
	private int lifeMax ; // vie max
	[Range(0,100)]
	public int hunger; // faim du joueur 
	private int hungerMax;  // faim Maximal du joueur ( quand le joueur est rassasié ) 
	[Range(0,100)]
	public int eater; // soiffe du joueur 
	private int eaterMax;  // faim Maximal du joueur ( quand le joueur est rassasié ) 
	[Range(0,500)]
	public int stamina; // endurance du joueur 
	private int staminaMax;  // endurance Maximal du joueur ( quand le joueur est rassasié ) 


	private float realTime ; // temps du jeu réel ( calculé à chaque frame )


	// gestion des stats d'interface ( faim , soiffe , endurance )
	public GameObject statUI;


	// gestion de la faim 
	private Scrollbar hungerImage;
	private Text hungerText;
	private float actualTimeHunger; // gestion du temps lorsque le joueur a perdu de la faim 
	public float timeForLooseHunger ;    // temps avant de perdre de la faim

	//gestion de la soiffe
	private Scrollbar eaterImage;
	private Text eaterText;
	private float actualTimeEater; // gestion du temps lorsque le joueur a perdu de la faim 
	public float timeForLooseEater ;    // temps avant de perdre de la faim

	// gestion de l'endurance 
	private Scrollbar staminaImage;
	private Text staminaText;
	private float actualTimeStamina; // gestion du temps lorsque le joueur a perdu de la faim 
	public float timeForLooseStamina ;    // temps avant de perdre de la faim


	// gestion du sang et de la regeneration de vie
	public GameObject bloodUI ; // Image de sang
	public float timeBeforeRestoreLife ;    // temps avant de pouvoir ce soigner 
	private float actualTimeWhenAttacked; // gestion du temps lorsque le joueur est attaque
	private bool attacked ; // le joueur est attaqué ou non

	// Use this for initialization
	void Start () {
		// initialisation des interfaces
		initBloodUI ();
		initStatUI ();

		attacked = false;

		// initialisation des timers 
		realTime = Time.time ;
		actualTimeWhenAttacked = realTime;
		actualTimeHunger = realTime ;
		actualTimeEater = realTime ;

		// initialisation des stat maximal
		lifeMax = 100; 
		hungerMax = 100; // en pourent
		eaterMax = 100; // en pourcent 
		staminaMax = 500;
	}

	private void initBloodUI(){
		if (bloodUI != null) {
			bloodUI.SetActive(true);
		} else {
			Debug.LogWarning ("Vous n'avez pas d'image de renseigner dans bloodUI du script stat");
		}
	}

	private void initStatUI(){
		if (statUI != null) {
			statUI.SetActive (true);
			hungerImage = statUI.transform.FindChild ("hungerUI").GetComponent<Scrollbar> ();
			hungerText = statUI.transform.FindChild ("hungerUI").FindChild ("text").GetComponent<Text> ();	
			eaterImage = statUI.transform.FindChild ("eaterUI").GetComponent<Scrollbar> ();
			eaterText = statUI.transform.FindChild ("eaterUI").FindChild ("text").GetComponent<Text> ();	
			staminaImage = statUI.transform.FindChild ("staminaUI").GetComponent<Scrollbar> ();
			staminaText = statUI.transform.FindChild ("staminaUI").FindChild ("text").GetComponent<Text> ();	
		} else {
			Debug.LogWarning ("Vous n'avez pas de GUI de renseigner dans StatUI du script stat");
		}
	}
	
	// Update is called once per frame
	void Update () {

		realTime = Time.time;

		upDateHunger (); // met à jour la faim 
		upDateEater (); // met à jour la soiffe
		upDateStamina (); // met à jour l'endurance 
		upDateLife (); // met à jour la vie ( si 0 = mort , si > 100 = 100 , si attacked == false = regen )
		upDateAttacked (); // met à jour le statut attacked 

        if (statUI != null)
        {
            upDateHungerBar(); // met à jour la barre de faim 
            upDateEaterBar(); // met à jour la barre de soiffe
            upDateStaminaBar(); // met à jour la barre d'endurance
            upDateBlood(); // met à jour l'affichage du sang

        }




    }

        private void upDateHunger(){
		if (realTime >= actualTimeHunger + timeForLooseHunger && hunger > 0) { // diminution de la faim en fonction du temps
			hunger -- ;
			actualTimeHunger = Time.time ;
		}
		if (hunger < 0) {
			hunger = 0;
		} else if (hunger > hungerMax) {
			hunger = hungerMax;
		}
	}

	private void upDateHungerBar(){
		hungerText.text = (hunger + " % ");
		if (hunger != 0) {
			float fillAmount = (float)hunger / (float)hungerMax;
			hungerImage.size = fillAmount;
		}
	}

	private void upDateEater(){
		if (realTime >= actualTimeEater + timeForLooseEater) { // augmentation de la faim en fonction du temps
			eater -- ;
			actualTimeEater = Time.time ;
		}
	}

	private void upDateEaterBar(){
		eaterText.text = (eater + " % ");
		if (eater != 0) {
			float fillAmount = (float)eater / (float)eaterMax;
			eaterImage.size = fillAmount;
		}
	}

	private void upDateStamina(){
		if (Input.GetKey (KeyCode.LeftShift) && stamina > 0) { // augmentation de la faim en fonction du temps
			stamina--;
			actualTimeStamina = Time.time;
		} 
		if (realTime >= actualTimeStamina + timeForLooseStamina && stamina < staminaMax) { // augmentation de la faim en fonction du temps
			stamina ++ ;
			actualTimeStamina = Time.time ;
		}
		if (stamina <= 0) { // si plus d'endurance on peut plus courir
			GetComponent<FirstPersonController> ().setCanRunning (true);
		} else {
			GetComponent<FirstPersonController> ().setCanRunning (false);
		}
		if (stamina > staminaMax) { // bloque la vie à 100 HP
			stamina = staminaMax;
		}	
	}

	private void upDateStaminaBar(){
		staminaText.text = (stamina + " % ");
		if (stamina != 0) {
			float fillAmount = (float)stamina / (float)staminaMax;
			staminaImage.size = fillAmount;
		}
	}

	private void upDateBlood(){
		if (bloodUI != null) {
			if (life >= 1 && life < 30) {
				bloodUI.GetComponent<Animator> ().Play("bigBlood");
			}
			if (life >= 30 && life < 60) {
				bloodUI.GetComponent<Animator> ().Play("blood");
			}
			if (life >= 60 && life < 80) {
				bloodUI.GetComponent<Animator> ().Play("littleBlood");
			}
			if (life >= 80 && life <= lifeMax) {
				bloodUI.GetComponent<Animator> ().Play("noBlood");
			}
		}
	}

	private void upDateLife(){
		if (life <= 0) { // si HP < 0 alors on est mort
			dead ();
		}
		if (life > lifeMax) { // bloque la vie à 100 HP
			life = lifeMax;
		}	
		if (!attacked && life < lifeMax && life > 0 ) { // regenération des HP
			life ++ ;
		}
	}

	private void upDateAttacked(){
		if (realTime >= actualTimeWhenAttacked + timeBeforeRestoreLife) { // si sa fait assez longtemps que l'on n'est plus attaquer alors on met attacked a false 
			attacked = false ;
		}
	}


	public void applyDamage(int damage){
		this.life -= damage;
		attacked = true;
		actualTimeWhenAttacked = Time.time;
	}

	private void dead(){
		//Destroy (this.gameObject);
	}

	public void setLife(int life){
		this.life = life ;
	}


	public int getLife(){
		return this.life;
	}


	public void setHunger(int hunger){
		this.hunger = hunger ;
		if (this.hunger >= hungerMax) {
			hunger = hungerMax;
		}
	}


	public int getHunger(){
		return this.hunger;
	}

		
}
