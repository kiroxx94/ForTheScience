using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public GameObject[] weapons;


    public float switchWeaponTime = 0.25f;

    public bool canSwitch = false;

    public int weaponToSelect = 0;

    // Use this for initialization
    void Start () {
        DeselectWeapon();
        weapons[0].SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("1") && weapons.Length >= 1 && canSwitch && weaponToSelect != 0)
        {
            DeselectWeapon();
            weaponToSelect = 0;
        }
        else if (Input.GetKeyDown("2") && weapons.Length >= 2 && canSwitch && weaponToSelect != 1)
        {
            DeselectWeapon();
            weaponToSelect = 1;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && canSwitch)
        {
            weaponToSelect++;
            if (weaponToSelect > (weapons.Length - 1))
            {
                weaponToSelect = 0;
            }
            DeselectWeapon();
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && canSwitch)
        {
            weaponToSelect--;
            if (weaponToSelect < 0)
            {
                weaponToSelect = weapons.Length - 1;
            }
            DeselectWeapon();
        }


    }

    void SelectWeapon(int i)
    {
        weapons[i].SetActive(true);
        //weapons[i].SendMessage("select", SendMessageOptions.DontRequireReceiver);
    }

    void DeselectWeapon()
    {
        canSwitch = false;
        for (int i = 0; i < weapons.Length; i++){
            //weapons[i].SendMessage("Deselect", SendMessageOptions.DontRequireReceiver);
            weapons[i].SetActive(false);
        }

        //StartCoroutine("SelectedWeapon", switchWeaponTime);
        SelectWeapon(weaponToSelect);
        canSwitch = true;
    }

    IEnumerator SelectedWeapon(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            SelectWeapon(weaponToSelect);
            canSwitch = true;

        }
    }


}
