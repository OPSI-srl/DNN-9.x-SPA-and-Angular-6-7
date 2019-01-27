using System;
using System.Web.Caching;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Angular6Demo.Model
{
    // Name of the corresponding database table
    [TableName("Angularmodule_Items")]
    //setup the primary key for table
    [PrimaryKey("ItemId", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("BBAngular_Items_", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class ItemInfo
    {
        ///<summary>
        /// The ID of your object with the name of the ItemName
        ///</summary>
        public int ItemId { get; set; }

        ///<summary>
        /// A string with the title of the Item
        ///</summary>
        [ColumnName("ItemName")]
        public string Title { get; set; }

        ///<summary>
        /// A string with the description of the object
        ///</summary>
        [ColumnName("ItemDescription")]
        public string Description { get; set; }

        ///<summary>
        /// User id of the assigned user for the object
        ///</summary>
        public int? AssignedUserId { get; set; }

        ///<summary>
        /// The username of the assigned user for the object
        ///</summary>
        [ReadOnlyColumn]
        public string AssignedUserName { get; set; }

        ///<summary>
        /// The ModuleId of where the object was created and gets displayed
        ///</summary>
        public int ModuleId { get; set; }

        ///<summary>
        /// The Sort field defines the display order
        ///</summary>
        public int Sort { get; set; }

        ///<summary>
        /// User id of the user who created the object
        ///</summary>
        public int CreatedByUserId { get; set; }

        ///<summary>
        /// An integer for the user id of the user who last updated the object
        ///</summary>
        public int LastModifiedByUserId { get; set; }

        ///<summary>
        /// The date the object was created
        ///</summary>
        public DateTime CreatedOnDate { get; set; }

        ///<summary>
        /// The date the object was last updated
        ///</summary>
        public DateTime LastModifiedOnDate { get; set; }
    }
}
