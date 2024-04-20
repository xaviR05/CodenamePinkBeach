using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GtaViceCity.Weapons;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour
{
    int totalWeapons = 1;
    public int currentWeaponIndex;

    public GameObject[] guns;
    public GameObject weaponHolder;
    public GameObject currentGun;

    [SerializeField] private RawImage WeaponIcon;
    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
        WeaponIcon.texture = guns[currentWeaponIndex].GetComponent<WeaponInfo>().WeaponIcon;
    }

    void Update()
    {
        //totalWeapons = weaponHolder.transform.childCount;

        if (totalWeapons < weaponHolder.transform.childCount)
        {
            totalWeapons = weaponHolder.transform.childCount;
            GroupResize(totalWeapons, ref guns);
            for (int i = 0; i < totalWeapons; i++)
            {
                guns[i] = weaponHolder.transform.GetChild(i).gameObject;
                guns[i].SetActive(false);
            }

            guns[totalWeapons - 1].SetActive(true);
            currentGun = guns[totalWeapons - 1];
            currentWeaponIndex = totalWeapons - 1;

        }

        //Next
        if (/*Input.GetKeyDown(KeyCode.C)*/Input.mouseScrollDelta.y > 0)
        {
            if (currentWeaponIndex < totalWeapons - 1)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex += 1;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
            else
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex = 0;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
            WeaponIcon.texture = guns[currentWeaponIndex].GetComponent<WeaponInfo>().WeaponIcon;
        }

        //Previous
        if (/*Input.GetKeyDown(KeyCode.X)*/Input.mouseScrollDelta.y < 0)
        {
            if (currentWeaponIndex > 0)
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex -= 1;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
            else
            {
                guns[currentWeaponIndex].SetActive(false);
                currentWeaponIndex = guns.Length-1;
                guns[currentWeaponIndex].SetActive(true);
                currentGun = guns[currentWeaponIndex];
            }
            WeaponIcon.texture = guns[currentWeaponIndex].GetComponent<WeaponInfo>().WeaponIcon;
        }
    }

    public void GroupResize(int Size, ref GameObject[] Group)
    {

        GameObject[] temp = new GameObject[Size];
        for (int c = 1; c < Mathf.Min(Size, Group.Length); c++)
        {
            temp[c] = Group[c];
        }
        Group = temp;
    }
}
