using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 각종 스크립트와 그에 대한 코드 넘버를 열거하는 열거자입니다.
    /// </summary>
    public enum ScriptTypeCode
    {
        /// <summary>
        /// ButtonScript 입니다.
        /// </summary>
        ButtonScript = 0,

        /// <summary>
        /// MessageScript 입니다.
        /// </summary>
        MessageScript = 1,

        /// <summary>
        /// InputScript 입니다.
        /// </summary>
        InputScript = 2,

        /// <summary>
        /// SleepScript 입니다.
        /// </summary>
        SleepScript = 3,

        /// <summary>
        /// JumpScript 입니다.
        /// </summary>
        JumpScript = 4,

        /// <summary>
        /// SoundScript 입니다.
        /// </summary>
        SoundScript = 5,

        /// <summary>
        /// VibrationScript 입니다.
        /// </summary>
        VibrationScript = 6,

        /// <summary>
        /// MoveScript 입니다.
        /// </summary>
        MoveScript = 7,

        /// <summary>
        /// BackgroundScript 입니다.
        /// </summary>
        BackgroundScript = 8
    }
}
