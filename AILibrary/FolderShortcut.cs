using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AILibrary
{
    /// <summary>
    /// 폴더와 관련된 간단한 정보만을 기록하는 클래스입니다.
    /// </summary>
    public class FolderShortcut : IUsableItem
    {
        /// <summary>
        /// 폴더의 이름을 가져옵니다. 읽기 전용입니다.
        /// </summary>
        public readonly string FolderName;

        /// <summary>
        /// 폴더의 ID를 가져옵니다. 읽기 전용입니다.
        /// </summary>
        public readonly int FolderID;

        /// <summary>
        /// 폴더의 이미지(Sprite)를 가져옵니다. 읽기 전용입니다.
        /// </summary>
        public readonly Sprite FolderSprite;

        /// <summary>
        /// 폴더의 간단한 정보를 통해 FolderShortcut 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="folderID">폴더의 ID를 가리킵니다.</param>
        /// <param name="folderName">폴더의 이름을 가리킵니다.</param>
        /// <param name="folderSprite">폴더의 이미지(Sprite)를 나타냅니다.</param>
        public FolderShortcut(int folderID, string folderName, Sprite folderSprite)
        {
            this.FolderName = folderName;
            this.FolderID = folderID;
            this.FolderSprite = folderSprite;
        }

        ///// <summary>
        ///// 현재 가지고 있는 폴더 정보로 실체화 된 폴더를 만들어냅니다. 이 클래스가 가지고 있는 ID에 해당하는 Xml 파일이 Resources/Folders에 존재해야 합니다.
        ///// </summary>
        ///// <returns>실체화 된 폴더입니다.</returns>
        //public Folder MakeFolder()
        //{
        //    XmlFolderReader xmlReader = new XmlFolderReader(Resources.Load<TextAsset>("Folders/" + this.FolderID).text, false);
        //    return xmlReader.GetFolder();
        //}
    }
}