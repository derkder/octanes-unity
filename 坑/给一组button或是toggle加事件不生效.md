[https://blog.csdn.net/weixin_43818160/article/details/99739265]   
```
    void AddClickEvents()
    {
        int x = 0;
        foreach (Button item in buttons)
        {
            int y = x;
            item.onClick.AddListener(()=>ClickEvent2(y));
            x++;
        }
    }
```

若使用第二种方法，在添加事件时要注意，不论是使用foreach遍历还是使用for循环来添加，不可以直接将x或者for循环的i作为点击事件的参数来传入。  
因为button.onClick.AddListener(()=>ClickEvent2(y))的原理是使用委托来实现的，这里传入的方法的参数是一个引用，如果这个引用的值发生了变化，那么在你点击时用到的将是变化后的值，
所以我们需要每次循环都重新声明一个局部的int变量来储存每次的循环的int值来作为一个参数传入。  
错误示例：   
```
List<Button> _listBtns = new List<Button>();
for (int i = 0; i < _listBtns.Count; ++i )
{
    _listBtns[i].onClick.AddListener(()=>ClickEvent2(i));
}
```
