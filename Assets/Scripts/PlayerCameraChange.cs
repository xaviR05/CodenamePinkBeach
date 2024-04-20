using UnityEngine;
using StarterAssets;

public class PlayerCameraChange : MonoBehaviour
{
    [SerializeField] private GameObject [] cameras;
    public int currentCameraIndex;
    public GameObject currentCamera;
    private StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    void Start()
    {
        cameras[0].SetActive(true);
        currentCamera = cameras[0];
        currentCameraIndex = 0;
    }

    void Update()
    {
        if (starterAssetsInputs.changeCamera)
        {
            Debug.Log("Hola");
            if (currentCameraIndex < cameras.Length - 1)
            {
                cameras[currentCameraIndex].SetActive(false);
                currentCameraIndex += 1;
                cameras[currentCameraIndex].SetActive(true);
                currentCamera = cameras[currentCameraIndex];
            }
            else
            {
                cameras[currentCameraIndex].SetActive(false);
                currentCameraIndex = 0;
                cameras[currentCameraIndex].SetActive(true);
                currentCamera = cameras[currentCameraIndex];
            }
            starterAssetsInputs.changeCamera = false;
        }
    }
}
