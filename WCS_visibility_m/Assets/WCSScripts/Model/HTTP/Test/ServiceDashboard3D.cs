using System;
using System.Collections.Generic;
using WCSScripts.Model.HTTP.Base;

namespace WCSScripts.Model.HTTP.Test
{

    public class ServiceDashboard3D : BaseService
    {

        public BodyDashboard3DResAll lktBodyResAll;

        public class BodyDashboard3D : LktBody
        {
            public string currentTimeStart;
            public string currentTimeEnd;

            public BodyDashboard3D()
            {
                currentTimeStart = "";
                currentTimeEnd = "";
            }
        }



        public class BodyDashboard3DRes : LktBody
        {
            //public LktHeader lktHeader;

            public string objCode;
            public string bcrCode;
            public string logCall;
            public string logCode;
            public string logMessage;
            public string logDetailMessage;
            public string addDateTime;
            

            public BodyDashboard3DRes()
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

        [System.Serializable]
        public class BodyDashboard3DResAll
        {
            public LktHeader lktHeader;
            public List<BodyDashboard3DRes> lktBody;

            

            public BodyDashboard3DResAll()
            {
                lktHeader = new LktHeader();
                lktBody = new List<BodyDashboard3DRes>();
            }
        }



        public ServiceDashboard3D()
        {
            

            this.payload = new LktPayload();


            lktBodyResAll = new BodyDashboard3DResAll();
            //this.lktBody = new List<LktBody>();

            //this.lkt

        }
    }
}

