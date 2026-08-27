using Microsoft.Playwright;

namespace InsuranceAutomation.CLDC.Pages.Locators;

/// <summary>
/// v57 canonical locator registry keyed by raw Tosca ModuleAttribute GUID.
/// A physical Tosca control that appears in more than one generated Page repository is defined here once only.
/// </summary>
internal static class CanonicalDuckCreekLocatorFactory
{
    public static ILocator ByModuleAttributeGuid(IPage page, string guid) => guid.ToLowerInvariant() switch
    {
        "3a13d49c-1679-21d3-307d-9ac2d420ffb8" => page.GetByRole(AriaRole.Link, new() { Name = "Add Client", Exact = true }), //  | Add Client
        "3a13d49c-1679-a316-96ce-ca532c48906e" => page.GetByRole(AriaRole.Textbox, new() { Name = "IndividualType", Exact = true }), //  | IndividualType
        "3a13d49c-1679-fa35-fde2-a6f6475ff53f" => page.GetByRole(AriaRole.Textbox, new() { Name = "Insured Type*", Exact = true }), //  | Insured Type*
        "3a13d49c-1688-9e6e-3bd3-33b0fdcf5ebc" => page.GetByRole(AriaRole.Textbox, new() { Name = "SearchValue", Exact = true }), //  | SearchValue
        "3a13d49c-1688-c094-cab0-01ca8db25c92" => page.GetByRole(AriaRole.Link, new() { Name = "Addl Interests", Exact = true }), // BAP Navigation Links | Additional Interests
        "3a13d49c-1697-0f88-b883-20bf5c0d330f" => page.GetByRole(AriaRole.Link, new() { Name = "General Liab", Exact = true }), // UMB Navigation Links | General Liab
        "3a13d49c-1697-10a4-df69-6f4dc21706f3" => page.GetByRole(AriaRole.Link, new() { Name = "Businessowners", Exact = true }), // UMB Navigation Links | Businessowners
        "3a13d49c-1697-2795-c091-4c635a79407e" => page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true }), // Businessowners | Policy Number
        "3a13d49c-1697-3ef2-a3f1-10c0a03b8675" => page.GetByRole(AriaRole.Link, new() { Name = "Watercraft Liability", Exact = true }), // UMB Navigation Links | Watercraft Liability
        "3a13d49c-1697-4099-cdcb-b51261d5962d" => page.GetByRole(AriaRole.Textbox, new() { Name = "Modification Factor", Exact = true }), // Pricing | Modification Factor
        "3a13d49c-1697-50ef-718a-9eff146a551c" => page.GetByRole(AriaRole.Link, new() { Name = "Commercial Auto", Exact = true }), // UMB Navigation Links | Commercial Auto
        "3a13d49c-1697-5b7e-1059-24533633c948" => page.GetByRole(AriaRole.Link, new() { Name = "Import Policy Data", Exact = true }), // Businessowners | Import Policy Data Button
        "3a13d49c-1697-62eb-1046-d8904ca7eb14" => page.GetByRole(AriaRole.Textbox, new() { Name = "Expiration Date", Exact = true }), // Businessowners | Expiration Date
        "3a13d49c-1697-68c5-7803-bcdd157945fb" => page.GetByRole(AriaRole.Textbox, new() { Name = "Total Subject Premium*", Exact = true }), // Businessowners | Total Subject Premium*
        "3a13d49c-1697-6bf0-f011-0c6b89932520" => page.GetByRole(AriaRole.Link, new() { Name = "SFP - 10 Liability/Farm", Exact = true }), // UMB Navigation Links | SFP - 10 Liability/Farm
        "3a13d49c-1697-9599-a2ea-9374855150e2" => page.GetByRole(AriaRole.Link, new() { Name = "Employers Liab", Exact = true }), // UMB Navigation Links | Employers Liab
        "3a13d49c-1697-ac3b-2048-796e25a28c0b" => page.GetByRole(AriaRole.Textbox, new() { Name = "Effective Date", Exact = true }), // Businessowners | Effective Date
        "3a13d49c-1697-ae5b-45b5-df53d1fb9b8f" => page.GetByRole(AriaRole.Link, new() { Name = "Personal Auto", Exact = true }), // UMB Navigation Links | Personal Auto
        "3a13d49c-1697-b124-eb68-7d72e20b1cb2" => page.GetByRole(AriaRole.Link, new() { Name = "CPP Liability", Exact = true }), // UMB Navigation Links | CPP Liability
        "3a13d49c-1697-b30f-c867-596198679155" => page.GetByRole(AriaRole.Link, new() { Name = "Homeowner's Liability", Exact = true }), // UMB Navigation Links | Homeowner's Liability
        "3a13d49c-1697-f277-7905-08e882cb4baa" => page.GetByRole(AriaRole.Link, new() { Name = "Motorcycle Liability", Exact = true }), // UMB Navigation Links | Motorcycle Liability
        "3a13d49c-1697-f99b-bc35-ce694290718a" => page.GetByRole(AriaRole.Link, new() { Name = "Rental Owners Liability", Exact = true }), // UMB Navigation Links | Rental Owners Liability
        "3a13d49c-16f1-3c8c-26cf-6ef3cb7d13c7" => page.Locator("[id=\"pageTop\"]"), // Additional Interests Schedule | Addl Interests
        "3a13d49c-16f1-5235-6ac4-b01a5f07f090" => page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010CF_1_1-inputEl\"]"), //  | Date Of Birth*
        "3a13d49c-16f1-6ee5-b6f2-1ec6da80521a" => page.GetByRole(AriaRole.Link, new() { Name = "Endorsements", Exact = true }), // GL Navigation Links | Endorsements
        "3a13d49c-16f1-7104-229a-892e18f1a07f" => page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010C8_1_1-inputEl\"]"), //  | First Name*
        "3a13d49c-16f1-7dec-7fe6-bf7cff13bc04" => page.GetByRole(AriaRole.Textbox, new() { Name = "Hired Auto Form*", Exact = true }), // Risk Schedule|Hired Auto | Hired Auto Form*
        "3a13d49c-16f1-fd52-8a69-a72f6ca273e5" => page.Locator("[id=\"f_c174FBAF5A7CF4DFEA3CDA0B3A89411D010CA_1_1-inputEl\"]"), //  | Last Name*
        "3a13d49c-1700-0ca0-26e9-1f003690dc99" => page.GetByRole(AriaRole.Textbox, new() { Name = "Prod PD Ded", Exact = true }), // Policy Covg|GL | Prod PD Ded
        "3a13d49c-1700-1b2e-8774-90d2b00bf944" => page.GetByRole(AriaRole.Textbox, new() { Name = "Medical", Exact = true }), // Policy Covg|GL | Medical
        "3a13d49c-1700-22cc-e9ee-5fbbaef42d8c" => page.GetByRole(AriaRole.Link, new() { Name = "Update Answers", Exact = true }), // Property UW Questions | Update Answers
        "3a13d49c-1700-2650-8f24-19c05dba284b" => page.GetByRole(AriaRole.Textbox, new() { Name = "Fire Damage", Exact = true }), // Policy Covg|GL | Fire Damage
        "3a13d49c-1700-277f-f8c3-5a7e01456e49" => page.GetByRole(AriaRole.Textbox, new() { Name = "PremOp Ded", Exact = true }), // Policy Covg|GL | PremOp Ded
        "3a13d49c-1700-3255-282f-15a94c7a106d" => page.GetByRole(AriaRole.Textbox, new() { Name = "PremOp PD Ded", Exact = true }), // Policy Covg|GL | PremOp PD Ded
        "3a13d49c-1700-371e-c808-c1dcd0cae17d" => page.GetByRole(AriaRole.Link, new() { Name = "Detail", Exact = true }), //  | Detail
        "3a13d49c-1700-454b-5278-9f3e549fbf37" => page.Locator("[id=\"pageTitle\"]"), // Endorsements|Main | Endorsements
        "3a13d49c-1700-4cec-e5f0-b402c1b9fc50" => page.Locator("[id=\"f_l5E228A3F9AC041EBB7129353068D3F69167_3_1-inputEl\"]"), // Policy Covg|GL | # of Seasonal/Temporary Employees*
        "3a13d49c-1700-5aa5-ccad-be01b1072c20" => page.GetByRole(AriaRole.Link, new() { Name = "Add Endorsement", Exact = true }), // Endorsements|Main | Add Endorsement
        "3a13d49c-1700-6910-f085-905e20437cbe" => page.GetByRole(AriaRole.Textbox, new() { Name = "Occurence Limit", Exact = true }), // Policy Covg|GL | Occurence Limit
        "3a13d49c-1700-6b9e-7a82-759a0390c142" => page.Locator("[id=\"f_l5E228A3F9AC041EBB7129353068D3F69165_3_1-inputEl\"]"), // Policy Covg|GL | # of Full-Time Employees*
        "3a13d49c-1700-702f-ab45-977a2cd5409c" => page.GetByRole(AriaRole.Textbox, new() { Name = "Property of Others Rating Group", Exact = true }), // Property Add Class | Property of Others Rating Group
        "3a13d49c-1700-7505-61ee-35ff4430c9d2" => page.GetByRole(AriaRole.Textbox, new() { Name = "Aggregate Limit", Exact = true }), // Policy Covg|GL | Aggregate Limit
        "3a13d49c-1700-7641-373b-5b21ae14d400" => page.GetByRole(AriaRole.Textbox, new() { Name = "Products Agg Limit", Exact = true }), // Policy Covg|GL | Products Agg Limit
        "3a13d49c-1700-769e-b228-7a3436bb62eb" => page.Locator("[id=\"pageTitle\"]"), // Policy Covg|GL | Policy Covg
        "3a13d49c-1700-88fd-c07c-9f9ab9138604" => page.GetByRole(AriaRole.Textbox, new() { Name = "Pers Adv Inj", Exact = true }), // Policy Covg|GL | Pers Adv Inj
        "3a13d49c-1700-930b-1ff7-13efbf42ac65" => page.GetByRole(AriaRole.Textbox, new() { Name = "Prod BI Ded", Exact = true }), // Policy Covg|GL | Prod BI Ded
        "3a13d49c-1700-9844-6210-6e05ab67ffc8" => page.GetByRole(AriaRole.Textbox, new() { Name = "Is the Insured engaged in any Snow or Ice Removal Operations?*", Exact = true }), // Policy Covg|GL | Is the Insured engaged in any Snow or Ice Removal Operations?*
        "3a13d49c-1700-a97e-db29-b634782f5f0c" => page.GetByRole(AriaRole.Textbox, new() { Name = "Ded Type", Exact = true }), // Policy Covg|GL | Ded Type
        "3a13d49c-1700-b6ea-5343-993db0eb88bd" => page.GetByRole(AriaRole.Textbox, new() { Name = "Deductible Basis", Exact = true }), // Policy Covg|GL | Deductible Basis
        "3a13d49c-1700-d017-0ba5-688c8af0bf55" => page.Locator("[id=\"pageTitle\"]"), // General Liability Information | General Liability Information
        "3a13d49c-1700-d1b3-1a9a-5519e5296a7f" => page.Locator("[id=\"f_l5E228A3F9AC041EBB7129353068D3F69166_3_1-inputEl\"]"), // Policy Covg|GL | # of Part-Time Employees*
        "3a13d49c-1700-e550-22ce-3a4125c40dfb" => page.Locator("[fieldref=\"CovEndorsementsInput.IndicatorPropertyDamageCG2142\"], [data-fieldref=\"CovEndorsementsInput.IndicatorPropertyDamageCG2142\"]"), // [CG2142] Exclusion - Explosion, Collapse and Underground Property Damage Hazard (Specified Operations) | Exclude Underground Property Damage Hazard
        "3a13d49c-1700-f4d8-335f-cea3f953bf5e" => page.GetByRole(AriaRole.Textbox, new() { Name = "Does any Risk generate power other than Private Windmills or Emergency Backup?*", Exact = true }), // Policy Covg | Does any Risk generate power other than Private Windmills or Emergency Backup?*
        "3a13d49c-171e-17ac-180b-20fce969d8b7" => page.GetByRole(AriaRole.Textbox, new() { Name = "Policy Number", Exact = true }), // Commercial Auto | Policy Number
        "3a13d49c-171e-1c33-a204-db3ffc91138e" => page.GetByRole(AriaRole.Textbox, new() { Name = "PD Limit*", Exact = true }), // Recreational Vehicle Liability | PD Limit*
        "3a13d49c-171e-4b30-555c-4b79b411c0fd" => page.GetByRole(AriaRole.Textbox, new() { Name = "Liability Limit*", Exact = true }), // Commercial Auto | Liability Limit*
        "3a13d49c-171e-cfec-8c22-a2e5f7a16ea9" => page.GetByRole(AriaRole.Link, new() { Name = "Save for Later", Exact = true }), // Insurance Designee | Save for Later
        "3a13d49c-172d-73c0-91ea-b7991fa97b13" => page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true }), // Risk - Bailees Customers | OK
        "3a13d49c-172d-357f-0e66-b5c4938eeda1" => page.Locator("[id=\"f_rFE68631942E64B1BA3A954F11A424A13A_1_1-inputEl\"]"), // Risk - Accounts Receivable | Search Result
        "3a13d49c-172d-481d-8ffc-b47cce97273a" => page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740887_1_1-inputEl\"]"), // Risk - Bailees Customers | Search Value
        "3a13d49c-172d-5b3b-bf4a-564b4d225f8b" => page.Locator("[id=\"f_rFE68631942E64B1BA3A954F11A424A139_1_1-inputEl\"]"), // Risk - Accounts Receivable | Search Value
        "3a13d49c-172d-64b2-5e0b-f700919e536b" => page.Locator("[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB111_1_1-inputEl\"]"), // Risk - Computer Systems | Search Result
        "3a13d49c-172d-9338-df10-a309c3e3c058" => page.Locator("[id=\"pageTitle\"]"), // Policy Covg - Main | Policy Covg
        "3a13d49c-172d-9372-feda-ed7f73106a12" => page.Locator("[id=\"pageTitle\"]"), // Endorsement - Main |  Endorsement Heading
        "3a13d49c-172d-993e-d4b4-b6589f8b3c4f" => page.Locator("[id=\"f_c1130867FA0E9485FBAA81AF58751740889_1_1-inputEl\"]"), // Risk - Bailees Customers | Search Result
        "3a13d49c-172d-a0a4-7d37-fbe634036887" => page.GetByRole(AriaRole.Link, new() { Name = "Update Answers", Exact = true }), // Specific Underwriting Questions - Contractors Equipment | Update Answers
        "3a13d49c-172d-a4c5-1221-65f506afd5b8" => page.GetByRole(AriaRole.Link, new() { Name = "Policy Covg", Exact = true }), // IM Navigation Links | Policy Covg
        "3a13d49c-172d-b5bb-ae1c-348164b75bbb" => page.Locator("[id=\"f_CCE14981F38894A679A407BA735B5959BD3_3_1-inputEl\"]"), // Endorsement - CM 66 01 Exclude Named Customer | Address
        "3a13d49c-172d-d12e-b14d-c5c2d366b2bb" => page.Locator("[id=\"pageTitle\"]"), // Specific Underwriting Questions - Accounts Receivable | Accounts Receivable Heading
        "3a13d49c-172d-e6d1-13bd-997e7f292085" => page.GetByRole(AriaRole.Link, new() { Name = "Add Coverage Form", Exact = true }), // Policy Covg - Main | Add Coverage Form
        "3a13d49c-172d-eb63-48b6-c4fba029f2b7" => page.Locator("[id=\"f_l1A9C547373A24FF38DA9C54C82FB349811CE_3_1-inputEl\"]"), // Policy Covg - Main | Coverage Form To Be Added
        "3a13d49c-172d-87fd-649f-1d8b0fc57589" => page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true }), // Risk - Accounts Receivable | OK
        "3a13d49c-172d-ecfb-0d38-ef21709415e3" => page.GetByRole(AriaRole.Link, new() { Name = "OK", Exact = true }), // Risk - Computer Systems | OK
        "3a13d49c-172d-ee80-e28d-fc69f13515c2" => page.Locator("[id=\"f_c7EF1BABFA5C74E4E875A7BF40793DEB110_1_1-inputEl\"]"), // Risk - Computer Systems | Search Value
        _ => throw new ArgumentOutOfRangeException(nameof(guid), guid, "Unknown canonical CL|DC Tosca ModuleAttribute GUID.")
    };
}
