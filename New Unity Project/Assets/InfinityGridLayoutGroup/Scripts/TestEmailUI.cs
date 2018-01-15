
//https://github.com/ThisisGame/InfinityGridLayoutGroup

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace ThisisGame
{

    public class TestEmailUI : MonoBehaviour
    {

        InfinityGridLayoutGroup infinityGridLayoutGroup;

        //可以加载总的个数
        public int amount = 20;

        // Use this for initialization
        void Start()
        {
            ////初始化数据列表;
            infinityGridLayoutGroup = transform.Find("Panel_Scroll/Panel_Grid").GetComponent<InfinityGridLayoutGroup>(); //Viewport / Content
            //设置可以加载总的个数
            infinityGridLayoutGroup.SetAmount(amount);
            
            infinityGridLayoutGroup.updateChildrenCallback = UpdateChildrenCallback;
        }

        void UpdateChildrenCallback(int index, Transform trans)
        {
            
            Debug.Log("UpdateChildrenCallback: index=" + index + " name:" + trans.name);

            Text text = trans.Find("Text").GetComponent<Text>();
            text.text = index.ToString();
        }
    }

}
