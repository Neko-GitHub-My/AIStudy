namespace Framework.Module.Event
{
    /// <summary>
    /// 事件类型常量
    /// </summary>
    public static class EventType
    {
        // 游戏生命周期事件
        public const string GAME_START = "GameStart";
        public const string GAME_PAUSE = "GamePause";
        public const string GAME_RESUME = "GameResume";
        public const string GAME_END = "GameEnd";

        // 场景事件
        public const string SCENE_LOAD_START = "SceneLoadStart";
        public const string SCENE_LOAD_COMPLETE = "SceneLoadComplete";
        public const string SCENE_UNLOAD_START = "SceneUnloadStart";
        public const string SCENE_UNLOAD_COMPLETE = "SceneUnloadComplete";

        // UI 事件
        public const string UI_PANEL_OPEN = "UIPanelOpen";
        public const string UI_PANEL_CLOSE = "UIPanelClose";

        // 资源事件
        public const string ASSET_LOAD_START = "AssetLoadStart";
        public const string ASSET_LOAD_COMPLETE = "AssetLoadComplete";
        public const string ASSET_LOAD_FAILED = "AssetLoadFailed";
    }
}
