using CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgie
{
    class GenericDeviceModelList
    {
        private List<GenericDeviceModel> deviceModelList;

        public List<GenericDeviceModel> DeviceModelList
        {
            get { return deviceModelList; }
            set { deviceModelList = value; }
        }

        public GenericDeviceModelList()
        {
            this.DeviceModelList = new List<GenericDeviceModel>();
            // Create a generic List of devicemodels
            this.DeviceModelList.Add(new GenericDeviceModel());
            this.DeviceModelList.Add(new GenericDeviceModel());
            this.DeviceModelList.Add(new GenericDeviceModel());

        }

    }
}
