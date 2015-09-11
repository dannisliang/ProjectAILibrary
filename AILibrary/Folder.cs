using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AILibrary
{
    /// <summary>
    /// 폴더에 대한 정보를 담고 있는 클래스입니다.
    /// </summary>
    public class Folder : IUsableItem
    {
        private List<FolderShortcut> lowerFolderInfo;           // 해당 폴더의 하위 폴더들에 대한 정보를 가지고 있는 ArrayList입니다.
        private List<Item> containItem;                         // 해당 폴더에 속해있는 아이템들에 대한 정보를 가지고 있는 ArrayList입니다.
  
        /// <summary>
        /// 폴더 구현을 위해 필요한 정보를 가지고 Folder 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="folderID">해당 폴더의 ID입니다.</param>
        /// <param name="folderName">해당 폴더의 이름입니다.</param>
        /// <param name="folderSprite">해당 폴더의 이미지를 가리킵니다.</param>
        /// <param name="upperFolderInfo">해당 폴더의 상위 폴더 정보입니다.</param>
        /// <param name="isAccessible">해당 폴더의 접근 여부입니다. 기본 값은 False입니다.</param>
        /// <param name="lowerFolderInfo">해당 폴더의 하위 폴더들의 ID를 가리킵니다. 기본 값은 Null(존재하지 않음)입니다.</param>
        /// <param name="items">해당 폴더에 속해있는 아이템의 리스트입니다.</param>
        public Folder(int folderID, string folderName, Sprite folderSprite, FolderShortcut upperFolderInfo, bool isAccessible = false, FolderShortcut[] lowerFolderInfo = null, params Item[] items)
        {
            this.FolderID = folderID;
            this.Name = folderName;
            this.UpperFolderInfo = upperFolderInfo;
            this.IsAccessible = isAccessible;
            this.FolderSprite = folderSprite;
            this.lowerFolderInfo = new List<FolderShortcut>();
            this.containItem = new List<Item>();

            if (lowerFolderInfo != null)
            {
                this.lowerFolderInfo.AddRange(lowerFolderInfo);
            }

            if (items != null)
            {
                this.containItem.AddRange(items);
            }
        }

        /// <summary>
        /// 해당 폴더의 ID를 가져옵니다. 읽기 전용 프로퍼티입니다.
        /// </summary>
        public int FolderID
        {
            get;
            private set;
        }

        /// <summary>
        /// 해당 폴더의 상위 폴더를 가져옵니다. 읽기 전용 프로퍼티입니다.
        /// </summary>
        public FolderShortcut UpperFolderInfo
        {
            get;
            private set;
        }

        /// <summary>
        /// 해당 폴더의 이름을 가져옵니다. 읽기 전용 프로퍼티입니다.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 해당 폴더에 접근 가능한 지에 대한 여부를 가져오거나 설정합니다.
        /// </summary>
        public bool IsAccessible
        {
            get;
            set;
        }

        /// <summary>
        /// 해당 폴더에 속해있는 아이템의 리스트를 가져옵니다.
        /// </summary>
        public Item[] Items
        {
            get { return this.containItem.ToArray(); }
        }

        /// <summary>
        /// 해당 폴더의 하위 폴더들의 리스트를 가져옵니다.
        /// </summary>
        public FolderShortcut[] LowerFolderInfo
        {
            get { return this.lowerFolderInfo.ToArray(); }
        }

        /// <summary>
        /// 해당 폴더의 이미지 정보(Sprite)를 가져옵니다.
        /// </summary>
        public Sprite FolderSprite
        {
            get;
            private set;
        }

        /// <summary>
        /// 해당 폴더에 속하는 아이템을 추가합니다.
        /// </summary>
        /// <param name="item">추가하고자 하는 아이템입니다.</param>
        public void AddItem(Item item)
        {
            this.containItem.Add(item);
        }

        /// <summary>
        /// 해당 폴더에 속해있던 아이템을 이 폴더 리스트에서 지웁니다.
        /// </summary>
        /// <param name="item">지우고자 하는 아이템입니다.</param>
        public void DeleteItem(Item item)
        {
            this.containItem.Remove(item);
        }

        /// <summary>
        /// 해당 폴더의 하위 폴더를 추가합니다.
        /// </summary>
        /// <param name="folder">추가하고자 하는 폴더입니다.</param>
        public void AddLowerFolder(FolderShortcut folder)
        {
            this.lowerFolderInfo.Add(folder);
        }

        /// <summary>
        /// 인자로 전달된 폴더를 해당 폴더의 하위 폴더 리스트에서 지웁니다.
        /// </summary>
        /// <param name="folder">지우고자 하는 폴더입니다.</param>
        public void DeleteLowerFolder(FolderShortcut folder)
        {
            this.lowerFolderInfo.Remove(folder);
        }

        /// <summary>
        /// 현재 폴더의 정보를 이용하여 FolderShortcut 인스턴스를 만듭니다.
        /// </summary>
        /// <returns>FolderShortcut 인스턴스입니다.</returns>
        public FolderShortcut ToShortcut()
        {
            return new FolderShortcut(this.FolderID, this.Name, this.FolderSprite);
        }

        /// <summary>
        /// 해당 폴더에 들어있는 모든 정보들을 문자열에 담아 반환해줍니다.
        /// </summary>
        /// <returns>해당 폴더의 정보가 담겨있는 문자열입니다.</returns>
        public string PrintFolderInfo()
        {
            StringBuilder infoBuilder = new StringBuilder();
            
            if (this.UpperFolderInfo != null)                           // 상위 폴더에 대한 정보를 담습니다.
            {
                infoBuilder.Append("[상위 폴더]  ");
                infoBuilder.AppendLine(this.UpperFolderInfo.FolderName);
            }
            else
            {
                infoBuilder.AppendLine("--! 루트 폴더입니다. !--");
            }

            infoBuilder.AppendLine();
            infoBuilder.AppendLine("--! 하위 폴더 !--");


            if (this.LowerFolderInfo.Length == 0)
            {
                infoBuilder.AppendLine("[하위 폴더가 없습니다.]");
            }
            else
            {
                foreach (FolderShortcut lowerFolder in this.LowerFolderInfo)       // 하위 폴더에 대한 정보를 담습니다.
                {
                    infoBuilder.Append(lowerFolder.FolderName);
                    
                    if (IntegratedData.GetFolderData(lowerFolder.FolderID).IsAccessible)
                    {
                        infoBuilder.AppendLine("     [접근 가능]");
                    }
                    else
                    {
                        infoBuilder.AppendLine("     [접근 불가능]");
                    }
                }
            }

            int showItemCount = 0;
            infoBuilder.AppendLine("--! 아이템 !--");


            foreach (Item item in this.Items)                       // 아이템들에 대한 정보를 담습니다.
            {
                if (item.IsGet)
                {
                    infoBuilder.Append(item.Name);
                    showItemCount++;

                    if (item.IsImported)
                    {
                        infoBuilder.AppendLine("     [Import 됨]");
                    }
                    else
                    {
                        infoBuilder.AppendLine("     [Import 되지 않음]");
                    }
                }
            }

            if (showItemCount == 0)
            {
                infoBuilder.AppendLine("[아이템이 없습니다.]");
            }

            return infoBuilder.ToString();
        }

        /// <summary>
        /// 폴더 배열에서 찾고자 하는 아이템을 찾아줍니다. 찾지 못하면 null을 반환합니다.
        /// </summary>
        /// <param name="folders">여러 폴더가 들어있는 배열입니다.</param>
        /// <param name="nameToFind">찾고자 하는 폴더의 이름입니다.</param>
        /// <returns>찾은 폴더입니다.</returns>
        public static Folder FindFolder(Folder[] folders, string nameToFind)
        {
            return Array.Find<Folder>(folders, (folder => folder.Name == nameToFind));
        }
    }
}