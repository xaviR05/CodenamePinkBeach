using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ThirdPersonShooterController : MonoBehaviour
{
    /*public enum WeaponTypes
    {
        shootable,
        flamethrower,
        throwable,
        melee
    }
    [SerializeField] private WeaponTypes currentWeaponTypes;*/


    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private GameObject scope;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask;
    //[SerializeField] private GameObject debugTransform;
    //[SerializeField] private GameObject AimRig;
    [SerializeField] private Transform pfBulletProjectile;
    private GameObject spawnBulletPosition;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;

    [SerializeField] private ParticleSystem flames;

    //[SerializeField] private GameObject RigidBuilderEnablerObject; 
    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        spawnBulletPosition = GameObject.Find("FirePoint");
    }

    private void Start()
    {
        flames.gameObject.SetActive(false);
        //AimRig.gameObject.SetActive(false);
    }

    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            mouseWorldPosition = raycastHit.point;
        }

        Aim(raycastHit, mouseWorldPosition);
        
    }

    public void Aim(RaycastHit raycastHit, Vector3 mouseWorldPosition)
    {
        if (starterAssetsInputs.aim)
        {
            //RigidBuilderEnablerObject.GetComponent<RigBuilderEnabler>().rb.enabled = true;
            //debugTransform.transform.position = raycastHit.point;
            //debugTransform.transform.position = Vector3.MoveTowards(debugTransform.transform.position, raycastHit.point, 0.8f);
            //AimRig.gameObject.SetActive(true);
            aimVirtualCamera.gameObject.SetActive(true);
            scope.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotationOnMove(false);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            //RigidBuilderEnablerObject.GetComponent<RigBuilderEnabler>().rb.enabled = false;
            //debugTransform.transform.position = new Vector3(0f, 1.294998f, 3.75f);
            //AimRig.gameObject.SetActive(false);
            aimVirtualCamera.gameObject.SetActive(false);
            scope.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotationOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }
        /*
        if (currentWeaponTypes == WeaponTypes.shootable)
        {
            if (starterAssetsInputs.shoot)
            {
                Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.transform.position).normalized;
                Instantiate(pfBulletProjectile, spawnBulletPosition.transform.position, Quaternion.LookRotation(aimDir, Vector3.up));
                starterAssetsInputs.shoot = false;
            }
        }
        else if (currentWeaponTypes == WeaponTypes.flamethrower)
        {
            if (starterAssetsInputs.shootFlames)
            {
                flames.gameObject.SetActive(true);
            }
            else
            {
                flames.gameObject.SetActive(false);
            }
        }*/
    }
}
