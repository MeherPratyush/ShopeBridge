using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopeBride.Models
{
    public class InventoryBO
    {
    }
    public class GetInvetoryDetailResponseBO
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public string Description { get; set; }
        public int  Price{ get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class InventoryRequestBO
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class InventoryResponseBO
    {
        public InventoryResponseBO()
        {
            _mErrorCode = -1;
            errMessage = "Unable to Process ur request, Please try again later.";
        }
        private int _mErrorCode;
        public string errMessage { get; private set; }
        public int errCode
        {
            get { return _mErrorCode; }
            set
            {
                _mErrorCode = value;
                switch (this._mErrorCode)
                {
                    case 0: this.errMessage = "Saved Successfully."; break;
                    case -1: this.errMessage = "Unable to Process ur request, Please try again later."; break;
                }
            }
        }
    }
    public class DeleteInvetoryRequestBO
    {
        public int InventoryId { get; set; }
        public bool IsDeleted { get; set; }
    }

    }