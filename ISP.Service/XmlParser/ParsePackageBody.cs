using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ISP.Xml
{
    public partial class XmlParser
    {
        private DataRow drAdvisors;
        private DataRow drFunds;
        private DataRow drFundDetails;
        private DataRow drManagers;
        private DataRow drManagersEducation;
        private DataRow drManagerCredential;

        private int fundCount = 0;

        private bool readNext = true;

        private bool oneEighthCompleted = false;
        private bool twoEighthCompleted = false;
        private bool threeEighthCompleted = false;
        private bool fourEighthCompleted = false;
        private bool fiveEighthCompleted = false;
        private bool sixEighthCompleted = false;
        private bool sevenEighthCompleted = false;

        private bool inOperation = false;
        private bool inProspectusObjective = false;
        private bool inMorningstarCategory = false;
        private bool inMorningstarPrimaryBenchmark = false;
        private bool inMorningstarSecondaryBenchmark = false;
        private bool inMinimumInvestment = false;

        /// <summary>
        /// Begins the initialized XmlReader and organizes Morningstar XML data into DataTables and DataRows as it is read.
        /// This method checks for certain points in the XML document to complete the old DataRow and start a new one.
        /// </summary>
        private void ParsePackageBody()
        {
            WriteToEventLog("Transforming XML Data.", 0.15m);

            while ((!readNext || xmlReader.Read()) && ContinueProcess)
            {
                readNext = true;

                ReportProgress();

                if (HandleDataRows())
                    continue;

                if (String.IsNullOrWhiteSpace(xmlReader.Name))
                    continue;

                switch (xmlReader.Name)
                {
                    // Handle bool entry to check where we are in the file
                    // Answers questions like, Which <name> node are we in?

                    case "Operation":
                        if (nodeIsElement())
                            inOperation = true;
                        else if (nodeIsEndElement())
                            inOperation = false;
                        break;
                    case "MorningstarProspectusObjective":
                        if (nodeIsElement())
                            inProspectusObjective = true;
                        else if (nodeIsEndElement())
                            inProspectusObjective = false;
                        break;
                    case "MorningstarCategory":
                        if (nodeIsElement())
                            inMorningstarCategory = true;
                        else if (nodeIsEndElement())
                            inMorningstarCategory = false;
                        break;
                    case "MorningstarPrimaryBenchmark":
                        if (nodeIsElement())
                            inMorningstarPrimaryBenchmark = true;
                        else if (nodeIsEndElement())
                            inMorningstarPrimaryBenchmark = false;
                        break;
                    case "MorningstarSecondaryBenchmark":
                        if (nodeIsElement())
                            inMorningstarSecondaryBenchmark = true;
                        else if (nodeIsEndElement())
                            inMorningstarSecondaryBenchmark = false;
                        break;
                    case "MinimumInvestment":
                        if (nodeIsElement())
                            inMinimumInvestment = true;
                        else if (nodeIsEndElement())
                            inMinimumInvestment = false;
                        break;

                    // Fund
                    
                    case "InvestmentVehicleName":
                        XmlToDataRow(drFunds, "FundName", inOperation);
                        break;
                    case "TradingSymbol":
                        XmlToDataRow(drFunds, "Ticker", inOperation);
                        break;
                    case "GlobalCategoryName":
                        XmlToDataRow(drFunds, "Category", inOperation);
                        break;
                    case "CUSIP":
                        XmlToDataRow(drFunds, "CUSIP", inOperation);
                        break;
                    case "FundFamilyName":
                        XmlToDataRow(drFunds, "Family", inOperation);
                        break;
                    case "InceptionDate":
                        XmlToDataRow(drFunds, "InceptionDate", inOperation);
                        break;
                    case "InitialRetirementInvestment":
                        XmlToDataRow(drFunds, "InitialRetirementInvestment", inMinimumInvestment);
                        break;
                    case "Date":
                        XmlToDataRow(drFunds, "MinimumInvestmentDate", inMinimumInvestment);
                        break;
                    case "ShareClassId":
                        XmlToDataRow(drFunds, "ShareClassId", inOperation);
                        break;
                    case "SubsequentInvestment":
                        XmlToDataRow(drFunds, "SubsequentInvestment", inMinimumInvestment);
                        break;
                    case "Name":
                        XmlToDataRow(drFunds, "ProspectusObjective", inProspectusObjective);
                        XmlToDataRow(drFunds, "MorningstarCategoryName", inMorningstarCategory);
                        XmlToDataRow(drFunds, "MorningstarPrimaryBenchmarkName", inMorningstarPrimaryBenchmark);
                        XmlToDataRow(drFunds, "MorningstarSecondaryBenchmarkName", inMorningstarSecondaryBenchmark);
                        break;
                    case "Id":
                        XmlToDataRow(drFunds, "MorningstarCategoryId", inMorningstarCategory);
                        XmlToDataRow(drFunds, "MorningstarPrimaryBenchmarkId", inMorningstarPrimaryBenchmark);
                        XmlToDataRow(drFunds, "MorningstarSecondaryBenchmarkId", inMorningstarSecondaryBenchmark);
                        break;
                    
                    // Manager
                    
                    case "ManagerId":
                        XmlToDataRow(drManagers, "MorningstarManagerId");
                        break;
                    case "StartDate":
                        XmlToDataRow(drManagers, "StartDate", drManagers != null);
                        break;
                    case "GivenName":
                        XmlToDataRow(drManagers, "FirstName");
                        break;
                    case "MiddleName":
                        XmlToDataRow(drManagers, "MiddleName");
                        break;
                    case "FamilyName":
                        XmlToDataRow(drManagers, "LastName");
                        break;
                    case "ProfessionalBiography":
                        XmlToDataRow(drManagers, "Biography");
                        break;

                    // ManagerEducation

                    case "School":
                        XmlToDataRow(drManagersEducation, "Institution", drManagersEducation != null);
                        break;
                    case "Year":
                        XmlToDataRow(drManagersEducation, "Year", drManagersEducation != null);
                        break;
                    case "Degree":
                        XmlToDataRow(drManagersEducation, "DegreeType", drManagersEducation != null);
                        break;
                    case "Major":
                        XmlToDataRow(drManagersEducation, "Emphasis", drManagersEducation != null);
                        break;

                    // ManagerCredential

                    case "CertificationName":
                        drManagerCredential = ResultSet.ManagerCredential.NewRow();
                        drManagerCredential["ManagerId"] = drManagers["MorningstarManagerId"];
                        XmlToDataRow(drManagerCredential, "Credential");
                        ResultSet.ManagerCredential.Rows.Add(drManagerCredential);
                        drManagerCredential = null;
                        break;

                    // FundDetail

                    case "CreditQualityA":
                        XmlToDataRow(drFundDetails, "a");
                        break;
                    case "CreditQualityAA":
                        XmlToDataRow(drFundDetails, "aa");
                        break;
                    case "CreditQualityAAA":
                        XmlToDataRow(drFundDetails, "aaa");
                        break;
                    case "RegionAfricaLong":
                        XmlToDataRow(drFundDetails, "Africa");
                        break;
                    case "AnnualReturnMarketY1":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "AnnRetY1");
                        break;
                    case "AnnualReturnNAVY1":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "AnnRetY1");
                        break;
                    case "AnnualReturnMarketY10":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "AnnRetY10");
                        break;
                    case "AnnualReturnNAVY10":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "AnnRetY10");
                        break;
                    case "AnnualReturnMarketY2":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "AnnRetY2");
                        break;
                    case "AnnualReturnNAVY2":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "AnnRetY2");
                        break;
                    case "AnnualReturnMarketY3":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "AnnRetY3");
                        break;
                    case "AnnualReturnNAVY3":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "AnnRetY3");
                        break;
                    case "AnnualReturnMarketY4":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "AnnRetY4");
                        break;
                    case "AnnualReturnNAVY4":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "AnnRetY4");
                        break;
                    case "AnnualReturnMarketY5":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "AnnRetY5");
                        break;
                    case "AnnualReturnNAVY5":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "AnnRetY5");
                        break;
                    case "AnnualReturnMarketY6":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "AnnRetY6");
                        break;
                    case "AnnualReturnNAVY6":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "AnnRetY6");
                        break;
                    case "AnnualReturnMarketY7":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "AnnRetY7"); 
                        break;
                    case "AnnualReturnNAVY7":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "AnnRetY7");
                        break;
                    case "AnnualReturnMarketY8":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "AnnRetY8");
                        break;
                    case "AnnualReturnNAVY8":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "AnnRetY8");
                        break;
                    case "AnnualReturnMarketY9":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "AnnRetY9");
                        break;
                    case "AnnualReturnNAVY9":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "AnnRetY9");
                        break;
                    case "RegionAsiaDevelopedLong":
                        XmlToDataRow(drFundDetails, "asiadev");
                        break;
                    case "RegionAsiaEmergingLong":
                        XmlToDataRow(drFundDetails, "asiaemrg");
                        break;
                    case "AssetAllocationCashLong":
                        XmlToDataRow(drFundDetails, "AssetAllocationCashLong");
                        break;
                    case "AssetAllocationCashShort":
                        XmlToDataRow(drFundDetails, "AssetAllocationCashShort");
                        break;
                    case "AssetAllocationNonUSBondLong":
                        XmlToDataRow(drFundDetails, "AssetAllocationNonUSBondLong");
                        break;
                    case "AssetAllocationNonUSBondNet":
                        XmlToDataRow(drFundDetails, "AssetAllocationNonUSBondNet", "NonUSBondLong");
                        break;
                    case "AssetAllocationNonUSBondShort":
                        XmlToDataRow(drFundDetails, "AssetAllocationNonUSBondShort");
                        break;
                    case "AssetAllocationNonUSStockLong":
                        XmlToDataRow(drFundDetails, "AssetAllocationNonUSStockLong");
                        break;
                    case "AssetAllocationNonUSStockShort":
                        XmlToDataRow(drFundDetails, "AssetAllocationNonUSStockShort");
                        break;
                    case "AssetAllocationOtherLong":
                        XmlToDataRow(drFundDetails, "AssetAllocationOtherLong"); 
                        break;
                    case "AssetAllocationOtherShort":
                        XmlToDataRow(drFundDetails, "AssetAllocationOtherShort");
                        break;
                    case "AssetAllocationUSBondLong":
                        XmlToDataRow(drFundDetails, "AssetAllocationUSBondLong"); 
                        break;
                    case "AssetAllocationUSBondShort":
                        XmlToDataRow(drFundDetails, "AssetAllocationUSBondShort"); 
                        break;
                    case "AssetAllocationUSStockLong":
                        XmlToDataRow(drFundDetails, "AssetAllocationUSStockLong");
                        break;
                    case "AssetAllocationUSStockShort":
                        XmlToDataRow(drFundDetails, "AssetAllocationUSStockShort");
                        break;
                    case "BondPrimarySectorAssetBackedNet":
                        XmlToDataRow(drFundDetails, "AssetBacked");
                        break;
                    case "RegionAustralasiaLong":
                        XmlToDataRow(drFundDetails, "australasia");
                        break;
                    case "AverageCreditQualityLong":
                        XmlToDataRow(drFundDetails, "avgCreditQuality");
                        break;
                    case "EffectiveDurationLong":
                        XmlToDataRow(drFundDetails, "avgEffDuration"); 
                        break;
                    case "EffectiveMaturityLong":
                        XmlToDataRow(drFundDetails, "avgMaturity"); 
                        break;
                    case "AverageCouponLong":
                        XmlToDataRow(drFundDetails, "avgWeightedCoupon");
                        break;
                    case "CreditQualityB":
                        XmlToDataRow(drFundDetails, "b"); 
                        break;
                    case "StockSectorBasicMaterialsNet":
                        XmlToDataRow(drFundDetails, "StockSectorBasicMaterialsNet", "BasicMaterials");
                        break;
                    case "CreditQualityBB":
                        XmlToDataRow(drFundDetails, "bb"); 
                        break;
                    case "CreditQualityBBB":
                        XmlToDataRow(drFundDetails, "bbb"); 
                        break;
                    case "CreditQualityBelowB":
                        XmlToDataRow(drFundDetails, "belowB"); 
                        break;
                    case "AssetAllocationUSBondNet":
                        XmlToDataRow(drFundDetails, "USBond", "Bonds");
                        break;
                    case "BondSectorAssetbackedNet":
                        XmlToDataRow(drFundDetails, "BondSectorAssetbackedNet");
                        break;
                    case "BondSectorCashNet":
                        XmlToDataRow(drFundDetails, "BondSectorCashNet");
                        break;
                    case "BondSectorConvertibleNet":
                        XmlToDataRow(drFundDetails, "BondSectorConvertibleNet"); 
                        break;
                    case "BondSectorForeignCorpNet":
                        XmlToDataRow(drFundDetails, "BondSectorForeignCorpNet");
                        break;
                    case "BondSectorForeignGovtNet":
                        XmlToDataRow(drFundDetails, "BondSectorForeignGovtNet");
                        break;
                    case "BondSectorInflationPrNet":
                        XmlToDataRow(drFundDetails, "BondSectorInflationPrNet"); 
                        break;
                    case "BondSectorMortgageARMNet":
                        XmlToDataRow(drFundDetails, "BondSectorMortgageARMNet"); 
                        break;
                    case "BondSectorMortgageCMONet":
                        XmlToDataRow(drFundDetails, "BondSectorMortgageCMONet");
                        break;
                    case "BondSectorMtgPassthruNet":
                        XmlToDataRow(drFundDetails, "BondSectorMtgPassthruNet");
                        break;
                    case "BondSectorMunicipalNet":
                        XmlToDataRow(drFundDetails, "BondSectorMunicipalNet");
                        break;
                    case "BondSectorTIPSNet":
                        XmlToDataRow(drFundDetails, "BondSectorTIPSNet");
                        break;
                    case "BondSectorUSAgencyNet":
                        XmlToDataRow(drFundDetails, "BondSectorUSAgencyNet");
                        break;
                    case "BondSectorUSCorporateNet":
                        XmlToDataRow(drFundDetails, "BondSectorUSCorporateNet");
                        break;
                    case "BondSectorUSTreasuryNet":
                        XmlToDataRow(drFundDetails, "BondSectorUSTreasuryNet");
                        break;
                    case "ForecastedBookValueGrowthLong":
                        XmlToDataRow(drFundDetails, "bookValueGrowth", "pbRatioTTM");
                        break;
                    case "ProspectiveBookValueYieldLong":
                        XmlToDataRow(drFundDetails, "bookValueGrowth", "pbRatioTTM");
                        break;
                    case "CaptureRatioDownY1":
                        XmlToDataRow(drFundDetails, "CaptureRatioDown");
                        break;
                    case "CaptureRatioUpY1":
                        XmlToDataRow(drFundDetails, "CaptureRatioUp");
                        break;
                    case "AssetAllocationCashNet":
                        XmlToDataRow(drFundDetails, "Cash");
                        break;
                    case "ForecastedCashFlowGrowthLong":
                        XmlToDataRow(drFundDetails, "cashFlowGrowth");
                        break;
                    case "ProspectiveCashFlowYieldLong":
                        XmlToDataRow(drFundDetails, "PcRatioTTM");
                        break;
                    case "PortfolioDate":
                        XmlToDataRow(drFundDetails, "PortfolioDate");
                        break;
                    case "StockSectorConsumerCyclicalNet":
                        XmlToDataRow(drFundDetails, "StockSectorConsumerCyclicalNet", "ConsumerCyclical");
                        break;
                    case "StockSectorConsumerDefensiveNet":
                        XmlToDataRow(drFundDetails, "StockSectorConsumerDefensiveNet", "ConsumerDefensive"); 
                        break;
                    case "StockSectorConsumerDefensiveLong":
                        XmlToDataRow(drFundDetails, "ConsumerGoods");
                        break;
                    case "StockSectorConsumerCyclicalLong":
                        XmlToDataRow(drFundDetails, "ConsumerServices");
                        break;
                    case "BondPrimarySectorCorporateBondNet":
                        XmlToDataRow(drFundDetails, "Corporate");
                        break;
                    case "RegionDevelopedCountryNet":
                        XmlToDataRow(drFundDetails, "RegionDevelopedCountryNet", "DevelopedCountry");
                        break;
                    case "RegionEmergingMarketNet":
                        XmlToDataRow(drFundDetails, "RegionEmergingMarketNet", "EmergingMarket");
                        break;
                    case "StockSectorEnergyLong":
                        XmlToDataRow(drFundDetails, "Energy"); 
                        break;
                    case "EPS":
                        XmlToDataRow(drFundDetails, "EPS"); 
                        break;
                    case "EquityStyleBoxLong":
                        XmlToDataRow(drFundDetails, "EquityStyle");
                        break;
                    case "RegionEuropeEmergingLong":
                        XmlToDataRow(drFundDetails, "europeEmrg"); 
                        break;
                    case "RegionEuropeExEuroLong":
                        XmlToDataRow(drFundDetails, "EuropeExEuro"); 
                        break;
                    case "RegionEurozoneLong":
                        XmlToDataRow(drFundDetails, "Eurozone");
                        break;
                    case "StockSectorFinancialServicesLong":
                        XmlToDataRow(drFundDetails, "FinancialServices"); 
                        break;
                    case "FundNetAssets":
                        XmlToDataRow(drFundDetails, "FundNetAssets"); 
                        break;
                    case "MarketCapitalValueLong":
                        XmlToDataRow(drFundDetails, "geoAvgMarketCap");
                        break;
                    case "BondPrimarySectorGovernmentNet":
                        XmlToDataRow(drFundDetails, "Government");
                        break;
                    case "StockSectorHealthcareLong":
                        XmlToDataRow(drFundDetails, "Healthcare");
                        break;
                    case "Past3YearEarningsGrowthLong":
                        XmlToDataRow(drFundDetails, "historicalEarnGrowth");
                        break;
                    case "StockSectorIndustrialsLong":
                        XmlToDataRow(drFundDetails, "IndustrialMaterials");
                        break;
                    case "RegionJapanLong":
                        XmlToDataRow(drFundDetails, "japan");
                        break;
                    case "StyleBoxLargeBlendRescaledLong":
                        XmlToDataRow(drFundDetails, "LargeCore");
                        break;
                    case "StyleBoxLargeGrowthRescaledLong":
                        XmlToDataRow(drFundDetails, "LargeGrowth"); 
                        break;
                    case "StyleBoxLargeValueRescaledLong":
                        XmlToDataRow(drFundDetails, "LargeValue"); 
                        break;
                    case "RegionLatinAmericaLong":
                        XmlToDataRow(drFundDetails, "latinAmerica");
                        break;
                    case "Forecasted5YearEarningsGrowthLong":
                        XmlToDataRow(drFundDetails, "LongTermEarnGrowth");
                        break;
                    case "StyleBoxMidBlendRescaledLong":
                        XmlToDataRow(drFundDetails, "MediumCore");
                        break;
                    case "StyleBoxMidGrowthRescaledLong":
                        XmlToDataRow(drFundDetails, "MediumGrowth");
                        break;
                    case "StyleBoxMidValueRescaledLong":
                        XmlToDataRow(drFundDetails, "MediumValue");
                        break;
                    case "RegionMiddleEastLong":
                        XmlToDataRow(drFundDetails, "MiddleEast");
                        break;
                    case "InitialInvestment":
                        XmlToDataRow(drFundDetails, "MinInitPurchase"); 
                        break;
                    case "AssetAllocationNonUSStockNet":
                        XmlToDataRow(drFundDetails, "nonUsStocks"); 
                        break;
                    case "RegionCanadaLong":
                        XmlToDataRow(drFundDetails, "NorthAmericaCanada"); 
                        break;
                    case "RegionUnitedStatesLong":
                        XmlToDataRow(drFundDetails, "NorthAmericaUS");
                        break;
                    case "RegionNotClassifiedNet":
                        XmlToDataRow(drFundDetails, "RegionNotClassifiedNet", "NotClassified");
                        break;
                    case "CreditQualityNotRated":
                        XmlToDataRow(drFundDetails, "NRorNA"); 
                        break;
                    case "AssetAllocationOtherNet":
                        XmlToDataRow(drFundDetails, "Other"); 
                        break;
                    case "ProspectiveEarningsYieldLong":
                        XmlToDataRow(drFundDetails, "peRatioTTM", "priceProspectiveEarn"); 
                        break;
                    case "PrimaryIndexTreynorRatioY1":
                        XmlToDataRow(drFundDetails, "PrimaryIndexTreynorRatio"); 
                        break;
                    case "ProspectiveDividendYieldLong":
                        XmlToDataRow(drFundDetails, "prospectiveDividendYield"); 
                        break;
                    case "ProspectusGrossExpenseRatio":
                        XmlToDataRow(drFundDetails, "ProspectusGrossExpenseRatio");
                        break;
                    case "ProspectusNetExpenseRatio":
                        XmlToDataRow(drFundDetails, "ProspectusNetExpenseRatio");
                        break;
                    case "AnnualReportNetExpenseRatio":
                        XmlToDataRow(drFundDetails, "AuditedExpenseRatio");
                        break;
                    case "ProspectiveRevenueYieldLong":
                        XmlToDataRow(drFundDetails, "psRatioTTM"); 
                        break;
                    case "TrailingReturnY1CategoryRank":
                        XmlToDataRow(drFundDetails, "RankCat12Month"); 
                        break;
                    case "TrailingReturnY3CategoryRank":
                        XmlToDataRow(drFundDetails, "RankCat3Yr"); 
                        break;
                    case "TrailingReturnY5CategoryRank":
                        XmlToDataRow(drFundDetails, "RankCat5Yr"); 
                        break;
                    case "StockSectorRealEstateNet":
                        XmlToDataRow(drFundDetails, "StockSectorRealEstateNet", "RealEstate");
                        break;
                    case "RegionAfricaNet":
                        XmlToDataRow(drFundDetails, "RegionAfricaNet"); 
                        break;
                    case "RegionAsiaDevelopedNet":
                        XmlToDataRow(drFundDetails, "RegionAsiaDevelopedNet"); 
                        break;
                    case "RegionAustralasiaNet":
                        XmlToDataRow(drFundDetails, "RegionAustralasiaNet"); 
                        break;
                    case "RegionCanadaNet":
                        XmlToDataRow(drFundDetails, "RegionCanadaNet"); 
                        break;
                    case "RegionEuropeEmergingNet":
                        XmlToDataRow(drFundDetails, "RegionEuropeEmergingNet"); 
                        break;
                    case "RegionEuropeExEuroNet":
                        XmlToDataRow(drFundDetails, "RegionEuropeExEuroNet"); 
                        break;
                    case "RegionEurozoneNet":
                        XmlToDataRow(drFundDetails, "RegionEurozoneNet"); 
                        break;
                    case "RegionJapanNet":
                        XmlToDataRow(drFundDetails, "RegionJapanNet"); 
                        break;
                    case "RegionLatinAmericaNet":
                        XmlToDataRow(drFundDetails, "RegionLatinAmericaNet"); 
                        break;
                    case "RegionMiddleEastNet":
                        XmlToDataRow(drFundDetails, "RegionMiddleEastNet"); 
                        break;
                    case "RegionUnitedKingdomNet":
                        XmlToDataRow(drFundDetails, "RegionUnitedKingdomNet"); 
                        break;
                    case "RegionUnitedStatesNet":
                        XmlToDataRow(drFundDetails, "RegionUnitedStatesNet"); 
                        break;
                    case "Actual12B1":
                        XmlToDataRow(drFundDetails, "RevenueSharing"); 
                        break;
                    case "ForecastedRevenueGrowthLong":
                        XmlToDataRow(drFundDetails, "salesGrowth"); 
                        break;
                    case "SECYield":
                        XmlToDataRow(drFundDetails, "SECYield");
                        break;
                    case "SharpeRatioY1":
                        XmlToDataRow(drFundDetails, "SharpeRatio");
                        break;
                    case "StyleBoxSmallBlendRescaledLong":
                        XmlToDataRow(drFundDetails, "SmallCore");
                        break;
                    case "StyleBoxSmallGrowthRescaledLong":
                        XmlToDataRow(drFundDetails, "smallGrowth");
                        break;
                    case "StyleBoxSmallValueRescaledLong":
                        XmlToDataRow(drFundDetails, "smallValue");
                        break;
                    case "SortinoRatioY1":
                        XmlToDataRow(drFundDetails, "SortinoRatio");
                        break;
                    case "StandardDeviationY3":
                        XmlToDataRow(drFundDetails, "StdDev3yr");
                        break;
                    case "StandardDeviationY5":
                        XmlToDataRow(drFundDetails, "StdDev5Yr");
                        break;
                    case "StockSectorCommunicationServicesNet":
                        XmlToDataRow(drFundDetails, "StockSectorCommunicationServicesNet");
                        break;
                    case "StockSectorEnergyNet":
                        XmlToDataRow(drFundDetails, "StockSectorEnergyNet");
                        break;
                    case "StockSectorFinancialServicesNet":
                        XmlToDataRow(drFundDetails, "StockSectorFinancialServicesNet");
                        break;
                    case "StockSectorHealthcareNet":
                        XmlToDataRow(drFundDetails, "StockSectorHealthcareNet");
                        break;
                    case "StockSectorIndustrialsNet":
                        XmlToDataRow(drFundDetails, "StockSectorIndustrialsNet");
                        break;
                    case "StockSectorTechnologyNet":
                        XmlToDataRow(drFundDetails, "StockSectorTechnologyNet", "Technology");
                        break;
                    case "StockSectorUtilitiesNet":
                        XmlToDataRow(drFundDetails, "StockSectorUtilitiesNet");
                        break;
                    case "StockSectorCommunicationServicesLong":
                        XmlToDataRow(drFundDetails, "Telcom");
                        break;
                    case "WeightingTop10Holdings":
                        XmlToDataRow(drFundDetails, "Top10Holdings");
                        break;
                    case "NumberOfHoldingNet":
                        XmlToDataRow(drFundDetails, "TotNumOfHoldings");
                        break;
                    case "TrailingMarketReturnY1":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "TotRet12Mo");
                        break;
                    case "TrailingReturnY1":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "TotRet12Mo");
                        break;
                    case "TrailingMarketReturnY10":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "TotRetAnnlzd10Yr");
                        break;
                    case "TrailingReturnY10":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "TotRetAnnlzd10Yr");
                        break;
                    case "TrailingMarketReturnY15":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "TrailingReturnY15");
                        break;
                    case "TrailingMarketReturnY3":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "TotRetAnnlzd3Yr");
                        break;
                    case "TrailingReturnY3":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "TotRetAnnlzd3Yr");
                        break;
                    case "TrailingMarketReturnY5":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "TotRetAnnlzd5Yr");
                        break;
                    case "TrailingReturnY5":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "TotRetAnnlzd5Yr");
                        break;
                    case "TrailingMarketReturnSinceInception":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "TotRetSinceIncept");
                        break;
                    case "TrailingReturnSinceInception":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "TotRetSinceIncept");
                        break;
                    case "TrailingMarketReturnM1":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "TrailingReturnM1");
                        break;
                    case "TrailingReturnM1":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "TrailingReturnM1");
                        break;
                    case "TrailingMarketReturnM3":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "TrailingReturnM3");
                        break;
                    case "TrailingReturnM3":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "TrailingReturnM3");
                        break;
                    case "TrailingMarketReturnM6":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "TrailingReturnM6");
                        break;
                    case "TrailingReturnM6":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "TrailingReturnM6");
                        break;
                    case "TrailingReturnY15":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "TrailingReturnY15");
                        break;
                    case "TrailingMarketReturnYTD":
                        if (this.PackageType == PackageTypes.Index)
                            XmlToDataRow(drFundDetails, "TrailingReturnYTD");
                        break;
                    case "TrailingReturnYTD":
                        if (this.PackageType == PackageTypes.Fund || this.PackageType == PackageTypes.Category)
                            XmlToDataRow(drFundDetails, "TrailingReturnYTD");
                        break;
                    case "TurnoverRatio":
                        XmlToDataRow(drFundDetails, "turnOverRatio");
                        break;
                    case "TrailingY1Yield":
                        XmlToDataRow(drFundDetails, "twelveMonthYield");
                        break;
                    case "RegionUnitedKingdomLong":
                        XmlToDataRow(drFundDetails, "unitedKingdom");
                        break;
                    case "BondSuperSectorGovernmentLong":
                        XmlToDataRow(drFundDetails, "UsGovt");
                        break;
                    case "AssetAllocationUSStockNet":
                        XmlToDataRow(drFundDetails, "usStocks");
                        break;
                    case "StockSectorUtilitiesLong":
                        XmlToDataRow(drFundDetails, "Utility");
                        break;
                    }
            }

            string _eventLogEntry = "XML data tranformation complete." + Environment.NewLine
                        + "         Rows Affected - Funds................" + ResultSet.Fund.Rows.Count.ToString("#,#") + Environment.NewLine
                        + "         Rows Affected - Fund Details........." + ResultSet.FundDetail.Rows.Count.ToString("#,#") + Environment.NewLine
                        + "         Rows Affected - Managers............." + ResultSet.Manager.Rows.Count.ToString("#,#") + Environment.NewLine
                        + "         Rows Affected - Manager Education...." + ResultSet.ManagerEducation.Rows.Count.ToString("#,#") + Environment.NewLine
                        + "         Rows Affected - Manager Credentials.." + ResultSet.ManagerCredential.Rows.Count.ToString("#,#") + Environment.NewLine
                        + "         Rows Affected - Advisors............." + ResultSet.Advisor.Rows.Count.ToString("#,#");

            WriteToEventLog(_eventLogEntry, 0.4m);
        }

        private void ReportProgress()
        {
            if (this.PackageType == XmlParser.PackageTypes.Fund)
            {
                if (fundCount > 3125 && !oneEighthCompleted)
                {
                    PercentComplete = 0.18m;
                    oneEighthCompleted = true;
                }
                else if (fundCount > 6250 && !twoEighthCompleted)
                {
                    PercentComplete = 0.21m;
                    twoEighthCompleted = true;
                }
                else if (fundCount > 9375 && !threeEighthCompleted)
                {
                    PercentComplete = 0.25m;
                    threeEighthCompleted = true;
                }
                else if (fundCount > 12500 && !fourEighthCompleted)
                {
                    PercentComplete = 0.28m;
                    fourEighthCompleted = true;
                }
                else if (fundCount > 15625 && !fiveEighthCompleted)
                {
                    PercentComplete = 0.32m;
                    fiveEighthCompleted = true;
                }
                else if (fundCount > 18750 && !sixEighthCompleted)
                {
                    PercentComplete = 0.35m;
                    sixEighthCompleted = true;
                }
                else if (fundCount > 21875 && !sevenEighthCompleted)
                {
                    PercentComplete = 0.38m;
                    sevenEighthCompleted = true;
                }
            }
            else
            {
                if (fundCount > 250 && !oneEighthCompleted)
                {
                    PercentComplete = 0.18m;
                    oneEighthCompleted = true;
                }
                else if (fundCount > 500 && !twoEighthCompleted)
                {
                    PercentComplete = 0.21m;
                    twoEighthCompleted = true;
                }
                else if (fundCount > 750 && !threeEighthCompleted)
                {
                    PercentComplete = 0.25m;
                    threeEighthCompleted = true;
                }
                else if (fundCount > 1000 && !fourEighthCompleted)
                {
                    PercentComplete = 0.28m;
                    fourEighthCompleted = true;
                }
                else if (fundCount > 1250 && !fiveEighthCompleted)
                {
                    PercentComplete = 0.32m;
                    fiveEighthCompleted = true;
                }
                else if (fundCount > 1500 && !sixEighthCompleted)
                {
                    PercentComplete = 0.35m;
                    sixEighthCompleted = true;
                }
                else if (fundCount > 1750 && !sevenEighthCompleted)
                {
                    PercentComplete = 0.38m;
                    sevenEighthCompleted = true;
                }
            }
        }
    }
}
