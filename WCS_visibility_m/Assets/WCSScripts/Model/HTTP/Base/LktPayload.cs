using System;
using System.Collections.Generic;

namespace WCSScripts.Model.HTTP.Base
{
    [System.Serializable]
    public class LktPayload
    {
        public LktHeader lktHeader;
        public List<LktBody> lktBody;

        public LktPayload()
        {
            lktHeader = new LktHeader();
        }
    }
}

