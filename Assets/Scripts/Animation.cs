using UnityEngine;
using DG.Tweening;

public class Animation : MonoBehaviour
{
    [SerializeField] Transform moon;
    Material skyMat;

    float density = 0;

    // Start is called before the first frame update
    void Start()
    {
        skyMat = RenderSettings.skybox;




    }

    void FillSky()
    {
        DOTween.To(() => density, x => density = x, .25f, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            density = 0;
            skyMat.SetFloat("_Density", density);
            DOTween.KillAll();

            FillSky();
            moon.DOMove(new Vector3(-14, -5, 72), 0);
            moon.DOMove(new Vector3(-14, 5, 72), 2);
        }

        skyMat.SetFloat("_Density", density);
    }

    void OnDestroy()
    {
        skyMat.SetFloat("_Density", .27f);    
    }
}
