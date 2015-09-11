using System.Collections;
using System.Text;
using System;

namespace AILibrary
{
    /// <summary>
    /// 문자열이 콘솔 모드에서 어떤 명령을 가리키는지 해석하는 정적 클래스입니다.
    /// </summary>
    public static class CommandDecoder
    {
        /// <summary>
        /// 문자열이 콘솔 모드에서 어떤 명령을 가리키는지 해석하는 메서드입니다.
        /// </summary>
        /// <param name="line">해석하고자 하는 문자열입니다.</param>
        /// <returns>해석된 명령어입니다.</returns>
        public static CommandList InterpretCommand(string line)
        {
            string[] splitedLine = line.ToLower().Split(' ');              // 대, 소문자를 구분하지 않습니다.

            try
            {
                return (CommandList)Enum.Parse(typeof(CommandList), splitedLine[0]);
            }
            catch (ArgumentException)
            {
                if (splitedLine[0] == string.Empty)
                {
                    return CommandList.empty;
                }

                return CommandList.none;
            }
        }
    }
}