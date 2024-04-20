using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GtaViceCity.Weapons;
using UnityEngine.UI;

public class WeaponInfo : MonoBehaviour
{
    public Texture WeaponIcon;
    public string WeaponName;
    public WeaponCategory Type;
    public GameObject WeaponPrefab;
    public Vector3 SpawnPoint;
    public Vector3 SpawnRotation;
}
