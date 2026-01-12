using Framework.Core;

namespace Framework.Module.Audio
{
    /// <summary>
    /// 音频管理接口
    /// </summary>
    public interface IAudioManager : IModule
    {
        /// <summary>
        /// 播放背景音乐
        /// </summary>
        /// <param name="clipName">音频片段名称</param>
        /// <param name="loop">是否循环</param>
        void PlayMusic(string clipName, bool loop = true);

        /// <summary>
        /// 停止背景音乐
        /// </summary>
        void StopMusic();

        /// <summary>
        /// 暂停背景音乐
        /// </summary>
        void PauseMusic();

        /// <summary>
        /// 恢复背景音乐
        /// </summary>
        void ResumeMusic();

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="clipName">音频片段名称</param>
        /// <param name="volume">音量（0-1）</param>
        void PlaySound(string clipName, float volume = 1.0f);

        /// <summary>
        /// 设置背景音乐音量
        /// </summary>
        /// <param name="volume">音量（0-1）</param>
        void SetMusicVolume(float volume);

        /// <summary>
        /// 设置音效音量
        /// </summary>
        /// <param name="volume">音量（0-1）</param>
        void SetSoundVolume(float volume);
    }
}
