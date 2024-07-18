using Dblayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class StockMenuMV
    {
        RemyDbEntities db = new RemyDbEntities();
        public StockMenuMV()
        {
            GetAllCategories();
            GetOrderTypes();
            GetAllItems(string.Empty);
        }
        public StockMenuMV(string searchkey)
        {
            GetAllCategories();
            GetOrderTypes();
            GetAllItems(searchkey);
        }

        public StockMenuMV(string searchkey, List<FilterCategoryMV> list_categories, List<FilterOrderTypeMV> list_ordertypes)
        {
            categorylist = list_categories;
            ordertypelist = list_ordertypes;
            GetAllItems(searchkey);
        }

        public string SearchKey { get; set; }
        public List<ItemMV> AllItems { get; set; }
        private void GetAllItems(string key)
        {
            AllItems = new List<ItemMV>();
            var checked_categories = categorylist.Where(c => c.CategoryStatus == true) != null ? categorylist.Where(c => c.CategoryStatus == true).Count() : 0;
            var checked_ordertypes = ordertypelist.Where(c => c.OrderTypeStatus == true) != null ? ordertypelist.Where(c => c.OrderTypeStatus == true).Count() : 0;
            if (String.IsNullOrEmpty(key) && checked_categories == 0 && checked_ordertypes == 0)
            {
                foreach (var item in db.StockItemTables.Where(i => i.VisibleStatusID == 1).ToList())
                {
                    var ordertype = db.OrderTypeTables.Find(item.OrderTypeID).OrderType;
                    AllItems.Add(new ItemMV()
                    {
                        StockItemID = item.StockItemID,
                        ItemPhotoPath = item.ItemPhotoPath,
                        StockItemTitle = item.StockItemTitle,
                        ItemSize = item.ItemSize,
                        UnitPrice = item.UnitPrice,
                        OrderType = ordertype,
                        Rating = item.StockItemID
                    });
                }
            }
            else if (String.IsNullOrEmpty(key) && (checked_categories > 0 || checked_ordertypes > 0))
            {
                foreach (var category in categorylist.Where(c => c.CategoryStatus == true).ToList())
                {
                    foreach (var item in db.StockItemTables.Where(i => i.VisibleStatusID == 1 && i.StockItemCategoryID == category.StockMenuCategoryID).ToList())
                    {
                        var ordertype = db.OrderTypeTables.Find(item.OrderTypeID).OrderType;
                        AllItems.Add(new ItemMV()
                        {
                            StockItemID = item.StockItemID,
                            ItemPhotoPath = item.ItemPhotoPath,
                            StockItemTitle = item.StockItemTitle,
                            ItemSize = item.ItemSize,
                            UnitPrice = item.UnitPrice,
                            OrderType = ordertype,
                            Rating = item.StockItemID
                        });
                    }
                }
                foreach (var order_type in ordertypelist.Where(o => o.OrderTypeStatus == true).ToList())
                {
                    foreach (var item in db.StockItemTables.Where(i => i.VisibleStatusID == 1 && i.OrderTypeID == order_type.OrderTypeID).ToList())
                    {
                        var ordertype = db.OrderTypeTables.Find(item.OrderTypeID).OrderType;
                        AllItems.Add(new ItemMV()
                        {
                            StockItemID = item.StockItemID,
                            ItemPhotoPath = item.ItemPhotoPath,
                            StockItemTitle = item.StockItemTitle,
                            ItemSize = item.ItemSize,
                            UnitPrice = item.UnitPrice,
                            OrderType = ordertype,
                            Rating = item.StockItemID
                        });
                    }
                }
            }
            else if (!String.IsNullOrEmpty(key) && (checked_categories > 0 || checked_ordertypes > 0))
            {
                foreach (var category in categorylist.Where(c => c.CategoryStatus == true).ToList())
                {
                    foreach (var item in db.StockItemTables.Where(i => i.VisibleStatusID == 1 && i.StockItemCategoryID == category.StockMenuCategoryID && i.StockItemTitle.Trim().ToLower().Contains(key.Trim().ToLower())).ToList())
                    {
                        var ordertype = db.OrderTypeTables.Find(item.OrderTypeID).OrderType;
                        AllItems.Add(new ItemMV()
                        {
                            StockItemID = item.StockItemID,
                            ItemPhotoPath = item.ItemPhotoPath,
                            StockItemTitle = item.StockItemTitle,
                            ItemSize = item.ItemSize,
                            UnitPrice = item.UnitPrice,
                            OrderType = ordertype,
                            Rating = item.StockItemID
                        });
                    }
                }
                foreach (var order_type in ordertypelist.Where(o => o.OrderTypeStatus == true).ToList())
                {
                    foreach (var item in db.StockItemTables.Where(i => i.VisibleStatusID == 1 && i.OrderTypeID == order_type.OrderTypeID && i.StockItemTitle.Trim().ToLower().Contains(key.Trim().ToLower())).ToList())
                    {
                        var ordertype = db.OrderTypeTables.Find(item.OrderTypeID).OrderType;
                        AllItems.Add(new ItemMV()
                        {
                            StockItemID = item.StockItemID,
                            ItemPhotoPath = item.ItemPhotoPath,
                            StockItemTitle = item.StockItemTitle,
                            ItemSize = item.ItemSize,
                            UnitPrice = item.UnitPrice,
                            OrderType = ordertype,
                            Rating = item.StockItemID
                        });
                    }
                }
            }
            else if (!String.IsNullOrEmpty(key) && (checked_categories == 0 || checked_ordertypes == 0))
            {
                foreach (var item in db.StockItemTables.Where(i => i.VisibleStatusID == 1 && i.StockItemTitle.Trim().ToLower().Contains(key.Trim().ToLower())).ToList())
                {
                    var ordertype = db.OrderTypeTables.Find(item.OrderTypeID).OrderType;
                    AllItems.Add(new ItemMV()
                    {
                        StockItemID = item.StockItemID,
                        ItemPhotoPath = item.ItemPhotoPath,
                        StockItemTitle = item.StockItemTitle,
                        ItemSize = item.ItemSize,
                        UnitPrice = item.UnitPrice,
                        OrderType = ordertype,
                        Rating = item.StockItemID
                    });
                }
            }
        }

        public List<FilterCategoryMV> categorylist { get; set; }
        private void GetAllCategories()
        {
            categorylist = new List<FilterCategoryMV>();
            foreach (var category in db.StockItemCategoryTables.Where(c => c.VisibleStatusID == 1).ToList())
            {
                categorylist.Add(new FilterCategoryMV()
                {
                    StockMenuCategoryID = category.StockItemCategoryID,
                    StockMenuCategory = category.StockItemCategory,
                    CategoryStatus = false
                });
            }
        }

        public List<FilterOrderTypeMV> ordertypelist { get; set; }
        private void GetOrderTypes()
        {
            ordertypelist = new List<FilterOrderTypeMV>();
            foreach (var ordertype in db.OrderTypeTables.ToList())
            {
                ordertypelist.Add(new FilterOrderTypeMV()
                {
                    OrderTypeID = ordertype.OrderTypeID,
                    OrderType = ordertype.OrderType
                });
            }
        }
    }
}