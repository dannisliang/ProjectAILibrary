using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
        /// <summary>
        /// 콘솔 모드에서 사용되는 메시지들을 담고 있는 정적 클래스입니다.
        /// </summary>
        public static class CommandMessage
        {
            /// <summary>
            /// 초기 안내 메시지를 가져옵니다.
            /// </summary>
            public static readonly string IntroductionMsg
                = "Starting Program......\n.........................................\nSystem Status : <color=green><b>ALL GREEN</b></color>\nChecking File......\n.................\n/*From Now, Not finished Text (Developing)..*/)\nSome distorted date is found.\nWrong pointing is found.\n.................................................................\nSome distortion has been found.\nThis program is <i>unstable</i>.\n<b>PLEASE RUN</b> repairing program.\nProgram Version : AI_ver.0.0.1\nHelp : Display the guide of console commands...";
            /// <summary>
            /// 존재하지 않는 명령어를 입력했을 때 출력할 메시지를 가져옵니다.
            /// </summary>
            public static readonly string NotExistMsg
                = "존재하지 않는 명령어입니다. (개발용 메시지)";
            /// <summary>
            /// Clear 명령어에 너무 많은 매개변수를 입력했을 때 메시지를 가져옵니다.
            /// </summary>
            public static readonly string ClearTooManyArgsMsg
                = "Clear 명령을 실행하기 위한 매개변수가 너무 많습니다.";
            /// <summary>
            /// Run 명령어를 입력했을 때 기본적으로 출력할 메시지를 가져옵니다.
            /// </summary>
            public static readonly string RunMsg
                = "Run 명령어 실행됨 - (개발용 메시지)";
            /// <summary>
            /// Run 명령어에 너무 많은 매개변수를 입력했을 때 메시지를 가져옵니다.
            /// </summary>
            public static readonly string RunTooManyArgsMsg
                = "Run 명령을 실행하기 위한 매개변수가 너무 많습니다.";
            /// <summary>
            /// Import 명령어에 너무 적은 매개변수를 넣었을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string ImportTooLessArgsMsg
                = "Import 명령을 실행하기 위한 매개변수가 너무 적습니다.";
            /// <summary>
            /// Import 명령어에 너무 많은 매개변수를 넣었을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string ImportTooManyArgsMsg
                = "Import 명령을 실행하기 위한 매개변수가 너무 많습니다.";
            /// <summary>
            /// Import 실행 시 파일을 찾을 수 없었을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string ImportNotFoundMsg
                = "Import 하려는 파일을 찾을 수 없습니다. - (개발용 메시지)";
            /// <summary>
            /// Import 실행 시 파일이 이미 Import 되었을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string ImportAlreadyMsg
                = "이미 Import 되어있는 파일입니다. - (개발용 메시지)";
            /// <summary>
            /// Open 명령어 수행 도중 파일을 찾을 수 없을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string OpenNotFoundMsg
                = "열고자 하는 파일을 찾을 수 없습니다.";
            /// <summary>
            /// Open 명령어에 너무 많은 매개변수를 넣었을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string OpenTooManyArgsMsg
                = "Open 명령을 실행하기 위한 매개변수가 너무 많습니다.";
            /// <summary>
            /// Open 명령어에 너무 적은 매개변수를 넣었을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string OpenTooLessArgsMsg
                = "Open 명령을 실행하기 위한 매개변수가 너무 적습니다.";
            /// <summary>
            /// Import 되지 않은 파일을 열려고 할 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string OpenNotImportedMsg
                = "열기 위한 파일이 Import 되지 않아 열 수 없습니다.";
            /// <summary>
            /// 루트 디렉토리에서 상위 디렉토리로 이동하려 할 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string DirNoUpperForRootMsg
                = "루트 폴더는 상위 폴더를 가질 수 없습니다. (개발용 메시지)";
            /// <summary>
            /// 찾고자 하는 폴더를 찾지 못했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string DirNotFoundMsg
                = "디렉토리를 찾을 수 없습니다. (개발용 메시지)";
            /// <summary>
            /// 폴더에 접근이 불가능할 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string DirNotAccessibleMsg
                = "접근할 수 없는 디렉토리입니다. (개발용 메시지)";
            /// <summary>
            /// MoveDir 명령어에서 유저가 너무 많은 매개변수를 입력했을 때의 메시지를 가져옵니다.   
            /// </summary>
            public static readonly string DirTooManyArgsMsg
                = "MoveDir 명령어에 너무 많은 매개변수를 입력하셨습니다. (개발용 메시지)";
            /// <summary>
            /// MoveDir 명령어에서 유저가 너무 적은 매개변수를 입력했을 때의 메시지를 가져옵니다.   
            /// </summary>
            public static readonly string DirTooLessArgsMsg
                = "MoveDir 명령을 실행하기 위한 매개변수가 너무 적습니다.";
            /// <summary>
            /// ShowDir 명령어에 너무 많은 매개변수를 입력했을 때 메시지를 가져옵니다.
            /// </summary>
            public static readonly string DirShowTooManyArgs
                = "ShowDir 명령을 수행하기 위한 매개변수가 너무 많습니다.";
            /// <summary>
            /// 도움말 명령어를 입력했을 때 출력할 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpMsg
                = "도움말 메시지 - (개발용 메시지)";
            /// <summary>
            /// 도움말 명령어에 너무 많은 매개변수를 입력했을 때 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpTooManyArgsMsg
                = "Help 명령어에 너무 많은 매개변수가 들어가 있습니다.";
            /// <summary>
            /// 도움말을 불러오려는 명령어가 존재하지 않을 때 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpCommandNotFoundMsg
                = "없는 명령어에 대한 도움말을 요청했습니다.";
            /// <summary>
            /// Run 명령어에 대한 도움말을 요청했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpRunCommandMsg
                = "Run 명령어 도움말";
            /// <summary>
            /// Open 명령어에 대한 도움말을 요청했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpOpenCommandMsg
                = "Open 명령어 도움말";
            /// <summary>
            /// Import 명령어에 대한 도움말을 요청했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpImportCommandMsg
                = "Import 명령어 도움말";
            /// <summary>
            /// MoveDir 명령어에 대한 도움말을 요청했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpMoveDirCommandMsg
                = "MoveDir 명령어 도움말";
            /// <summary>
            /// Clear 명령어에 대한 도움말을 요청했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpClearCommandMsg
                = "Clear 명령어 도움말";
            /// <summary>
            /// ShowDir 명령어에 대한 도움말을 요청했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpShowDirCommandMsg
                = "ShowDir 명령어 도움말";
            /// <summary>
            /// Mix 명령어에 대한 도움말을 요청했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpMixCommandMsg
                = "Mix 명령어 도움말";
            /// <summary>
            /// Admin 명령어에 대한 도움말을 요청했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpAdminCommandMsg
                = "Admin 명령어 도움말";
            /// <summary>
            /// Repair 명령어에 대한 도움말을 요청했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpRepairCommandMsg
                = "Repair 명령어 도움말";
            /// <summary>
            /// Info 명령어에 대한 도움말을 요청했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpInfoCommandMsg
                = "Info 명령어 도움말";
            /// <summary>
            /// ChangeStyle 명령어에 대한 도움말을 요청했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpChangeStyleCommandMsg
                = "ChangeStyle 명령어 도움말";
            /// <summary>
            /// SetGUI 명령어에 대한 도움말을 요청했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpSetGUICommandMsg
                = "SetGUI 명령어 도움말";
            /// <summary>
            /// Exit 명령어에 대한 도움말을 요청했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string HelpExitCommandMsg
                = "Exit 명령어 도움말";
            /// <summary>
            /// Exit 명령어에 너무 많은 매개변수를 입력했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string ExitTooManyArgsMsg
                = "Exit 명령어에 너무 많은 매개변수가 들어가 있습니다.";
            /// <summary>
            /// Info 명령을 실행하기 위한 매개변수가 너무 적을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string InfoTooLessArgsMsg
                = "Info 명령을 실행하기 위한 매개변수가 너무 적습니다.";
            /// <summary>
            /// Info 명령을 실행하기 위한 매개변수가 너무 많을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string InfoTooManyArgsMsg
                = "Info 명령어에 너무 많은 매개변수가 들어가 있습니다.";
            /// <summary>
            /// Info 명령 실행 시 파일을 찾을 수 없을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string InfoNotFoundMsg
                = "열고자 하는 파일을 찾을 수 없습니다.";
            /// <summary>
            /// Repair 명령을 실행하기 위한 매개변수가 너무 많을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string RepairTooManyArgsMsg
                = "Repair 명령어에 너무 많은 매개변수가 들어가 있습니다.";
            /// <summary>
            /// Repair 명령을 성공적으로 수행했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string RepairSuccessMsg
                = "시도만 됩니다.";
            /// <summary>
            /// SetGUI 명령을 실행하기 위한 매개변수가 너무 적을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string SetGUITooLessArgsMsg
                = "SetGUI 명령어에 너무 적은 매개변수가 들어가 있습니다.";
            /// <summary>
            /// SetGUI 명령을 실행하기 위한 매개변수가 너무 많을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string SetGUITooManyArgsMsg
                = "SetGUI 명령어에 너무 많은 매개변수가 들어가 있습니다.";
            /// <summary>
            /// SetGUI 명령 실행 시에 올바르지 않은 매개변수를 입력했을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string SetGUIInvalidArgsMsg
                = "올바르지 않은 매개변수가 들어가 있습니다.";
            /// <summary>
            /// SetGUI 명령에서 GUI 설정을 켰을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string SetGUIOnMsg
                = "GUI가 On 되었습니다.";
            /// <summary>
            /// SetGUI 명령에서 이미 GUI 옵션이 켜져있었을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string SetGUIAlreadyOnMsg
                = "GUI가 이미 On 상태입니다.";
            /// <summary>
            /// SetGUI 명령에서 GUI 설정을 껐을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string SetGUIOffMsg
                = "GUI가 Off 되었습니다.";
            /// <summary>
            /// SetGUI 명령에서 이미 GUI 옵션이 꺼져있었을 때의 메시지를 가져옵니다.
            /// </summary>
            public static readonly string SetGUIAlreadyOffMsg
                = "GUI가 이미 Off 상태입니다.";

            private static string nextLineMsg
                = currentDir + "<color=yellow> $ </color>";
            private static readonly string importSuccessMsg
                = "파일을 성공적으로 Import 하였습니다. (개발용 메시지)";
            private static string currentDir
                = "<color=lime>/root</color>";
            
            /// <summary>
            /// Import를 성공적으로 완료했을 때의 메시지를 가져옵니다.
            /// </summary>
            /// <param name="itemName">아이템 이름입니다.</param>
            /// <returns>가져오는 메시지입니다.</returns>
            public static string ImportSuccessMsg(string itemName)
            {
                return itemName + importSuccessMsg;
            }

            /// <summary>
            /// 개행 후 출력할 메시지를 가져옵니다.
            /// </summary>
            public static string NextLineMsg
            {
                get { return CurrentDir + nextLineMsg; }
            }

            /// <summary>
            /// 현재 폴더 경로를 가져오거나 설정합니다.
            /// </summary>
            public static string CurrentDir
            {
                get { return currentDir; }
                set 
                {
                    currentDir = string.Format("<color=lime>{0}</color>", value);
                    nextLineMsg = currentDir + "<color=yellow> $ </color>";
                }
            }
        }
}