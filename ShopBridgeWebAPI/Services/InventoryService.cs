using ShopeBride.DAO;
using ShopeBride.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopeBride.Services
{
    public class InventoryService
    {
        InventoryDAO objInventoryDAO = new InventoryDAO();
        internal List<GetInvetoryDetailResponseBO> GetInventoryDetails()
        {
            return objInventoryDAO.GetInventoryDetails();
        }

        internal InventoryResponseBO SaveInventoryDetails(InventoryRequestBO objRequest)
        {
            return objInventoryDAO.SaveInventoryDetails(objRequest);
        }

        internal InventoryResponseBO UpdateInventoryDetails(InventoryRequestBO objRequest)
        {
            return objInventoryDAO.UpdateInventoryDetails(objRequest);
        }

        internal InventoryResponseBO DeleteInventoryDetails(DeleteInvetoryRequestBO objRequest)
        {
            return objInventoryDAO.DeleteInventoryDetails(objRequest);
        }
    }
}