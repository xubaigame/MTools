
// ****************************************************
//     文件：LogConfig.cs
//     作者：积极向上小木木
//     邮箱: positivemumu@126.com
//     日期：2021/07/23 20:05
//     功能：配置信息及枚举类，负责对日志工具进行初始的配置。
// *****************************************************

using System;

namespace DetailLogTool {
    public enum LoggerType {
        Unity,
        Console,
    }
    public enum LogColor {
        None,
        Red,
        Green,
        Blue,
        Cyan,
        Magenta,
        Yellow
    }

    public class DetailLogConfig {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool enableLog = true;
        /// <summary>
        /// 日志前缀
        /// </summary>
        public string logPrefix = "#";
        /// <summary>
        /// 时间标记
        /// </summary>
        public bool enableTime = true;
        /// <summary>
        /// 间隔符号
        /// </summary>
        public string logSeparate = ">>";
        /// <summary>
        /// 线程ID
        /// </summary>
        public bool enableThreadID = true;
        /// <summary>
        /// 堆栈信息
        /// </summary>
        public bool enableTrace = true;
        /// <summary>
        /// 文件保存
        /// </summary>
        public bool enableSave = true;
        /// <summary>
        /// 日志覆盖
        /// </summary>
        public bool enableCover = true;
        private string _savePath;
        public string savePath {
            get {
                if(_savePath == null) {
                    if(loggerEnum == LoggerType.Unity) {
                        Type type = Type.GetType("UnityEngine.Application, UnityEngine");
                        _savePath = type.GetProperty("persistentDataPath").GetValue(null).ToString() + "/PELog/";
                    }
                    else {
                        _savePath = string.Format("{0}Logs\\", AppDomain.CurrentDomain.BaseDirectory);
                    }
                }
                return _savePath;
            }
            set {
                _savePath = value;
            }
        }
        /// <summary>
        /// 日志文件名称
        /// </summary>
        public string saveName = "ConsolePELog.txt";
        /// <summary>
        /// 日志输出器类型
        /// </summary>
        public LoggerType loggerEnum = LoggerType.Console;
        /// <summary>
        /// TODO
        /// </summary>
        public Action<int> GetFrameIndex;
    }

    interface ILogger {
        void Log(string msg, LogColor logColor = LogColor.None);
        void Warn(string msg);
        void Error(string msg);
    }
}