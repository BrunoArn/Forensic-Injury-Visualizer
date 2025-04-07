using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MosaicManager : MonoBehaviour
{
    [Header("Mosaic Pages")]
    [Space]
    [SerializeField] private List<MosaicPage> mosaicPages;


    private List<Image> mosaicChildImages = new List<Image>();
    
    [Header("Buttons")]
    [Space]
    [SerializeField] private GameObject NextButton;
    [SerializeField] private GameObject previousButton;

    private int currentPage;

    void Start()
    {
        currentPage = 0;
        SetUpImages();
        UpdateMosaicPage(currentPage);
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

    private void SetUpImages() 
    {
       foreach (Transform child in transform)
       {
            if (child.childCount > 0) {
                Transform grandChild = child.GetChild(0);
                Image img = grandChild.GetComponent<Image>();

                if(img != null) {
                    mosaicChildImages.Add(img);
                }
            }
       }
    }

    private void UpdateMosaicPage(int page) {
        for (int i = 0; i < mosaicChildImages.Count; i++) {
            mosaicChildImages[i].sprite = mosaicPages[page].GetSprite(i);
        }
        currentPage = page;
    }
}
