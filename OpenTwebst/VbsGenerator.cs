﻿/*
 * This file is part of Open Twebst - web automation framework.
 * Copyright (c) 2012 Adrian Dorache
 * adrian.dorache@codecentrix.com
 *
 * Open Twebst is free software: you can redistribute it
 * and/or modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version.
 *
 * Open Twebst is distributed in the hope that it will be
 * useful, but WITHOUT ANY WARRANTY; without even the implied warranty
 * of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with Open Twebst. If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * Twebst can be used under a commercial license if such has been acquired
 * (see http://www.codecentrix.com/). The commercial license does not
 * cover derived or ported versions created by third parties under GPL.
 */

using System;
using System.Collections.Generic;
using System.Text;



namespace CatStudio
{
    class VbsGenerator : BaseLanguageGenerator
    {
        public VbsGenerator()
        {
            this.BACK_NAVIGATION_STATEMENT                  = "Call browser.nativeBrowser.GoBack()";
            this.FORWARD_NAVIGATION_STATEMENT               = "Call browser.nativeBrowser.GoForward()";
            this.START_UP_STATEMENT                         = "Option Explicit\n" + "Dim core\n" + "Dim browser\n" + "Set core    = CreateObject(\"OpenTwebst.Core\")\n" + "Set browser = core.StartBrowser(\"{0}\")\n";
            this.CLICK_NO_INDEX_STATEMENT                   = "Call browser.FindElement(\"{0}\", \"{1}={2}\").{3}";
            this.CLICK_NO_INDEX_NO_ATTR_STATEMENT           = "Call browser.FindElement(\"{0}\", \"\").{1}";
            this.CLICK_STATEMENT                            = "Call browser.FindElement(\"{0}\", \"{1}={2}, index={3}\").{4}";
            this.CLICK_NO_ATTR_STATEMENT                    = "Call browser.FindElement(\"{0}\", \"index={1}\").{2}";
            this.TEXT_CHANGED_NO_INDEX_STATEMENT            = "Call browser.FindElement(\"{0}\", \"{1}={2}\").InputText(\"{3}\")";
            this.TEXT_CHANGED_NO_INDEX_NO_ATTR_STATEMENT    = "Call browser.FindElement(\"{0}\", \"\").InputText(\"{1}\")";
            this.TEXT_CHANGED_STATEMENT                     = "Call browser.FindElement(\"{0}\", \"{1}={2}, index={3}\").InputText(\"{4}\")";
            this.TEXT_CHANGED_NO_ATTR_STATEMENT             = "Call browser.FindElement(\"{0}\", \"index={1}\").InputText(\"{2}\")";
            this.TEXT_CHANGED_ON_FILE_IE8_COMMENT           = "'Because of new HTML 5 security specifications, IE8 - IE9 does not reveal the real local path of the file you have selected. You have to manually change the code";
            this.SELECT_MULTIPLE_DECLARATION                = "Dim s\nSet ";
            this.SELECT_MULTIPLE_FIRST_ITEM_STATEMENT       = "Call s.Select(\"{0}\")";
            this.SELECT_MULTIPLE_NO_INDEX_STATEMENT         = "{0}Set s = browser.FindElement(\"{1}\", \"{2}={3}\")\n";
            this.SELECT_MULTIPLE_NO_INDEX_NO_ATTR_STATEMENT = "{0}Set s = browser.FindElement(\"{1}\", \"\")\n";
            this.SELECT_MULTIPLE_STATEMENT                  = "{0}Set s = browser.FindElement(\"{1}\", \"{2}={3}, index={4}\")\n";
            this.SELECT_MULTIPLE_NO_ATTR_STATEMENT          = "{0}Set s = browser.FindElement(\"{1}\", \"index={2}\")\n";
            this.ADD_SELECTION_STATEMENT                    = "\nCall s.AddSelection(\"{0}\")";
            this.SELECT_NO_INDEX_STATEMENT                  = "Call browser.FindElement(\"{0}\", \"{1}={2}\").Select(\"{3}\")";
            this.SELECT_NO_INDEX_NO_ATTR_STATEMENT          = "Call browser.FindElement(\"{0}\", \"\").Select(\"{1}\")";
            this.SELECT_STATEMENT                           = "Call browser.FindElement(\"{0}\", \"{1}={2}, index={3}\").Select(\"{4}\")";
            this.SELECT_NO_ATTR_STATEMENT                   = "Call browser.FindElement(\"{0}\", \"index={1}\").Select(\"{2}\")";

            // For Win64 add a comment on how to start a .vbs script as 32 bit process.
            if (CatStudioConstants.IsWin64)
            {
                this.START_UP_STATEMENT = "'On Windows 64 bit use the command line below to launch the script as a 32 bit process:\n' %windir%\\SysWOW64\\wscript.exe TwebstScript.vbs\n\n" + this.START_UP_STATEMENT;
            }
            else
            {
                this.START_UP_STATEMENT = "'Use the command line below to launch the script (or just double click the .vbs file):\n' %windir%\\system32\\wscript.exe TwebstScript.vbs\n\n" + this.START_UP_STATEMENT;
            }
        }


        protected override String EscapeStr(String source)
        {
            if (source == null)
            {
                return null;
            }

            String result = source.Replace("\"", "\"\"").Replace("\r\n", "\" & vbCrLf & \"").Replace("\r", "\" & vbCr & \"").Replace("\n", "\" & vbLf & \"");
            return result;
        }


        internal override void Play(String code)
        {
            PlayWScript(code, FileExt);
        }

        
        internal override String FileExt
        {
            get { return ".vbs"; }
        }

        public override string ToString()
        {
            return "VBScript";
        }
    }
}
