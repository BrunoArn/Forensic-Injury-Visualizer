using System.Collections;
using UnityEngine;

public class CanvasFade : MonoBehaviour
{

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeDuration = 0.3f;

    [SerializeField] Camera mainCamera;
    [SerializeField] Transform focusTarget; //objeto para o centro do canvas
    [SerializeField] Vector3 offset = new Vector3(0, 0, -10); // distancia do objeto

    [SerializeField] Vector3 middleCameraPosition;

    void Start()
    {
        if (mainCamera == null) { mainCamera = Camera.main; }

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void ShowCanvas() {
        gameObject.SetActive(true);
        StartCoroutine(FadeCanvasRoutine(1, middleCameraPosition));
    }

    public void HideCanvas() {
        StartCoroutine(FadeCanvasRoutine(0, focusTarget.position + offset));
    }

    IEnumerator FadeCanvasRoutine(float targetAlpha, Vector3 cameraTargetPosition) {
        float startAlpha = canvasGroup.alpha;
        float time = 0f;

        Vector3 startCamPos = mainCamera.transform.position;

        while (time < fadeDuration) {

            float t = time/fadeDuration;

            //camera move
            mainCamera.transform.position = Vector3.Lerp(startCamPos, cameraTargetPosition, t);
            //canvas fade
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, t);

            time += Time.deltaTime;
            yield return null;
        }

        //finalizaçao exata
        mainCamera.transform.position = cameraTargetPosition;
        canvasGroup.alpha = targetAlpha;

        bool isVisible = targetAlpha > 0;
        canvasGroup.interactable = isVisible;
        canvasGroup.blocksRaycasts = isVisible;

        if(!isVisible) { gameObject.SetActive(false); }
    }
}
