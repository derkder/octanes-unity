## 大致思想
先烘培贴图，记录顶点位置与颜色

## 附加 ： 解决不同animclip里render order会改变的问题
记录当前anim clip中的triangleIndex（所有vertives的）

## spine知识小课堂
### slot插槽
里面会插入mesh attachment或者是region attachment(图片)。这个插槽是决定渲染顺序的（也就是里面插入的这些attachmenti现在都会跟着这个插槽的渲染顺序了）



