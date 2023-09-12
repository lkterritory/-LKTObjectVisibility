using System;

namespace WCSScripts.Model.HTTP.Base
{

    [System.Serializable]
    public class LktHeader
    {
        public string type = "RESPONSE";
        public string call = "PAGE.DASHBOARD.3D.GET";
        public string status = "01";
        public string message = "";
        public string certificate = "";
        public string centerCode = "hyscm";
        public string clientCode = "hy";
        public string arehouseCode = "HY_NONSAN";
    }
}
