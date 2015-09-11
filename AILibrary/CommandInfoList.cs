using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 명령어 실행 시 일어날 수 있는 상황들을 나열하고 있는 열거형입니다.
    /// </summary>
    public enum CommandInfoList
    {
        /// <summary>
        /// 아무것도 아닌 상태입니다.
        /// </summary>
        Nothing,

        /// <summary>
        /// 파일/폴더/명령어 등을 찾지 못한 상태입니다.
        /// </summary>
        NotFound,

        /// <summary>
        /// 파일이나 폴더에 접근할 수 없는 상태입니다.
        /// </summary>
        NotAccessible,

        /// <summary>
        /// 폴더 이동 시 상위 폴더를 찾지 못한 상태입니다.
        /// </summary>
        RootNoUpper,

        /// <summary>
        /// 명령어에 너무 많은 매개변수를 입력한 상태입니다.
        /// </summary>
        TooManyArgs,

        /// <summary>
        /// 명령어에 너무 적은 매개변수를 입력한 상태입니다.
        /// </summary>
        TooLessArgs,

        /// <summary>
        /// 명령어를 실행한 상태입니다.
        /// </summary>
        Execute,

        /// <summary>
        /// 명령어에 잘못된 매개변수를 입력한 상태입니다.
        /// </summary>
        Invalid,

        /// <summary>
        /// 이미 실행된 명령어를 다시 실행한 상태입니다.
        /// </summary>
        AlreadyExecute
    }
}
