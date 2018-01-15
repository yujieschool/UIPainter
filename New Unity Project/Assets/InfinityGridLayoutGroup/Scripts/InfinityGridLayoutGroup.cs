
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//  [RequireComponent (typeof(XXXX))]
//  其中XX为依赖的脚本，或者Unity组件
//  这样，当你挂这个脚本时，XX脚本也被挂上去了

[RequireComponent(typeof(GridLayoutGroup))]
[RequireComponent(typeof(ContentSizeFitter))]

public class InfinityGridLayoutGroup : MonoBehaviour 
{

    [SerializeField]
    int minAmount = 0;//实现无限滚动，需要的最少的child数量。屏幕上能看到的+一行看不到的，比如我在屏幕上能看到 2 行，每一行 2 个。则这个值为 2行*2个 + 1 行* 2个 = 6个。

    RectTransform rectTransform;

    GridLayoutGroup gridLayoutGroup;
    ContentSizeFitter contentSizeFitter;

    ScrollRect scrollRect;

    List<RectTransform> childrenRect=new List<RectTransform>();

    Vector2 startPosition;

    int amount = 0;

    public delegate void UpdateChildrenCallbackDelegate(int index, Transform trans);
    public UpdateChildrenCallbackDelegate updateChildrenCallback = null;

    int realIndex = -1;


    IEnumerator InitChildren()
    {
        yield return 0;
        


      
            //获取Panel_Grid的宽度和位置;
            rectTransform = GetComponent<RectTransform>();

            gridLayoutGroup = GetComponent<GridLayoutGroup>();
            gridLayoutGroup.enabled = false;
            contentSizeFitter = GetComponent<ContentSizeFitter>();
            contentSizeFitter.enabled = false;
           
            //注册ScrollRect滚动回调;
            scrollRect = transform.parent.GetComponent<ScrollRect>();
            scrollRect.onValueChanged.AddListener((data) => { ScrollCallback(data); });

            //获取所有child anchoredPosition 以及 SiblingIndex;
            for (int index = 0; index < transform.childCount; index++)
            {
                Transform child=transform.GetChild(index);
                RectTransform childRectTrans= child.GetComponent<RectTransform>();

            }
       
            realIndex = -1;

            //children重新设置anchoredPosition;
            for (int index = 0; index < transform.childCount; index++)
            {
                Transform child = transform.GetChild(index);
                
                RectTransform childRectTrans = child.GetComponent<RectTransform>();
               
            }
        

        //获取所有child;
        for (int index = 0; index < transform.childCount; index++)
        {
            Transform trans = transform.GetChild(index);
            

            childrenRect.Add(transform.GetChild(index).GetComponent<RectTransform>());

            //初始化前面几个
            UpdateChildrenCallback(childrenRect.Count - 1, transform.GetChild(index));
        }
        //Panel_Grid起始位置
        startPosition = rectTransform.anchoredPosition;

        realIndex = childrenRect.Count - 1;
 
    }

    void ScrollCallback(Vector2 data)
    {
        UpdateChildren();
    }

    void UpdateChildren()
    {
        if (transform.childCount < minAmount)
        {
            return;
        }

        Vector2 currentPos = rectTransform.anchoredPosition;
        
        
        float offsetY = currentPos.y - startPosition.y;
        //判断Panel_Grid是往上拉还是往下拉
        if (offsetY > 0)
        {
            //向上拉，向下扩展;
            {
                if (realIndex >= amount - 1)
                {
                    startPosition = currentPos;
                    return;
                }

                float scrollRectUp = scrollRect.transform.TransformPoint(Vector3.zero).y;

                Vector3 childBottomLeft = new Vector3(childrenRect[0].anchoredPosition.x, childrenRect[0].anchoredPosition.y 
                    - gridLayoutGroup.cellSize.y, 0f);
                float childBottom = transform.TransformPoint(childBottomLeft).y;

                if (childBottom >= scrollRectUp)
                {                  

                    //移动到底部;
                    for (int index = 0; index < gridLayoutGroup.constraintCount; index++)
                    {
                        childrenRect[index].SetAsLastSibling();

                        childrenRect[index].anchoredPosition = new Vector2(childrenRect[index].anchoredPosition.x, 
                            childrenRect[childrenRect.Count - 1].anchoredPosition.y - gridLayoutGroup.cellSize.y - 
                                gridLayoutGroup.spacing.y);

                        realIndex++;

                        if (realIndex > amount - 1)
                        {
                            childrenRect[index].gameObject.SetActive(false);
                        }
                        else
                        {
                            UpdateChildrenCallback(realIndex, childrenRect[index]);
                        }
                    }

                    //GridLayoutGroup 底部加长;
                    rectTransform.sizeDelta += new Vector2(0, gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y);

                    //更新child;
                    for (int index = 0; index < childrenRect.Count; index++)
                    {
                        childrenRect[index] = transform.GetChild(index).GetComponent<RectTransform>();
                    }
                }
            }
        }
        else
        {
            //Debug.Log("Drag Down");
            //向下拉，下面收缩;
            if (realIndex + 1 <= childrenRect.Count)
            {
                startPosition = currentPos;
                return;
            }
            RectTransform scrollRectTransform = scrollRect.GetComponent<RectTransform>();
            Vector3 scrollRectAnchorBottom = new Vector3(0, -scrollRectTransform.rect.height - gridLayoutGroup.spacing.y, 0f);
            float scrollRectBottom = scrollRect.transform.TransformPoint(scrollRectAnchorBottom).y;

            Vector3 childUpLeft = new Vector3(childrenRect[childrenRect.Count - 1].anchoredPosition.x, childrenRect
                [childrenRect.Count - 1].anchoredPosition.y, 0f);

            float childUp = transform.TransformPoint(childUpLeft).y;

            if (childUp < scrollRectBottom)
            {
                //Debug.Log("childUp < scrollRectBottom");

                //把底部的一行 移动到顶部
                for (int index = 0; index < gridLayoutGroup.constraintCount; index++)
                {
                    childrenRect[childrenRect.Count - 1 - index].SetAsFirstSibling();

                    childrenRect[childrenRect.Count - 1 - index].anchoredPosition = new Vector2(childrenRect[childrenRect.Count 
                        - 1 - index].anchoredPosition.x, childrenRect[0].anchoredPosition.y + gridLayoutGroup.cellSize.y + 
                            gridLayoutGroup.spacing.y);

                    childrenRect[childrenRect.Count - 1 - index].gameObject.SetActive(true);

                    UpdateChildrenCallback(realIndex - childrenRect.Count - index, childrenRect[childrenRect.Count - 1 - index]);
                }

                realIndex -= gridLayoutGroup.constraintCount;

                //GridLayoutGroup 底部缩短;
                rectTransform.sizeDelta -= new Vector2(0, gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y);

                //更新child;
                for (int index = 0; index < childrenRect.Count; index++)
                {
                    childrenRect[index] = transform.GetChild(index).GetComponent<RectTransform>();
                }
            }
        }
  
        startPosition = currentPos;
    }
    /// <summary>
    /// 更新text里数字
    /// </summary>
    void UpdateChildrenCallback(int index,Transform trans)
    {
        if (updateChildrenCallback != null)
        {
            updateChildrenCallback(index, trans);
        }
    }


    /// <summary>
    /// 设置总的个数;
    /// </summary>
    /// <param name="count"></param>
    public void SetAmount(int count)
    {
        ///设置总的个数
        amount = count;

        StartCoroutine(InitChildren());
    }
}
