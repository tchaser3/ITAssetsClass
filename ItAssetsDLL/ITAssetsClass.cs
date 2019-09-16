/* Title:           IT Assets Class
 * Date:            12-4-18
 * Author:          Terry Holmes
 * 
 * Description:     This class is for the IT Assets */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace ItAssetsDLL
{
    public class ITAssetsClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        ITAssetsDataSet aITAssetsDataSet;
        ITAssetsDataSetTableAdapters.itassetsTableAdapter aITAssetsTableAdapter;

        InsertITAssetEntryTableAdapters.QueriesTableAdapter aInsertITAssetTableAdapter;

        UpdateITAssetLocationEntryTableAdapters.QueriesTableAdapter aUpdateITAssetLocationTableAdapter;

        FindITAssetsByItemDataSet aFindITAssetsByItemDataSet;
        FindITAssetsByItemDataSetTableAdapters.FindITAssetByItemTableAdapter aFindITAssetsByItemTableAdapter;

        FindITAssetBySerialNumberDataSet aFindITAssetBySerialNumberDataSet;
        FindITAssetBySerialNumberDataSetTableAdapters.FindITAssetBySerialNumberTableAdapter aFindITAssetBySerialNumberTableAdapter;

        FindITAssetsByItemIDDataSet aFindITAssetsByItemIDDataSet;
        FindITAssetsByItemIDDataSetTableAdapters.FindITAssetByItemIDTableAdapter aFindITAssetsByItemIDTableAdapter;

        RetireITAssetsEntryTableAdapters.QueriesTableAdapter aRetireITAssetsTableAdapter;

        FindActiveITAssetsDataSet aFindActiveITAssetsDataSet;
        FindActiveITAssetsDataSetTableAdapters.FindActiveITAssetsTableAdapter aFindActiveITAssetsTableAdapter;

        FindITAssetsByLocationDataSet aFindITAssetsByLocationDataSet;
        FindITAssetsByLocationDataSetTableAdapters.FindITAssestsByLocationTableAdapter aFindItAssetsByLocationTableAdapter;

        FindRetiredITAssetsDataSet aFindRetiredITAssetsDataSet;
        FindRetiredITAssetsDataSetTableAdapters.FindRetiredITAssetsTableAdapter aFindRetiredITAssetsTableAdapter;

        FindCurrentITAssetsByOfficeDataSet aFindCurrentITAssetsByOfficeDataSet;
        FindCurrentITAssetsByOfficeDataSetTableAdapters.FindCurrentITAssetsByOfficeTableAdapter aFindCurrentITAssetsByOfficeTableAdapter;

        public FindCurrentITAssetsByOfficeDataSet FindCurrentITAssetsByOffice(string strOffice)
        {
            try
            {
                aFindCurrentITAssetsByOfficeDataSet = new FindCurrentITAssetsByOfficeDataSet();
                aFindCurrentITAssetsByOfficeTableAdapter = new FindCurrentITAssetsByOfficeDataSetTableAdapters.FindCurrentITAssetsByOfficeTableAdapter();
                aFindCurrentITAssetsByOfficeTableAdapter.Fill(aFindCurrentITAssetsByOfficeDataSet.FindCurrentITAssetsByOffice, strOffice);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "IT Assets Class // Find Current IT Assets By Office " + Ex.Message);
            }

            return aFindCurrentITAssetsByOfficeDataSet;
        }
        public FindRetiredITAssetsDataSet FindRetiredITAssets(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindRetiredITAssetsDataSet = new FindRetiredITAssetsDataSet();
                aFindRetiredITAssetsTableAdapter = new FindRetiredITAssetsDataSetTableAdapters.FindRetiredITAssetsTableAdapter();
                aFindRetiredITAssetsTableAdapter.Fill(aFindRetiredITAssetsDataSet.FindRetiredITAssets, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "IT Assets Class // Find Retired IT Assets " + Ex.Message);
            }

            return aFindRetiredITAssetsDataSet;
        }
        public FindITAssetsByLocationDataSet FindItAssetsByLocation(int intWarehouseID)
        {
            try
            {
                aFindITAssetsByLocationDataSet = new FindITAssetsByLocationDataSet();
                aFindItAssetsByLocationTableAdapter = new FindITAssetsByLocationDataSetTableAdapters.FindITAssestsByLocationTableAdapter();
                aFindItAssetsByLocationTableAdapter.Fill(aFindITAssetsByLocationDataSet.FindITAssestsByLocation, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "It Assets Class // Find IT Assets By Location " + Ex.Message);
            }

            return aFindITAssetsByLocationDataSet;
        }
        public FindActiveITAssetsDataSet FindActiveITAssets()
        {
            try
            {
                aFindActiveITAssetsDataSet = new FindActiveITAssetsDataSet();
                aFindActiveITAssetsTableAdapter = new FindActiveITAssetsDataSetTableAdapters.FindActiveITAssetsTableAdapter();
                aFindActiveITAssetsTableAdapter.Fill(aFindActiveITAssetsDataSet.FindActiveITAssets);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "IT Assets Class // Find Active IT Assets " + Ex.Message);
            }

            return aFindActiveITAssetsDataSet;
        }
        public bool RetireITAssets(int intItemID, DateTime datRetirementDate, string strRetirementNotes)
        {
            bool blnFatatError = false;

            try
            {
                aRetireITAssetsTableAdapter = new RetireITAssetsEntryTableAdapters.QueriesTableAdapter();
                aRetireITAssetsTableAdapter.RetireITAssets(intItemID, datRetirementDate, strRetirementNotes);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "IT Assets Class // Retire It Assets " + Ex.Message);

                blnFatatError = true;
            }

            return blnFatatError;
        }
        public FindITAssetsByItemIDDataSet FindITAssetsByItemID(int intItemID)
        {
            try
            {
                aFindITAssetsByItemIDDataSet = new FindITAssetsByItemIDDataSet();
                aFindITAssetsByItemIDTableAdapter = new FindITAssetsByItemIDDataSetTableAdapters.FindITAssetByItemIDTableAdapter();
                aFindITAssetsByItemIDTableAdapter.Fill(aFindITAssetsByItemIDDataSet.FindITAssetByItemID, intItemID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "IT Assets Class // Find IT Assets by Item ID " + Ex.Message);
            }

            return aFindITAssetsByItemIDDataSet;
        }
        public FindITAssetBySerialNumberDataSet FindITAssetBySerialNumber(string strSerialNumber)
        {
            try
            {
                aFindITAssetBySerialNumberDataSet = new FindITAssetBySerialNumberDataSet();
                aFindITAssetBySerialNumberTableAdapter = new FindITAssetBySerialNumberDataSetTableAdapters.FindITAssetBySerialNumberTableAdapter();
                aFindITAssetBySerialNumberTableAdapter.Fill(aFindITAssetBySerialNumberDataSet.FindITAssetBySerialNumber, strSerialNumber);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "IT Asset Class // Find IT Asset By Serial Number " + Ex.Message);
            }

            return aFindITAssetBySerialNumberDataSet;
        }
        public FindITAssetsByItemDataSet FindITAssetsByItem(string strItem)
        {
            try
            {
                aFindITAssetsByItemDataSet = new FindITAssetsByItemDataSet();
                aFindITAssetsByItemTableAdapter = new FindITAssetsByItemDataSetTableAdapters.FindITAssetByItemTableAdapter();
                aFindITAssetsByItemTableAdapter.Fill(aFindITAssetsByItemDataSet.FindITAssetByItem, strItem);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "IT Assets Class // Find IT Assets By Item " + Ex.Message);
            }

            return aFindITAssetsByItemDataSet;
        }
        public bool UpdateITAssetLocation(int intItemID, int intWarehouseID)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateITAssetLocationTableAdapter = new UpdateITAssetLocationEntryTableAdapters.QueriesTableAdapter();
                aUpdateITAssetLocationTableAdapter.UpdateITAssetLocation(intItemID, intWarehouseID);
            }
            catch (Exception Ex)
            {
                blnFatalError = true;

                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "IT Asset Class // Update IT Asset Location " + Ex.Message);
            }

            return blnFatalError;
        }
        public bool InsertITAsset(string strItem, string strManufacturer, string strModel, string strSerialNumber, int intQuantity, decimal decItemValue, string strUpgrades, int intWarehouseID)
        {
            bool blnFatalError = false;

            try
            {
                aInsertITAssetTableAdapter = new InsertITAssetEntryTableAdapters.QueriesTableAdapter();
                aInsertITAssetTableAdapter.InsertITAsset(strItem, strManufacturer, strModel, strSerialNumber, intQuantity, decItemValue, strUpgrades, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "IT Assets Class // Insert IT Asset " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public ITAssetsDataSet GetITAssetsInfo()
        {
            try
            {
                aITAssetsDataSet = new ITAssetsDataSet();
                aITAssetsTableAdapter = new ITAssetsDataSetTableAdapters.itassetsTableAdapter();
                aITAssetsTableAdapter.Fill(aITAssetsDataSet.itassets);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "IT Assets Class // Get IT Assets Info " + Ex.Message);
            }

            return aITAssetsDataSet;
        }
        public void UpdateITAssetsDB(ITAssetsDataSet aITAssetsDataSet)
        {
            try
            {
                aITAssetsTableAdapter = new ITAssetsDataSetTableAdapters.itassetsTableAdapter();
                aITAssetsTableAdapter.Update(aITAssetsDataSet.itassets);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "IT Assets Class // Update IT Assets DB " + Ex.Message);
            }
        }
    }
}
