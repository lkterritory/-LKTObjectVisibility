using System;

namespace WCSScripts.Model.Box
{

	public class BoxInfo
	{
		public string objCode;
        public string bcrCode;
        public string logCall;
        public string logCode;
        public string logMessage;
        public string logDetailMessage;
        public string addDateTime;

        public int nPathRR = 0;

        public BoxInfo()
		{
            objCode = "";
            bcrCode = "";
            logCall = "";
            logCode = "";
            logMessage = "";
            logDetailMessage = "";
            addDateTime = "";
        }
	}
}

