using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 콘솔 모드에서 사용 가능한 명령어들을 나열하고 있는 열거형입니다.
    /// </summary>
    public enum CommandList
    {
        /// <summary>
        /// 지원하지 않는 명령어입니다.
        /// </summary>
        none,

        /// <summary>
        /// 초기 도입 메시지 명령어입니다.
        /// </summary>
        introduction,

        /// <summary>
        /// 아무 명령어도 입력하지 않은 상태입니다.
        /// </summary>
        empty,

        /// <summary>
        /// Run 명령어입니다.
        /// </summary>
        run,

        /// <summary>
        /// 도움말 명령어입니다.
        /// </summary>
        help,

        /// <summary>
        /// Clear 명령어입니다.
        /// </summary>
        clear,

        /// <summary>
        /// 폴더 위치를 변경하는 명령어입니다.
        /// </summary>
        movedir,

        /// <summary>
        /// 폴더의 내용을 보여주는 명령어입니다.
        /// </summary>
        showdir,

        /// <summary>
        /// 획득한 아이템을 Import 시키는 명령어입니다.
        /// </summary>
        import,

        /// <summary>
        /// Import 시킨 아이템을 열어보는 명령어입니다.
        /// </summary>
        open,

        /// <summary>
        /// 콘솔 모드를 나가는 명령어입니다.
        /// </summary>
        exit,

        /// <summary>
        /// 관리자 모드를 실행시키는 명령어입니다.
        /// </summary>
        admin,

        /// <summary>
        /// 프로그램 복구를 시도하는 명령어입니다.
        /// </summary>
        repair,

        /// <summary>
        /// 파일의 정보를 보는 명령어입니다.
        /// </summary>
        info,

        /// <summary>
        /// 
        /// </summary>
        changestyle,

        /// <summary>
        /// GUI에 대한 설정을 하는 명령어입니다.
        /// </summary>
        setgui
    }
}
