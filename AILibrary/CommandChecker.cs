using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AILibrary
{
    /// <summary>
    /// 명령어 실행을 검사하는 클래스입니다.
    /// </summary>
    public class CommandChecker
    {
        private CommandXmlReader xmlReader;

        /// <summary>
        /// 주어진 정보를 이용하여 CommandChecker 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="xmlReader">명령어 정보를 읽어들이기 위한 변수입니다.</param>
        public CommandChecker(CommandXmlReader xmlReader)
        {
            this.xmlReader = xmlReader;
        }

        /// <summary>
        /// 현재 명령어의 매개 변수 개수가 올바른지 검사합니다. false는 너무 많은 매개변수, null은 너무 적은 매개변수를 가리킵니다. true는 정상 입력입니다.
        /// </summary>
        /// <param name="command">현재 명령어를 가리킵니다.</param>
        /// <param name="userInput">들어온 문자열 Input을 가리킵니다.</param>
        /// <returns>성공 여부입니다.</returns>
        public bool? CheckArgumentNumber(CommandList command, string userInput)
        {
            string[] splitInput = userInput.Split(' ');

            if (splitInput.Length > this.xmlReader.MaxArgumentNumber(command))
            {
                return false;
            }
            else if (splitInput.Length < this.xmlReader.MinArgumentNumber(command))
            {
                return null;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 현재 폴더에서 찾고자 하는 파일이 있는지 찾아냅니다. 아이템이 얻어지지 않았을 경우에도 탐색 실패로 처리됩니다.
        /// </summary>
        /// <param name="currentFolder">대상 폴더입니다.</param>
        /// <param name="fileName">찾고자 하는 아이템의 이름을 가리킵니다.</param>
        /// <returns>찾아낸 결과입니다. 실패할 경우 null을 return합니다.</returns>
        public Item CheckFileFound(Folder currentFolder, string fileName)
        {
            try
            {
                Item foundItem = Item.FindItem(currentFolder.Items, fileName);

                if (foundItem != null && foundItem.IsGet)
                {
                    return foundItem;
                }
                else
                {
                    return null;
                }
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        /// <summary>
        /// 현재 폴더에서 상위/하위 폴더가 존재하는지 찾아냅니다. 만약 접근 가능하지 않을 경우에도 실패로 처리됩니다.
        /// </summary>
        /// <param name="currentFolder">대상 폴더입니다.</param>
        /// <param name="folderName">찾고자 하는 폴더의 이름입니다.</param>
        /// <param name="isFindingUpper">상위 폴더를 찾아낼 것인지 결정합니다.</param>
        /// <returns>찾아낸 결과입니다. 실패할 경우 null을 return합니다.</returns>
        public FolderShortcut CheckFolderFound(Folder currentFolder, string folderName, bool isFindingUpper = false)
        {
            try
            {
                FolderShortcut foundFolderShortcut = Array.Find<FolderShortcut>(currentFolder.LowerFolderInfo, folderInfo => folderInfo.FolderName == folderName);

                if (isFindingUpper)
                {
                    return currentFolder.UpperFolderInfo;
                }
                else
                {
                    if (!foundFolderShortcut.Equals(null))
                    {
                        return foundFolderShortcut;
                    }

                    return null;
                }
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
    }
}
