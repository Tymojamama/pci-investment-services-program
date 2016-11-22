using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ISP.Xml
{
    public partial class XmlParser
    {
        /// <summary>
        /// An instance of DataTables used for storing parsed XML in memory.
        /// </summary>
        public class DataSet
        {
            public DataTable Import;
            public DataTable Manager;
            public DataTable ManagerEducation;
            public DataTable ManagerCredential;
            public DataTable Advisor;
            public DataTable Fund;
            public DataTable FundDetail;

            public DataSet()
            {
                CreateTableImport();
                CreateTableManager();
                CreateTableManagerEducation();
                CreateTableManagerCredential();
                CreateTableAdvisor();
                CreateTableFund();
                CreateTableFundDetail();
            }

            private void CreateTableImport()
            {
                Import = new DataTable();
                Import.Columns.Add("PackageName");
                Import.Columns.Add("Universe");
                Import.Columns.Add("AsOfDate");
                Import.Columns.Add("Version");
                Import.Columns.Add("ImportErrorOccurred");
                Import.Columns.Add("CreatedBy", typeof(Guid));
                Import.Columns.Add("CreatedOn", typeof(DateTime));
            }

            private void CreateTableManager()
            {
                Manager = new DataTable();
                Manager.Columns.Add("MorningstarFundId");
                Manager.Columns.Add("MorningstarManagerId");
                Manager.Columns.Add("FirstName");
                Manager.Columns.Add("MiddleName");
                Manager.Columns.Add("LastName");
                Manager.Columns.Add("StartDate");
                Manager.Columns.Add("Credentials");
                Manager.Columns.Add("Biography");
            }

            private void CreateTableManagerEducation()
            {
                ManagerEducation = new DataTable();
                ManagerEducation.Columns.Add("ManagerId");
                ManagerEducation.Columns.Add("Institution");
                ManagerEducation.Columns.Add("DegreeType");
                ManagerEducation.Columns.Add("Emphasis");
                ManagerEducation.Columns.Add("Year");
            }

            private void CreateTableManagerCredential()
            {
                ManagerCredential = new DataTable();
                ManagerCredential.Columns.Add("ManagerId");
                ManagerCredential.Columns.Add("Credential");
            }

            private void CreateTableAdvisor()
            {
                Advisor = new DataTable();
                Advisor.Columns.Add("MorningstarFundId");
                Advisor.Columns.Add("MorningstarAdvisorId");
                Advisor.Columns.Add("AdvisorName");
            }

            private void CreateTableFund()
            {
                Fund = new DataTable();
                Fund.Columns.Add("MorningstarFundId");
                Fund.Columns.Add("FundName");
                Fund.Columns.Add("Ticker");
                Fund.Columns.Add("Category");
                Fund.Columns.Add("ProspectusObjective");
                Fund.Columns.Add("Family");
                Fund.Columns.Add("InceptionDate");
                Fund.Columns.Add("ShareClassId");
                Fund.Columns.Add("CUSIP");
                Fund.Columns.Add("MinimumInvestmentDate");
                Fund.Columns.Add("SubsequentInvestment");
                Fund.Columns.Add("InitialRetirementInvestment");
                Fund.Columns.Add("MorningstarCategoryId");
                Fund.Columns.Add("MorningstarCategoryName");
                Fund.Columns.Add("MorningstarPrimaryBenchmarkId");
                Fund.Columns.Add("MorningstarPrimaryBenchmarkName");
                Fund.Columns.Add("MorningstarSecondaryBenchmarkId");
                Fund.Columns.Add("MorningstarSecondaryBenchmarkName");
            }

            private void CreateTableFundDetail()
            {
                FundDetail = new DataTable();
                FundDetail.Columns.Add("MorningstarFundId");
                FundDetail.Columns.Add("a");
                FundDetail.Columns.Add("aa");
                FundDetail.Columns.Add("aaa");
                FundDetail.Columns.Add("Africa");
                FundDetail.Columns.Add("AfricaAndMiddleEast");
                FundDetail.Columns.Add("AnnRetY1");
                FundDetail.Columns.Add("AnnRetY2");
                FundDetail.Columns.Add("AnnRetY3");
                FundDetail.Columns.Add("AnnRetY4");
                FundDetail.Columns.Add("AnnRetY5");
                FundDetail.Columns.Add("AnnRetY6");
                FundDetail.Columns.Add("AnnRetY7");
                FundDetail.Columns.Add("AnnRetY8");
                FundDetail.Columns.Add("AnnRetY9");
                FundDetail.Columns.Add("AnnRetY10");
                FundDetail.Columns.Add("AsiaDev");
                FundDetail.Columns.Add("AsiaEmrg");
                FundDetail.Columns.Add("AssetAllocationCashLong");
                FundDetail.Columns.Add("AssetAllocationCashShort");
                FundDetail.Columns.Add("AssetAllocationNonUSBondLong");
                FundDetail.Columns.Add("AssetAllocationNonUSBondNet");
                FundDetail.Columns.Add("AssetAllocationNonUSBondShort");
                FundDetail.Columns.Add("AssetAllocationNonUSStockLong");
                FundDetail.Columns.Add("AssetAllocationNonUSStockShort");
                FundDetail.Columns.Add("AssetAllocationOtherLong");
                FundDetail.Columns.Add("AssetAllocationOtherShort");
                FundDetail.Columns.Add("AssetAllocationUSBondLong");
                FundDetail.Columns.Add("AssetAllocationUSBondShort");
                FundDetail.Columns.Add("AssetAllocationUSStockLong");
                FundDetail.Columns.Add("AssetAllocationUSStockShort");
                FundDetail.Columns.Add("AssetBacked");
                FundDetail.Columns.Add("AuditedExpenseRatio");
                FundDetail.Columns.Add("Australasia");
                FundDetail.Columns.Add("AvgCreditQuality");
                FundDetail.Columns.Add("AvgEffDuration");
                FundDetail.Columns.Add("AvgMaturity");
                FundDetail.Columns.Add("AvgWeightedCoupon");
                FundDetail.Columns.Add("b");
                FundDetail.Columns.Add("BasicMaterials");
                FundDetail.Columns.Add("bb");
                FundDetail.Columns.Add("bbb");
                FundDetail.Columns.Add("belowB");
                FundDetail.Columns.Add("Bonds");
                FundDetail.Columns.Add("BondSectorAssetbackedNet");
                FundDetail.Columns.Add("BondSectorCashNet");
                FundDetail.Columns.Add("BondSectorConvertibleNet");
                FundDetail.Columns.Add("BondSectorForeignCorpNet");
                FundDetail.Columns.Add("BondSectorForeignGovtNet");
                FundDetail.Columns.Add("BondSectorInflationPrNet");
                FundDetail.Columns.Add("BondSectorMortgageARMNet");
                FundDetail.Columns.Add("BondSectorMortgageCMONet");
                FundDetail.Columns.Add("BondSectorMtgPassthruNet");
                FundDetail.Columns.Add("BondSectorMunicipalNet");
                FundDetail.Columns.Add("BondSectorTIPSNet");
                FundDetail.Columns.Add("BondSectorUSAgencyNet");
                FundDetail.Columns.Add("BondSectorUSCorporateNet");
                FundDetail.Columns.Add("BondSectorUSTreasuryNet");
                FundDetail.Columns.Add("BookValueGrowth");
                FundDetail.Columns.Add("BusinessServices");
                FundDetail.Columns.Add("CaptureRatioDown");
                FundDetail.Columns.Add("CaptureRatioUp");
                FundDetail.Columns.Add("Cash");
                FundDetail.Columns.Add("CashFlowGrowth");
                FundDetail.Columns.Add("ConsumerCyclical");
                FundDetail.Columns.Add("ConsumerDefensive");
                FundDetail.Columns.Add("ConsumerGoods");
                FundDetail.Columns.Add("ConsumerServices");
                FundDetail.Columns.Add("Corporate");
                FundDetail.Columns.Add("DevelopedCountry");
                FundDetail.Columns.Add("EmergingMarket");
                FundDetail.Columns.Add("Energy");
                FundDetail.Columns.Add("EPS");
                FundDetail.Columns.Add("EquityStyle");
                FundDetail.Columns.Add("EuropeDev");
                FundDetail.Columns.Add("EuropeEmrg");
                FundDetail.Columns.Add("EuropeExEuro");
                FundDetail.Columns.Add("Eurozone");
                FundDetail.Columns.Add("FinancialServices");
                FundDetail.Columns.Add("FixedIncStyle");
                FundDetail.Columns.Add("FundNetAssets");
                FundDetail.Columns.Add("GeoAvgMarketCap");
                FundDetail.Columns.Add("Government");
                FundDetail.Columns.Add("Hardware");
                FundDetail.Columns.Add("Healthcare");
                FundDetail.Columns.Add("HistoricalEarnGrowth");
                FundDetail.Columns.Add("IndustrialMaterials");
                FundDetail.Columns.Add("Japan");
                FundDetail.Columns.Add("LargeCore");
                FundDetail.Columns.Add("LargeGrowth");
                FundDetail.Columns.Add("LargeValue");
                FundDetail.Columns.Add("LatinAmerica");
                FundDetail.Columns.Add("LongTermEarnGrowth");
                FundDetail.Columns.Add("Media");
                FundDetail.Columns.Add("MediumCore");
                FundDetail.Columns.Add("MediumGrowth");
                FundDetail.Columns.Add("MediumValue");
                FundDetail.Columns.Add("MiddleEast");
                FundDetail.Columns.Add("MinInitPurchase");
                FundDetail.Columns.Add("NonUSBondLong");
                FundDetail.Columns.Add("NonUSstocks");
                FundDetail.Columns.Add("NorthAmerica");
                FundDetail.Columns.Add("NorthAmericaCanada");
                FundDetail.Columns.Add("NorthAmericaUS");
                FundDetail.Columns.Add("NotClassified");
                FundDetail.Columns.Add("NRorNA");
                FundDetail.Columns.Add("Other");
                FundDetail.Columns.Add("PbRatioTTM");
                FundDetail.Columns.Add("PcRatioTTM");
                FundDetail.Columns.Add("PeRatioTTM");
                FundDetail.Columns.Add("PortfolioDate");
                FundDetail.Columns.Add("PriceProspectiveEarn");
                FundDetail.Columns.Add("PrimaryIndexTreynorRatio");
                FundDetail.Columns.Add("ProspectiveDividendYield");
                FundDetail.Columns.Add("ProspectusGrossExpenseRatio");
                FundDetail.Columns.Add("ProspectusNetExpenseRatio");
                FundDetail.Columns.Add("PsRatioTTM");
                FundDetail.Columns.Add("PurchaseConstraints");
                FundDetail.Columns.Add("RankCat12Month");
                FundDetail.Columns.Add("RankCat3Yr");
                FundDetail.Columns.Add("RankCat5Yr");
                FundDetail.Columns.Add("RealEstate");
                FundDetail.Columns.Add("RegionAfricaNet");
                FundDetail.Columns.Add("RegionAsiaDevelopedNet");
                FundDetail.Columns.Add("RegionAustralasiaNet");
                FundDetail.Columns.Add("RegionCanadaNet");
                FundDetail.Columns.Add("RegionDevelopedCountryNet");
                FundDetail.Columns.Add("RegionEmergingMarketNet");
                FundDetail.Columns.Add("RegionEuropeEmergingNet");
                FundDetail.Columns.Add("RegionEuropeExEuroNet");
                FundDetail.Columns.Add("RegionEurozoneNet");
                FundDetail.Columns.Add("RegionJapanNet");
                FundDetail.Columns.Add("RegionLatinAmericaNet");
                FundDetail.Columns.Add("RegionMiddleEastNet");
                FundDetail.Columns.Add("RegionNotClassifiedNet");
                FundDetail.Columns.Add("RegionUnitedKingdomNet");
                FundDetail.Columns.Add("RegionUnitedStatesNet");
                FundDetail.Columns.Add("revenueSharing");
                FundDetail.Columns.Add("SalesGrowth");
                FundDetail.Columns.Add("SECYield");
                FundDetail.Columns.Add("SharpeRatio");
                FundDetail.Columns.Add("SmallCore");
                FundDetail.Columns.Add("SmallGrowth");
                FundDetail.Columns.Add("SmallValue");
                FundDetail.Columns.Add("Software");
                FundDetail.Columns.Add("SortinoRatio");
                FundDetail.Columns.Add("SpecialCriteria");
                FundDetail.Columns.Add("StdDev3Yr");
                FundDetail.Columns.Add("StdDev5Yr");
                FundDetail.Columns.Add("StockSectorBasicMaterialsNet");
                FundDetail.Columns.Add("StockSectorCommunicationServicesNet");
                FundDetail.Columns.Add("StockSectorConsumerCyclicalNet");
                FundDetail.Columns.Add("StockSectorConsumerDefensiveNet");
                FundDetail.Columns.Add("StockSectorEnergyNet");
                FundDetail.Columns.Add("StockSectorFinancialServicesNet");
                FundDetail.Columns.Add("StockSectorHealthcareNet");
                FundDetail.Columns.Add("StockSectorIndustrialsNet");
                FundDetail.Columns.Add("StockSectorRealEstateNet");
                FundDetail.Columns.Add("StockSectorTechnologyNet");
                FundDetail.Columns.Add("StockSectorUtilitiesNet");
                FundDetail.Columns.Add("SuperRegAmericas");
                FundDetail.Columns.Add("SuperRegGreaterAsia");
                FundDetail.Columns.Add("SuperRegGreaterEurope");
                FundDetail.Columns.Add("SuperSectInfoEcon");
                FundDetail.Columns.Add("SuperSectManufactEcon");
                FundDetail.Columns.Add("SuperSectServiceEcon");
                FundDetail.Columns.Add("Technology");
                FundDetail.Columns.Add("Telcom");
                FundDetail.Columns.Add("top10holdings");
                FundDetail.Columns.Add("TotNumOfHoldings");
                FundDetail.Columns.Add("totRet12Mo");
                FundDetail.Columns.Add("TotRetAnnlzd10Yr");
                FundDetail.Columns.Add("TotRetAnnlzd15Yr");
                FundDetail.Columns.Add("totRetAnnlzd3Yr");
                FundDetail.Columns.Add("TotRetAnnlzd5Yr");
                FundDetail.Columns.Add("TotRetSinceIncept");
                FundDetail.Columns.Add("TrailingReturnM1");
                FundDetail.Columns.Add("TrailingReturnM3");
                FundDetail.Columns.Add("TrailingReturnM6");
                FundDetail.Columns.Add("TrailingReturnY15");
                FundDetail.Columns.Add("TrailingReturnYTD");
                FundDetail.Columns.Add("TurnoverRatio");
                FundDetail.Columns.Add("TwelveMonthYield");
                FundDetail.Columns.Add("UnitedKingdom");
                FundDetail.Columns.Add("USBond");
                FundDetail.Columns.Add("UsGovt");
                FundDetail.Columns.Add("USstocks");
                FundDetail.Columns.Add("Utility");
            }
        }
    }
}
