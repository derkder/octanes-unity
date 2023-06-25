### 预研过程：  
#### 需求概述：  
        将语音转换为瑶台的人物脸部表情动作  
#### 说明：
        瑶台的人物脸部表情动作的控制方式是脸部skinned mesh rendererd的51个参数
#### 各插件预研
        ![Audio2face插件预研](/动画系统/imgs/audio2face预研.png)



---



### 实际开发：
#### 插件网址：  
         https://github.com/hecomi/uLipSync#vrm-support
#### 对应的插件组件说明：           
       ![Audio2face组件说明](/动画系统/imgs/audio2face组件说明.png)
#### 具体使用方法：
将上面说的两个组件挂在人物身上，选中人物脸部的skin mesh  renderer。生成新的profile文件，对其进行校准得到映射关系，校准使用麦克风——组件uLipSyncMicrophone， 校准使用音谱——组件uLuLipSyncMicrophone   
上面设置了wav格式文件中的内容片段和音素对应的关系，在我们使用的插件中，每个音素对应一个blendshape参数的修改，这在瑶台人物脸部使用了51维的脸部表现显然是不合理的，因此进行重映射，映射的方式为更改脚本的核心更改如下：


       ```
        using UnityEngine;
        using System.Collections.Generic;        
        namespace uLipSync
        {
                public class BSInfoG
                {
                    public int idx;
                    public float weight;
                    public BSInfoG(int _idx, float _weight)
                    {
                        this.idx = _idx;//人物脸部bs的idx
                        this.weight = _weight;
                    }
                }
                Dictionary<int, List<BSInfoG>> phone2bs = new Dictionary<int, List<BSInfoG>>();//每个元音对应一组bs变量    
                void Start()
                {
                    //a
                    List<BSInfoG> temp0 = new List<BSInfoG>();
                    temp0.Add(new BSInfoG(19, 50));//jawOpen
                    temp0.Add(new BSInfoG(16, 80));//BrowseUpcenter
                    phone2bs.Add(0, temp0);
                    //e
                    List<BSInfoG> temp1 = new List<BSInfoG>();
                    temp1.Add(new BSInfoG(19, 0));//jawOpen
                    temp1.Add(new BSInfoG(24, 50));//BrowseUpcenter
                    temp1.Add(new BSInfoG(25, 50));//BrowseUpcenter
                    temp1.Add(new BSInfoG(26, 50));//BrowseUpcenter
                    temp1.Add(new BSInfoG(27, 50));//BrowseUpcenter
                    phone2bs.Add(1, temp1);
                    //i
                    List<BSInfoG> temp2 = new List<BSInfoG>();
                    temp2.Add(new BSInfoG(19, 80));//jawOpen
                    temp2.Add(new BSInfoG(2, 80));//EyeSquintL
                    temp2.Add(new BSInfoG(3, 80));//EyeSquintR
                    phone2bs.Add(2, temp2);
                    //o
                    List<BSInfoG> temp3 = new List<BSInfoG>();
                    temp3.Add(new BSInfoG(19, 20));//jawOpen
                    temp3.Add(new BSInfoG(14, 100));//BrowseDownL
                    temp3.Add(new BSInfoG(15, 100));//BrowseDownR
                    phone2bs.Add(3, temp3);
                    //u
                    List<BSInfoG> temp4 = new List<BSInfoG>();
                    temp4.Add(new BSInfoG(19, 10));//jawOpen
                    temp4.Add(new BSInfoG(24, 30));//BrowseUpcenter
                    temp4.Add(new BSInfoG(25, 30));//BrowseUpcenter
                    temp4.Add(new BSInfoG(26, 30));//BrowseUpcenter
                    temp4.Add(new BSInfoG(27, 30));//BrowseUpcenter
                    phone2bs.Add(4, temp4);
                    //n
                    List<BSInfoG> temp5 = new List<BSInfoG>();
                    temp5.Add(new BSInfoG(19, 0));//jawOpen
                    temp5.Add(new BSInfoG(24, 30));//BrowseUpcenter
                    temp5.Add(new BSInfoG(25, 30));//BrowseUpcenter
                    temp5.Add(new BSInfoG(26, 30));//BrowseUpcenter
                    temp5.Add(new BSInfoG(27, 30));//BrowseUpcenter
                    phone2bs.Add(5, temp5);
                    //s
                    List<BSInfoG> temp6 = new List<BSInfoG>();
                    temp6.Add(new BSInfoG(19, 0));//jawOpen
                    temp6.Add(new BSInfoG(24, 50));//BrowseUpcenter
                    temp6.Add(new BSInfoG(25, 50));//BrowseUpcenter
                    temp6.Add(new BSInfoG(26, 50));//BrowseUpcenter
                    temp6.Add(new BSInfoG(27, 50));//BrowseUpcenter
                    phone2bs.Add(6, temp6);
                    //-
                    List<BSInfoG> temp7 = new List<BSInfoG>();
                    for(int i = 0; i < 51; ++i)
                    {
                        temp7.Add(new BSInfoG(i, 0));
                    }
                    phone2bs.Add(7, temp7);
                }
                void LateUpdate()
                {
                    OnApplyBlendShapes();
                }
                protected virtual void OnApplyBlendShapes()
                {
                    if (!skinnedMeshRenderer) return;
                    //Debug.Log(""+null = skinnedMeshRenderer);
                    foreach (var bs in blendShapes)
                    {
                        if (bs.index < 0) continue;
                        Debug.Log("bs.index" + bs.index);
                        List<BSInfoG> temp = phone2bs[bs.index];
                        for(int j = 0; j < temp.Count; ++j)
                        {
                            skinnedMeshRenderer.SetBlendShapeWeight(temp[j].idx, 0f);
                        }
                    }
        
                    foreach (var bs in blendShapes)
                    {
                        if (bs.index < 0) continue;
                        List<BSInfoG> temp = phone2bs[bs.index];
                        for (int j = 0; j < temp.Count; ++j)
                        {
                            float weight = skinnedMeshRenderer.GetBlendShapeWeight(temp[j].idx);
                            weight += bs.weight * bs.maxWeight * volume * temp[j].weight;//
                            weight = Mathf.Min(weight, 80);
                            skinnedMeshRenderer.SetBlendShapeWeight(temp[j].idx, weight);
                        }
                    }
                }
        ```


### 实际效果：
  为了防止被逮捕，放在我手机里了，其中因为对于每个音素(这里设置了8组)调一组51维的bs参数十分繁琐，以及在办公室里aaaaaiiiiiiiooooooo的通过麦克风校准很尴尬，所以效果欠佳。其实这个插件本身可以达到非常好的效果
       
