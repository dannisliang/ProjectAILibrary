//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace AILibrary
//{
//    /// <summary>
//    /// 각종 명령어에 대해서 명령어 실행 가능 여부를 검사하는 메서드들을 제공하는 정적 클래스입니다.
//    /// </summary>
//    public static class CommandExecuter
//    {
//        /// <summary>
//        /// Run 명령어를 실행할 수 있는지 검사합니다.
//        /// </summary>
//        /// <param name="messageBuilder">명령어에 맞는 메시지를 담기 위한 StringBuilder입니다. 메서드가 수행되면 Builder에 처리된 메시지가 담겨집니다.</param>
//        /// <param name="userInput">유저가 입력한 명령입니다.</param>
//        /// <returns>명령어를 실행할 수 있는지에 대한 성공 여부입니다.</returns>
//        public static bool CheckRunExecute(StringBuilder messageBuilder, string userInput)
//        {
//            string[] splitInput = userInput.Split(' ');
//            messageBuilder.AppendLine();

//            switch (splitInput.Length)
//            {
//                case 1:
//                    {
//                        messageBuilder.Append(CommandMessage.RunMsg);
//                        return true;
//                    }
//                default:
//                    {
//                        messageBuilder.Append(CommandMessage.RunTooManyArgsMsg);
//                        return false;
//                    }
//            }
//        }

//        /// <summary>
//        /// Help 명령어를 실행할 수 있는지 검사합니다.
//        /// </summary>
//        /// <param name="messageBuilder">명령어에 맞는 메시지를 담기 위한 StringBuilder입니다. 메서드가 수행되면 Builder에 처리된 메시지가 담겨집니다.</param>
//        /// <param name="userInput">유저가 입력한 명령입니다.</param>
//        /// <returns>명령어를 실행할 수 있는지에 대한 성공 여부입니다.</returns>
//        public static bool CheckHelpExecute(StringBuilder messageBuilder, string userInput)
//        {
//            string[] splitInput = userInput.Split(' ');
//            messageBuilder.AppendLine();

//            switch (splitInput.Length)
//            {
//                case 1:
//                    {
//                        messageBuilder.Append(CommandMessage.HelpMsg);
//                        return true;
//                    }
//                case 2:
//                    {
//                        messageBuilder.Append((CommandDecoder.InterpretCommand(splitInput[1])));
//                        return true;
//                    }
//                default:
//                    {
//                        messageBuilder.Append(CommandMessage.HelpTooManyArgsMsg);
//                        return false;
//                    }
//            }
//        }

//        /// <summary>
//        /// Clear 명령어를 실행할 수 있는지 검사합니다.
//        /// </summary>
//        /// <param name="messageBuilder">명령어에 맞는 메시지를 담기 위한 StringBuilder입니다. 메서드가 수행되면 Builder에 처리된 메시지가 담겨집니다.</param>
//        /// <param name="userInput">유저가 입력한 명령입니다.</param>
//        /// <returns>명령어를 실행할 수 있는지에 대한 성공 여부입니다.</returns>
//        public static bool CheckClearExecute(StringBuilder messageBuilder, string userInput)
//        {
//            string[] splitInput = userInput.Split(' ');

//            switch (splitInput.Length)
//            {
//                case 1:
//                    {
//                        return true;
//                    }
//                default:
//                    {
//                        messageBuilder.Append(CommandMessage.ClearTooManyArgsMsg);
//                        return false;
//                    }
//            }
//        }

//        /// <summary>
//        /// Open 명령어를 실행할 수 있는지 검사합니다.
//        /// </summary>
//        /// <param name="messageBuilder">명령어에 맞는 메시지를 담기 위한 StringBuilder입니다. 메서드가 수행되면 Builder에 처리된 메시지가 담겨집니다.</param>
//        /// <param name="currentFolder">현재 유저가 들어가 있는 폴더를 가리킵니다.</param>
//        /// <param name="userInput">유저가 입력한 명령입니다.</param>
//        /// <returns>유저의 명령어에 의해 찾아낸 아이템입니다.</returns>
//        public static Item CheckOpenExecute(StringBuilder messageBuilder, Folder currentFolder, string userInput)
//        {
//            string[] splitInput = userInput.Split(' ');
//            messageBuilder.AppendLine();

//            switch (splitInput.Length)
//            {
//                case 1:
//                    {
//                        messageBuilder.Append(CommandMessage.OpenTooLessArgsMsg);
//                        return null;
//                    }
//                case 2:
//                    {
//                        Item foundItem = Item.FindItem(currentFolder.Items, splitInput[1]);

//                        if (foundItem != null && foundItem.IsGet)
//                        {
//                            if (foundItem.IsImported)
//                            {
//                                messageBuilder.Remove(messageBuilder.Length - 1, 1);        // 개행 문자 제거
//                                return foundItem;
//                            }
//                            else
//                            {
//                                messageBuilder.Append(CommandMessage.OpenNotImportedMsg);
//                                return null;
//                            }
//                        }
//                        else
//                        {
//                            messageBuilder.Append(CommandMessage.OpenNotFoundMsg);
//                            return null;
//                        }
//                    }
//                default:
//                    {
//                        messageBuilder.Append(CommandMessage.OpenTooManyArgsMsg);
//                        return null;
//                    }
//            }
//        }

//        /// <summary>
//        /// Import 명령어를 실행할 수 있는지 검사합니다.
//        /// </summary>
//        /// <param name="messageBuilder">명령어에 맞는 메시지를 담기 위한 StringBuilder입니다. 메서드가 수행되면 Builder에 처리된 메시지가 담겨집니다.</param>
//        /// <param name="currentFolder">현재 유저가 들어가 있는 폴더를 가리킵니다.</param>
//        /// <param name="userInput">유저가 입력한 명령입니다.</param>
//        /// <returns>유저의 명령어에 의해 찾아낸 아이템입니다.</returns>
//        public static Item CheckImportExecute(StringBuilder messageBuilder, Folder currentFolder, string userInput)
//        {
//            string[] splitInput = userInput.Split(' ');
//            messageBuilder.AppendLine();

//            switch (splitInput.Length)
//            {
//                case 1:
//                    {
//                        messageBuilder.Append(CommandMessage.ImportTooLessArgsMsg);
//                        return null;
//                    }
//                case 2:
//                    {
//                        Item foundItem = Item.FindItem(currentFolder.Items, splitInput[1]);

//                        if (foundItem != null && foundItem.IsGet)
//                        {
//                            if (foundItem.IsImported)
//                            {
//                                messageBuilder.Append(CommandMessage.ImportAlreadyMsg);
//                                return null;
//                            }
//                            else
//                            {
//                                messageBuilder.Append(CommandMessage.ImportSuccessMsg(foundItem.Name));
//                                return foundItem;
//                            }
//                        }
//                        else
//                        {
//                            messageBuilder.Append(CommandMessage.ImportNotFoundMsg);
//                            return null;
//                        }
//                    }
//                default:
//                    {
//                        messageBuilder.Append(CommandMessage.ImportTooManyArgsMsg);
//                        return null;
//                    }
//            }
//        }

//        /// <summary>
//        /// MoveDir 명령어를 실행할 수 있는지 검사합니다.
//        /// </summary>
//        /// <param name="messageBuilder">명령어에 맞는 메시지를 담기 위한 StringBuilder입니다. 메서드가 수행되면 Builder에 처리된 메시지가 담겨집니다.</param>
//        /// <param name="currentFolder">현재 유저가 들어가 있는 폴더를 가리킵니다.</param>
//        /// <param name="userInput">유저가 입력한 명령입니다.</param>
//        /// <returns>유저의 명령어에 의해 찾아낸 폴더입니다.</returns>
//        public static Folder CheckMoveDirExecute(StringBuilder messageBuilder, Folder currentFolder, string userInput)
//        {
//            string[] splitInput = userInput.Split(' ');
//            messageBuilder.AppendLine();

//            switch (splitInput.Length)
//            {
//                case 1:
//                    {
//                        messageBuilder.Append(CommandMessage.DirTooLessArgsMsg);
//                        return null;
//                    }
//                case 2:
//                    {
//                        Folder foundFolder = Folder.FindFolder(currentFolder.LowerFolders, splitInput[1]);

//                        if (splitInput[1] == "..")
//                        {
//                            if (currentFolder.UpperFolder != null)
//                            {
//                                messageBuilder.Remove(messageBuilder.Length - 1, 1);        // 개행 문자 제거
//                                CommandMessage.CurrentDir = CommandMessage.CurrentDir.Substring(12, CommandMessage.CurrentDir.Length - currentFolder.Name.Length - 21);
//                                return currentFolder.UpperFolder;
//                            }
//                            else
//                            {
//                                messageBuilder.Append(CommandMessage.DirNoUpperForRootMsg);
//                                return null;
//                            }
//                        }

//                        if (foundFolder != null)
//                        {
//                            if (!foundFolder.IsAccessible)
//                            {
//                                messageBuilder.Append(CommandMessage.DirNotAccessibleMsg);
//                                return null;
//                            }
//                            else
//                            {
//                                messageBuilder.Remove(messageBuilder.Length - 1, 1);        // 개행 문자 제거
//                                CommandMessage.CurrentDir = CommandMessage.CurrentDir.Substring(12, CommandMessage.CurrentDir.Length - 20) + string.Format("/{0}", foundFolder.Name);
//                                return foundFolder;
//                            }

//                        }
//                        else
//                        {
//                            messageBuilder.Append(CommandMessage.DirNotFoundMsg);
//                            return null;
//                        }
//                    }
//                default:
//                    {
//                        messageBuilder.Append(CommandMessage.DirTooManyArgsMsg);
//                        return null;
//                    }
//            }
//        }

//        /// <summary>
//        /// MoveDir 명령어를 실행할 수 있는지 검사합니다.
//        /// </summary>
//        /// <param name="messageBuilder">명령어에 맞는 메시지를 담기 위한 StringBuilder입니다. 메서드가 수행되면 Builder에 처리된 메시지가 담겨집니다.</param>
//        /// <param name="currentFolder">현재 유저가 들어가 있는 폴더를 가리킵니다.</param>
//        /// <param name="userInput">유저가 입력한 명령입니다.</param>
//        /// <returns>명령어를 실행할 수 있는지에 대한 성공 여부입니다.</returns>
//        public static bool CheckShowDirExecute(StringBuilder messageBuilder, Folder currentFolder, string userInput)
//        {
//            string[] splitInput = userInput.Split(' ');
//            messageBuilder.AppendLine();

//            switch (splitInput.Length)
//            {
//                case 1:
//                    {
//                        return true;
//                    }
//                default:
//                    {
//                        messageBuilder.Append(CommandMessage.DirShowTooManyArgs);
//                        return false;
//                    }
//            }
//        }

//        /// <summary>
//        /// Exit 명령어를 실행할 수 있는지 검사합니다.
//        /// </summary>
//        /// <param name="messageBuilder">명령어에 맞는 메시지를 담기 위한 StringBuilder입니다. 메서드가 수행되면 Builder에 처리된 메시지가 담겨집니다.</param>
//        /// <param name="userInput">유저가 입력한 명령입니다.</param>
//        /// <returns>명령어를 실행할 수 있는지에 대한 성공 여부입니다.</returns>
//        public static bool CheckExitExecute(StringBuilder messageBuilder, string userInput)
//        {
//            string[] splitInput = userInput.Split(' ');
//            messageBuilder.AppendLine();

//            switch (splitInput.Length)
//            {
//                case 1:
//                    {
//                        return true;
//                    }
//                default:
//                    {
//                        messageBuilder.Append(CommandMessage.ExitTooManyArgsMsg);
//                        return false;
//                    }
//            }
//        }

//        /// <summary>
//        /// Info 명령어를 실행할 수 있는지 검사합니다.
//        /// </summary>
//        /// <param name="messageBuilder">명령어에 맞는 메시지를 담기 위한 StringBuilder입니다. 메서드가 수행되면 Builder에 처리된 메시지가 담겨집니다.</param>
//        /// <param name="currentFolder">현재 유저가 들어가 있는 폴더를 가리킵니다.</param>
//        /// <param name="userInput">유저가 입력한 명령입니다.</param>
//        /// <returns>유저의 명령어에 의해 찾아낸 아이템입니다.</returns>
//        public static Item CheckInfoExecute(StringBuilder messageBuilder, Folder currentFolder, string userInput)
//        {
//            string[] splitInput = userInput.Split(' ');
//            messageBuilder.AppendLine();

//            switch (splitInput.Length)
//            {
//                case 1:
//                    {
//                        messageBuilder.Append(CommandMessage.InfoTooLessArgsMsg);
//                        return null;
//                    }
//                case 2:
//                    {
//                        Item foundItem = Item.FindItem(currentFolder.Items, splitInput[1]);

//                        if (foundItem != null && foundItem.IsGet)
//                        {
//                            return foundItem;
//                        }
//                        else
//                        {
//                            messageBuilder.Append(CommandMessage.InfoNotFoundMsg);
//                            return null;
//                        }
//                    }
//                default:
//                    {
//                        messageBuilder.Append(CommandMessage.InfoTooManyArgsMsg);
//                        return null;
//                    }
//            }
//        }

//        /// <summary>
//        /// Repair 명령어를 실행할 수 있는지 검사합니다.
//        /// </summary>
//        /// <param name="messageBuilder">명령어에 맞는 메시지를 담기 위한 StringBuilder입니다. 메서드가 수행되면 Builder에 처리된 메시지가 담겨집니다.</param>
//        /// <param name="userInput">유저가 입력한 명령입니다.</param>
//        /// <returns>명령어를 실행할 수 있는지에 대한 성공 여부입니다.</returns>
//        public static bool CheckRepairExecute(StringBuilder messageBuilder, string userInput)
//        {
//            string[] splitInput = userInput.Split(' ');
//            messageBuilder.AppendLine();

//            switch (splitInput.Length)
//            {
//                case 1:
//                    {
//                        messageBuilder.Append(CommandMessage.RepairSuccessMsg);
//                        return true;
//                    }
//                default:
//                    {
//                        messageBuilder.Append(CommandMessage.RepairTooManyArgsMsg);
//                        return false;
//                    }
//            }
//        }

//        /// <summary>
//        /// SetGUI 명령어를 실행할 수 있는지 검사합니다.
//        /// </summary>
//        /// <param name="messageBuilder">명령어에 맞는 메시지를 담기 위한 StringBuilder입니다. 메서드가 수행되면 Builder에 처리된 메시지가 담겨집니다.</param>
//        /// <param name="userInput">유저가 입력한 명령입니다.</param>
//        /// <returns>명령어를 실행할 수 있는지에 대한 성공 여부입니다.</returns>
//        public static bool CheckSetGUIExecute(StringBuilder messageBuilder, string userInput)
//        {
//            string[] splitInput = userInput.Split(' ');
//            messageBuilder.AppendLine();

//            switch (splitInput.Length)
//            {
//                case 1:
//                    {
//                        messageBuilder.Append(CommandMessage.SetGUITooLessArgsMsg);
//                        return false;
//                    }
//                case 2:
//                    {
//                        if (splitInput[1] == "on")
//                        {
//                            // TODO : If on, error
//                            messageBuilder.Append(CommandMessage.SetGUIOnMsg);
//                            return true;
//                        }
//                        else if (splitInput[1] == "off")
//                        {
//                            // TODO : if off, error
//                            messageBuilder.Append(CommandMessage.SetGUIOffMsg);
//                            return true;
//                        }
//                        else
//                        {
//                            messageBuilder.Append(CommandMessage.SetGUIInvalidArgsMsg);
//                            return false;
//                        }
//                    }
//                default:
//                    {
//                        messageBuilder.Append(CommandMessage.SetGUITooManyArgsMsg);
//                        return false;
//                    }
//            }
//        }

//        /// <summary>
//        /// None에 해당하는 명령어를 실행합니다.
//        /// </summary>
//        /// <param name="messageBuilder">명령어에 맞는 메시지를 담기 위한 StringBuilder입니다. 메서드가 수행되면 Builder에 처리된 메시지가 담겨집니다.</param>
//        public static void ExecuteNone(StringBuilder messageBuilder)
//        {
//            messageBuilder.AppendLine();
//            messageBuilder.Append(CommandMessage.NotExistMsg);
//        }
//    }
//}
