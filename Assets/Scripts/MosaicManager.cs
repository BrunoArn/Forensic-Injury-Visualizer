using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MosaicManager : MonoBehaviour
{
    [SerializeField] private List<MosaicPage> mosaicPages;
    [SerializeField] private List<GameObject> mosaicImages;

    [SerializeField] private GameObject NextButton;
    [SerializeField] private GameObject previousButton;

    private int currentPage;

    void Start()
    {
        currentPage = 0;
        UpdateMosaicPage(currentPage);
        Debug.Log(mosaicPages.Count);
    }

    void Update()
    {
        if (currentPage == 0){
            previousButton.SetActive(false);
        } else { 
            previousButton.SetActive(true);
        }

        if (currentPage == mosaicPages.Count -1 || mosaicPages.Count == 1) {
            NextButton.SetActive(false);
        } else {
            NextButton.SetActive(true);
        }
    }

    public void SetUpNextPage() {
        UpdateMosaicPage(currentPage + 1);
    }

    public void SetUpPreviousPage() {
        UpdateMosaicPage(currentPage - 1);
    }

    private void UpdateMosaicPage(int page) {
        Debug.Log("Updating Page, current page is: " + page);

        for (int i = 0; i < mosaicImages.Count; i++) {
            Image image = mosaicImages[i].GetComponent<Image>();
            image.sprite = mosaicPages[page].GetSprite(i);
        }
        currentPage = page;
    }
}
