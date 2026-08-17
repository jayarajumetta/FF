using InsuranceAutomation.Core;
using InsuranceAutomation.PLDC.Pages.Locators;

namespace InsuranceAutomation.PLDC.Pages;

public sealed class VehiclesPage
{
    private readonly VehiclesLocators _locators;
    private readonly ScenarioData _data;
    private readonly UiActions _ui;

    public VehiclesPage(BrowserSession browser, ScenarioData data, UiActions ui)
    {
        _locators = new VehiclesLocators(browser.Page);
        _data = data;
        _ui = ui;
    }

    // Business step: I review the driver information summary
    public async Task ReviewTheDriverInformationSummaryAsync()
    {
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0053_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.Single))
        {
            await _ui.VerifyAsync(_locators.Single, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0054_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.MaritalStatusSingle))
        {
            await _ui.ClickAsync(_locators.MaritalStatusSingle);
        }
        if (_data.Condition("'Marital Status' != \"Married\""))
        {
            await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' != \"Divorced\""))
        {
            await _ui.ClickAsync(_locators.Divorced);
        }
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
            await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
            await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
            await _ui.ClickAsync(_locators.Divorced);
        }
        // EQDriverEducationLevel_5a720bPage.DriverEducationLevel_0055_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.HighSchoolDiplomaOrGED))
        {
            await _ui.VerifyAsync(_locators.HighSchoolDiplomaOrGED, _data.Resolve("True"), "Enabled");
        }
        // EQDriverEducationLevel_5a720bPage.DriverEducationLevel_0056_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.MDNJEducationLevelUnknown))
        {
            await _ui.ClickAsync(_locators.MDNJEducationLevelUnknown);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Unknown\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"HighSchool\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"HighSchool\""))
        {
            await _ui.ClickAsync(_locators.HighSchoolDiplomaOrGED);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Trade\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Trade\""))
        {
            await _ui.ClickAsync(_locators.VocationalOrTradeSchoolDegree);
        }
        if (_data.Condition("MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\""))
        {
            await _ui.SelectAsync(_locators.MoreOptionsEdu, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"SomeCollege\""))
        {
            await _ui.WaitAsync(_locators.SomeCollege, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"SomeCollege\""))
        {
            await _ui.ClickAsync(_locators.SomeCollege);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"InCollege\""))
        {
            await _ui.WaitAsync(_locators.CurrentlyInCollege, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"InCollege\""))
        {
            await _ui.ClickAsync(_locators.CurrentlyInCollege);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"CollegeDegree\""))
        {
            await _ui.WaitAsync(_locators.CollegeDegreeGraduateWork, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"CollegeDegree\""))
        {
            await _ui.ClickAsync(_locators.CollegeDegreeGraduateWork);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.WaitAsync(_locators.GraduateDegreeJDMasters, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.ClickAsync(_locators.GraduateDegreeJDMasters);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.WaitAsync(_locators.PostGraduateDegreeMedicalDegreePhDEdDEtc, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.ClickAsync(_locators.PostGraduateDegreeMedicalDegreePhDEdDEtc);
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0057_8f9ff6Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Condition verify relationship spouse button exist; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.Spouse, _data.Resolve("Exists"), "");
        }
        await _ui.ClickAsync(_locators.AccountOwner);
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0058_8f9ff6Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Then Relationship for account owner exist; 'Policy Type' != \"Cycle\""))
        {
            await _ui.SelectAsync(_locators.RelationshipToAccountOwnerNULL, _data.Resolve("{{data:select_relationship_to_account_owner_null_122}}"));
        }
        if (_data.Condition("'Relationship to Account Owner' != NULL"))
        {
            await _ui.ClickAsync(_locators.AccountOwner);
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0059_8f9ff6Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Condition Check if Relationship is account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.AccountOwnerReadOnly, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0060_8f9ff6Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Then Relationship is account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.AccountOwnerReadOnly, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0061_8f9ff6Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Else Make script fail due to Relationship other than account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.AccountOwner);
            await _ui.PressAsync(_locators.AccountOwner, "Click");
            await _ui.PressAsync(_locators.AccountOwner, "scroll[2]");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatusCycle_0062_8f9ff6Async
        if (_data.Condition("'Policy Type' == \"Cycle\""))
        {
            await _ui.WaitAsync(_locators.IsThisDriverANamedInsured, "Visible");
        }
        if (_data.Condition("'Named Insured?' == \"PrimaryNamedIns\""))
        {
            await _ui.ClickAsync(_locators.PrimaryNamedInsured);
            await _ui.PressAsync(_locators.PrimaryNamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NamedIns\""))
        {
            await _ui.ClickAsync(_locators.NamedInsured);
            await _ui.PressAsync(_locators.NamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NotNamedIns\""))
        {
            await _ui.ClickAsync(_locators.NotANamedInsured);
            await _ui.PressAsync(_locators.NotANamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Related);
            await _ui.PressAsync(_locators.Related, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
            await _ui.PressAsync(_locators.Related, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"NoCycleLicense\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"NoCycleLicense\""))
        {
            await _ui.SelectAsync(_locators.NoCycleLicense, _data.Resolve(""));
        }
        if (_data.Condition("'Operator Status' != \"Assigned\" AND 'Operator Status' != \"NoCycleLicense\" AND 'Operator Status' != \"Related\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Military\""))
        {
            await _ui.ClickAsync(_locators.Military);
        }
        if (_data.Condition("'Operator Status' == \"Missionary\""))
        {
            await _ui.ClickAsync(_locators.Missionary);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.SelectAsync(_locators.NonDriver, _data.Resolve(""));
        }
        if (_data.Condition("'Operator Status' == \"OtherIns\""))
        {
            await _ui.ClickAsync(_locators.OtherInsurance);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.WaitAsync(_locators.NonDriverReason, "Visible");
        }
        if (_data.Condition("'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_143}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_144}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_145}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_146}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_147}}"));
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0063_8f9ff6Async
        if (_data.Condition("'Policy Type' != \"Cycle\""))
        {
            await _ui.WaitAsync(_locators.IsThisDriverANamedInsured, "Visible");
        }
        if (_data.Condition("'Named Insured?' == \"PrimaryNamedIns\""))
        {
            await _ui.ClickAsync(_locators.PrimaryNamedInsured);
            await _ui.PressAsync(_locators.PrimaryNamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NamedIns\""))
        {
            await _ui.ClickAsync(_locators.NamedInsured);
            await _ui.PressAsync(_locators.NamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NotNamedIns\""))
        {
            await _ui.ClickAsync(_locators.NotANamedInsured);
            await _ui.PressAsync(_locators.NotANamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.NonDriver);
            await _ui.PressAsync(_locators.NonDriver, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
        }
        if (_data.Condition("'Operator Status' == \"Military\""))
        {
            await _ui.ClickAsync(_locators.Military);
        }
        if (_data.Condition("'Operator Status' == \"Missionary\""))
        {
            await _ui.ClickAsync(_locators.Missionary);
        }
        if (_data.Condition("'Operator Status' == \"OtherIns\""))
        {
            await _ui.ClickAsync(_locators.OtherInsurance);
        }
        if (_data.Condition("'Operator Status' == \"Roomate\""))
        {
            await _ui.ClickAsync(_locators.Roommate);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.WaitAsync(_locators.NonDriverReason, "Visible");
        }
        if (_data.Condition("'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.NeverLicensed);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.Underage);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.MedicalCondition);
        }
        if (_data.Condition("'If NonDriver: Reason' != \"NeverLicensed\" AND 'If NonDriver: Reason' != \"Underage\" AND 'If NonDriver: Reason' != \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.SelectAsync(_locators.MoreOptionsNonDriver, _data.Resolve(""));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.Surrendered);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.PermitDriver);
        }
        // EQDriverLicenseTime_01b659Page.LicenseInfo_0064_8f9ff6Async
        if (_data.Condition("'State Licensed(XX)' != NULL"))
        {
            await _ui.FillAsync(_locators.LicenseState, _data.Get("AL_ClientData.State"));
        }
        if (_data.Condition("'Drivers License #' != NULL"))
        {
            await _ui.FillAsync(_locators.DriverSLicenseNumber, _data.Resolve("{{data:driver_s_license_number_169}}"));
            await _ui.PressAsync(_locators.DriverSLicenseNumber, "CTRL+A");
        }
        if (_data.Condition("'Drivers License #' != NULL"))
        {
            await _ui.FillAsync(_locators.DriverSLicenseNumber, _data.Get("AL_ClientData.DL Number"));
        }
        await _ui.FillAsync(_locators.YrsLicensedCurrentState, _data.Resolve("{{data:yrs_licensed_current_state_171}}"));
        await _ui.PressAsync(_locators.YrsLicensedCurrentState, "CTRL+A");
        await _ui.FillAsync(_locators.YrsLicensedCurrentState, _data.Resolve("{{data:yrs_licensed_current_state_172}}"));
        await _ui.FillAsync(_locators.MonthsLicensedCurrentState, _data.Resolve("{{data:months_licensed_current_state_173}}"));
        await _ui.PressAsync(_locators.MonthsLicensedCurrentState, "CTRL+A");
        await _ui.FillAsync(_locators.MonthsLicensedCurrentState, _data.Resolve("{{data:months_licensed_current_state_174}}"));
        if (_data.Condition("'State' == \"TX\""))
        {
            await _ui.FillAsync(_locators.DaysOperatedUninsured, _data.Resolve("{{data:daysoperateduninsured_175}}"));
        }
        if (_data.Condition("'State' == \"CA\""))
        {
            await _ui.FillAsync(_locators.YrsLicensedAllStates, _data.Resolve("{{data:yrslicensed_all_states_176}}"));
            await _ui.PressAsync(_locators.YrsLicensedAllStates, "CTRL+A");
        }
        if (_data.Condition("'State' == \"CA\""))
        {
            await _ui.FillAsync(_locators.YrsLicensedAllStates, _data.Resolve("{{data:yrslicensed_all_states_177}}"));
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.NoD053A);
            await _ui.PressAsync(_locators.NoD053A, "Click");
            await _ui.PressAsync(_locators.NoD053A, "Scroll[2]");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0065_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove))
        {
            await _ui.VerifyAsync(_locators.WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0066_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.NoPreviouslyInsured))
        {
            await _ui.SelectAsync(_locators.NoPreviouslyInsured, _data.Resolve(""));
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0067_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.PriorCarrierName))
        {
            await _ui.VerifyAsync(_locators.PriorCarrierName, _data.Resolve("Exists"), "");
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0068_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue9CB7A))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0069_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.NoNeedWasNotLicensed))
        {
            await _ui.VerifyAsync(_locators.NoNeedWasNotLicensed, _data.Resolve("Visible"), "");
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0070_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.NoNeedWasNotLicensed))
        {
            await _ui.ClickAsync(_locators.NoNeedWasNotLicensed);
            await _ui.PressAsync(_locators.NoNeedWasNotLicensed, "End");
            await _ui.PressAsync(_locators.NoNeedWasNotLicensed, "Click");
        }
        await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        // EQPriorInsuranceInfo_a40db0Page.SaveContinue_0071_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue9CB7A))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        }
        // EQExpiredLicensePopUp_ac02e7Page.EQExpiredLicensePopUp_0072_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.CONTINUED555D))
        {
            await _ui.WaitAsync(_locators.CONTINUED555D, "Exists");
        }
        // EQExpiredLicensePopUp_ac02e7Page.EQExpiredLicensePopUp_0073_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.CONTINUED555D))
        {
            await _ui.ClickAsync(_locators.CONTINUED555D);
        }
    }

    // Business step: I complete vehicle Summary 1st Cycle Summary
    public async Task CompleteVehicleSummary1stCycleSummaryAsync()
    {
        // EQCyclePreFillSelection_50c48bPage.CycleSelection_0081_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.SelectVehicle))
        {
            await _ui.WaitAsync(_locators.SelectVehicle, "Visible");
        }
        // EQCyclePreFillSelection_50c48bPage.CycleSelection_0082_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.AdditionalVehicleSF5D93))
        {
            await _ui.ClickAsync(_locators.AdditionalVehicleSF5D93);
        }
        await _ui.ClickAsync(_locators.CyclePreFillSelectionNext);
        // EQ1stCycle_d9650fPage.CycleSummary_0083_8f9ff6Async
        await _ui.WaitAsync(_locators.VIN8EE56, "True");
        await _ui.FillAsync(_locators.VIN8EE56, _data.Resolve("{{data:vin_201}}"));
        await _ui.PressAsync(_locators.VIN8EE56, "POST:TAB");
        await _ui.PressAsync(_locators.VIN8EE56, "Tab");
        await _ui.WaitAsync(_locators.PleaseSelectTheVehicleCD741, "Visible");
        await _ui.ClickAsync(_locators.Cycle1C1864);
        if (_data.Condition("'Primary Use' == \"Pleasure Use\""))
        {
            await _ui.ClickAsync(_locators.PleasureUse);
        }
        if (_data.Condition("'Primary Use' == \"Not Pleasure Use\""))
        {
            await _ui.SelectAsync(_locators.NotPleasureUse, _data.Resolve(""));
        }
        if (_data.Condition("'Primary Use' == \"Under Construction\""))
        {
            await _ui.ClickAsync(_locators.UnderConstruction);
        }
        if (_data.Condition("'Loan/Leased/Own' == \"Loan\""))
        {
            await _ui.ClickAsync(_locators.LoanED36C);
        }
        if (_data.Condition("'Loan/Leased/Own' == \"Leased\""))
        {
            await _ui.ClickAsync(_locators.Leased87268);
        }
        if (_data.Condition("'Loan/Leased/Own' == \"Own\""))
        {
            await _ui.ClickAsync(_locators.OwnD044E);
        }
        if (_data.Condition("State == \"OK\""))
        {
            await _ui.SelectAsync(_locators.NoRegisteredFedTribe, _data.Resolve(""));
        }
        await _ui.WaitAsync(_locators.DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications051FD, "Visible");
        if (_data.Condition("'NonFactory Mods?' == \"Yes\""))
        {
            await _ui.SelectAsync(_locators.Yes, _data.Resolve(""));
        }
        if (_data.Condition("'NonFactory Mods?' == \"No\""))
        {
            await _ui.SelectAsync(_locators.NoD9E4D, _data.Resolve(""));
        }
        if (_data.Condition("'NonFactory Mods?' == \"Yes\""))
        {
            await _ui.WaitAsync(_locators.LblDescriptionOfMods, "Visible");
        }
        if (_data.Condition("'NonFactory Mods?' == \"Yes\""))
        {
            await _ui.FillAsync(_locators.DescriptionOfMods, _data.Resolve("{{data:description_of_mods_216}}"));
        }
        if (_data.Condition("'Primary Use' == \"Under Construction\""))
        {
            await _ui.FillAsync(_locators.CurrentValue, _data.Get("Current Value(UnderConstruction)"));
        }
        if (_data.Condition("State == \"NY\" OR State == \"NJ\" OR State == \"CA\""))
        {
            await _ui.FillAsync(_locators.AnnualMileage12A49, _data.Resolve("{{data:annual_mileage_218}}"));
        }
        await _ui.ClickAsync(_locators.SaveAndContinue8EF26);
    }

    // Business step: I complete vehicle Summary Add Cycle/Next
    public async Task CompleteVehicleSummaryAddCycleNextAsync()
    {
        // EQAddCycleNext_1286f9Page.AddCycleNext_0084_8f9ff6Async
        if (_data.Condition("'Additional Cycle?' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.AddAdditionalVehicle);
        }
        if (_data.Condition("'Additional Cycle?' == \"No\""))
        {
            await _ui.ClickAsync(_locators.AddCycleNextNext);
        }
    }

    // Business step: I complete vehicle Summary Vintage Cycle
    public async Task CompleteVehicleSummaryVintageCycleAsync()
    {
        // EQVintageCycle_b2e4eePage.VintageCycle_0085_8f9ff6Async
        await _ui.WaitAsync(_locators.CycleVIN, "True");
        await _ui.FillAsync(_locators.CycleVIN, _data.Resolve("{{data:cycle_vin_223}}"));
        await _ui.PressAsync(_locators.CycleVIN, "POST:TAB");
        await _ui.PressAsync(_locators.CycleVIN, "Tab");
        await _ui.WaitAsync(_locators.PleaseSelectTheVehicleBBB72, "Visible");
        await _ui.ClickAsync(_locators.Cycle1734D7);
        await _ui.WaitAsync(_locators.VehicleType, "Visible");
        await _ui.ClickAsync(_locators.Vintage);
        await _ui.WaitAsync(_locators.IsThisVehicleOwnedOrFinanced, "Visible");
        if (_data.Condition("'Loan/Leased/Own' == \"Loan\""))
        {
            await _ui.ClickAsync(_locators.Loan49242);
        }
        if (_data.Condition("'Loan/Leased/Own' == \"Leased\""))
        {
            await _ui.ClickAsync(_locators.Leased26B32);
        }
        if (_data.Condition("'Loan/Leased/Own' == \"Own\""))
        {
            await _ui.ClickAsync(_locators.Own7C709);
        }
        await _ui.WaitAsync(_locators.DoesThisVehicleHaveAnyNonFactoryAdditionsAlterationsOrModifications21ABD, "Visible");
        await _ui.SelectAsync(_locators.No7C269, _data.Resolve(""));
        await _ui.FillAsync(_locators.AgreedValueF302B, _data.Resolve("{{data:agreed_value_235}}"));
        await _ui.FillAsync(_locators.AppraisalDateD909C, _data.Resolve("{{data:appraisal_date_236}}"));
        await _ui.ClickAsync(_locators.SaveAndContinueBE6CD);
        // EQOwnedPopup_4a587aPage.OwnedPopup_0086_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.LblOwnedPopup))
        {
            await _ui.VerifyAsync(_locators.LblOwnedPopup, _data.Resolve("Visible"), "");
        }
        // EQOwnedPopup_4a587aPage.OwnedPopup_0087_8f9ff6Async
        if (await _ui.ExistsAsync(_locators.CONTINUEF07C7))
        {
            await _ui.ClickAsync(_locators.CONTINUEF07C7);
        }
    }

    // Business step: I complete vehicle Summary Add Cycle/Next for add additional vehicle
    public async Task CompleteVehicleSummaryAddCycleNextForAddAdditionalVehicleAsync()
    {
        // EQAddCycleNext_1286f9Page.AddCycleNext_0088_8f9ff6Async
        if (_data.Condition("'Additional Cycle?' == \"Yes\""))
        {
            await _ui.ClickAsync(_locators.AddAdditionalVehicle);
        }
        if (_data.Condition("'Additional Cycle?' == \"No\""))
        {
            await _ui.ClickAsync(_locators.AddCycleNextNext);
        }
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0089_8f9ff6Async
        _data.Set("Driver 1 Vehicle", _data.Resolve("{{data:driver_1_vehicle}}"));
        _data.Set("Driver 1 Principal Occasional", _data.Resolve("{{data:driver_1_principal_occasional}}"));
        _data.Set("Driver 2 Vehicle", _data.Get("Driver 2 Vehicle"));
        _data.Set("Driver 2 Principal Occasional", _data.Get("Driver 2 Principal Occasional"));
        _data.Set("Driver 3 Vehicle", _data.Get("Driver 3 Vehicle"));
        _data.Set("Driver 3 Principal Occasional", _data.Get("Driver 3 Principal Occasional"));
        _data.Set("Driver 4 Vehicle", _data.Get("Driver 4 Vehicle"));
        _data.Set("Driver 4 Principal Occasional", _data.Get("Driver 4 Principal Occasional"));
        _data.Set("Driver 5 Vehicle", _data.Get("Driver 5 Vehicle"));
        _data.Set("Driver 5 Principal Occasional", _data.Get("Driver 5 Principal Occasional"));
    }

    // Business step: I complete auto AddlCov Vehicle Coverages
    public async Task CompleteAutoAddlCovVehicleCoveragesAsync()
    {
        // EQVehicleCoveragesSection_2f4d8bPage.EQVehicleCoveragesSection_0140_8f9ff6Async
        if (_data.Condition("'UMPD/UIMPD_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV1);
        }
        if (_data.Condition("'UMPD Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle1);
            await _ui.PressAsync(_locators.UMPDCoverageVehicle1, "Click");
            await _ui.PressAsync(_locators.UMPDCoverageVehicle1, "scroll[2]");
        }
        if (_data.Condition("'UMPD Coverage_V1' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV1);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV1);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV1, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV1, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV1);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V1' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV1);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV1, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV1, "Scroll[2]");
        }
        if (_data.Condition("'UMPD/UIMPD_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV2);
        }
        if (_data.Condition("'UMPD Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle2);
        }
        if (_data.Condition("'UMPD Coverage_V2' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV2);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV2);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV2, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV2, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV2);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV2);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV2, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV2, "scroll[2]");
        }
        if (_data.Condition("'Towing and Labor' != NULL"))
        {
            await _ui.SelectAsync(_locators.NoCoverageV1Towing, _data.Resolve(""));
        }
        if (_data.Condition("'UMPD/UIMPD_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV3);
        }
        if (_data.Condition("'UMPD Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle3);
        }
        if (_data.Condition("'UMPD Coverage_V3' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV3);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV3);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV3, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV3, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV3);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V3' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV3);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV3, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV3, "scroll[2]");
        }
        if (_data.Condition("'Cycle Accessories_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.CycleAccessoriesV3);
        }
        if (_data.Condition("'Original Parts_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.OriginalPartsV3);
        }
        if (_data.Condition("'UMPD/UIMPD_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV4);
        }
        if (_data.Condition("'UMPD Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle4);
        }
        if (_data.Condition("'UMPD Coverage_V4' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV4);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV4);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV4, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV4, "end");
        }
        if (_data.Condition("'Theft Deductible_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV4);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V4' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV4);
        }
        if (_data.Condition("'Cycle Accessories_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.CycleAccessoriesV4);
        }
        if (_data.Condition("'Original Parts_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.OriginalPartsV4);
        }
    }

    // Business step: I review the driver information summary
    public async Task ReviewTheDriverInformationSummaryAsync2()
    {
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0053_8f5301Async
        if (await _ui.ExistsAsync(_locators.Single))
        {
            await _ui.VerifyAsync(_locators.Single, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0054_8f5301Async
        if (await _ui.ExistsAsync(_locators.MaritalStatusSingle))
        {
            await _ui.ClickAsync(_locators.MaritalStatusSingle);
        }
        if (_data.Condition("'Marital Status' != \"Married\""))
        {
            await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' != \"Divorced\""))
        {
            await _ui.ClickAsync(_locators.Divorced);
        }
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
            await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
            await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
            await _ui.ClickAsync(_locators.Divorced);
        }
        // EQDriverEducationLevel_5a720bPage.DriverEducationLevel_0055_8f5301Async
        if (await _ui.ExistsAsync(_locators.HighSchoolDiplomaOrGED))
        {
            await _ui.VerifyAsync(_locators.HighSchoolDiplomaOrGED, _data.Resolve("True"), "Enabled");
        }
        // EQDriverEducationLevel_5a720bPage.DriverEducationLevel_0056_8f5301Async
        if (await _ui.ExistsAsync(_locators.MDNJEducationLevelUnknown))
        {
            await _ui.ClickAsync(_locators.MDNJEducationLevelUnknown);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Unknown\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"HighSchool\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"HighSchool\""))
        {
            await _ui.ClickAsync(_locators.HighSchoolDiplomaOrGED);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Trade\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Trade\""))
        {
            await _ui.ClickAsync(_locators.VocationalOrTradeSchoolDegree);
        }
        if (_data.Condition("MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\""))
        {
            await _ui.SelectAsync(_locators.MoreOptionsEdu, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"SomeCollege\""))
        {
            await _ui.WaitAsync(_locators.SomeCollege, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"SomeCollege\""))
        {
            await _ui.ClickAsync(_locators.SomeCollege);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"InCollege\""))
        {
            await _ui.WaitAsync(_locators.CurrentlyInCollege, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"InCollege\""))
        {
            await _ui.ClickAsync(_locators.CurrentlyInCollege);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"CollegeDegree\""))
        {
            await _ui.WaitAsync(_locators.CollegeDegreeGraduateWork, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"CollegeDegree\""))
        {
            await _ui.ClickAsync(_locators.CollegeDegreeGraduateWork);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.WaitAsync(_locators.GraduateDegreeJDMasters, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.ClickAsync(_locators.GraduateDegreeJDMasters);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.WaitAsync(_locators.PostGraduateDegreeMedicalDegreePhDEdDEtc, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.ClickAsync(_locators.PostGraduateDegreeMedicalDegreePhDEdDEtc);
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0057_8f5301Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Condition verify relationship spouse button exist; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.Spouse, _data.Resolve("Exists"), "");
        }
        await _ui.ClickAsync(_locators.AccountOwner);
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0058_8f5301Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Then Relationship for account owner exist; 'Policy Type' != \"Cycle\""))
        {
            await _ui.SelectAsync(_locators.RelationshipToAccountOwnerNULL, _data.Resolve("{{data:select_relationship_to_account_owner_null_122}}"));
        }
        if (_data.Condition("'Relationship to Account Owner' != NULL"))
        {
            await _ui.ClickAsync(_locators.AccountOwner);
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0059_8f5301Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Condition Check if Relationship is account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.AccountOwnerReadOnly, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0060_8f5301Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Then Relationship is account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.AccountOwnerReadOnly, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0061_8f5301Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Else Make script fail due to Relationship other than account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.AccountOwner);
            await _ui.PressAsync(_locators.AccountOwner, "Click");
            await _ui.PressAsync(_locators.AccountOwner, "scroll[2]");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatusCycle_0062_8f5301Async
        if (_data.Condition("'Policy Type' == \"Cycle\""))
        {
            await _ui.WaitAsync(_locators.IsThisDriverANamedInsured, "Visible");
        }
        if (_data.Condition("'Named Insured?' == \"PrimaryNamedIns\""))
        {
            await _ui.ClickAsync(_locators.PrimaryNamedInsured);
            await _ui.PressAsync(_locators.PrimaryNamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NamedIns\""))
        {
            await _ui.ClickAsync(_locators.NamedInsured);
            await _ui.PressAsync(_locators.NamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NotNamedIns\""))
        {
            await _ui.ClickAsync(_locators.NotANamedInsured);
            await _ui.PressAsync(_locators.NotANamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Related);
            await _ui.PressAsync(_locators.Related, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
            await _ui.PressAsync(_locators.Related, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"NoCycleLicense\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"NoCycleLicense\""))
        {
            await _ui.SelectAsync(_locators.NoCycleLicense, _data.Resolve(""));
        }
        if (_data.Condition("'Operator Status' != \"Assigned\" AND 'Operator Status' != \"NoCycleLicense\" AND 'Operator Status' != \"Related\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Military\""))
        {
            await _ui.ClickAsync(_locators.Military);
        }
        if (_data.Condition("'Operator Status' == \"Missionary\""))
        {
            await _ui.ClickAsync(_locators.Missionary);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.SelectAsync(_locators.NonDriver, _data.Resolve(""));
        }
        if (_data.Condition("'Operator Status' == \"OtherIns\""))
        {
            await _ui.ClickAsync(_locators.OtherInsurance);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.WaitAsync(_locators.NonDriverReason, "Visible");
        }
        if (_data.Condition("'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_143}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_144}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_145}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_146}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_147}}"));
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0063_8f5301Async
        if (_data.Condition("'Policy Type' != \"Cycle\""))
        {
            await _ui.WaitAsync(_locators.IsThisDriverANamedInsured, "Visible");
        }
        if (_data.Condition("'Named Insured?' == \"PrimaryNamedIns\""))
        {
            await _ui.ClickAsync(_locators.PrimaryNamedInsured);
            await _ui.PressAsync(_locators.PrimaryNamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NamedIns\""))
        {
            await _ui.ClickAsync(_locators.NamedInsured);
            await _ui.PressAsync(_locators.NamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NotNamedIns\""))
        {
            await _ui.ClickAsync(_locators.NotANamedInsured);
            await _ui.PressAsync(_locators.NotANamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.NonDriver);
            await _ui.PressAsync(_locators.NonDriver, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
        }
        if (_data.Condition("'Operator Status' == \"Military\""))
        {
            await _ui.ClickAsync(_locators.Military);
        }
        if (_data.Condition("'Operator Status' == \"Missionary\""))
        {
            await _ui.ClickAsync(_locators.Missionary);
        }
        if (_data.Condition("'Operator Status' == \"OtherIns\""))
        {
            await _ui.ClickAsync(_locators.OtherInsurance);
        }
        if (_data.Condition("'Operator Status' == \"Roomate\""))
        {
            await _ui.ClickAsync(_locators.Roommate);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.WaitAsync(_locators.NonDriverReason, "Visible");
        }
        if (_data.Condition("'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.NeverLicensed);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.Underage);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.MedicalCondition);
        }
        if (_data.Condition("'If NonDriver: Reason' != \"NeverLicensed\" AND 'If NonDriver: Reason' != \"Underage\" AND 'If NonDriver: Reason' != \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.SelectAsync(_locators.MoreOptionsNonDriver, _data.Resolve(""));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.Surrendered);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.PermitDriver);
        }
        // EQDriverLicenseTime_01b659Page.LicenseInfo_0064_8f5301Async
        if (_data.Condition("'State Licensed(XX)' != NULL"))
        {
            await _ui.FillAsync(_locators.LicenseState, _data.Get("State Licensed(XX)"));
        }
        if (_data.Condition("'Drivers License #' != NULL"))
        {
            await _ui.FillAsync(_locators.DriverSLicenseNumber, _data.Resolve("{{data:driver_s_license_number_169}}"));
            await _ui.PressAsync(_locators.DriverSLicenseNumber, "CTRL+A");
        }
        if (_data.Condition("'Drivers License #' != NULL"))
        {
            await _ui.FillAsync(_locators.DriverSLicenseNumber, _data.Get("Drivers License #"));
        }
        await _ui.FillAsync(_locators.YrsLicensedCurrentState, _data.Resolve("{{data:yrs_licensed_current_state_171}}"));
        await _ui.PressAsync(_locators.YrsLicensedCurrentState, "CTRL+A");
        await _ui.FillAsync(_locators.YrsLicensedCurrentState, _data.Resolve("{{data:yrs_licensed_current_state_172}}"));
        await _ui.FillAsync(_locators.MonthsLicensedCurrentState, _data.Resolve("{{data:months_licensed_current_state_173}}"));
        await _ui.PressAsync(_locators.MonthsLicensedCurrentState, "CTRL+A");
        await _ui.FillAsync(_locators.MonthsLicensedCurrentState, _data.Resolve("{{data:months_licensed_current_state_174}}"));
        if (_data.Condition("'State' == \"TX\""))
        {
            await _ui.FillAsync(_locators.DaysOperatedUninsured, _data.Resolve("{{data:daysoperateduninsured_175}}"));
        }
        if (_data.Condition("'State' == \"CA\""))
        {
            await _ui.FillAsync(_locators.YrsLicensedAllStates, _data.Resolve("{{data:yrslicensed_all_states_176}}"));
            await _ui.PressAsync(_locators.YrsLicensedAllStates, "CTRL+A");
        }
        if (_data.Condition("'State' == \"CA\""))
        {
            await _ui.FillAsync(_locators.YrsLicensedAllStates, _data.Resolve("{{data:yrslicensed_all_states_177}}"));
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.NoD053A);
            await _ui.PressAsync(_locators.NoD053A, "Click");
            await _ui.PressAsync(_locators.NoD053A, "Scroll[2]");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0065_8f5301Async
        if (await _ui.ExistsAsync(_locators.WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove))
        {
            await _ui.VerifyAsync(_locators.WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0066_8f5301Async
        if (await _ui.ExistsAsync(_locators.NoPreviouslyInsured))
        {
            await _ui.SelectAsync(_locators.NoPreviouslyInsured, _data.Resolve(""));
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0067_8f5301Async
        if (await _ui.ExistsAsync(_locators.PriorCarrierName))
        {
            await _ui.VerifyAsync(_locators.PriorCarrierName, _data.Resolve("Exists"), "");
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0068_8f5301Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue9CB7A))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0069_8f5301Async
        if (await _ui.ExistsAsync(_locators.NoNeedWasNotLicensed))
        {
            await _ui.VerifyAsync(_locators.NoNeedWasNotLicensed, _data.Resolve("Visible"), "");
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0070_8f5301Async
        if (await _ui.ExistsAsync(_locators.NoNeedWasNotLicensed))
        {
            await _ui.ClickAsync(_locators.NoNeedWasNotLicensed);
            await _ui.PressAsync(_locators.NoNeedWasNotLicensed, "End");
            await _ui.PressAsync(_locators.NoNeedWasNotLicensed, "Click");
        }
        await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        // EQPriorInsuranceInfo_a40db0Page.SaveContinue_0071_8f5301Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue9CB7A))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        }
        // EQExpiredLicensePopUp_ac02e7Page.EQExpiredLicensePopUp_0072_8f5301Async
        if (await _ui.ExistsAsync(_locators.CONTINUED555D))
        {
            await _ui.WaitAsync(_locators.CONTINUED555D, "Exists");
        }
        // EQExpiredLicensePopUp_ac02e7Page.EQExpiredLicensePopUp_0073_8f5301Async
        if (await _ui.ExistsAsync(_locators.CONTINUED555D))
        {
            await _ui.ClickAsync(_locators.CONTINUED555D);
        }
    }

    // Business step: I complete vehicle Summary Automobile Rate Filing
    public async Task CompleteVehicleSummaryAutomobileRateFilingAsync()
    {
        // EQCAVerifiedMileage_306316Page.EQCAVerifiedMileage_0085_8f5301Async
        await _ui.VerifyAsync(_locators.EQCAVerifiedMileage, _data.Resolve("Exists"), "");
        // EQVehicleInformation_7d0869Page.EQVehicleInformation_0086_8f5301Async
        if (await _ui.ExistsAsync(_locators.MOREOPTIONS))
        {
            await _ui.WaitAsync(_locators.MOREOPTIONS, "Visible");
        }
        // EQVehicleInformation_7d0869Page.EQVehicleInformation_0087_8f5301Async
        if (await _ui.ExistsAsync(_locators.MOREOPTIONS))
        {
            await _ui.SelectAsync(_locators.MOREOPTIONS, _data.Resolve(""));
        }
        await _ui.ClickAsync(_locators.AdditionalVehicleS62C9A);
        await _ui.ClickAsync(_locators.VehicleInformationNext);
        // EQVehicleInformation_7d0869Page.EQVehicleInformation_0088_8f5301Async
        if (await _ui.ExistsAsync(_locators.AdditionalVehicle))
        {
            await _ui.ClickAsync(_locators.AdditionalVehicle);
        }
        await _ui.ClickAsync(_locators.VehicleInformationNext);
        // EQVehicleAutoVin1_fdc6bdPage.EQVehicleVin_0089_8f5301Async
        await _ui.WaitAsync(_locators.VIN06D01, "True");
        await _ui.ClickAsync(_locators.VIN06D01);
        await _ui.FillAsync(_locators.VIN06D01, _data.Resolve("{{data:txt_vin_214}}"));
        await _ui.PressAsync(_locators.VIN06D01, "POST:TAB");
        await _ui.PressAsync(_locators.VIN06D01, "Tab");
        await _ui.ClickAsync(_locators.Vehicle1);
        // EQVehicleSummaryAutoMotorHomeUse_e4fbccPage.EQVehicleSummaryAutoUse_0090_8f5301Async
        if (_data.Condition("Loan != NULL"))
        {
            await _ui.ClickAsync(_locators.Loan4369D);
        }
        if (_data.Condition("Lease != NULL"))
        {
            await _ui.ClickAsync(_locators.Leased14EA4);
        }
        if (_data.Condition("Loan == NULL AND Lease == NULL"))
        {
            await _ui.ClickAsync(_locators.Own49EEC);
        }
        if (_data.Condition("State == \"OK\""))
        {
            await _ui.SelectAsync(_locators.NativeAmericanRegisterNO, _data.Resolve(""));
        }
        if (_data.Condition("AntiTheft != NULL AND State != \"AZ\" AND State != \"MD\" AND State != \"OH\" AND State != \"CA\" AND State != \"VA\" AND State != \"WI\" AND State != \"UT\""))
        {
            await _ui.SelectAsync(_locators.AntiTheftYes, _data.Resolve(""));
        }
        if (_data.Condition("AntiTheft != NULL AND State == \"IL\""))
        {
            await _ui.ClickAsync(_locators.ILCategory1);
        }
        if (_data.Condition("State == \"NJ\" AND AntiTheft != NULL"))
        {
            await _ui.ClickAsync(_locators.CategoryI);
        }
        if (_data.Condition("AntiTheft != NULL AND (State == \"NY\" OR State == \"VT\")"))
        {
            await _ui.ClickAsync(_locators.ActiveDisablingDevice);
        }
        if (_data.Condition("PickUp != NULL AND (State == \"NY\" OR State = \"VA\")"))
        {
            await _ui.SelectAsync(_locators.CamperShellNo, _data.Resolve(""));
        }
        if (_data.Condition("State == \"CA\""))
        {
            await _ui.ClickAsync(_locators.PleasureCANYFFCIC);
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.ClickAsync(_locators.N1Day);
        }
        if (_data.Condition("State == \"NY\" AND Company == \"FFCIC\""))
        {
            await _ui.FillAsync(_locators.NYFFCICTotalAnnualMiles, _data.Resolve("{{data:ny_ffcic_total_annual_miles_228}}"));
            await _ui.PressAsync(_locators.NYFFCICTotalAnnualMiles, "CTRL+A");
        }
        if (_data.Condition("State == \"NY\" AND Company == \"FFCIC\""))
        {
            await _ui.FillAsync(_locators.NYFFCICTotalAnnualMiles, _data.Resolve("{{data:ny_ffcic_total_annual_miles_229}}"));
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.WorkMilesDay, _data.Resolve("{{data:work_miles_day_230}}"));
            await _ui.PressAsync(_locators.WorkMilesDay, "CTRL+A");
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.WorkMilesDay, _data.Resolve("{{data:work_miles_day_231}}"));
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.NonWorkAnnualMiles, _data.Resolve("{{data:non_work_annual_miles_232}}"));
            await _ui.PressAsync(_locators.NonWorkAnnualMiles, "CTRL+A");
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.NonWorkAnnualMiles, _data.Resolve("{{data:non_work_annual_miles_233}}"));
        }
        if (_data.Condition("'Farm/Use' != NULL AND State == \"CA\""))
        {
            await _ui.SelectAsync(_locators.UseCAMoreOptions, _data.Resolve(""));
        }
        if (_data.Condition("'Farm/Use' != NULL AND (State != \"NY\" and Company !=\"FFCIC\")"))
        {
            await _ui.SelectAsync(_locators.MoreOptionsFarmUse, _data.Resolve(""));
        }
        await _ui.FillAsync(_locators.PurchaseDateBB8AF, _data.Resolve("{{data:txt_purchase_date_236}}"));
        await _ui.PressAsync(_locators.PurchaseDateBB8AF, "CTRL+A");
        await _ui.FillAsync(_locators.PurchaseDateBB8AF, _data.Resolve("{{data:txt_purchase_date_237}}"));
        await _ui.FillAsync(_locators.Odometer3843F, _data.Resolve("{{data:txt_odometer_238}}"));
        await _ui.PressAsync(_locators.Odometer3843F, "CTRL+A");
        await _ui.FillAsync(_locators.Odometer3843F, _data.Resolve("{{data:txt_odometer_239}}"));
        await _ui.ClickAsync(_locators.SaveContinue2E7CD);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0094_8f5301Async
        await _ui.ClickAsync(_locators.AddVehicle);
        // EQVehicleSummaryAutoAdditional_2aa54aPage.EQVehicleSummaryAutoAdditional_0095_8f5301Async
        await _ui.WaitAsync(_locators.VIN0A17C, "True");
        await _ui.FillAsync(_locators.VIN0A17C, _data.Resolve("{{data:vin_243}}"));
        await _ui.PressAsync(_locators.VIN0A17C, "POST:TAB");
        await _ui.PressAsync(_locators.VIN0A17C, "Tab");
        await _ui.ClickAsync(_locators.Veh1);
        await _ui.ClickAsync(_locators.VehicleMoreOptions);
        await _ui.PressAsync(_locators.VehicleMoreOptions, "Click");
        await _ui.PressAsync(_locators.VehicleMoreOptions, "Scroll[1]");
        await _ui.ClickAsync(_locators.CollectorCar);
        await _ui.SelectAsync(_locators.CollectorCarTypeMoreOptions, _data.Resolve(""));
        await _ui.ClickAsync(_locators.Classic);
        await _ui.PressAsync(_locators.Classic, "Click");
        await _ui.PressAsync(_locators.Classic, "scroll[3]");
        await _ui.FillAsync(_locators.AgreedValue8E288, _data.Resolve("{{data:agreed_value_250}}"));
        await _ui.ClickAsync(_locators.OwnB8575);
        await _ui.PressAsync(_locators.OwnB8575, "scroll[3]");
        await _ui.PressAsync(_locators.OwnB8575, "Click");
        await _ui.ClickAsync(_locators.Continue);
        await _ui.ClickAsync(_locators.RestrictedUse);
        await _ui.PressAsync(_locators.RestrictedUse, "scroll[2]");
        await _ui.PressAsync(_locators.RestrictedUse, "Click");
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_254}}"));
        await _ui.PressAsync(_locators.AppraisalDate8A115, "CTRL+A");
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_255}}"));
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_256}}"));
        await _ui.PressAsync(_locators.TotalAnnualMileage, "CTRL+A");
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_257}}"));
        await _ui.ClickAsync(_locators.SaveContinue86B78);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0096_8f5301Async
        await _ui.ClickAsync(_locators.AddVehicle);
        // EQVehicleSummaryAutoAdditional_2aa54aPage.EQVehicleSummaryAutoAdditional_0097_8f5301Async
        await _ui.WaitAsync(_locators.VIN0A17C, "True");
        await _ui.FillAsync(_locators.VIN0A17C, _data.Get("VIN 3"));
        await _ui.PressAsync(_locators.VIN0A17C, "POST:TAB");
        await _ui.PressAsync(_locators.VIN0A17C, "Tab");
        await _ui.ClickAsync(_locators.Veh3);
        await _ui.SelectAsync(_locators.VehicleMoreOptions, _data.Resolve(""));
        await _ui.ClickAsync(_locators.CollectorCar);
        await _ui.PressAsync(_locators.CollectorCar, "Click");
        await _ui.PressAsync(_locators.CollectorCar, "scroll[1]");
        await _ui.ClickAsync(_locators.ModernClassic);
        await _ui.PressAsync(_locators.ModernClassic, "Click");
        await _ui.PressAsync(_locators.ModernClassic, "scroll[2]");
        await _ui.FillAsync(_locators.AgreedValue8E288, _data.Get("Agreed Value Veh 3"));
        await _ui.ClickAsync(_locators.OwnB8575);
        await _ui.PressAsync(_locators.OwnB8575, "scroll[2]");
        await _ui.PressAsync(_locators.OwnB8575, "Click");
        await _ui.PressAsync(_locators.OwnB8575, "scroll[2]");
        await _ui.ClickAsync(_locators.Continue);
        await _ui.ClickAsync(_locators.RestrictedUse);
        await _ui.PressAsync(_locators.RestrictedUse, "Click");
        await _ui.PressAsync(_locators.RestrictedUse, "END");
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_271}}"));
        await _ui.PressAsync(_locators.AppraisalDate8A115, "CTRL+A");
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_272}}"));
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_273}}"));
        await _ui.PressAsync(_locators.OdometerD648F, "CTRL+A");
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_274}}"));
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_275}}"));
        await _ui.PressAsync(_locators.TotalAnnualMileage, "CTRL+A");
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Get("Annual Mileage Veh 3"));
        await _ui.ClickAsync(_locators.SaveContinue86B78);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0098_8f5301Async
        await _ui.ClickAsync(_locators.AddVehicle);
        // EQVehicleSummaryAutoAdditional_2aa54aPage.EQVehicleSummaryAutoAdditional_0099_8f5301Async
        await _ui.WaitAsync(_locators.VIN0A17C, "True");
        await _ui.FillAsync(_locators.VIN0A17C, _data.Get("VIN 4"));
        await _ui.PressAsync(_locators.VIN0A17C, "POST:TAB");
        await _ui.PressAsync(_locators.VIN0A17C, "Tab");
        await _ui.ClickAsync(_locators.Veh1);
        await _ui.ClickAsync(_locators.OwnB8575);
        await _ui.PressAsync(_locators.OwnB8575, "Click");
        await _ui.PressAsync(_locators.OwnB8575, "scroll[2]");
        await _ui.ClickAsync(_locators.Continue);
        await _ui.FillAsync(_locators.PurchaseDate736F4, _data.Resolve("{{data:purchase_date_285}}"));
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_286}}"));
        await _ui.PressAsync(_locators.OdometerD648F, "CTRL+A");
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_287}}"));
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_288}}"));
        await _ui.PressAsync(_locators.TotalAnnualMileage, "CTRL+A");
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Get("Annual Mileage Veh 4"));
        await _ui.ClickAsync(_locators.SaveContinue86B78);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0100_8f5301Async
        await _ui.WaitAsync(_locators.PricingDetailsNext, "Exists");
        await _ui.ClickAsync(_locators.PricingDetailsNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0101_8f5301Async
        _data.Set("Driver 1 Vehicle", _data.Resolve("{{data:driver_1_vehicle}}"));
        _data.Set("Driver 1 Principal Occasional", _data.Resolve("{{data:driver_1_principal_occasional}}"));
        _data.Set("Driver 2 Vehicle", _data.Get("Driver 2 Vehicle"));
        _data.Set("Driver 2 Principal Occasional", _data.Get("Driver 2 Principal Occasional"));
        _data.Set("Driver 3 Vehicle", _data.Get("Driver 3 Vehicle"));
        _data.Set("Driver 3 Principal Occasional", _data.Get("Driver 3 Principal Occasional"));
        _data.Set("Driver 4 Vehicle", _data.Get("Driver 4 Vehicle"));
        _data.Set("Driver 4 Principal Occasional", _data.Get("Driver 4 Principal Occasional"));
        _data.Set("Driver 5 Vehicle", _data.Get("Driver 5 Vehicle"));
        _data.Set("Driver 5 Principal Occasional", _data.Get("Driver 5 Principal Occasional"));
    }

    // Business step: I complete auto AddlCov Vehicle Coverages
    public async Task CompleteAutoAddlCovVehicleCoveragesAsync2()
    {
        // EQVehicleCoveragesSection_2f4d8bPage.EQVehicleCoveragesSection_0152_8f5301Async
        if (_data.Condition("'UMPD/UIMPD_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV1);
        }
        if (_data.Condition("'UMPD Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle1);
            await _ui.PressAsync(_locators.UMPDCoverageVehicle1, "Click");
            await _ui.PressAsync(_locators.UMPDCoverageVehicle1, "scroll[2]");
        }
        if (_data.Condition("'UMPD Coverage_V1' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV1);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV1);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV1, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV1, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV1);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V1' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV1);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV1, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV1, "Scroll[2]");
        }
        if (_data.Condition("'UMPD/UIMPD_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV2);
        }
        if (_data.Condition("'UMPD Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle2);
        }
        if (_data.Condition("'UMPD Coverage_V2' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV2);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV2);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV2, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV2, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV2);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV2);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV2, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV2, "scroll[2]");
        }
        if (_data.Condition("'Towing and Labor' != NULL"))
        {
            await _ui.SelectAsync(_locators.NoCoverageV1Towing, _data.Resolve(""));
        }
        if (_data.Condition("'UMPD/UIMPD_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV3);
        }
        if (_data.Condition("'UMPD Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle3);
        }
        if (_data.Condition("'UMPD Coverage_V3' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV3);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV3);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV3, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV3, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV3);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V3' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV3);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV3, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV3, "scroll[2]");
        }
        if (_data.Condition("'Cycle Accessories_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.CycleAccessoriesV3);
        }
        if (_data.Condition("'Original Parts_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.OriginalPartsV3);
        }
        if (_data.Condition("'UMPD/UIMPD_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV4);
        }
        if (_data.Condition("'UMPD Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle4);
        }
        if (_data.Condition("'UMPD Coverage_V4' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV4);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV4);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV4, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV4, "end");
        }
        if (_data.Condition("'Theft Deductible_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV4);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V4' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV4);
        }
        if (_data.Condition("'Cycle Accessories_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.CycleAccessoriesV4);
        }
        if (_data.Condition("'Original Parts_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.OriginalPartsV4);
        }
    }

    // Business step: I review the driver information summary
    public async Task ReviewTheDriverInformationSummaryAsync3()
    {
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0053_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.Single))
        {
            await _ui.VerifyAsync(_locators.Single, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0054_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.MaritalStatusSingle))
        {
            await _ui.ClickAsync(_locators.MaritalStatusSingle);
        }
        if (_data.Condition("'Marital Status' != \"Married\""))
        {
            await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' != \"Divorced\""))
        {
            await _ui.ClickAsync(_locators.Divorced);
        }
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
            await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
            await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
            await _ui.ClickAsync(_locators.Divorced);
        }
        // EQDriverEducationLevel_5a720bPage.DriverEducationLevel_0055_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.HighSchoolDiplomaOrGED))
        {
            await _ui.VerifyAsync(_locators.HighSchoolDiplomaOrGED, _data.Resolve("True"), "Enabled");
        }
        // EQDriverEducationLevel_5a720bPage.DriverEducationLevel_0056_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.MDNJEducationLevelUnknown))
        {
            await _ui.ClickAsync(_locators.MDNJEducationLevelUnknown);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Unknown\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"HighSchool\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"HighSchool\""))
        {
            await _ui.ClickAsync(_locators.HighSchoolDiplomaOrGED);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Trade\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Trade\""))
        {
            await _ui.ClickAsync(_locators.VocationalOrTradeSchoolDegree);
        }
        if (_data.Condition("MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\""))
        {
            await _ui.SelectAsync(_locators.MoreOptionsEdu, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"SomeCollege\""))
        {
            await _ui.WaitAsync(_locators.SomeCollege, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"SomeCollege\""))
        {
            await _ui.ClickAsync(_locators.SomeCollege);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"InCollege\""))
        {
            await _ui.WaitAsync(_locators.CurrentlyInCollege, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"InCollege\""))
        {
            await _ui.ClickAsync(_locators.CurrentlyInCollege);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"CollegeDegree\""))
        {
            await _ui.WaitAsync(_locators.CollegeDegreeGraduateWork, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"CollegeDegree\""))
        {
            await _ui.ClickAsync(_locators.CollegeDegreeGraduateWork);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.WaitAsync(_locators.GraduateDegreeJDMasters, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.ClickAsync(_locators.GraduateDegreeJDMasters);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.WaitAsync(_locators.PostGraduateDegreeMedicalDegreePhDEdDEtc, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.ClickAsync(_locators.PostGraduateDegreeMedicalDegreePhDEdDEtc);
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0057_e2e0d7Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Condition verify relationship spouse button exist; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.Spouse, _data.Resolve("Exists"), "");
        }
        await _ui.ClickAsync(_locators.AccountOwner);
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0058_e2e0d7Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Then Relationship for account owner exist; 'Policy Type' != \"Cycle\""))
        {
            await _ui.SelectAsync(_locators.RelationshipToAccountOwnerNULL, _data.Resolve("{{data:select_relationship_to_account_owner_null_122}}"));
        }
        if (_data.Condition("'Relationship to Account Owner' != NULL"))
        {
            await _ui.ClickAsync(_locators.AccountOwner);
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0059_e2e0d7Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Condition Check if Relationship is account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.AccountOwnerReadOnly, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0060_e2e0d7Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Then Relationship is account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.AccountOwnerReadOnly, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0061_e2e0d7Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Else Make script fail due to Relationship other than account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.AccountOwner);
            await _ui.PressAsync(_locators.AccountOwner, "Click");
            await _ui.PressAsync(_locators.AccountOwner, "scroll[2]");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatusCycle_0062_e2e0d7Async
        if (_data.Condition("'Policy Type' == \"Cycle\""))
        {
            await _ui.WaitAsync(_locators.IsThisDriverANamedInsured, "Visible");
        }
        if (_data.Condition("'Named Insured?' == \"PrimaryNamedIns\""))
        {
            await _ui.ClickAsync(_locators.PrimaryNamedInsured);
            await _ui.PressAsync(_locators.PrimaryNamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NamedIns\""))
        {
            await _ui.ClickAsync(_locators.NamedInsured);
            await _ui.PressAsync(_locators.NamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NotNamedIns\""))
        {
            await _ui.ClickAsync(_locators.NotANamedInsured);
            await _ui.PressAsync(_locators.NotANamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Related);
            await _ui.PressAsync(_locators.Related, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
            await _ui.PressAsync(_locators.Related, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"NoCycleLicense\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"NoCycleLicense\""))
        {
            await _ui.SelectAsync(_locators.NoCycleLicense, _data.Resolve(""));
        }
        if (_data.Condition("'Operator Status' != \"Assigned\" AND 'Operator Status' != \"NoCycleLicense\" AND 'Operator Status' != \"Related\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Military\""))
        {
            await _ui.ClickAsync(_locators.Military);
        }
        if (_data.Condition("'Operator Status' == \"Missionary\""))
        {
            await _ui.ClickAsync(_locators.Missionary);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.SelectAsync(_locators.NonDriver, _data.Resolve(""));
        }
        if (_data.Condition("'Operator Status' == \"OtherIns\""))
        {
            await _ui.ClickAsync(_locators.OtherInsurance);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.WaitAsync(_locators.NonDriverReason, "Visible");
        }
        if (_data.Condition("'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_143}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_144}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_145}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_146}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_147}}"));
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0063_e2e0d7Async
        if (_data.Condition("'Policy Type' != \"Cycle\""))
        {
            await _ui.WaitAsync(_locators.IsThisDriverANamedInsured, "Visible");
        }
        if (_data.Condition("'Named Insured?' == \"PrimaryNamedIns\""))
        {
            await _ui.ClickAsync(_locators.PrimaryNamedInsured);
            await _ui.PressAsync(_locators.PrimaryNamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NamedIns\""))
        {
            await _ui.ClickAsync(_locators.NamedInsured);
            await _ui.PressAsync(_locators.NamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NotNamedIns\""))
        {
            await _ui.ClickAsync(_locators.NotANamedInsured);
            await _ui.PressAsync(_locators.NotANamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.NonDriver);
            await _ui.PressAsync(_locators.NonDriver, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
        }
        if (_data.Condition("'Operator Status' == \"Military\""))
        {
            await _ui.ClickAsync(_locators.Military);
        }
        if (_data.Condition("'Operator Status' == \"Missionary\""))
        {
            await _ui.ClickAsync(_locators.Missionary);
        }
        if (_data.Condition("'Operator Status' == \"OtherIns\""))
        {
            await _ui.ClickAsync(_locators.OtherInsurance);
        }
        if (_data.Condition("'Operator Status' == \"Roomate\""))
        {
            await _ui.ClickAsync(_locators.Roommate);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.WaitAsync(_locators.NonDriverReason, "Visible");
        }
        if (_data.Condition("'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.NeverLicensed);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.Underage);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.MedicalCondition);
        }
        if (_data.Condition("'If NonDriver: Reason' != \"NeverLicensed\" AND 'If NonDriver: Reason' != \"Underage\" AND 'If NonDriver: Reason' != \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.SelectAsync(_locators.MoreOptionsNonDriver, _data.Resolve(""));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.Surrendered);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.PermitDriver);
        }
        // EQDriverLicenseTime_01b659Page.LicenseInfo_0064_e2e0d7Async
        if (_data.Condition("'State Licensed(XX)' != NULL"))
        {
            await _ui.FillAsync(_locators.LicenseState, _data.Get("AL_ClientData.State"));
        }
        if (_data.Condition("'Drivers License #' != NULL"))
        {
            await _ui.FillAsync(_locators.DriverSLicenseNumber, _data.Resolve("{{data:driver_s_license_number_169}}"));
            await _ui.PressAsync(_locators.DriverSLicenseNumber, "CTRL+A");
        }
        if (_data.Condition("'Drivers License #' != NULL"))
        {
            await _ui.FillAsync(_locators.DriverSLicenseNumber, _data.Get("AL_ClientData.DL Number"));
        }
        await _ui.FillAsync(_locators.YrsLicensedCurrentState, _data.Resolve("{{data:yrs_licensed_current_state_171}}"));
        await _ui.PressAsync(_locators.YrsLicensedCurrentState, "CTRL+A");
        await _ui.FillAsync(_locators.YrsLicensedCurrentState, _data.Resolve("{{data:yrs_licensed_current_state_172}}"));
        await _ui.FillAsync(_locators.MonthsLicensedCurrentState, _data.Resolve("{{data:months_licensed_current_state_173}}"));
        await _ui.PressAsync(_locators.MonthsLicensedCurrentState, "CTRL+A");
        await _ui.FillAsync(_locators.MonthsLicensedCurrentState, _data.Resolve("{{data:months_licensed_current_state_174}}"));
        if (_data.Condition("'State' == \"TX\""))
        {
            await _ui.FillAsync(_locators.DaysOperatedUninsured, _data.Resolve("{{data:daysoperateduninsured_175}}"));
        }
        if (_data.Condition("'State' == \"CA\""))
        {
            await _ui.FillAsync(_locators.YrsLicensedAllStates, _data.Resolve("{{data:yrslicensed_all_states_176}}"));
            await _ui.PressAsync(_locators.YrsLicensedAllStates, "CTRL+A");
        }
        if (_data.Condition("'State' == \"CA\""))
        {
            await _ui.FillAsync(_locators.YrsLicensedAllStates, _data.Resolve("{{data:yrslicensed_all_states_177}}"));
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.NoD053A);
            await _ui.PressAsync(_locators.NoD053A, "Click");
            await _ui.PressAsync(_locators.NoD053A, "Scroll[2]");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0065_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove))
        {
            await _ui.VerifyAsync(_locators.WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0066_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.NoPreviouslyInsured))
        {
            await _ui.SelectAsync(_locators.NoPreviouslyInsured, _data.Resolve(""));
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0067_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.PriorCarrierName))
        {
            await _ui.VerifyAsync(_locators.PriorCarrierName, _data.Resolve("Exists"), "");
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0068_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue9CB7A))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0069_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.NoNeedWasNotLicensed))
        {
            await _ui.VerifyAsync(_locators.NoNeedWasNotLicensed, _data.Resolve("Visible"), "");
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0070_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.NoNeedWasNotLicensed))
        {
            await _ui.ClickAsync(_locators.NoNeedWasNotLicensed);
            await _ui.PressAsync(_locators.NoNeedWasNotLicensed, "End");
            await _ui.PressAsync(_locators.NoNeedWasNotLicensed, "Click");
        }
        await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        // EQPriorInsuranceInfo_a40db0Page.SaveContinue_0071_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue9CB7A))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        }
        // EQExpiredLicensePopUp_ac02e7Page.EQExpiredLicensePopUp_0072_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.CONTINUED555D))
        {
            await _ui.WaitAsync(_locators.CONTINUED555D, "Exists");
        }
        // EQExpiredLicensePopUp_ac02e7Page.EQExpiredLicensePopUp_0073_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.CONTINUED555D))
        {
            await _ui.ClickAsync(_locators.CONTINUED555D);
        }
    }

    // Business step: I complete vehicle Summary Automobile Rate Filing Common Auto
    public async Task CompleteVehicleSummaryAutomobileRateFilingCommonAutoAsync()
    {
        // EQVehicleInformation_7d0869Page.EQVehicleInformation_0085_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.AdditionalVehicle))
        {
            await _ui.WaitAsync(_locators.AdditionalVehicle, "Visible");
        }
        // EQVehicleInformation_7d0869Page.EQVehicleInformation_0086_e2e0d7Async
        if (await _ui.ExistsAsync(_locators.AdditionalVehicle))
        {
            await _ui.ClickAsync(_locators.AdditionalVehicle);
        }
        await _ui.ClickAsync(_locators.VehicleInformationNext);
        // EQVehicleAutoVin1_fdc6bdPage.EQVehicleVin_0087_e2e0d7Async
        await _ui.WaitAsync(_locators.VIN06D01, "True");
        await _ui.ClickAsync(_locators.VIN06D01);
        await _ui.FillAsync(_locators.VIN06D01, _data.Resolve("{{data:txt_vin_210}}"));
        await _ui.PressAsync(_locators.VIN06D01, "POST:TAB");
        await _ui.PressAsync(_locators.VIN06D01, "Tab");
        await _ui.ClickAsync(_locators.Vehicle1);
        // EQVehicleSummaryAutoMotorHomeUse_e4fbccPage.EQVehicleSummaryAutoUse_0088_e2e0d7Async
        if (_data.Condition("Loan != NULL"))
        {
            await _ui.ClickAsync(_locators.Loan4369D);
        }
        if (_data.Condition("Lease != NULL"))
        {
            await _ui.ClickAsync(_locators.Leased14EA4);
        }
        if (_data.Condition("Loan == NULL AND Lease == NULL"))
        {
            await _ui.ClickAsync(_locators.Own49EEC);
        }
        if (_data.Condition("State == \"OK\""))
        {
            await _ui.SelectAsync(_locators.NativeAmericanRegisterNO, _data.Resolve(""));
        }
        if (_data.Condition("AntiTheft != NULL AND State != \"AZ\" AND State != \"MD\" AND State != \"OH\" AND State != \"CA\" AND State != \"VA\" AND State != \"WI\" AND State != \"UT\""))
        {
            await _ui.SelectAsync(_locators.AntiTheftYes, _data.Resolve(""));
        }
        if (_data.Condition("AntiTheft != NULL AND State == \"IL\""))
        {
            await _ui.ClickAsync(_locators.ILCategory1);
        }
        if (_data.Condition("State == \"NJ\" AND AntiTheft != NULL"))
        {
            await _ui.ClickAsync(_locators.CategoryI);
        }
        if (_data.Condition("AntiTheft != NULL AND (State == \"NY\" OR State == \"VT\")"))
        {
            await _ui.ClickAsync(_locators.ActiveDisablingDevice);
        }
        if (_data.Condition("PickUp != NULL AND (State == \"NY\" OR State = \"VA\")"))
        {
            await _ui.SelectAsync(_locators.CamperShellNo, _data.Resolve(""));
        }
        if (_data.Condition("State == \"CA\""))
        {
            await _ui.ClickAsync(_locators.PleasureCANYFFCIC);
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.ClickAsync(_locators.N1Day);
        }
        if (_data.Condition("State == \"NY\" AND Company == \"FFCIC\""))
        {
            await _ui.FillAsync(_locators.NYFFCICTotalAnnualMiles, _data.Resolve("{{data:ny_ffcic_total_annual_miles_224}}"));
            await _ui.PressAsync(_locators.NYFFCICTotalAnnualMiles, "CTRL+A");
        }
        if (_data.Condition("State == \"NY\" AND Company == \"FFCIC\""))
        {
            await _ui.FillAsync(_locators.NYFFCICTotalAnnualMiles, _data.Resolve("{{data:ny_ffcic_total_annual_miles_225}}"));
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.WorkMilesDay, _data.Resolve("{{data:work_miles_day_226}}"));
            await _ui.PressAsync(_locators.WorkMilesDay, "CTRL+A");
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.WorkMilesDay, _data.Resolve("{{data:work_miles_day_227}}"));
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.NonWorkAnnualMiles, _data.Resolve("{{data:non_work_annual_miles_228}}"));
            await _ui.PressAsync(_locators.NonWorkAnnualMiles, "CTRL+A");
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.NonWorkAnnualMiles, _data.Resolve("{{data:non_work_annual_miles_229}}"));
        }
        if (_data.Condition("'Farm/Use' != NULL AND State == \"CA\""))
        {
            await _ui.SelectAsync(_locators.UseCAMoreOptions, _data.Resolve(""));
        }
        if (_data.Condition("'Farm/Use' != NULL AND (State != \"NY\" and Company !=\"FFCIC\")"))
        {
            await _ui.SelectAsync(_locators.MoreOptionsFarmUse, _data.Resolve(""));
        }
        await _ui.FillAsync(_locators.PurchaseDateBB8AF, _data.Resolve("{{data:txt_purchase_date_232}}"));
        await _ui.PressAsync(_locators.PurchaseDateBB8AF, "CTRL+A");
        await _ui.FillAsync(_locators.PurchaseDateBB8AF, _data.Resolve("{{data:txt_purchase_date_233}}"));
        await _ui.FillAsync(_locators.Odometer3843F, _data.Resolve("{{data:txt_odometer_234}}"));
        await _ui.PressAsync(_locators.Odometer3843F, "CTRL+A");
        await _ui.FillAsync(_locators.Odometer3843F, _data.Resolve("{{data:txt_odometer_235}}"));
        if (_data.Condition("State != \"KS\""))
        {
            await _ui.FillAsync(_locators.AnnualMileage51344, _data.Resolve("{{data:txt_annual_mileage_236}}"));
            await _ui.PressAsync(_locators.AnnualMileage51344, "CTRL+A");
        }
        if (_data.Condition("State != \"KS\""))
        {
            await _ui.FillAsync(_locators.AnnualMileage51344, _data.Resolve("{{data:txt_annual_mileage_237}}"));
        }
        await _ui.ClickAsync(_locators.SaveContinue2E7CD);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0092_e2e0d7Async
        await _ui.ClickAsync(_locators.AddVehicle);
        // EQVehicleSummaryAutoAdditional_2aa54aPage.EQVehicleSummaryAutoAdditional_0093_e2e0d7Async
        await _ui.WaitAsync(_locators.VIN0A17C, "True");
        await _ui.FillAsync(_locators.VIN0A17C, _data.Resolve("{{data:vin_241}}"));
        await _ui.PressAsync(_locators.VIN0A17C, "POST:TAB");
        await _ui.PressAsync(_locators.VIN0A17C, "Tab");
        await _ui.ClickAsync(_locators.Veh1);
        await _ui.SelectAsync(_locators.VehicleMoreOptions, _data.Resolve(""));
        await _ui.ClickAsync(_locators.CollectorCar);
        await _ui.SelectAsync(_locators.CollectorCarTypeMoreOptions, _data.Resolve(""));
        await _ui.ClickAsync(_locators.Classic);
        await _ui.FillAsync(_locators.AgreedValue8E288, _data.Resolve("{{data:agreed_value_248}}"));
        await _ui.ClickAsync(_locators.OwnB8575);
        await _ui.ClickAsync(_locators.Continue);
        if (_data.Condition("State != \"KS\""))
        {
            await _ui.ClickAsync(_locators.RestrictedUse);
        }
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_252}}"));
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_253}}"));
        await _ui.PressAsync(_locators.TotalAnnualMileage, "CTRL+A");
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_254}}"));
        await _ui.ClickAsync(_locators.SaveContinue86B78);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0094_e2e0d7Async
        await _ui.ClickAsync(_locators.AddVehicle);
        // EQVehicleSummaryAutoAdditional_2aa54aPage.EQVehicleSummaryAutoAdditional_0095_e2e0d7Async
        await _ui.WaitAsync(_locators.VIN0A17C, "True");
        await _ui.FillAsync(_locators.VIN0A17C, _data.Resolve("{{data:vin_258}}"));
        await _ui.PressAsync(_locators.VIN0A17C, "POST:TAB");
        await _ui.PressAsync(_locators.VIN0A17C, "Tab");
        await _ui.ClickAsync(_locators.Veh3);
        await _ui.SelectAsync(_locators.VehicleMoreOptions, _data.Resolve(""));
        await _ui.ClickAsync(_locators.CollectorCar);
        await _ui.ClickAsync(_locators.ModernClassic);
        await _ui.FillAsync(_locators.AgreedValue8E288, _data.Resolve("{{data:agreed_value_264}}"));
        await _ui.ClickAsync(_locators.OwnB8575);
        await _ui.ClickAsync(_locators.Continue);
        if (_data.Condition("State != \"KS\""))
        {
            await _ui.ClickAsync(_locators.RestrictedUse);
        }
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_268}}"));
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_269}}"));
        await _ui.PressAsync(_locators.OdometerD648F, "CTRL+A");
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_270}}"));
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_271}}"));
        await _ui.PressAsync(_locators.TotalAnnualMileage, "CTRL+A");
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_272}}"));
        await _ui.ClickAsync(_locators.SaveContinue86B78);
        // EQCAVerifiedMileage_306316Page.EQCAVerifiedMileage_0096_e2e0d7Async
        if (_data.Condition("State == \"CA\""))
        {
            await _ui.ClickAsync(_locators.OptOut);
        }
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0097_e2e0d7Async
        await _ui.ClickAsync(_locators.PricingDetailsNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0098_e2e0d7Async
        _data.Set("Driver 1 Vehicle", _data.Resolve("{{data:driver_1_vehicle}}"));
        _data.Set("Driver 1 Principal Occasional", _data.Resolve("{{data:driver_1_principal_occasional}}"));
        _data.Set("Driver 2 Vehicle", _data.Get("Driver 2 Vehicle"));
        _data.Set("Driver 2 Principal Occasional", _data.Get("Driver 2 Principal Occasional"));
        _data.Set("Driver 3 Vehicle", _data.Get("Driver 3 Vehicle"));
        _data.Set("Driver 3 Principal Occasional", _data.Get("Driver 3 Principal Occasional"));
        _data.Set("Driver 4 Vehicle", _data.Get("Driver 4 Vehicle"));
        _data.Set("Driver 4 Principal Occasional", _data.Get("Driver 4 Principal Occasional"));
        _data.Set("Driver 5 Vehicle", _data.Get("Driver 5 Vehicle"));
        _data.Set("Driver 5 Principal Occasional", _data.Get("Driver 5 Principal Occasional"));
    }

    // Business step: I complete auto AddlCov Vehicle Coverages
    public async Task CompleteAutoAddlCovVehicleCoveragesAsync3()
    {
        // EQVehicleCoveragesSection_2f4d8bPage.EQVehicleCoveragesSection_0149_e2e0d7Async
        if (_data.Condition("'UMPD/UIMPD_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV1);
        }
        if (_data.Condition("'UMPD Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle1);
            await _ui.PressAsync(_locators.UMPDCoverageVehicle1, "Click");
            await _ui.PressAsync(_locators.UMPDCoverageVehicle1, "scroll[2]");
        }
        if (_data.Condition("'UMPD Coverage_V1' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV1);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV1);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV1, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV1, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV1);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V1' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV1);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV1, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV1, "Scroll[2]");
        }
        if (_data.Condition("'UMPD/UIMPD_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV2);
        }
        if (_data.Condition("'UMPD Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle2);
        }
        if (_data.Condition("'UMPD Coverage_V2' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV2);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV2);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV2, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV2, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV2);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV2);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV2, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV2, "scroll[2]");
        }
        if (_data.Condition("'Towing and Labor' != NULL"))
        {
            await _ui.SelectAsync(_locators.NoCoverageV1Towing, _data.Resolve(""));
        }
        if (_data.Condition("'UMPD/UIMPD_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV3);
        }
        if (_data.Condition("'UMPD Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle3);
        }
        if (_data.Condition("'UMPD Coverage_V3' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV3);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV3);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV3, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV3, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV3);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V3' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV3);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV3, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV3, "scroll[2]");
        }
        if (_data.Condition("'Cycle Accessories_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.CycleAccessoriesV3);
        }
        if (_data.Condition("'Original Parts_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.OriginalPartsV3);
        }
        if (_data.Condition("'UMPD/UIMPD_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV4);
        }
        if (_data.Condition("'UMPD Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle4);
        }
        if (_data.Condition("'UMPD Coverage_V4' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV4);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV4);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV4, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV4, "end");
        }
        if (_data.Condition("'Theft Deductible_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV4);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V4' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV4);
        }
        if (_data.Condition("'Cycle Accessories_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.CycleAccessoriesV4);
        }
        if (_data.Condition("'Original Parts_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.OriginalPartsV4);
        }
    }

    // Business step: I review the driver information summary
    public async Task ReviewTheDriverInformationSummaryAsync4()
    {
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0053_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.Single))
        {
            await _ui.VerifyAsync(_locators.Single, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0054_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.MaritalStatusSingle))
        {
            await _ui.ClickAsync(_locators.MaritalStatusSingle);
        }
        if (_data.Condition("'Marital Status' != \"Married\""))
        {
            await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' != \"Divorced\""))
        {
            await _ui.ClickAsync(_locators.Divorced);
        }
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
            await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
            await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
            await _ui.ClickAsync(_locators.Divorced);
        }
        // EQDriverEducationLevel_5a720bPage.DriverEducationLevel_0055_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.HighSchoolDiplomaOrGED))
        {
            await _ui.VerifyAsync(_locators.HighSchoolDiplomaOrGED, _data.Resolve("True"), "Enabled");
        }
        // EQDriverEducationLevel_5a720bPage.DriverEducationLevel_0056_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.MDNJEducationLevelUnknown))
        {
            await _ui.ClickAsync(_locators.MDNJEducationLevelUnknown);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Unknown\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"HighSchool\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"HighSchool\""))
        {
            await _ui.ClickAsync(_locators.HighSchoolDiplomaOrGED);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Trade\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Trade\""))
        {
            await _ui.ClickAsync(_locators.VocationalOrTradeSchoolDegree);
        }
        if (_data.Condition("MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\""))
        {
            await _ui.SelectAsync(_locators.MoreOptionsEdu, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"SomeCollege\""))
        {
            await _ui.WaitAsync(_locators.SomeCollege, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"SomeCollege\""))
        {
            await _ui.ClickAsync(_locators.SomeCollege);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"InCollege\""))
        {
            await _ui.WaitAsync(_locators.CurrentlyInCollege, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"InCollege\""))
        {
            await _ui.ClickAsync(_locators.CurrentlyInCollege);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"CollegeDegree\""))
        {
            await _ui.WaitAsync(_locators.CollegeDegreeGraduateWork, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"CollegeDegree\""))
        {
            await _ui.ClickAsync(_locators.CollegeDegreeGraduateWork);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.WaitAsync(_locators.GraduateDegreeJDMasters, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.ClickAsync(_locators.GraduateDegreeJDMasters);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.WaitAsync(_locators.PostGraduateDegreeMedicalDegreePhDEdDEtc, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.ClickAsync(_locators.PostGraduateDegreeMedicalDegreePhDEdDEtc);
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0057_bafd4aAsync
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Condition verify relationship spouse button exist; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.Spouse, _data.Resolve("Exists"), "");
        }
        await _ui.ClickAsync(_locators.AccountOwner);
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0058_bafd4aAsync
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Then Relationship for account owner exist; 'Policy Type' != \"Cycle\""))
        {
            await _ui.SelectAsync(_locators.RelationshipToAccountOwnerNULL, _data.Resolve("{{data:select_relationship_to_account_owner_null_122}}"));
        }
        if (_data.Condition("'Relationship to Account Owner' != NULL"))
        {
            await _ui.ClickAsync(_locators.AccountOwner);
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0059_bafd4aAsync
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Condition Check if Relationship is account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.AccountOwnerReadOnly, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0060_bafd4aAsync
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Then Relationship is account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.AccountOwnerReadOnly, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0061_bafd4aAsync
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Else Make script fail due to Relationship other than account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.AccountOwner);
            await _ui.PressAsync(_locators.AccountOwner, "Click");
            await _ui.PressAsync(_locators.AccountOwner, "scroll[2]");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatusCycle_0062_bafd4aAsync
        if (_data.Condition("'Policy Type' == \"Cycle\""))
        {
            await _ui.WaitAsync(_locators.IsThisDriverANamedInsured, "Visible");
        }
        if (_data.Condition("'Named Insured?' == \"PrimaryNamedIns\""))
        {
            await _ui.ClickAsync(_locators.PrimaryNamedInsured);
            await _ui.PressAsync(_locators.PrimaryNamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NamedIns\""))
        {
            await _ui.ClickAsync(_locators.NamedInsured);
            await _ui.PressAsync(_locators.NamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NotNamedIns\""))
        {
            await _ui.ClickAsync(_locators.NotANamedInsured);
            await _ui.PressAsync(_locators.NotANamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Related);
            await _ui.PressAsync(_locators.Related, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
            await _ui.PressAsync(_locators.Related, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"NoCycleLicense\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"NoCycleLicense\""))
        {
            await _ui.SelectAsync(_locators.NoCycleLicense, _data.Resolve(""));
        }
        if (_data.Condition("'Operator Status' != \"Assigned\" AND 'Operator Status' != \"NoCycleLicense\" AND 'Operator Status' != \"Related\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Military\""))
        {
            await _ui.ClickAsync(_locators.Military);
        }
        if (_data.Condition("'Operator Status' == \"Missionary\""))
        {
            await _ui.ClickAsync(_locators.Missionary);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.SelectAsync(_locators.NonDriver, _data.Resolve(""));
        }
        if (_data.Condition("'Operator Status' == \"OtherIns\""))
        {
            await _ui.ClickAsync(_locators.OtherInsurance);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.WaitAsync(_locators.NonDriverReason, "Visible");
        }
        if (_data.Condition("'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_143}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_144}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_145}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_146}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_147}}"));
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0063_bafd4aAsync
        if (_data.Condition("'Policy Type' != \"Cycle\""))
        {
            await _ui.WaitAsync(_locators.IsThisDriverANamedInsured, "Visible");
        }
        if (_data.Condition("'Named Insured?' == \"PrimaryNamedIns\""))
        {
            await _ui.ClickAsync(_locators.PrimaryNamedInsured);
            await _ui.PressAsync(_locators.PrimaryNamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NamedIns\""))
        {
            await _ui.ClickAsync(_locators.NamedInsured);
            await _ui.PressAsync(_locators.NamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NotNamedIns\""))
        {
            await _ui.ClickAsync(_locators.NotANamedInsured);
            await _ui.PressAsync(_locators.NotANamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.NonDriver);
            await _ui.PressAsync(_locators.NonDriver, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
        }
        if (_data.Condition("'Operator Status' == \"Military\""))
        {
            await _ui.ClickAsync(_locators.Military);
        }
        if (_data.Condition("'Operator Status' == \"Missionary\""))
        {
            await _ui.ClickAsync(_locators.Missionary);
        }
        if (_data.Condition("'Operator Status' == \"OtherIns\""))
        {
            await _ui.ClickAsync(_locators.OtherInsurance);
        }
        if (_data.Condition("'Operator Status' == \"Roomate\""))
        {
            await _ui.ClickAsync(_locators.Roommate);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.WaitAsync(_locators.NonDriverReason, "Visible");
        }
        if (_data.Condition("'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.NeverLicensed);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.Underage);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.MedicalCondition);
        }
        if (_data.Condition("'If NonDriver: Reason' != \"NeverLicensed\" AND 'If NonDriver: Reason' != \"Underage\" AND 'If NonDriver: Reason' != \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.SelectAsync(_locators.MoreOptionsNonDriver, _data.Resolve(""));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.Surrendered);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.PermitDriver);
        }
        // EQDriverLicenseTime_01b659Page.LicenseInfo_0064_bafd4aAsync
        if (_data.Condition("'State Licensed(XX)' != NULL"))
        {
            await _ui.FillAsync(_locators.LicenseState, _data.Get("AL_ClientData.State"));
        }
        if (_data.Condition("'Drivers License #' != NULL"))
        {
            await _ui.FillAsync(_locators.DriverSLicenseNumber, _data.Resolve("{{data:driver_s_license_number_169}}"));
            await _ui.PressAsync(_locators.DriverSLicenseNumber, "CTRL+A");
        }
        if (_data.Condition("'Drivers License #' != NULL"))
        {
            await _ui.FillAsync(_locators.DriverSLicenseNumber, _data.Get("AL_ClientData.DL Number"));
        }
        await _ui.FillAsync(_locators.YrsLicensedCurrentState, _data.Resolve("{{data:yrs_licensed_current_state_171}}"));
        await _ui.PressAsync(_locators.YrsLicensedCurrentState, "CTRL+A");
        await _ui.FillAsync(_locators.YrsLicensedCurrentState, _data.Resolve("{{data:yrs_licensed_current_state_172}}"));
        await _ui.FillAsync(_locators.MonthsLicensedCurrentState, _data.Resolve("{{data:months_licensed_current_state_173}}"));
        await _ui.PressAsync(_locators.MonthsLicensedCurrentState, "CTRL+A");
        await _ui.FillAsync(_locators.MonthsLicensedCurrentState, _data.Resolve("{{data:months_licensed_current_state_174}}"));
        if (_data.Condition("'State' == \"TX\""))
        {
            await _ui.FillAsync(_locators.DaysOperatedUninsured, _data.Resolve("{{data:daysoperateduninsured_175}}"));
        }
        if (_data.Condition("'State' == \"CA\""))
        {
            await _ui.FillAsync(_locators.YrsLicensedAllStates, _data.Resolve("{{data:yrslicensed_all_states_176}}"));
            await _ui.PressAsync(_locators.YrsLicensedAllStates, "CTRL+A");
        }
        if (_data.Condition("'State' == \"CA\""))
        {
            await _ui.FillAsync(_locators.YrsLicensedAllStates, _data.Resolve("{{data:yrslicensed_all_states_177}}"));
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.NoD053A);
            await _ui.PressAsync(_locators.NoD053A, "Click");
            await _ui.PressAsync(_locators.NoD053A, "Scroll[2]");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0065_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove))
        {
            await _ui.VerifyAsync(_locators.WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0066_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.NoPreviouslyInsured))
        {
            await _ui.SelectAsync(_locators.NoPreviouslyInsured, _data.Resolve(""));
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0067_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.PriorCarrierName))
        {
            await _ui.VerifyAsync(_locators.PriorCarrierName, _data.Resolve("Exists"), "");
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0068_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.SaveAndContinue9CB7A))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0069_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.NoNeedWasNotLicensed))
        {
            await _ui.VerifyAsync(_locators.NoNeedWasNotLicensed, _data.Resolve("Visible"), "");
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0070_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.NoNeedWasNotLicensed))
        {
            await _ui.ClickAsync(_locators.NoNeedWasNotLicensed);
            await _ui.PressAsync(_locators.NoNeedWasNotLicensed, "End");
            await _ui.PressAsync(_locators.NoNeedWasNotLicensed, "Click");
        }
        await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        // EQPriorInsuranceInfo_a40db0Page.SaveContinue_0071_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.SaveAndContinue9CB7A))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        }
        // EQExpiredLicensePopUp_ac02e7Page.EQExpiredLicensePopUp_0072_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.CONTINUED555D))
        {
            await _ui.WaitAsync(_locators.CONTINUED555D, "Exists");
        }
        // EQExpiredLicensePopUp_ac02e7Page.EQExpiredLicensePopUp_0073_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.CONTINUED555D))
        {
            await _ui.ClickAsync(_locators.CONTINUED555D);
        }
    }

    // Business step: I complete vehicle Summary Automobile Rate Filing Common Auto
    public async Task CompleteVehicleSummaryAutomobileRateFilingCommonAutoAsync2()
    {
        // EQVehicleInformation_7d0869Page.EQVehicleInformation_0085_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.AdditionalVehicle))
        {
            await _ui.WaitAsync(_locators.AdditionalVehicle, "Visible");
        }
        // EQVehicleInformation_7d0869Page.EQVehicleInformation_0086_bafd4aAsync
        if (await _ui.ExistsAsync(_locators.AdditionalVehicle))
        {
            await _ui.ClickAsync(_locators.AdditionalVehicle);
        }
        await _ui.ClickAsync(_locators.VehicleInformationNext);
        // EQVehicleAutoVin1_fdc6bdPage.EQVehicleVin_0087_bafd4aAsync
        await _ui.WaitAsync(_locators.VIN06D01, "True");
        await _ui.ClickAsync(_locators.VIN06D01);
        await _ui.FillAsync(_locators.VIN06D01, _data.Resolve("{{data:txt_vin_210}}"));
        await _ui.PressAsync(_locators.VIN06D01, "POST:TAB");
        await _ui.PressAsync(_locators.VIN06D01, "Tab");
        await _ui.ClickAsync(_locators.Vehicle1);
        // EQVehicleSummaryAutoMotorHomeUse_e4fbccPage.EQVehicleSummaryAutoUse_0088_bafd4aAsync
        if (_data.Condition("Loan != NULL"))
        {
            await _ui.ClickAsync(_locators.Loan4369D);
        }
        if (_data.Condition("Lease != NULL"))
        {
            await _ui.ClickAsync(_locators.Leased14EA4);
        }
        if (_data.Condition("Loan == NULL AND Lease == NULL"))
        {
            await _ui.ClickAsync(_locators.Own49EEC);
        }
        if (_data.Condition("State == \"OK\""))
        {
            await _ui.SelectAsync(_locators.NativeAmericanRegisterNO, _data.Resolve(""));
        }
        if (_data.Condition("AntiTheft != NULL AND State != \"AZ\" AND State != \"MD\" AND State != \"OH\" AND State != \"CA\" AND State != \"VA\" AND State != \"WI\" AND State != \"UT\""))
        {
            await _ui.SelectAsync(_locators.AntiTheftYes, _data.Resolve(""));
        }
        if (_data.Condition("AntiTheft != NULL AND State == \"IL\""))
        {
            await _ui.ClickAsync(_locators.ILCategory1);
        }
        if (_data.Condition("State == \"NJ\" AND AntiTheft != NULL"))
        {
            await _ui.ClickAsync(_locators.CategoryI);
        }
        if (_data.Condition("AntiTheft != NULL AND (State == \"NY\" OR State == \"VT\")"))
        {
            await _ui.ClickAsync(_locators.ActiveDisablingDevice);
        }
        if (_data.Condition("PickUp != NULL AND (State == \"NY\" OR State = \"VA\")"))
        {
            await _ui.SelectAsync(_locators.CamperShellNo, _data.Resolve(""));
        }
        if (_data.Condition("State == \"CA\""))
        {
            await _ui.ClickAsync(_locators.PleasureCANYFFCIC);
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.ClickAsync(_locators.N1Day);
        }
        if (_data.Condition("State == \"NY\" AND Company == \"FFCIC\""))
        {
            await _ui.FillAsync(_locators.NYFFCICTotalAnnualMiles, _data.Resolve("{{data:ny_ffcic_total_annual_miles_224}}"));
            await _ui.PressAsync(_locators.NYFFCICTotalAnnualMiles, "CTRL+A");
        }
        if (_data.Condition("State == \"NY\" AND Company == \"FFCIC\""))
        {
            await _ui.FillAsync(_locators.NYFFCICTotalAnnualMiles, _data.Resolve("{{data:ny_ffcic_total_annual_miles_225}}"));
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.WorkMilesDay, _data.Resolve("{{data:work_miles_day_226}}"));
            await _ui.PressAsync(_locators.WorkMilesDay, "CTRL+A");
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.WorkMilesDay, _data.Resolve("{{data:work_miles_day_227}}"));
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.NonWorkAnnualMiles, _data.Resolve("{{data:non_work_annual_miles_228}}"));
            await _ui.PressAsync(_locators.NonWorkAnnualMiles, "CTRL+A");
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.NonWorkAnnualMiles, _data.Resolve("{{data:non_work_annual_miles_229}}"));
        }
        if (_data.Condition("'Farm/Use' != NULL AND State == \"CA\""))
        {
            await _ui.SelectAsync(_locators.UseCAMoreOptions, _data.Resolve(""));
        }
        if (_data.Condition("'Farm/Use' != NULL AND (State != \"NY\" and Company !=\"FFCIC\")"))
        {
            await _ui.SelectAsync(_locators.MoreOptionsFarmUse, _data.Resolve(""));
        }
        await _ui.FillAsync(_locators.PurchaseDateBB8AF, _data.Resolve("{{data:txt_purchase_date_232}}"));
        await _ui.PressAsync(_locators.PurchaseDateBB8AF, "CTRL+A");
        await _ui.FillAsync(_locators.PurchaseDateBB8AF, _data.Resolve("{{data:txt_purchase_date_233}}"));
        await _ui.FillAsync(_locators.Odometer3843F, _data.Resolve("{{data:txt_odometer_234}}"));
        await _ui.PressAsync(_locators.Odometer3843F, "CTRL+A");
        await _ui.FillAsync(_locators.Odometer3843F, _data.Resolve("{{data:txt_odometer_235}}"));
        if (_data.Condition("State != \"KS\""))
        {
            await _ui.FillAsync(_locators.AnnualMileage51344, _data.Resolve("{{data:txt_annual_mileage_236}}"));
            await _ui.PressAsync(_locators.AnnualMileage51344, "CTRL+A");
        }
        if (_data.Condition("State != \"KS\""))
        {
            await _ui.FillAsync(_locators.AnnualMileage51344, _data.Resolve("{{data:txt_annual_mileage_237}}"));
        }
        await _ui.ClickAsync(_locators.SaveContinue2E7CD);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0092_bafd4aAsync
        await _ui.ClickAsync(_locators.AddVehicle);
        // EQVehicleSummaryAutoAdditional_2aa54aPage.EQVehicleSummaryAutoAdditional_0093_bafd4aAsync
        await _ui.WaitAsync(_locators.VIN0A17C, "True");
        await _ui.FillAsync(_locators.VIN0A17C, _data.Resolve("{{data:vin_241}}"));
        await _ui.PressAsync(_locators.VIN0A17C, "POST:TAB");
        await _ui.PressAsync(_locators.VIN0A17C, "Tab");
        await _ui.ClickAsync(_locators.Veh1);
        await _ui.SelectAsync(_locators.VehicleMoreOptions, _data.Resolve(""));
        await _ui.ClickAsync(_locators.CollectorCar);
        await _ui.SelectAsync(_locators.CollectorCarTypeMoreOptions, _data.Resolve(""));
        await _ui.ClickAsync(_locators.Classic);
        await _ui.FillAsync(_locators.AgreedValue8E288, _data.Resolve("{{data:agreed_value_248}}"));
        await _ui.ClickAsync(_locators.OwnB8575);
        await _ui.ClickAsync(_locators.Continue);
        if (_data.Condition("State != \"KS\""))
        {
            await _ui.ClickAsync(_locators.RestrictedUse);
        }
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_252}}"));
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_253}}"));
        await _ui.PressAsync(_locators.TotalAnnualMileage, "CTRL+A");
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_254}}"));
        await _ui.ClickAsync(_locators.SaveContinue86B78);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0094_bafd4aAsync
        await _ui.ClickAsync(_locators.AddVehicle);
        // EQVehicleSummaryAutoAdditional_2aa54aPage.EQVehicleSummaryAutoAdditional_0095_bafd4aAsync
        await _ui.WaitAsync(_locators.VIN0A17C, "True");
        await _ui.FillAsync(_locators.VIN0A17C, _data.Resolve("{{data:vin_258}}"));
        await _ui.PressAsync(_locators.VIN0A17C, "POST:TAB");
        await _ui.PressAsync(_locators.VIN0A17C, "Tab");
        await _ui.ClickAsync(_locators.Veh3);
        await _ui.SelectAsync(_locators.VehicleMoreOptions, _data.Resolve(""));
        await _ui.ClickAsync(_locators.CollectorCar);
        await _ui.ClickAsync(_locators.ModernClassic);
        await _ui.FillAsync(_locators.AgreedValue8E288, _data.Resolve("{{data:agreed_value_264}}"));
        await _ui.ClickAsync(_locators.OwnB8575);
        await _ui.ClickAsync(_locators.Continue);
        if (_data.Condition("State != \"KS\""))
        {
            await _ui.ClickAsync(_locators.RestrictedUse);
        }
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_268}}"));
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_269}}"));
        await _ui.PressAsync(_locators.OdometerD648F, "CTRL+A");
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_270}}"));
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_271}}"));
        await _ui.PressAsync(_locators.TotalAnnualMileage, "CTRL+A");
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_272}}"));
        await _ui.ClickAsync(_locators.SaveContinue86B78);
        // EQCAVerifiedMileage_306316Page.EQCAVerifiedMileage_0096_bafd4aAsync
        if (_data.Condition("State == \"CA\""))
        {
            await _ui.ClickAsync(_locators.OptOut);
        }
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0097_bafd4aAsync
        await _ui.ClickAsync(_locators.PricingDetailsNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0098_bafd4aAsync
        _data.Set("Driver 1 Vehicle", _data.Resolve("{{data:driver_1_vehicle}}"));
        _data.Set("Driver 1 Principal Occasional", _data.Resolve("{{data:driver_1_principal_occasional}}"));
        _data.Set("Driver 2 Vehicle", _data.Get("Driver 2 Vehicle"));
        _data.Set("Driver 2 Principal Occasional", _data.Get("Driver 2 Principal Occasional"));
        _data.Set("Driver 3 Vehicle", _data.Get("Driver 3 Vehicle"));
        _data.Set("Driver 3 Principal Occasional", _data.Get("Driver 3 Principal Occasional"));
        _data.Set("Driver 4 Vehicle", _data.Get("Driver 4 Vehicle"));
        _data.Set("Driver 4 Principal Occasional", _data.Get("Driver 4 Principal Occasional"));
        _data.Set("Driver 5 Vehicle", _data.Get("Driver 5 Vehicle"));
        _data.Set("Driver 5 Principal Occasional", _data.Get("Driver 5 Principal Occasional"));
    }

    // Business step: I complete auto AddlCov Vehicle Coverages
    public async Task CompleteAutoAddlCovVehicleCoveragesAsync4()
    {
        // EQVehicleCoveragesSection_2f4d8bPage.EQVehicleCoveragesSection_0149_bafd4aAsync
        if (_data.Condition("'UMPD/UIMPD_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV1);
        }
        if (_data.Condition("'UMPD Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle1);
            await _ui.PressAsync(_locators.UMPDCoverageVehicle1, "Click");
            await _ui.PressAsync(_locators.UMPDCoverageVehicle1, "scroll[2]");
        }
        if (_data.Condition("'UMPD Coverage_V1' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV1);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV1);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV1, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV1, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV1);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V1' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV1);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV1, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV1, "Scroll[2]");
        }
        if (_data.Condition("'UMPD/UIMPD_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV2);
        }
        if (_data.Condition("'UMPD Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle2);
        }
        if (_data.Condition("'UMPD Coverage_V2' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV2);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV2);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV2, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV2, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV2);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV2);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV2, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV2, "scroll[2]");
        }
        if (_data.Condition("'Towing and Labor' != NULL"))
        {
            await _ui.SelectAsync(_locators.NoCoverageV1Towing, _data.Resolve(""));
        }
        if (_data.Condition("'UMPD/UIMPD_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV3);
        }
        if (_data.Condition("'UMPD Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle3);
        }
        if (_data.Condition("'UMPD Coverage_V3' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV3);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV3);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV3, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV3, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV3);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V3' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV3);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV3, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV3, "scroll[2]");
        }
        if (_data.Condition("'Cycle Accessories_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.CycleAccessoriesV3);
        }
        if (_data.Condition("'Original Parts_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.OriginalPartsV3);
        }
        if (_data.Condition("'UMPD/UIMPD_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV4);
        }
        if (_data.Condition("'UMPD Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle4);
        }
        if (_data.Condition("'UMPD Coverage_V4' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV4);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV4);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV4, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV4, "end");
        }
        if (_data.Condition("'Theft Deductible_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV4);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V4' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV4);
        }
        if (_data.Condition("'Cycle Accessories_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.CycleAccessoriesV4);
        }
        if (_data.Condition("'Original Parts_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.OriginalPartsV4);
        }
    }

    // Business step: I review the driver information summary
    public async Task ReviewTheDriverInformationSummaryAsync5()
    {
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0053_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.Single))
        {
            await _ui.VerifyAsync(_locators.Single, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0054_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.MaritalStatusSingle))
        {
            await _ui.ClickAsync(_locators.MaritalStatusSingle);
        }
        if (_data.Condition("'Marital Status' != \"Married\""))
        {
            await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' != \"Divorced\""))
        {
            await _ui.ClickAsync(_locators.Divorced);
        }
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
            await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
            await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
            await _ui.ClickAsync(_locators.Divorced);
        }
        // EQDriverEducationLevel_5a720bPage.DriverEducationLevel_0055_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.HighSchoolDiplomaOrGED))
        {
            await _ui.VerifyAsync(_locators.HighSchoolDiplomaOrGED, _data.Resolve("True"), "Enabled");
        }
        // EQDriverEducationLevel_5a720bPage.DriverEducationLevel_0056_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.MDNJEducationLevelUnknown))
        {
            await _ui.ClickAsync(_locators.MDNJEducationLevelUnknown);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Unknown\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"HighSchool\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"HighSchool\""))
        {
            await _ui.ClickAsync(_locators.HighSchoolDiplomaOrGED);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Trade\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Trade\""))
        {
            await _ui.ClickAsync(_locators.VocationalOrTradeSchoolDegree);
        }
        if (_data.Condition("MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\""))
        {
            await _ui.SelectAsync(_locators.MoreOptionsEdu, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"SomeCollege\""))
        {
            await _ui.WaitAsync(_locators.SomeCollege, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"SomeCollege\""))
        {
            await _ui.ClickAsync(_locators.SomeCollege);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"InCollege\""))
        {
            await _ui.WaitAsync(_locators.CurrentlyInCollege, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"InCollege\""))
        {
            await _ui.ClickAsync(_locators.CurrentlyInCollege);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"CollegeDegree\""))
        {
            await _ui.WaitAsync(_locators.CollegeDegreeGraduateWork, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"CollegeDegree\""))
        {
            await _ui.ClickAsync(_locators.CollegeDegreeGraduateWork);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.WaitAsync(_locators.GraduateDegreeJDMasters, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.ClickAsync(_locators.GraduateDegreeJDMasters);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.WaitAsync(_locators.PostGraduateDegreeMedicalDegreePhDEdDEtc, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.ClickAsync(_locators.PostGraduateDegreeMedicalDegreePhDEdDEtc);
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0057_8f4c8fAsync
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Condition verify relationship spouse button exist; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.Spouse, _data.Resolve("Exists"), "");
        }
        await _ui.ClickAsync(_locators.AccountOwner);
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0058_8f4c8fAsync
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Then Relationship for account owner exist; 'Policy Type' != \"Cycle\""))
        {
            await _ui.SelectAsync(_locators.RelationshipToAccountOwnerNULL, _data.Resolve("{{data:select_relationship_to_account_owner_null_122}}"));
        }
        if (_data.Condition("'Relationship to Account Owner' != NULL"))
        {
            await _ui.ClickAsync(_locators.AccountOwner);
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0059_8f4c8fAsync
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Condition Check if Relationship is account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.AccountOwnerReadOnly, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0060_8f4c8fAsync
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Then Relationship is account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.AccountOwnerReadOnly, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0061_8f4c8fAsync
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Else Make script fail due to Relationship other than account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.AccountOwner);
            await _ui.PressAsync(_locators.AccountOwner, "Click");
            await _ui.PressAsync(_locators.AccountOwner, "scroll[2]");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatusCycle_0062_8f4c8fAsync
        if (_data.Condition("'Policy Type' == \"Cycle\""))
        {
            await _ui.WaitAsync(_locators.IsThisDriverANamedInsured, "Visible");
        }
        if (_data.Condition("'Named Insured?' == \"PrimaryNamedIns\""))
        {
            await _ui.ClickAsync(_locators.PrimaryNamedInsured);
            await _ui.PressAsync(_locators.PrimaryNamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NamedIns\""))
        {
            await _ui.ClickAsync(_locators.NamedInsured);
            await _ui.PressAsync(_locators.NamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NotNamedIns\""))
        {
            await _ui.ClickAsync(_locators.NotANamedInsured);
            await _ui.PressAsync(_locators.NotANamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Related);
            await _ui.PressAsync(_locators.Related, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
            await _ui.PressAsync(_locators.Related, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"NoCycleLicense\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"NoCycleLicense\""))
        {
            await _ui.SelectAsync(_locators.NoCycleLicense, _data.Resolve(""));
        }
        if (_data.Condition("'Operator Status' != \"Assigned\" AND 'Operator Status' != \"NoCycleLicense\" AND 'Operator Status' != \"Related\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Military\""))
        {
            await _ui.ClickAsync(_locators.Military);
        }
        if (_data.Condition("'Operator Status' == \"Missionary\""))
        {
            await _ui.ClickAsync(_locators.Missionary);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.SelectAsync(_locators.NonDriver, _data.Resolve(""));
        }
        if (_data.Condition("'Operator Status' == \"OtherIns\""))
        {
            await _ui.ClickAsync(_locators.OtherInsurance);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.WaitAsync(_locators.NonDriverReason, "Visible");
        }
        if (_data.Condition("'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_143}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_144}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_145}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_146}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_147}}"));
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0063_8f4c8fAsync
        if (_data.Condition("'Policy Type' != \"Cycle\""))
        {
            await _ui.WaitAsync(_locators.IsThisDriverANamedInsured, "Visible");
        }
        if (_data.Condition("'Named Insured?' == \"PrimaryNamedIns\""))
        {
            await _ui.ClickAsync(_locators.PrimaryNamedInsured);
            await _ui.PressAsync(_locators.PrimaryNamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NamedIns\""))
        {
            await _ui.ClickAsync(_locators.NamedInsured);
            await _ui.PressAsync(_locators.NamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NotNamedIns\""))
        {
            await _ui.ClickAsync(_locators.NotANamedInsured);
            await _ui.PressAsync(_locators.NotANamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.NonDriver);
            await _ui.PressAsync(_locators.NonDriver, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
        }
        if (_data.Condition("'Operator Status' == \"Military\""))
        {
            await _ui.ClickAsync(_locators.Military);
        }
        if (_data.Condition("'Operator Status' == \"Missionary\""))
        {
            await _ui.ClickAsync(_locators.Missionary);
        }
        if (_data.Condition("'Operator Status' == \"OtherIns\""))
        {
            await _ui.ClickAsync(_locators.OtherInsurance);
        }
        if (_data.Condition("'Operator Status' == \"Roomate\""))
        {
            await _ui.ClickAsync(_locators.Roommate);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.WaitAsync(_locators.NonDriverReason, "Visible");
        }
        if (_data.Condition("'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.NeverLicensed);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.Underage);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.MedicalCondition);
        }
        if (_data.Condition("'If NonDriver: Reason' != \"NeverLicensed\" AND 'If NonDriver: Reason' != \"Underage\" AND 'If NonDriver: Reason' != \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.SelectAsync(_locators.MoreOptionsNonDriver, _data.Resolve(""));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.Surrendered);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.PermitDriver);
        }
        // EQDriverLicenseTime_01b659Page.LicenseInfo_0064_8f4c8fAsync
        if (_data.Condition("'State Licensed(XX)' != NULL"))
        {
            await _ui.FillAsync(_locators.LicenseState, _data.Get("AL_ClientData.State"));
        }
        if (_data.Condition("'Drivers License #' != NULL"))
        {
            await _ui.FillAsync(_locators.DriverSLicenseNumber, _data.Resolve("{{data:driver_s_license_number_169}}"));
            await _ui.PressAsync(_locators.DriverSLicenseNumber, "CTRL+A");
        }
        if (_data.Condition("'Drivers License #' != NULL"))
        {
            await _ui.FillAsync(_locators.DriverSLicenseNumber, _data.Get("AL_ClientData.DL Number"));
        }
        await _ui.FillAsync(_locators.YrsLicensedCurrentState, _data.Resolve("{{data:yrs_licensed_current_state_171}}"));
        await _ui.PressAsync(_locators.YrsLicensedCurrentState, "CTRL+A");
        await _ui.FillAsync(_locators.YrsLicensedCurrentState, _data.Resolve("{{data:yrs_licensed_current_state_172}}"));
        await _ui.FillAsync(_locators.MonthsLicensedCurrentState, _data.Resolve("{{data:months_licensed_current_state_173}}"));
        await _ui.PressAsync(_locators.MonthsLicensedCurrentState, "CTRL+A");
        await _ui.FillAsync(_locators.MonthsLicensedCurrentState, _data.Resolve("{{data:months_licensed_current_state_174}}"));
        if (_data.Condition("'State' == \"TX\""))
        {
            await _ui.FillAsync(_locators.DaysOperatedUninsured, _data.Resolve("{{data:daysoperateduninsured_175}}"));
        }
        if (_data.Condition("'State' == \"CA\""))
        {
            await _ui.FillAsync(_locators.YrsLicensedAllStates, _data.Resolve("{{data:yrslicensed_all_states_176}}"));
            await _ui.PressAsync(_locators.YrsLicensedAllStates, "CTRL+A");
        }
        if (_data.Condition("'State' == \"CA\""))
        {
            await _ui.FillAsync(_locators.YrsLicensedAllStates, _data.Resolve("{{data:yrslicensed_all_states_177}}"));
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.NoD053A);
            await _ui.PressAsync(_locators.NoD053A, "Click");
            await _ui.PressAsync(_locators.NoD053A, "Scroll[2]");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0065_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove))
        {
            await _ui.VerifyAsync(_locators.WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0066_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.NoPreviouslyInsured))
        {
            await _ui.SelectAsync(_locators.NoPreviouslyInsured, _data.Resolve(""));
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0067_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.PriorCarrierName))
        {
            await _ui.VerifyAsync(_locators.PriorCarrierName, _data.Resolve("Exists"), "");
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0068_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.SaveAndContinue9CB7A))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0069_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.NoNeedWasNotLicensed))
        {
            await _ui.VerifyAsync(_locators.NoNeedWasNotLicensed, _data.Resolve("Visible"), "");
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0070_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.NoNeedWasNotLicensed))
        {
            await _ui.ClickAsync(_locators.NoNeedWasNotLicensed);
            await _ui.PressAsync(_locators.NoNeedWasNotLicensed, "End");
            await _ui.PressAsync(_locators.NoNeedWasNotLicensed, "Click");
        }
        await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        // EQPriorInsuranceInfo_a40db0Page.SaveContinue_0071_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.SaveAndContinue9CB7A))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        }
        // EQExpiredLicensePopUp_ac02e7Page.EQExpiredLicensePopUp_0072_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.CONTINUED555D))
        {
            await _ui.WaitAsync(_locators.CONTINUED555D, "Exists");
        }
        // EQExpiredLicensePopUp_ac02e7Page.EQExpiredLicensePopUp_0073_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.CONTINUED555D))
        {
            await _ui.ClickAsync(_locators.CONTINUED555D);
        }
    }

    // Business step: I complete vehicle Summary Automobile Rate Filing
    public async Task CompleteVehicleSummaryAutomobileRateFilingAsync2()
    {
        // EQCAVerifiedMileage_306316Page.EQCAVerifiedMileage_0085_8f4c8fAsync
        await _ui.VerifyAsync(_locators.EQCAVerifiedMileage, _data.Resolve("Exists"), "");
        // EQVehicleInformation_7d0869Page.EQVehicleInformation_0086_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.MOREOPTIONS))
        {
            await _ui.WaitAsync(_locators.MOREOPTIONS, "Visible");
        }
        // EQVehicleInformation_7d0869Page.EQVehicleInformation_0087_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.MOREOPTIONS))
        {
            await _ui.SelectAsync(_locators.MOREOPTIONS, _data.Resolve(""));
        }
        await _ui.ClickAsync(_locators.AdditionalVehicleS62C9A);
        await _ui.ClickAsync(_locators.VehicleInformationNext);
        // EQVehicleInformation_7d0869Page.EQVehicleInformation_0088_8f4c8fAsync
        if (await _ui.ExistsAsync(_locators.AdditionalVehicle))
        {
            await _ui.ClickAsync(_locators.AdditionalVehicle);
        }
        await _ui.ClickAsync(_locators.VehicleInformationNext);
        // EQVehicleAutoVin1_fdc6bdPage.EQVehicleVin_0089_8f4c8fAsync
        await _ui.WaitAsync(_locators.VIN06D01, "True");
        await _ui.ClickAsync(_locators.VIN06D01);
        await _ui.FillAsync(_locators.VIN06D01, _data.Resolve("{{data:txt_vin_214}}"));
        await _ui.PressAsync(_locators.VIN06D01, "POST:TAB");
        await _ui.PressAsync(_locators.VIN06D01, "Tab");
        await _ui.ClickAsync(_locators.Vehicle1);
        // EQVehicleSummaryAutoMotorHomeUse_e4fbccPage.EQVehicleSummaryAutoUse_0090_8f4c8fAsync
        if (_data.Condition("Loan != NULL"))
        {
            await _ui.ClickAsync(_locators.Loan4369D);
        }
        if (_data.Condition("Lease != NULL"))
        {
            await _ui.ClickAsync(_locators.Leased14EA4);
        }
        if (_data.Condition("Loan == NULL AND Lease == NULL"))
        {
            await _ui.ClickAsync(_locators.Own49EEC);
        }
        if (_data.Condition("State == \"OK\""))
        {
            await _ui.SelectAsync(_locators.NativeAmericanRegisterNO, _data.Resolve(""));
        }
        if (_data.Condition("AntiTheft != NULL AND State != \"AZ\" AND State != \"MD\" AND State != \"OH\" AND State != \"CA\" AND State != \"VA\" AND State != \"WI\" AND State != \"UT\""))
        {
            await _ui.SelectAsync(_locators.AntiTheftYes, _data.Resolve(""));
        }
        if (_data.Condition("AntiTheft != NULL AND State == \"IL\""))
        {
            await _ui.ClickAsync(_locators.ILCategory1);
        }
        if (_data.Condition("State == \"NJ\" AND AntiTheft != NULL"))
        {
            await _ui.ClickAsync(_locators.CategoryI);
        }
        if (_data.Condition("AntiTheft != NULL AND (State == \"NY\" OR State == \"VT\")"))
        {
            await _ui.ClickAsync(_locators.ActiveDisablingDevice);
        }
        if (_data.Condition("PickUp != NULL AND (State == \"NY\" OR State = \"VA\")"))
        {
            await _ui.SelectAsync(_locators.CamperShellNo, _data.Resolve(""));
        }
        if (_data.Condition("State == \"CA\""))
        {
            await _ui.ClickAsync(_locators.PleasureCANYFFCIC);
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.ClickAsync(_locators.N1Day);
        }
        if (_data.Condition("State == \"NY\" AND Company == \"FFCIC\""))
        {
            await _ui.FillAsync(_locators.NYFFCICTotalAnnualMiles, _data.Resolve("{{data:ny_ffcic_total_annual_miles_228}}"));
            await _ui.PressAsync(_locators.NYFFCICTotalAnnualMiles, "CTRL+A");
        }
        if (_data.Condition("State == \"NY\" AND Company == \"FFCIC\""))
        {
            await _ui.FillAsync(_locators.NYFFCICTotalAnnualMiles, _data.Resolve("{{data:ny_ffcic_total_annual_miles_229}}"));
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.WorkMilesDay, _data.Resolve("{{data:work_miles_day_230}}"));
            await _ui.PressAsync(_locators.WorkMilesDay, "CTRL+A");
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.WorkMilesDay, _data.Resolve("{{data:work_miles_day_231}}"));
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.NonWorkAnnualMiles, _data.Resolve("{{data:non_work_annual_miles_232}}"));
            await _ui.PressAsync(_locators.NonWorkAnnualMiles, "CTRL+A");
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.NonWorkAnnualMiles, _data.Resolve("{{data:non_work_annual_miles_233}}"));
        }
        if (_data.Condition("'Farm/Use' != NULL AND State == \"CA\""))
        {
            await _ui.SelectAsync(_locators.UseCAMoreOptions, _data.Resolve(""));
        }
        if (_data.Condition("'Farm/Use' != NULL AND (State != \"NY\" and Company !=\"FFCIC\")"))
        {
            await _ui.SelectAsync(_locators.MoreOptionsFarmUse, _data.Resolve(""));
        }
        await _ui.FillAsync(_locators.PurchaseDateBB8AF, _data.Resolve("{{data:txt_purchase_date_236}}"));
        await _ui.PressAsync(_locators.PurchaseDateBB8AF, "CTRL+A");
        await _ui.FillAsync(_locators.PurchaseDateBB8AF, _data.Resolve("{{data:txt_purchase_date_237}}"));
        await _ui.FillAsync(_locators.Odometer3843F, _data.Resolve("{{data:txt_odometer_238}}"));
        await _ui.PressAsync(_locators.Odometer3843F, "CTRL+A");
        await _ui.FillAsync(_locators.Odometer3843F, _data.Resolve("{{data:txt_odometer_239}}"));
        await _ui.ClickAsync(_locators.SaveContinue2E7CD);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0094_8f4c8fAsync
        await _ui.ClickAsync(_locators.AddVehicle);
        // EQVehicleSummaryAutoAdditional_2aa54aPage.EQVehicleSummaryAutoAdditional_0095_8f4c8fAsync
        await _ui.WaitAsync(_locators.VIN0A17C, "True");
        await _ui.FillAsync(_locators.VIN0A17C, _data.Resolve("{{data:vin_243}}"));
        await _ui.PressAsync(_locators.VIN0A17C, "POST:TAB");
        await _ui.PressAsync(_locators.VIN0A17C, "Tab");
        await _ui.ClickAsync(_locators.Veh1);
        await _ui.ClickAsync(_locators.VehicleMoreOptions);
        await _ui.PressAsync(_locators.VehicleMoreOptions, "Click");
        await _ui.PressAsync(_locators.VehicleMoreOptions, "Scroll[1]");
        await _ui.ClickAsync(_locators.CollectorCar);
        await _ui.SelectAsync(_locators.CollectorCarTypeMoreOptions, _data.Resolve(""));
        await _ui.ClickAsync(_locators.Classic);
        await _ui.PressAsync(_locators.Classic, "Click");
        await _ui.PressAsync(_locators.Classic, "scroll[3]");
        await _ui.FillAsync(_locators.AgreedValue8E288, _data.Resolve("{{data:agreed_value_250}}"));
        await _ui.ClickAsync(_locators.OwnB8575);
        await _ui.PressAsync(_locators.OwnB8575, "scroll[3]");
        await _ui.PressAsync(_locators.OwnB8575, "Click");
        await _ui.ClickAsync(_locators.Continue);
        await _ui.ClickAsync(_locators.RestrictedUse);
        await _ui.PressAsync(_locators.RestrictedUse, "scroll[2]");
        await _ui.PressAsync(_locators.RestrictedUse, "Click");
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_254}}"));
        await _ui.PressAsync(_locators.AppraisalDate8A115, "CTRL+A");
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_255}}"));
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_256}}"));
        await _ui.PressAsync(_locators.TotalAnnualMileage, "CTRL+A");
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_257}}"));
        await _ui.ClickAsync(_locators.SaveContinue86B78);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0096_8f4c8fAsync
        await _ui.ClickAsync(_locators.AddVehicle);
        // EQVehicleSummaryAutoAdditional_2aa54aPage.EQVehicleSummaryAutoAdditional_0097_8f4c8fAsync
        await _ui.WaitAsync(_locators.VIN0A17C, "True");
        await _ui.FillAsync(_locators.VIN0A17C, _data.Resolve("{{data:vin_261}}"));
        await _ui.PressAsync(_locators.VIN0A17C, "POST:TAB");
        await _ui.PressAsync(_locators.VIN0A17C, "Tab");
        await _ui.ClickAsync(_locators.Veh3);
        await _ui.SelectAsync(_locators.VehicleMoreOptions, _data.Resolve(""));
        await _ui.ClickAsync(_locators.CollectorCar);
        await _ui.PressAsync(_locators.CollectorCar, "Click");
        await _ui.PressAsync(_locators.CollectorCar, "scroll[1]");
        await _ui.ClickAsync(_locators.ModernClassic);
        await _ui.PressAsync(_locators.ModernClassic, "Click");
        await _ui.PressAsync(_locators.ModernClassic, "scroll[2]");
        await _ui.FillAsync(_locators.AgreedValue8E288, _data.Resolve("{{data:agreed_value_267}}"));
        await _ui.ClickAsync(_locators.OwnB8575);
        await _ui.PressAsync(_locators.OwnB8575, "scroll[2]");
        await _ui.PressAsync(_locators.OwnB8575, "Click");
        await _ui.PressAsync(_locators.OwnB8575, "scroll[2]");
        await _ui.ClickAsync(_locators.Continue);
        await _ui.ClickAsync(_locators.RestrictedUse);
        await _ui.PressAsync(_locators.RestrictedUse, "Click");
        await _ui.PressAsync(_locators.RestrictedUse, "END");
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_271}}"));
        await _ui.PressAsync(_locators.AppraisalDate8A115, "CTRL+A");
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_272}}"));
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_273}}"));
        await _ui.PressAsync(_locators.OdometerD648F, "CTRL+A");
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_274}}"));
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_275}}"));
        await _ui.PressAsync(_locators.TotalAnnualMileage, "CTRL+A");
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_276}}"));
        await _ui.ClickAsync(_locators.SaveContinue86B78);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0098_8f4c8fAsync
        await _ui.ClickAsync(_locators.AddVehicle);
        // EQVehicleSummaryAutoAdditional_2aa54aPage.EQVehicleSummaryAutoAdditional_0099_8f4c8fAsync
        await _ui.WaitAsync(_locators.VIN0A17C, "True");
        await _ui.FillAsync(_locators.VIN0A17C, _data.Get("VIN 4"));
        await _ui.PressAsync(_locators.VIN0A17C, "POST:TAB");
        await _ui.PressAsync(_locators.VIN0A17C, "Tab");
        await _ui.ClickAsync(_locators.Veh1);
        await _ui.ClickAsync(_locators.OwnB8575);
        await _ui.PressAsync(_locators.OwnB8575, "Click");
        await _ui.PressAsync(_locators.OwnB8575, "scroll[2]");
        await _ui.ClickAsync(_locators.Continue);
        await _ui.FillAsync(_locators.PurchaseDate736F4, _data.Resolve("{{data:purchase_date_285}}"));
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_286}}"));
        await _ui.PressAsync(_locators.OdometerD648F, "CTRL+A");
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_287}}"));
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_288}}"));
        await _ui.PressAsync(_locators.TotalAnnualMileage, "CTRL+A");
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Get("Annual Mileage Veh 4"));
        await _ui.ClickAsync(_locators.SaveContinue86B78);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0100_8f4c8fAsync
        await _ui.WaitAsync(_locators.PricingDetailsNext, "Exists");
        await _ui.ClickAsync(_locators.PricingDetailsNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0101_8f4c8fAsync
        _data.Set("Driver 1 Vehicle", _data.Resolve("{{data:driver_1_vehicle}}"));
        _data.Set("Driver 1 Principal Occasional", _data.Resolve("{{data:driver_1_principal_occasional}}"));
        _data.Set("Driver 2 Vehicle", _data.Get("Driver 2 Vehicle"));
        _data.Set("Driver 2 Principal Occasional", _data.Get("Driver 2 Principal Occasional"));
        _data.Set("Driver 3 Vehicle", _data.Get("Driver 3 Vehicle"));
        _data.Set("Driver 3 Principal Occasional", _data.Get("Driver 3 Principal Occasional"));
        _data.Set("Driver 4 Vehicle", _data.Get("Driver 4 Vehicle"));
        _data.Set("Driver 4 Principal Occasional", _data.Get("Driver 4 Principal Occasional"));
        _data.Set("Driver 5 Vehicle", _data.Get("Driver 5 Vehicle"));
        _data.Set("Driver 5 Principal Occasional", _data.Get("Driver 5 Principal Occasional"));
    }

    // Business step: I complete auto AddlCov Vehicle Coverages
    public async Task CompleteAutoAddlCovVehicleCoveragesAsync5()
    {
        // EQVehicleCoveragesSection_2f4d8bPage.EQVehicleCoveragesSection_0152_8f4c8fAsync
        if (_data.Condition("'UMPD/UIMPD_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV1);
        }
        if (_data.Condition("'UMPD Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle1);
            await _ui.PressAsync(_locators.UMPDCoverageVehicle1, "Click");
            await _ui.PressAsync(_locators.UMPDCoverageVehicle1, "scroll[2]");
        }
        if (_data.Condition("'UMPD Coverage_V1' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV1);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV1);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV1, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV1, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV1);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V1' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV1);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV1, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV1, "Scroll[2]");
        }
        if (_data.Condition("'UMPD/UIMPD_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV2);
        }
        if (_data.Condition("'UMPD Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle2);
        }
        if (_data.Condition("'UMPD Coverage_V2' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV2);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV2);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV2, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV2, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV2);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV2);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV2, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV2, "scroll[2]");
        }
        if (_data.Condition("'Towing and Labor' != NULL"))
        {
            await _ui.SelectAsync(_locators.NoCoverageV1Towing, _data.Resolve(""));
        }
        if (_data.Condition("'UMPD/UIMPD_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV3);
        }
        if (_data.Condition("'UMPD Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle3);
        }
        if (_data.Condition("'UMPD Coverage_V3' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV3);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV3);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV3, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV3, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV3);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V3' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV3);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV3, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV3, "scroll[2]");
        }
        if (_data.Condition("'Cycle Accessories_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.CycleAccessoriesV3);
        }
        if (_data.Condition("'Original Parts_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.OriginalPartsV3);
        }
        if (_data.Condition("'UMPD/UIMPD_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV4);
        }
        if (_data.Condition("'UMPD Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle4);
        }
        if (_data.Condition("'UMPD Coverage_V4' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV4);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV4);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV4, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV4, "end");
        }
        if (_data.Condition("'Theft Deductible_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV4);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V4' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV4);
        }
        if (_data.Condition("'Cycle Accessories_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.CycleAccessoriesV4);
        }
        if (_data.Condition("'Original Parts_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.OriginalPartsV4);
        }
    }

    // Business step: I review the driver information summary
    public async Task ReviewTheDriverInformationSummaryAsync6()
    {
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0053_10f911Async
        if (await _ui.ExistsAsync(_locators.Single))
        {
            await _ui.VerifyAsync(_locators.Single, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0054_10f911Async
        if (await _ui.ExistsAsync(_locators.MaritalStatusSingle))
        {
            await _ui.ClickAsync(_locators.MaritalStatusSingle);
        }
        if (_data.Condition("'Marital Status' != \"Married\""))
        {
            await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' != \"Divorced\""))
        {
            await _ui.ClickAsync(_locators.Divorced);
        }
        if (_data.Condition("'Marital Status' == \"Single\""))
        {
            await _ui.ClickAsync(_locators.Single);
        }
        if (_data.Condition("'Marital Status' == \"Married\""))
        {
            await _ui.SelectAsync(_locators.Married, _data.Resolve(""));
        }
        if (_data.Condition("'Marital Status' == \"Divorced\""))
        {
            await _ui.ClickAsync(_locators.Divorced);
        }
        // EQDriverEducationLevel_5a720bPage.DriverEducationLevel_0055_10f911Async
        if (await _ui.ExistsAsync(_locators.HighSchoolDiplomaOrGED))
        {
            await _ui.VerifyAsync(_locators.HighSchoolDiplomaOrGED, _data.Resolve("True"), "Enabled");
        }
        // EQDriverEducationLevel_5a720bPage.DriverEducationLevel_0056_10f911Async
        if (await _ui.ExistsAsync(_locators.MDNJEducationLevelUnknown))
        {
            await _ui.ClickAsync(_locators.MDNJEducationLevelUnknown);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Unknown\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"HighSchool\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"HighSchool\""))
        {
            await _ui.ClickAsync(_locators.HighSchoolDiplomaOrGED);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Trade\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"Trade\""))
        {
            await _ui.ClickAsync(_locators.VocationalOrTradeSchoolDegree);
        }
        if (_data.Condition("MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\""))
        {
            await _ui.SelectAsync(_locators.UnknownNoHighSchoolDiplomaOrGED, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel != \"Unknown\" AND MD_NJ_EducationLevel != \"HighSchool\" AND MD_NJ_EducationLevel != \"Trade\""))
        {
            await _ui.SelectAsync(_locators.MoreOptionsEdu, _data.Resolve(""));
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"SomeCollege\""))
        {
            await _ui.WaitAsync(_locators.SomeCollege, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"SomeCollege\""))
        {
            await _ui.ClickAsync(_locators.SomeCollege);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"InCollege\""))
        {
            await _ui.WaitAsync(_locators.CurrentlyInCollege, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"InCollege\""))
        {
            await _ui.ClickAsync(_locators.CurrentlyInCollege);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"CollegeDegree\""))
        {
            await _ui.WaitAsync(_locators.CollegeDegreeGraduateWork, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"CollegeDegree\""))
        {
            await _ui.ClickAsync(_locators.CollegeDegreeGraduateWork);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.WaitAsync(_locators.GraduateDegreeJDMasters, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.ClickAsync(_locators.GraduateDegreeJDMasters);
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.WaitAsync(_locators.PostGraduateDegreeMedicalDegreePhDEdDEtc, "Visible");
        }
        if (_data.Condition("MD_NJ_EducationLevel == \"GradDegree\""))
        {
            await _ui.ClickAsync(_locators.PostGraduateDegreeMedicalDegreePhDEdDEtc);
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0057_10f911Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Condition verify relationship spouse button exist; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.Spouse, _data.Resolve("Exists"), "");
        }
        await _ui.ClickAsync(_locators.AccountOwner);
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0058_10f911Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Then Relationship for account owner exist; 'Policy Type' != \"Cycle\""))
        {
            await _ui.SelectAsync(_locators.RelationshipToAccountOwnerNULL, _data.Resolve("{{data:select_relationship_to_account_owner_null_122}}"));
        }
        if (_data.Condition("'Relationship to Account Owner' != NULL"))
        {
            await _ui.ClickAsync(_locators.AccountOwner);
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0059_10f911Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Condition Check if Relationship is account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.AccountOwnerReadOnly, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0060_10f911Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Then Relationship is account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.VerifyAsync(_locators.AccountOwnerReadOnly, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0061_10f911Async
        if (_data.Condition("If options for Relationship to Account Owner are enabled > Else Check if Relationship is read only > If Check if Relationship is account owner > Else Make script fail due to Relationship other than account owner; 'Policy Type' != \"Cycle\""))
        {
            await _ui.ClickAsync(_locators.AccountOwner);
            await _ui.PressAsync(_locators.AccountOwner, "Click");
            await _ui.PressAsync(_locators.AccountOwner, "scroll[2]");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatusCycle_0062_10f911Async
        if (_data.Condition("'Policy Type' == \"Cycle\""))
        {
            await _ui.WaitAsync(_locators.IsThisDriverANamedInsured, "Visible");
        }
        if (_data.Condition("'Named Insured?' == \"PrimaryNamedIns\""))
        {
            await _ui.ClickAsync(_locators.PrimaryNamedInsured);
            await _ui.PressAsync(_locators.PrimaryNamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NamedIns\""))
        {
            await _ui.ClickAsync(_locators.NamedInsured);
            await _ui.PressAsync(_locators.NamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NotNamedIns\""))
        {
            await _ui.ClickAsync(_locators.NotANamedInsured);
            await _ui.PressAsync(_locators.NotANamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Related);
            await _ui.PressAsync(_locators.Related, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
            await _ui.PressAsync(_locators.Related, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"NoCycleLicense\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"NoCycleLicense\""))
        {
            await _ui.SelectAsync(_locators.NoCycleLicense, _data.Resolve(""));
        }
        if (_data.Condition("'Operator Status' != \"Assigned\" AND 'Operator Status' != \"NoCycleLicense\" AND 'Operator Status' != \"Related\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' == \"Military\""))
        {
            await _ui.ClickAsync(_locators.Military);
        }
        if (_data.Condition("'Operator Status' == \"Missionary\""))
        {
            await _ui.ClickAsync(_locators.Missionary);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.SelectAsync(_locators.NonDriver, _data.Resolve(""));
        }
        if (_data.Condition("'Operator Status' == \"OtherIns\""))
        {
            await _ui.ClickAsync(_locators.OtherInsurance);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.WaitAsync(_locators.NonDriverReason, "Visible");
        }
        if (_data.Condition("'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_143}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_144}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_145}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_146}}"));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\""))
        {
            await _ui.FillAsync(_locators.CycleNonDriverComboBox, _data.Resolve("{{data:cyclenondriver_combobox_147}}"));
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0063_10f911Async
        if (_data.Condition("'Policy Type' != \"Cycle\""))
        {
            await _ui.WaitAsync(_locators.IsThisDriverANamedInsured, "Visible");
        }
        if (_data.Condition("'Named Insured?' == \"PrimaryNamedIns\""))
        {
            await _ui.ClickAsync(_locators.PrimaryNamedInsured);
            await _ui.PressAsync(_locators.PrimaryNamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NamedIns\""))
        {
            await _ui.ClickAsync(_locators.NamedInsured);
            await _ui.PressAsync(_locators.NamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Named Insured?' == \"NotNamedIns\""))
        {
            await _ui.ClickAsync(_locators.NotANamedInsured);
            await _ui.PressAsync(_locators.NotANamedInsured, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
            await _ui.PressAsync(_locators.Assigned, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.NonDriver);
            await _ui.PressAsync(_locators.NonDriver, "scroll[2]");
        }
        if (_data.Condition("'Operator Status' != \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.Assigned);
        }
        if (_data.Condition("'Operator Status' == \"Related\""))
        {
            await _ui.ClickAsync(_locators.Related);
        }
        if (_data.Condition("'Operator Status' == \"Military\""))
        {
            await _ui.ClickAsync(_locators.Military);
        }
        if (_data.Condition("'Operator Status' == \"Missionary\""))
        {
            await _ui.ClickAsync(_locators.Missionary);
        }
        if (_data.Condition("'Operator Status' == \"OtherIns\""))
        {
            await _ui.ClickAsync(_locators.OtherInsurance);
        }
        if (_data.Condition("'Operator Status' == \"Roomate\""))
        {
            await _ui.ClickAsync(_locators.Roommate);
        }
        if (_data.Condition("'Operator Status' == \"NonDriver\""))
        {
            await _ui.WaitAsync(_locators.NonDriverReason, "Visible");
        }
        if (_data.Condition("'If NonDriver: Reason' == \"NeverLicensed\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.NeverLicensed);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Underage\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.Underage);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.MedicalCondition);
        }
        if (_data.Condition("'If NonDriver: Reason' != \"NeverLicensed\" AND 'If NonDriver: Reason' != \"Underage\" AND 'If NonDriver: Reason' != \"MedCondition\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.SelectAsync(_locators.MoreOptionsNonDriver, _data.Resolve(""));
        }
        if (_data.Condition("'If NonDriver: Reason' == \"Surrendered\" AND 'Operator Status' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.Surrendered);
        }
        if (_data.Condition("'If NonDriver: Reason' == \"PermitDriver\" AND 'If NonDriver: Reason' == \"NonDriver\""))
        {
            await _ui.ClickAsync(_locators.PermitDriver);
        }
        // EQDriverLicenseTime_01b659Page.LicenseInfo_0064_10f911Async
        if (_data.Condition("'State Licensed(XX)' != NULL"))
        {
            await _ui.FillAsync(_locators.LicenseState, _data.Get("AL_ClientData.State"));
        }
        if (_data.Condition("'Drivers License #' != NULL"))
        {
            await _ui.FillAsync(_locators.DriverSLicenseNumber, _data.Resolve("{{data:driver_s_license_number_169}}"));
            await _ui.PressAsync(_locators.DriverSLicenseNumber, "CTRL+A");
        }
        if (_data.Condition("'Drivers License #' != NULL"))
        {
            await _ui.FillAsync(_locators.DriverSLicenseNumber, _data.Get("AL_ClientData.DL Number"));
        }
        await _ui.FillAsync(_locators.YrsLicensedCurrentState, _data.Resolve("{{data:yrs_licensed_current_state_171}}"));
        await _ui.PressAsync(_locators.YrsLicensedCurrentState, "CTRL+A");
        await _ui.FillAsync(_locators.YrsLicensedCurrentState, _data.Resolve("{{data:yrs_licensed_current_state_172}}"));
        await _ui.FillAsync(_locators.MonthsLicensedCurrentState, _data.Resolve("{{data:months_licensed_current_state_173}}"));
        await _ui.PressAsync(_locators.MonthsLicensedCurrentState, "CTRL+A");
        await _ui.FillAsync(_locators.MonthsLicensedCurrentState, _data.Resolve("{{data:months_licensed_current_state_174}}"));
        if (_data.Condition("'State' == \"TX\""))
        {
            await _ui.FillAsync(_locators.DaysOperatedUninsured, _data.Resolve("{{data:daysoperateduninsured_175}}"));
        }
        if (_data.Condition("'State' == \"CA\""))
        {
            await _ui.FillAsync(_locators.YrsLicensedAllStates, _data.Resolve("{{data:yrslicensed_all_states_176}}"));
            await _ui.PressAsync(_locators.YrsLicensedAllStates, "CTRL+A");
        }
        if (_data.Condition("'State' == \"CA\""))
        {
            await _ui.FillAsync(_locators.YrsLicensedAllStates, _data.Resolve("{{data:yrslicensed_all_states_177}}"));
        }
        if (_data.Condition("'Operator Status' == \"Assigned\""))
        {
            await _ui.ClickAsync(_locators.NoD053A);
            await _ui.PressAsync(_locators.NoD053A, "Click");
            await _ui.PressAsync(_locators.NoD053A, "Scroll[2]");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0065_10f911Async
        if (await _ui.ExistsAsync(_locators.WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove))
        {
            await _ui.VerifyAsync(_locators.WasThisClientInsuredWithAmericanNationalImmediatelyPriorToTheCarrierListedAbove, _data.Resolve("Exists"), "");
        }
        // EQNamedInsOperatorStatus_36c72dPage.NamedInsOperatorStatus_0066_10f911Async
        if (await _ui.ExistsAsync(_locators.NoPreviouslyInsured))
        {
            await _ui.SelectAsync(_locators.NoPreviouslyInsured, _data.Resolve(""));
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0067_10f911Async
        if (await _ui.ExistsAsync(_locators.PriorCarrierName))
        {
            await _ui.VerifyAsync(_locators.PriorCarrierName, _data.Resolve("Exists"), "");
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0068_10f911Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue9CB7A))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0069_10f911Async
        if (await _ui.ExistsAsync(_locators.NoNeedWasNotLicensed))
        {
            await _ui.VerifyAsync(_locators.NoNeedWasNotLicensed, _data.Resolve("Visible"), "");
        }
        // EQPriorInsuranceInfo_a40db0Page.PriorInsuranceInfo_0070_10f911Async
        if (await _ui.ExistsAsync(_locators.NoNeedWasNotLicensed))
        {
            await _ui.ClickAsync(_locators.NoNeedWasNotLicensed);
            await _ui.PressAsync(_locators.NoNeedWasNotLicensed, "End");
            await _ui.PressAsync(_locators.NoNeedWasNotLicensed, "Click");
        }
        await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        // EQPriorInsuranceInfo_a40db0Page.SaveContinue_0071_10f911Async
        if (await _ui.ExistsAsync(_locators.SaveAndContinue9CB7A))
        {
            await _ui.ClickAsync(_locators.SaveAndContinue9CB7A);
        }
        // EQExpiredLicensePopUp_ac02e7Page.EQExpiredLicensePopUp_0072_10f911Async
        if (await _ui.ExistsAsync(_locators.CONTINUED555D))
        {
            await _ui.WaitAsync(_locators.CONTINUED555D, "Exists");
        }
        // EQExpiredLicensePopUp_ac02e7Page.EQExpiredLicensePopUp_0073_10f911Async
        if (await _ui.ExistsAsync(_locators.CONTINUED555D))
        {
            await _ui.ClickAsync(_locators.CONTINUED555D);
        }
    }

    // Business step: I complete vehicle Summary Automobile Rate Filing
    public async Task CompleteVehicleSummaryAutomobileRateFilingAsync3()
    {
        // EQCAVerifiedMileage_306316Page.EQCAVerifiedMileage_0085_10f911Async
        await _ui.VerifyAsync(_locators.EQCAVerifiedMileage, _data.Resolve("Exists"), "");
        // EQVehicleInformation_7d0869Page.EQVehicleInformation_0086_10f911Async
        if (await _ui.ExistsAsync(_locators.MOREOPTIONS))
        {
            await _ui.WaitAsync(_locators.MOREOPTIONS, "Visible");
        }
        // EQVehicleInformation_7d0869Page.EQVehicleInformation_0087_10f911Async
        if (await _ui.ExistsAsync(_locators.MOREOPTIONS))
        {
            await _ui.SelectAsync(_locators.MOREOPTIONS, _data.Resolve(""));
        }
        await _ui.ClickAsync(_locators.AdditionalVehicleS62C9A);
        await _ui.ClickAsync(_locators.VehicleInformationNext);
        // EQVehicleInformation_7d0869Page.EQVehicleInformation_0088_10f911Async
        if (await _ui.ExistsAsync(_locators.AdditionalVehicle))
        {
            await _ui.ClickAsync(_locators.AdditionalVehicle);
        }
        await _ui.ClickAsync(_locators.VehicleInformationNext);
        // EQVehicleAutoVin1_fdc6bdPage.EQVehicleVin_0089_10f911Async
        await _ui.WaitAsync(_locators.VIN06D01, "True");
        await _ui.ClickAsync(_locators.VIN06D01);
        await _ui.FillAsync(_locators.VIN06D01, _data.Resolve("{{data:txt_vin_217}}"));
        await _ui.PressAsync(_locators.VIN06D01, "POST:TAB");
        await _ui.PressAsync(_locators.VIN06D01, "Tab");
        await _ui.ClickAsync(_locators.Vehicle1);
        // EQVehicleSummaryAutoMotorHomeUse_e4fbccPage.EQVehicleSummaryAutoUse_0090_10f911Async
        if (_data.Condition("Loan != NULL"))
        {
            await _ui.ClickAsync(_locators.Loan4369D);
        }
        if (_data.Condition("Lease != NULL"))
        {
            await _ui.ClickAsync(_locators.Leased14EA4);
        }
        if (_data.Condition("Loan == NULL AND Lease == NULL"))
        {
            await _ui.ClickAsync(_locators.Own49EEC);
        }
        if (_data.Condition("State == \"OK\""))
        {
            await _ui.SelectAsync(_locators.NativeAmericanRegisterNO, _data.Resolve(""));
        }
        if (_data.Condition("AntiTheft != NULL AND State != \"AZ\" AND State != \"MD\" AND State != \"OH\" AND State != \"CA\" AND State != \"VA\" AND State != \"WI\" AND State != \"UT\""))
        {
            await _ui.SelectAsync(_locators.AntiTheftYes, _data.Resolve(""));
        }
        if (_data.Condition("AntiTheft != NULL AND State == \"IL\""))
        {
            await _ui.ClickAsync(_locators.ILCategory1);
        }
        if (_data.Condition("State == \"NJ\" AND AntiTheft != NULL"))
        {
            await _ui.ClickAsync(_locators.CategoryI);
        }
        if (_data.Condition("AntiTheft != NULL AND (State == \"NY\" OR State == \"VT\")"))
        {
            await _ui.ClickAsync(_locators.ActiveDisablingDevice);
        }
        if (_data.Condition("PickUp != NULL AND (State == \"NY\" OR State = \"VA\")"))
        {
            await _ui.SelectAsync(_locators.CamperShellNo, _data.Resolve(""));
        }
        if (_data.Condition("State == \"CA\""))
        {
            await _ui.ClickAsync(_locators.PleasureCANYFFCIC);
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.ClickAsync(_locators.N1Day);
        }
        if (_data.Condition("State == \"NY\" AND Company == \"FFCIC\""))
        {
            await _ui.FillAsync(_locators.NYFFCICTotalAnnualMiles, _data.Resolve("{{data:ny_ffcic_total_annual_miles_231}}"));
            await _ui.PressAsync(_locators.NYFFCICTotalAnnualMiles, "CTRL+A");
        }
        if (_data.Condition("State == \"NY\" AND Company == \"FFCIC\""))
        {
            await _ui.FillAsync(_locators.NYFFCICTotalAnnualMiles, _data.Resolve("{{data:ny_ffcic_total_annual_miles_232}}"));
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.WorkMilesDay, _data.Resolve("{{data:work_miles_day_233}}"));
            await _ui.PressAsync(_locators.WorkMilesDay, "CTRL+A");
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.WorkMilesDay, _data.Resolve("{{data:work_miles_day_234}}"));
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.NonWorkAnnualMiles, _data.Resolve("{{data:non_work_annual_miles_235}}"));
            await _ui.PressAsync(_locators.NonWorkAnnualMiles, "CTRL+A");
        }
        if (_data.Condition("State == \"KS\""))
        {
            await _ui.FillAsync(_locators.NonWorkAnnualMiles, _data.Resolve("{{data:non_work_annual_miles_236}}"));
        }
        if (_data.Condition("'Farm/Use' != NULL AND State == \"CA\""))
        {
            await _ui.SelectAsync(_locators.UseCAMoreOptions, _data.Resolve(""));
        }
        if (_data.Condition("'Farm/Use' != NULL AND (State != \"NY\" and Company !=\"FFCIC\")"))
        {
            await _ui.SelectAsync(_locators.MoreOptionsFarmUse, _data.Resolve(""));
        }
        await _ui.FillAsync(_locators.PurchaseDateBB8AF, _data.Resolve("{{data:txt_purchase_date_239}}"));
        await _ui.PressAsync(_locators.PurchaseDateBB8AF, "CTRL+A");
        await _ui.FillAsync(_locators.PurchaseDateBB8AF, _data.Resolve("{{data:txt_purchase_date_240}}"));
        await _ui.FillAsync(_locators.Odometer3843F, _data.Resolve("{{data:txt_odometer_241}}"));
        await _ui.PressAsync(_locators.Odometer3843F, "CTRL+A");
        await _ui.FillAsync(_locators.Odometer3843F, _data.Resolve("{{data:txt_odometer_242}}"));
        await _ui.ClickAsync(_locators.SaveContinue2E7CD);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0094_10f911Async
        await _ui.ClickAsync(_locators.AddVehicle);
        // EQVehicleSummaryAutoAdditional_2aa54aPage.EQVehicleSummaryAutoAdditional_0095_10f911Async
        await _ui.WaitAsync(_locators.VIN0A17C, "True");
        await _ui.FillAsync(_locators.VIN0A17C, _data.Resolve("{{data:vin_246}}"));
        await _ui.PressAsync(_locators.VIN0A17C, "POST:TAB");
        await _ui.PressAsync(_locators.VIN0A17C, "Tab");
        await _ui.ClickAsync(_locators.Veh1);
        await _ui.ClickAsync(_locators.VehicleMoreOptions);
        await _ui.PressAsync(_locators.VehicleMoreOptions, "Click");
        await _ui.PressAsync(_locators.VehicleMoreOptions, "Scroll[1]");
        await _ui.ClickAsync(_locators.CollectorCar);
        await _ui.SelectAsync(_locators.CollectorCarTypeMoreOptions, _data.Resolve(""));
        await _ui.ClickAsync(_locators.Classic);
        await _ui.PressAsync(_locators.Classic, "Click");
        await _ui.PressAsync(_locators.Classic, "scroll[3]");
        await _ui.FillAsync(_locators.AgreedValue8E288, _data.Resolve("{{data:agreed_value_253}}"));
        await _ui.ClickAsync(_locators.OwnB8575);
        await _ui.PressAsync(_locators.OwnB8575, "scroll[3]");
        await _ui.PressAsync(_locators.OwnB8575, "Click");
        await _ui.ClickAsync(_locators.Continue);
        await _ui.ClickAsync(_locators.RestrictedUse);
        await _ui.PressAsync(_locators.RestrictedUse, "scroll[2]");
        await _ui.PressAsync(_locators.RestrictedUse, "Click");
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_257}}"));
        await _ui.PressAsync(_locators.AppraisalDate8A115, "CTRL+A");
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_258}}"));
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_259}}"));
        await _ui.PressAsync(_locators.TotalAnnualMileage, "CTRL+A");
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_260}}"));
        await _ui.ClickAsync(_locators.SaveContinue86B78);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0096_10f911Async
        await _ui.ClickAsync(_locators.AddVehicle);
        // EQVehicleSummaryAutoAdditional_2aa54aPage.EQVehicleSummaryAutoAdditional_0097_10f911Async
        await _ui.WaitAsync(_locators.VIN0A17C, "True");
        await _ui.FillAsync(_locators.VIN0A17C, _data.Resolve("{{data:vin_264}}"));
        await _ui.PressAsync(_locators.VIN0A17C, "POST:TAB");
        await _ui.PressAsync(_locators.VIN0A17C, "Tab");
        await _ui.ClickAsync(_locators.Veh3);
        await _ui.SelectAsync(_locators.VehicleMoreOptions, _data.Resolve(""));
        await _ui.ClickAsync(_locators.CollectorCar);
        await _ui.PressAsync(_locators.CollectorCar, "Click");
        await _ui.PressAsync(_locators.CollectorCar, "scroll[1]");
        await _ui.ClickAsync(_locators.ModernClassic);
        await _ui.PressAsync(_locators.ModernClassic, "Click");
        await _ui.PressAsync(_locators.ModernClassic, "scroll[2]");
        await _ui.FillAsync(_locators.AgreedValue8E288, _data.Resolve("{{data:agreed_value_270}}"));
        await _ui.ClickAsync(_locators.OwnB8575);
        await _ui.PressAsync(_locators.OwnB8575, "scroll[2]");
        await _ui.PressAsync(_locators.OwnB8575, "Click");
        await _ui.PressAsync(_locators.OwnB8575, "scroll[2]");
        await _ui.ClickAsync(_locators.Continue);
        await _ui.ClickAsync(_locators.RestrictedUse);
        await _ui.PressAsync(_locators.RestrictedUse, "Click");
        await _ui.PressAsync(_locators.RestrictedUse, "END");
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_274}}"));
        await _ui.PressAsync(_locators.AppraisalDate8A115, "CTRL+A");
        await _ui.FillAsync(_locators.AppraisalDate8A115, _data.Resolve("{{data:appraisal_date_275}}"));
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_276}}"));
        await _ui.PressAsync(_locators.OdometerD648F, "CTRL+A");
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_277}}"));
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_278}}"));
        await _ui.PressAsync(_locators.TotalAnnualMileage, "CTRL+A");
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_279}}"));
        await _ui.ClickAsync(_locators.SaveContinue86B78);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0098_10f911Async
        await _ui.ClickAsync(_locators.AddVehicle);
        // EQVehicleSummaryAutoAdditional_2aa54aPage.EQVehicleSummaryAutoAdditional_0099_10f911Async
        await _ui.WaitAsync(_locators.VIN0A17C, "True");
        await _ui.FillAsync(_locators.VIN0A17C, _data.Resolve("{{data:vin_283}}"));
        await _ui.PressAsync(_locators.VIN0A17C, "POST:TAB");
        await _ui.PressAsync(_locators.VIN0A17C, "Tab");
        await _ui.ClickAsync(_locators.Veh1);
        await _ui.ClickAsync(_locators.OwnB8575);
        await _ui.PressAsync(_locators.OwnB8575, "Click");
        await _ui.PressAsync(_locators.OwnB8575, "scroll[2]");
        await _ui.ClickAsync(_locators.Continue);
        await _ui.FillAsync(_locators.PurchaseDate736F4, _data.Resolve("{{data:purchase_date_288}}"));
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_289}}"));
        await _ui.PressAsync(_locators.OdometerD648F, "CTRL+A");
        await _ui.FillAsync(_locators.OdometerD648F, _data.Resolve("{{data:odometer_290}}"));
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_291}}"));
        await _ui.PressAsync(_locators.TotalAnnualMileage, "CTRL+A");
        await _ui.FillAsync(_locators.TotalAnnualMileage, _data.Resolve("{{data:total_annual_mileage_292}}"));
        await _ui.ClickAsync(_locators.SaveContinue86B78);
        // EQVehicleSummaryNextAdd_a608b2Page.EQVehicleSummaryNextAdd_0100_10f911Async
        await _ui.WaitAsync(_locators.PricingDetailsNext, "Exists");
        await _ui.ClickAsync(_locators.PricingDetailsNext);
        // TBoxSetBuffer_e51da1Page.TBoxSetBuffer_0101_10f911Async
        _data.Set("Driver 1 Vehicle", _data.Resolve("{{data:driver_1_vehicle}}"));
        _data.Set("Driver 1 Principal Occasional", _data.Resolve("{{data:driver_1_principal_occasional}}"));
        _data.Set("Driver 2 Vehicle", _data.Get("Driver 2 Vehicle"));
        _data.Set("Driver 2 Principal Occasional", _data.Get("Driver 2 Principal Occasional"));
        _data.Set("Driver 3 Vehicle", _data.Get("Driver 3 Vehicle"));
        _data.Set("Driver 3 Principal Occasional", _data.Get("Driver 3 Principal Occasional"));
        _data.Set("Driver 4 Vehicle", _data.Get("Driver 4 Vehicle"));
        _data.Set("Driver 4 Principal Occasional", _data.Get("Driver 4 Principal Occasional"));
        _data.Set("Driver 5 Vehicle", _data.Get("Driver 5 Vehicle"));
        _data.Set("Driver 5 Principal Occasional", _data.Get("Driver 5 Principal Occasional"));
    }

    // Business step: I complete auto AddlCov Vehicle Coverages
    public async Task CompleteAutoAddlCovVehicleCoveragesAsync6()
    {
        // EQVehicleCoveragesSection_2f4d8bPage.EQVehicleCoveragesSection_0152_10f911Async
        if (_data.Condition("'UMPD/UIMPD_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV1);
        }
        if (_data.Condition("'UMPD Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle1);
            await _ui.PressAsync(_locators.UMPDCoverageVehicle1, "Click");
            await _ui.PressAsync(_locators.UMPDCoverageVehicle1, "scroll[2]");
        }
        if (_data.Condition("'UMPD Coverage_V1' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV1);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV1);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV1, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV1, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V1' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV1);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V1' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV1);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV1, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV1, "Scroll[2]");
        }
        if (_data.Condition("'UMPD/UIMPD_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV2);
        }
        if (_data.Condition("'UMPD Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle2);
        }
        if (_data.Condition("'UMPD Coverage_V2' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV2);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV2);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV2, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV2, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV2);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V2' != NULL"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV2);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV2, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV2, "scroll[2]");
        }
        if (_data.Condition("'Towing and Labor' != NULL"))
        {
            await _ui.SelectAsync(_locators.NoCoverageV1Towing, _data.Resolve(""));
        }
        if (_data.Condition("'UMPD/UIMPD_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV3);
        }
        if (_data.Condition("'UMPD Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle3);
        }
        if (_data.Condition("'UMPD Coverage_V3' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV3);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV3);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV3, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV3, "scroll[4]");
        }
        if (_data.Condition("'Theft Deductible_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV3);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V3' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV3);
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV3, "Click");
            await _ui.PressAsync(_locators.RoadsideAssistanceCoverageV3, "scroll[2]");
        }
        if (_data.Condition("'Cycle Accessories_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.CycleAccessoriesV3);
        }
        if (_data.Condition("'Original Parts_V3' != NULL"))
        {
            await _ui.ClickAsync(_locators.OriginalPartsV3);
        }
        if (_data.Condition("'UMPD/UIMPD_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDUIMPDV4);
        }
        if (_data.Condition("'UMPD Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UMPDCoverageVehicle4);
        }
        if (_data.Condition("'UMPD Coverage_V4' == \"MORE OPTIONS\""))
        {
            await _ui.SelectAsync(_locators.UMPDMoreOptionsCoverages, _data.Resolve(""));
        }
        if (_data.Condition("'UIMPD Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.UIMPDCoverageV4);
        }
        if (_data.Condition("'Rental Reimbursement Coverage_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.RentalReimbursementCoverageV4);
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV4, "Click");
            await _ui.PressAsync(_locators.RentalReimbursementCoverageV4, "end");
        }
        if (_data.Condition("'Theft Deductible_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.TheftDeductibleV4);
        }
        if (_data.Condition("'Roadside Assistance Coverage_V4' != NULL AND NOT(State == \"NY\")"))
        {
            await _ui.ClickAsync(_locators.RoadsideAssistanceCoverageV4);
        }
        if (_data.Condition("'Cycle Accessories_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.CycleAccessoriesV4);
        }
        if (_data.Condition("'Original Parts_V4' != NULL"))
        {
            await _ui.ClickAsync(_locators.OriginalPartsV4);
        }
    }

}
