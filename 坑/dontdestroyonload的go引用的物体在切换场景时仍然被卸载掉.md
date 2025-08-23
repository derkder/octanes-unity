## 原因
你的 IndoorLightManager 用 DontDestroyOnLoad 保住了自己，但 MaincityLightmapData 是个资源（ScriptableObject 资产）而不是场景里的对象。如果它不是通过可引用系统（如 Addressables 的句柄）被持有，Unity 可能把它和它依赖的贴图当成“未被使用”而卸载。


## 解决
用路径通过addressable系统加载进去  
```
private AsyncOperationHandle<RoomLightmapData> _lightmapDataHandle;
private bool _isLightmapDataLoaded;
_lightmapDataHandle = Addressables.LoadAssetAsync<RoomLightmapData>(LIGHTMAP_DATA_ADDRESS);
_lightmapDataHandle.Completed += OnMaincityLightmapDataLoaded;
```
