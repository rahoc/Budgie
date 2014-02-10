using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;
using Budgie;
using Budgie.DialogIn;

namespace Budgie.SemaineComponents
{
    class GenericDialogInput
    {
        private DialogInput dialogInput;

        internal DialogInput DialogInput
        {
            get { return dialogInput; }
            set { dialogInput = value; }
        }

        public GenericDialogInput()
        {
            IDialogInputItem dialogIn = new SelectionDialogInputItem("selObj1", "selbObjItem1");
            this.DialogInput = new DialogInput( "dialogId_1",
                                                "Budgie",
                                                "touchscreen",
                                                dialogIn);
        }
    }
}
