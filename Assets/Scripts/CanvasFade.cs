using System.Collections;
using UnityEngine;

public class CanvasFade : MonoBehaviour
{

    [SerializeField] private CanvasGroup injuryCanvasGroup;
    [SerializeField] private CanvasGroup allImagesCanvasGroup;
    [SerializeField] private CanvasGroup MosaicCanvasGroup;
    [SerializeField] private CanvasGroup babyButtonsCanvasGroup;
    [SerializeField] private float fadeDuration = 0.3f;

    [SerializeField] Camera mainCamera;
    [SerializeField] Transform focusTarget; //objeto para o centro do canvas
    [SerializeField] Vector3 offset = new Vector3(0, 0, -10); // distancia do objeto

    [SerializeField] Vector3 middleCameraPosition;

    void Start()
    {
        if (mainCamera == null) { mainCamera = Camera.main; }

        injuryCanvasGroup.alpha = 0;
        injuryCanvasGroup.interactable = false;
        injuryCanvasGroup.blocksRaycasts = false;

        MosaicCanvasGroup.alpha = 0;
        MosaicCanvasGroup.interactable = false;
        MosaicCanvasGroup.blocksRaycasts = false;
    }

    public void ShowInjuryCanvas() {
        //gameObject.SetActive(true);
        StartCoroutine(FadeCanvasRoutine(injuryCanvasGroup, 1));
        StartCoroutine(MoveCameraRoutine(middleCameraPosition));

        StartCoroutine(FadeCanvasRoutine(allImagesCanvasGroup, 0));
    }

    public void HideInjuryCanvas() {
        StartCoroutine(FadeCanvasRoutine(injuryCanvasGroup, 0));
        StartCoroutine(MoveCameraRoutine(focusTarget.position + offset));

        StartCoroutine(FadeCanvasRoutine(allImagesCanvasGroup, 1));
    }

    public void ShowMosaicCanvas() {
        StartCoroutine(FadeCanvasRoutine(MosaicCanvasGroup, 1));
        StartCoroutine(MoveCameraRoutine(middleCameraPosition));
        BabyButtonActivation(false);

        StartCoroutine(FadeCanvasRoutine(allImagesCanvasGroup, 0));
    }

    public void HideMosaicCanvas() {
        StartCoroutine(FadeCanvasRoutine(MosaicCanvasGroup, 0));
        StartCoroutine(MoveCameraRoutine(focusTarget.position + offset));
        BabyButtonActivation(true);

        StartCoroutine(FadeCanvasRoutine(allImagesCanvasGroup, 1));
    }

    private void BabyButtonActivation(bool isActive) {
        babyButtonsCanvasGroup.interactable = isActive;
        babyButtonsCanvasGroup.blocksRaycasts = isActive;
    }

    IEnumerator FadeCanvasRoutine(CanvasGroup canvasGroup, float targetAlpha) {
        float startAlpha = canvasGroup.alpha;
        float time = 0f;

        while (time < fadeDuration) {

            float t = time/fadeDuration;
            //canvas fade
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, t);

            time += Time.deltaTime;
            yield return null;
        }

        //finalizaçao exata
        canvasGroup.alpha = targetAlpha;

        bool isVisible = targetAlpha > 0;
        canvasGroup.interactable = isVisible;
        canvasGroup.blocksRaycasts = isVisible;

        //if(!isVisible) { gameObject.SetActive(false); }
    }

    IEnumerator MoveCameraRoutine(Vector3 cameraTargetPosition) {
        float time = 0f;
        Vector3 startCamPos = mainCamera.transform.position;

        while (time < fadeDuration) {
            float t = time/fadeDuration;

            mainCamera.transform.position = Vector3.Lerp(startCamPos, cameraTargetPosition, t);

            time += Time.deltaTime;
            yield return null;
         }

         mainCamera.transform.position = cameraTargetPosition;
    }
}
