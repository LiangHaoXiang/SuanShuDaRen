using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollerPage : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{

    ScrollRect rect;
    //页面：0，1，2，3 索引从0开始

   
    List<float> pages = new List<float>();
    int currentPageIndex = -1;

    public float smooting = 10f;//滑动速度

    float targethorizontal = 0;//滑动的起始目标

    bool isDrag = false;//是否拖拽结束

    public System.Action<int, int> OnPageChanged;

    float startime = 0f;
    float delay = 0.1f;
   
    // Use this for initialization
    void Start()
    {
        rect = transform.GetComponent<ScrollRect>();


        startime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {


        if (Time.time < startime + delay) return;
        UpdataPages();

        if (!isDrag && pages.Count > 0)
        {
            rect.horizontalNormalizedPosition = Mathf.Lerp(rect.horizontalNormalizedPosition, targethorizontal, Time.deltaTime * smooting);

        }
      


        
        
        // if (isDrag == false)
        //   {
        //    Invoke("ontoggle", 1f);


        // }


    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;

        float posX = rect.horizontalNormalizedPosition;
        int index = 0;
        //假设离第一位最近
        float offset = Mathf.Abs(pages[index] - posX);
        for (int i = 1; i < pages.Count; i++)
        {
            float temp = Mathf.Abs(pages[i] - posX);
            if (temp < offset)
            {
                index = i;
                //保存当前的偏移量
                offset = temp;
            }
        }

        if (index != currentPageIndex)
        {
            currentPageIndex = index;
            OnPageChanged(pages.Count, currentPageIndex);
        }
      
        targethorizontal = pages[index];

    }

    void UpdataPages()
    {
        //获取子对象的数量
        int count = this.rect.content.childCount;
        int temp = 0;
        for (int i = 0; i < count; i++)
        {
            if (this.rect.content.GetChild(i).gameObject.activeSelf)
            {
                temp++;
            }
        }
        count = temp;

        if (pages.Count != count)
        {
            if (count != 0)
            {
                pages.Clear();
                for (int i = 0; i < count; i++)
                {
                    float page = 0;
                    if (count != 1)
                        page = i / ((float)(count - 1));
                    pages.Add(page);
                }
            }
            OnEndDrag(null);
        }

    }
  

}
